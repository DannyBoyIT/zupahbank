using BusinessLib.Repositories;
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
            const string path = @".\Files\bankdata-small.txt";
            sut.ReadFromFile(path);
        }
        [Fact]
        public void CanWriteToFile()
        {
            var sut = new FileService();
            string[] text = { "Hello", "And", "Welcome" };
            sut.WriteNewFile(text);
        }
        [Fact]
        public void CanTransformFileToLists()
        {
            var sut = new FileService();
            var repo = FileRepository.Instance;
            const string path = @".\Files\bankdata-small.txt";
            sut.TransformFileToLists(repo, path);
            Assert.Equal(3, repo.Customers.Count);
            Assert.Equal(5, repo.Accounts.Count);
        }
    }
}