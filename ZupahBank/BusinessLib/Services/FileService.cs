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
        public string[] ReadFromFile(string path)
        {
            try
            {
                var file = File.ReadAllLines(path);
                return file;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void WriteNewFile(string[] file)
        {
            try
            {
                var fileName = DateTime.Now.ToString("yyyyMMdd-Hmm");
                var path = $".\\Files\\{fileName}.txt";
                File.WriteAllLines(path, file);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
