using BusinessLib.Services;
using System;
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
    }
}
