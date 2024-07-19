using System;
using System.IO;
using System.Linq;

namespace TemplateBuilder
{
    class Program
    {
        static void Main( string[] args )
        {
            string solutionFolder = FindSourceDirectory();
            string outPath = solutionFolder.Combine( "CK.Templates", "templates" );

            #region CK.DB package copy

            string cKDBPkgOut = outPath.Combine( "ckdbprojecttemplate" );
            CleanDirectory( cKDBPkgOut );
            CopyProjectEngine.Execute( solutionFolder.Combine( "CK.DB.Sample" ), cKDBPkgOut );

            #endregion

            #region CK.DB test package copy

            string cKDBTestPkgOut = outPath.Combine( "ckdbprojecttesttemplate" );
            CleanDirectory( cKDBTestPkgOut );
            CopyProjectEngine.Execute( solutionFolder.Combine( "Tests", "CK.DB.Sample.Tests" ), cKDBTestPkgOut );

            #endregion

            #region  Solution copy

            string solutionOut = outPath.Combine( "ckdbsolutiontemplate" );
            CleanDirectory( solutionOut );

            Directory.CreateDirectory( solutionOut.Combine( "Common" ) );
            foreach( var file in Directory.GetFiles( solutionFolder.Combine( "Common" ) ) )
            {
                CopyFile( file, solutionOut.Combine( "Common" ) );
            }

            CopyFile( solutionFolder.Combine( ".editorconfig" ), solutionOut );
            CopyFile( solutionFolder.Combine( ".gitignore" ), solutionOut );
            CopyAndModifyFile(
                solutionFolder.Combine( "appveyor.yml" ),
                solutionOut,
                content => content.Replace( "CK-Sample\\CK-Templates", "CK-Database-Projects\\CK-DB-NAME_PLACE_HOLDER_DASH" ) );
            CopyAndModifyFile(
                solutionFolder.Combine( "Directory.Build.props" ),
                solutionOut,
                content => content.Replace( "https://github.com/signature-opensource/CK-Templates", string.Empty ) );
            CopyFile( solutionFolder.Combine( "NuGet.config" ), solutionOut );
            CopyFile( solutionFolder.Combine( "RepositoryInfo.xml" ), solutionOut );

            foreach( var file in Directory.GetFiles( solutionFolder.Combine( "TemplateBuilder", "SolutionRessources" ) ) )
            {
                CopyFile( file, solutionOut );
            }

            CopyProjectEngine.Execute( solutionFolder.Combine( "CK.DB.Sample" ), solutionOut );

            Directory.CreateDirectory( solutionOut.Combine( "Tests" ) );
            CopyProjectEngine.Execute( solutionFolder.Combine( "Tests", "CK.DB.Sample.Tests" ), solutionOut.Combine( "Tests" ), letProjectReference: true );

            CopyProjectEngine.Execute( solutionFolder.Combine( "CodeCakeBuilder" ), solutionOut );
            CopyAndModifyFile(
                solutionFolder.Combine( "CodeCakeBuilder", "Build.cs" ),
                solutionOut.Combine( "CodeCakeBuilder" ),
                content => string.Join( '\n', content.Split( '\n' ).Where( line => !line.Contains( "Cake.DotNetRun( \"TemplateBuilder\" );" ) ) ) );

            #endregion
        }

        /// <summary>
        /// Find the solution directory of the running application.
        /// </summary>
        static string FindSourceDirectory()
        {
            string dir = Directory.GetCurrentDirectory();
            while( !File.Exists( dir.Combine( "CK-Templates.sln" ) ) )
            {
                dir = Path.GetDirectoryName( dir ) ?? throw new Exception( "Cannot find solution root dierctory." );
            }
            return dir;
        }

        /// <summary>
        /// Clean the content of the sepcified directory, except the sub directory ".template.config".
        /// </summary>
        /// <param name="directory">The directory to clean.</param>
        static void CleanDirectory( string directory )
        {
            foreach( string file in Directory.GetFiles( directory ) )
            {
                File.Delete( file );
            }
            foreach( string subDirectory in Directory.GetDirectories( directory ) )
            {
                if( Path.GetFileName( subDirectory ) != ".template.config" )
                {
                    Directory.Delete( subDirectory, true );
                }
            }
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
}
