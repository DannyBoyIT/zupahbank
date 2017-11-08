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
            sut.TransformFileToRepo(repo, path);
            //assert?
        }

        [Fact]
        public void CanTransformRepoToFile()
        {
            var sut = new FileService();
            var repo = FileRepository.Instance;
            repo.CreateCustomer("Isabellas Varor", "870310", "Hejsanvägen 5", "10520", "Stockholm");
            repo.CreateCustomer("Varor och sånt", "870310", "Hejsanvägen 5", "10520", "Stockholm");
            repo.CreateAccount(1000);
            repo.CreateAccount(1001);
            sut.TransformRepoToFile(repo);
        }
    }
}