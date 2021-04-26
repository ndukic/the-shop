using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using NUnit.Framework;
using System;
using TheShop.Domain.Exceptions;
using TheShop.Domain.Model;

namespace TheShop.Domain.Tests
{
    public class ShopServiceTests
    {
        private IFixture _fixture;
        private Mock<IDatabaseDriver> _databaseDriver;
        private Mock<ISupplierOrchestrator> _supplierOrchestrator;
        private ShopService _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            _supplierOrchestrator = new Mock<ISupplierOrchestrator>();
            _databaseDriver = new Mock<IDatabaseDriver>();

            _fixture.Inject(_supplierOrchestrator);
            _fixture.Inject(_databaseDriver);

            _sut = _fixture.Create<ShopService>();
        }

        [Test]
        public void Rethrows_ArticleNotFoundException()
        {
            Arrange_Exception_On_GetArticle();

            try
            {
                _sut.OrderAndSellArticle(1, 2, 3);
                Assert.Fail();
            }
            catch (ArticleNotFoundException)
            {
            }
        }

        [Test]
        public void Saves_Order_On_Successful_Sale()
        {
            var article = CreateArticle();

            _sut.TrySellArticle(article, 555);

            _databaseDriver.Verify(x => x.Save(It.IsAny<Order>()), Times.Once());
        }

        [Test]
        public void Throws_ArgumentNullException_On_Null_Article_Save()
        {
            Assert.Throws<NullReferenceException>(() => _sut.TrySellArticle(null, 321));
        }

        [Test]
        public void Return_Null_When_Get_NonExisting_Article()
        {
            _databaseDriver.Setup(x => x.GetById(6)).Returns((Article)null);

            var actualResult = _sut.GetById(6);

            Assert.IsNull(actualResult);
        }

        private void Arrange_Exception_On_GetArticle()
        {
            _supplierOrchestrator.Setup(x => x.GetArticle(It.IsAny<long>(), It.IsAny<double>())).Throws(new ArticleNotFoundException());
        }
        
        private Article CreateArticle()
        {
            return new Article()
            {
                Id = 111
            };
        }
    }
}