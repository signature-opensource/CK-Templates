using System.IO;

namespace TemplateBuilder;

static class StringExtensions
{
    /// <summary>
    /// Use <see cref="Path.Combine(string[])"/> to the current string.
    /// </summary>
    internal static string Combine( this string value, params string[] paths )
    {
        foreach( var path in paths )
        {
            value = Path.Combine( value, path );
        }
        return value;
    }
}
