using System.IO;
using System.Linq;

namespace TemplateBuilder
{
    static class CopyProjectEngine
    {
        internal static void Execute( string source, string destination, bool letProjectReference = false, bool isRoot = true )
        {
            if( isRoot )
            {
                // Copy project directory
                string dirName = Path.GetFileName( source ).Replace( "Sample", "NAME_PLACE_HOLDER_DOT" );
                destination = destination.Combine( dirName );
                Directory.CreateDirectory( destination );
            }

            // Copy sub directories
            foreach( string directory in Directory.GetDirectories( source ).Where( IsCopiableDirectory ) )
            {
                string newDestination = destination.Combine( Path.GetFileName( directory ) );
                Directory.CreateDirectory( newDestination );
                Execute( directory, newDestination, isRoot: false );
            }

            // Copy files
            foreach( string file in Directory.GetFiles( source ) )
            {
                string replace = file.EndsWith( ".csproj" )
                    ? "NAME_PLACE_HOLDER_DOT"
                    : "NAME_PLACE_HOLDER_CAMELCASE";

                string fileName = Path.GetFileName( file ).Replace( "Sample", replace );

                FileReplace( file, destination.Combine( fileName ), letProjectReference );
            }
        }

        static bool IsCopiableDirectory( string directory )
        {
            directory = Path.GetFileName( directory ).ToLower();
            return directory != "bin"
                && directory != "obj"
                && directory != "logs"
                && directory != "$stobjgen";
        }

        static void FileReplace( string sourceFile, string destinationFile, bool letProjectReference )
        {

            string fileContent = File.ReadAllText( sourceFile );

            switch( Path.GetExtension( sourceFile ) )
            {
                case ".sql":
                case ".tql":
                    fileContent = fileContent.Replace( "Sample", "NAME_PLACE_HOLDER_CAMELCASE" );
                    break;

                case ".cs":
                case ".md":
                    fileContent = fileContent.Replace( "CK.DB.Sample", "CK.DB.NAME_PLACE_HOLDER_DOT" );
                    fileContent = fileContent.Replace( "Sample", "NAME_PLACE_HOLDER_CAMELCASE" );
                    fileContent = fileContent.Replace( "sample", "NAME_PLACE_HOLDER_CAMELCASE" );
                    break;

                case ".csproj":
                    fileContent = fileContent.Replace( "Sample", "NAME_PLACE_HOLDER_DOT" );
                    if( !letProjectReference )
                    {
                        fileContent = string.Join( '\n', fileContent.Split( '\n' ).Where( line => !line.Contains( "ProjectReference" ) ) );
                    }
                    break;
            }

            File.WriteAllText( destinationFile, fileContent );
        }
    }
}
