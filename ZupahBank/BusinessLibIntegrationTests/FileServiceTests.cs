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
            var path = @".\Files\bankdata-small.txt";
            sut.ReadFromFile(path);
        }
        [Fact]
        public void CanWriteToFile()
        {
            var sut = new FileService();
            string[] text = { "Hello", "And", "Welcome" };
            sut.WriteNewFile(text);
        }
    }
}
