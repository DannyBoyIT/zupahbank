using BusinessLib.Services;
using System;
using System.IO;
using Xunit;

namespace BusinessLibIntegrationTests
{
    public class FileServiceTests
    {
        [Fact]
        public void CanReadFromFile()
        {
            var sut = new FileService();
            sut.ReadFromFile();
        }
        [Fact]
        public void CanWriteToFile()
        {
            var sut = new FileService();
            var path = @".\Files\bankdata-small.txt";
            var file = File.ReadAllLines(path);
            sut.WriteNewFile(file);
        }
    }
}
