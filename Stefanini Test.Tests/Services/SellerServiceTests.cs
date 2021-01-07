using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Stefanini_Test.Domain.Entities;
using Stefanini_Test.Domain.Repositories;
using Stefanini_Test.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini_Test.Tests.Services
{
    [TestClass]
    public class SellerServiceTests
    {

        Mock<ISellerRepository> _sellerRepositoryMock;

        [TestInitialize]
        public void Setup()
        {
            _sellerRepositoryMock = new Mock<ISellerRepository>();
            _sellerRepositoryMock.Setup(r => r.GetByUserId(It.IsAny<int>())).Returns<int>((int id) => 
                {
                    if (id == 1)
                        return new Domain.Entities.Seller();
                    else
                        return null;
                });

            _sellerRepositoryMock.Setup(r => r.FindAll()).Returns(() =>
                {
                    var list = new List<Seller>();
                    for (int i = 0; i < 5; i++) 
                    {
                        list.Add(new Seller());
                    };

                    return list;
                });
        }


        [TestMethod]
        public void GetByUserId_Sucess() 
        {
            var service = new SellerService(_sellerRepositoryMock.Object);

            var seller = service.GetByUserId(1);

            Assert.IsNotNull(seller);
        }

        [TestMethod]
        public void GetByUserIdTest_Fail()
        {
            var service = new SellerService(_sellerRepositoryMock.Object);

            var seller = service.GetByUserId(2);

            Assert.IsNull(seller);
        }

        [TestMethod]
        public void FindSellersTest_Fail()
        {
            var service = new SellerService(_sellerRepositoryMock.Object);

            var list = service.FindSellers();

            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count, 5);
        }
    }
}
