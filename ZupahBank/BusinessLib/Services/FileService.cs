using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLib.Models;

namespace BusinessLib.Services
{
    public class FileService
    {
        public string ReadFromFile()
        {
            try
            {
                using (var sr = new StreamReader("bankdata-small.txt"))
                {
                    foreach (var line in sr.ReadLine())
                    {
                        
                    }
                    // Read the stream to a string, and write the string to the console.
                    var file = sr.ReadToEnd();
                    return file;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void WriteNewFile()
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
