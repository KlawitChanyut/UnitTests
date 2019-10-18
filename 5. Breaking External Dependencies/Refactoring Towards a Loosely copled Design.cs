using System.IO;
using System;

namespace TestNinjaUnit._5.Breaking_External_Dependencies
{
    class Refactoring_Towards_a_Loosely_copled_Design
    {
        public interface IFileReader
        {
            string Read(string path);
        }

        public class FileReader : IFileReader
        {
            public string Read(string path)
            {
                return File.ReadAllText(path);
            }
        }
    }
}
