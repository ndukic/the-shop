using AutoFixture;
using AutoFixture.AutoMoq;
using NUnit.Framework;
using System;
using TheShop.Dal.InMemory;
using TheShop.Domain.Model;

namespace TheShop.Dal.Tests
{
    public class DatabaseDriverTests
    {
        private IFixture _fixture;
        private DatabaseInMemoryDriver _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            _sut = _fixture.Create<DatabaseInMemoryDriver>();
        }

        [Test]
        public void Saved_Article_Can_Be_Fetched_By_Id()
        {
            var article = CreateArticle();

            _sut.Save(article);
            var actual = _sut.GetById(article.Id);

            AssertArticlesAreEqual(article, actual);
        }

        [Test]
        public void Get_Article_That_Not_Exist_Should_Return_Null()
        {
            var actual = _sut.GetById(32);
            Assert.IsNull(actual);
        }

        [Test]
        public void Saved_Order_Can_Be_Fetched_By_Id()
        {
            var order = CreateOrder();

            _sut.Save(order);
            var actual = _sut.GetOrderById(order.Id);

            AssertOrdersAreEqual(order, actual);
        }

        [Test]
        public void Get_Order_That_Not_Exist_Should_Return_Null()
        {
            var actual = _sut.GetOrderById(767676);
            Assert.IsNull(actual);
        }

        private Article CreateArticle()
        {
            return new Article()
            {
                Id = 32,
                Name = "Awesome Article",
                Price = 42.23
            };
        }

        private void AssertArticlesAreEqual(Article expected, Article actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Price, actual.Price);
        }

        private Order CreateOrder()
        {
            return new Order()
            {
                Id = 1234,
                ArticleId = 113,
                Price = 42.23,
                BuyerId = 55,
                CreatedDate = DateTime.Now
            };
        }

        private void AssertOrdersAreEqual(Order expected, Order actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.ArticleId, actual.ArticleId);
            Assert.AreEqual(expected.Price, actual.Price);
            Assert.AreEqual(expected.BuyerId, actual.BuyerId);
            Assert.AreEqual(expected.CreatedDate, actual.CreatedDate);
        }
    }
}