using System;
using System.Text;
using System.IO;
namespace laba1lib
{
    public static class Generator
    {
        private static readonly Random _random = new Random();
        public static string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;
            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
        public static void Generate(long lines,string Path)
        {
            using (StreamWriter file1 = new StreamWriter(Path, true, Encoding.UTF8, 100))
            {
                for (int i = 0; i < lines; i++)
                {
                    file1.WriteLine(RandomString(90, false));
                }
            }
        }
    }
}
