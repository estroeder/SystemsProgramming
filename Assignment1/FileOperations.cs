using System.Collections.Generic;
using System.IO;

namespace Assignment1
{
    internal class FileOperations
    {
        public List<string> GetFileContents(string fileName)
        {
            return new List<string>(File.ReadAllLines($@"C:\Users\estro\source\repos\Assign2\Assign2\{fileName}"));
        }
    }
}