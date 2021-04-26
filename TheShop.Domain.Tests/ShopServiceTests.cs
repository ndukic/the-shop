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
        public void Saves_Article_On_Successful_Sale()
        {
            var article = CreateArticle();
            var article2 = CreateArticle();

            _sut.TrySellArticle(article, 555);

            _databaseDriver.Verify(x => x.Save(article), Times.Once());
            _databaseDriver.Verify(x => x.Save(article2), Times.Never());
        }

        [Test]
        public void Throws_ArgumentNullException_On_Null_Article_Save()
        {
            Assert.Throws<NullReferenceException>(() => _sut.TrySellArticle(null, 321));
        }

        private void Arrange_Exception_On_GetArticle()
        {
            _supplierOrchestrator.Setup(x => x.GetArticle(It.IsAny<int>(), It.IsAny<int>())).Throws(new ArticleNotFoundException());
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