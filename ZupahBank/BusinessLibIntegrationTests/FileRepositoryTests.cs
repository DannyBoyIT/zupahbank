using BusinessLib.Repositories;
using BusinessLib.Services;
using System;
using System.IO;
using Xunit;

namespace BusinessLibIntegrationTests
{
    public class FileRepositoryTests
    {
        [Fact]
        public void CanTransformFileToLists()
        {
            var sut = new FileRepository();
            var path = @".\Files\bankdata-small.txt";
            sut.TransformFileToLists(path);
        }
        [Fact]
        public void CanAddAccount()
        {

        }
        [Fact]
        public void CanAddCustomer()
        {

        }
        [Fact]
        public void CanAddTransaction()
        {

        }
    }
}
