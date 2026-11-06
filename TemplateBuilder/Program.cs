using System;
using System.IO;
using System.Linq;

namespace TemplateBuilder;

/// <summary>
/// Generates the "CK.Templates/templates" working folder (ignored by git) from the regular projects
/// of this solution. It is run by the build of this project (see TemplateBuilder.csproj): the pack
/// of CK.Templates then packages the generated templates.
/// </summary>
class Program
{
    static int Main( string[] args )
    {
        try
        {
            string solutionFolder = args.Length > 0 ? Path.GetFullPath( args[0] ) : FindSolutionFolder();
            Generate( solutionFolder );
            return 0;
        }
        catch( Exception ex )
        {
            Console.Error.WriteLine( $"TemplateBuilder failed: {ex}" );
            return 1;
        }
    }

    static void Generate( string solutionFolder )
    {
        string outPath = solutionFolder.Combine( "CK.Templates", "templates" );
        if( Directory.Exists( outPath ) )
        {
            Directory.Delete( outPath, recursive: true );
        }

        #region CK.DB package copy

        string cKDBPkgOut = outPath.Combine( "ckdbprojecttemplate" );
        Directory.CreateDirectory( cKDBPkgOut );
        CopyProjectEngine.Execute( solutionFolder.Combine( "CK.DB.Sample" ), cKDBPkgOut );

        #endregion

        #region CK.DB test package copy

        string cKDBTestPkgOut = outPath.Combine( "ckdbprojecttesttemplate" );
        Directory.CreateDirectory( cKDBTestPkgOut );
        CopyProjectEngine.Execute( solutionFolder.Combine( "Tests", "CK.DB.Sample.Tests" ), cKDBTestPkgOut );

        #endregion

        #region  Solution copy

        string solutionOut = outPath.Combine( "ckdbsolutiontemplate" );
        Directory.CreateDirectory( solutionOut );

        Directory.CreateDirectory( solutionOut.Combine( "Common" ) );
        foreach( var file in Directory.GetFiles( solutionFolder.Combine( "Common" ) ) )
        {
            CopyFile( file, solutionOut.Combine( "Common" ) );
        }

        CopyFile( solutionFolder.Combine( ".editorconfig" ), solutionOut );
        // The generated templates folder is specific to this repository.
        CopyAndModifyFile(
            solutionFolder.Combine( ".gitignore" ),
            solutionOut,
            content => string.Join( '\n', content.Split( '\n' ).Where( line => !line.Contains( "CK.Templates/templates/" ) ) ) );
        CopyFile( solutionFolder.Combine( "Directory.Build.props" ), solutionOut );
        CopyFile( solutionFolder.Combine( "Directory.Build.targets" ), solutionOut );
        CopyFile( solutionFolder.Combine( "global.json" ), solutionOut );
        CopyFile( solutionFolder.Combine( "nuget.config" ), solutionOut );

        foreach( var file in Directory.GetFiles( solutionFolder.Combine( "TemplateBuilder", "SolutionRessources" ) ) )
        {
            CopyFile( file, solutionOut );
        }

        CopyProjectEngine.Execute( solutionFolder.Combine( "CK.DB.Sample" ), solutionOut );

        Directory.CreateDirectory( solutionOut.Combine( "Tests" ) );
        CopyProjectEngine.Execute( solutionFolder.Combine( "Tests", "CK.DB.Sample.Tests" ), solutionOut.Combine( "Tests" ), letProjectReference: true );

        #endregion

        CopyTemplateConfigurations( solutionFolder.Combine( "TemplateBuilder", "Templates" ), outPath );
    }

    /// <summary>
    /// Copies the hand-written "&lt;name&gt;.&lt;file&gt;" files (like "ckdbsolutiontemplate.template.json")
    /// to "&lt;name&gt;/.template.config/&lt;file&gt;" in the output folder.
    /// </summary>
    static void CopyTemplateConfigurations( string templatesFolder, string outPath )
    {
        foreach( var file in Directory.GetFiles( templatesFolder ) )
        {
            string fileName = Path.GetFileName( file );
            int idx = fileName.IndexOf( '.' );
            if( idx <= 0 ) throw new Exception( $"Invalid file name '{file}': expected '<template name>.<file name>'." );
            string templateFolder = outPath.Combine( fileName.Substring( 0, idx ) );
            if( !Directory.Exists( templateFolder ) ) throw new Exception( $"File '{file}' doesn't match any generated template." );
            string configFolder = templateFolder.Combine( ".template.config" );
            Directory.CreateDirectory( configFolder );
            File.Copy( file, configFolder.Combine( fileName.Substring( idx + 1 ) ) );
        }
    }

    /// <summary>
    /// Finds the solution folder by looking for "CK-Templates.slnx" from the current directory.
    /// </summary>
    static string FindSolutionFolder()
    {
        string dir = Directory.GetCurrentDirectory();
        while( !File.Exists( dir.Combine( "CK-Templates.slnx" ) ) )
        {
            dir = Path.GetDirectoryName( dir ) ?? throw new Exception( "Cannot find the solution folder (CK-Templates.slnx)." );
        }
        return dir;
    }

    /// <summary>
    /// Copy the file to the specified directory. Uses the same file name.
    /// </summary>
    /// <param name="sourceFile">The file to copy.</param>
    /// <param name="destinationDirectory">The destination directory of the new file.</param>
    static void CopyFile( string sourceFile, string destinationDirectory )
    {
        File.Copy( sourceFile, destinationDirectory.Combine( Path.GetFileName( sourceFile ) ) );
    }

    /// <summary>
    /// Copy the file to the specified directory. Uses the same file name.
    /// Applies the <paramref name="modifier"/> to the file content.
    /// </summary>
    /// <param name="sourceFile">The file to copy.</param>
    /// <param name="destinationDirectory">The destination directory of the new file.</param>
    /// <param name="modifier">The modifier applied to the file content.</param>
    static void CopyAndModifyFile( string sourceFile, string destinationDirectory, Func<string, string> modifier )
    {
        File.WriteAllText(
            destinationDirectory.Combine( Path.GetFileName( sourceFile ) ),
            modifier( File.ReadAllText( sourceFile ) ) );
    }
}
