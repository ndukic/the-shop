using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TheShop.Domain.Model;

namespace TheShop.Services.Tests
{
    public class SupplierOrchestratorTests
    {
        private IFixture _fixture;
        private Mock<ILogger<SupplierService>> _logger;
        private Mock<IEnumerable<ISupplierGateway>> _supplierGateways;
        private SupplierService _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            _logger = new Mock<ILogger<SupplierService>>();
            _supplierGateways = new Mock<IEnumerable<ISupplierGateway>>();

            _sut = new SupplierService(_logger.Object, _supplierGateways.Object);
        }

        [Test]
        public void No_Existing_SupplierGateway_Implementations_Should_Return_Negative_Values()
        {
            Arrange_No_Implementation_Of_ISupplierGateway();

            var actual = _sut.IsArticleInInventory(16);

            Assert.IsFalse(actual);
        }

        [Test]
        public void Article_Is_In_Inventory_If_Only_Second_Supplier_Has_It()
        {
            Arrange_Second_Gateway_Have_Article_With_Price(53.54);

            var actual = _sut.IsArticleInInventory(156);

            Assert.IsTrue(actual);
        }

        [Test]
        public void Keeps_Looking_For_Articles_If_First_Supplier_Does_Not_Have_It()
        {
            Arrange_Second_Gateway_Have_Article_With_Price(53.54);

            var actual = _sut.GetArticle(67, 100.24);

            Assert.IsNotNull(actual);
        }

        private void Arrange_No_Implementation_Of_ISupplierGateway()
        {
            _supplierGateways.Setup(x => x.GetEnumerator()).Returns(new List<ISupplierGateway>().GetEnumerator());
        }

        private void Arrange_Second_Gateway_Have_Article_With_Price(double articlePrice)
        {
            var list = new List<ISupplierGateway>();

            var mock1 = new Mock<ISupplierGateway>();
            var mock2 = new Mock<ISupplierGateway>();

            mock1.Setup(x => x.IsArticleInInventory(It.IsAny<long>())).Returns(false);
            mock1.Setup(x => x.GetArticle(It.IsAny<long>())).Returns((Article)null);

            mock2.Setup(x => x.IsArticleInInventory(It.IsAny<long>())).Returns(true);
            var article = new Article();
            article.Price = articlePrice;
            mock2.Setup(x => x.GetArticle(It.IsAny<long>())).Returns(article);

            list.Add(mock1.Object);
            list.Add(mock2.Object);

            _supplierGateways.Setup(x => x.GetEnumerator()).Returns(() => list.GetEnumerator());
        }
    }
}