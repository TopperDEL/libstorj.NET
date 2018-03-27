using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LibStorj.Wrapper.Contracts.Interfaces;
using LibStorj.Wrapper.x64;
using System.Threading.Tasks;

namespace LibStorj.Wrapper.Test
{
    [TestClass]
    public class StorjTest
    {
        private Mock<io.storj.libstorj.Storj> _storjJava;
        private IStorj _sut;

        [TestInitialize]
        public void Init()
        {
            _storjJava = new Mock<io.storj.libstorj.Storj>();
            _sut = new Storj(_storjJava.Object);
        }

        [TestMethod]
        public async Task GetBuckets_Returns_Buckets()
        {
            Mock<io.storj.libstorj.GetBucketsCallback> cb = new Mock<io.storj.libstorj.GetBucketsCallback>();
            _storjJava.Setup(s => s.getBuckets(It.IsAny<io.storj.libstorj.GetBucketsCallback>())).Callback(() => {  });

            var buckets = await _sut.GetBucketsAsync();
        }
    }
}
