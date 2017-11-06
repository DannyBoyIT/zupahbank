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
        public string[] ReadFromFile()
        {
            try
            {
                var path =  @".\Files\bankdata-small.txt";
                var file = File.ReadAllLines(path);

                return file;
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
