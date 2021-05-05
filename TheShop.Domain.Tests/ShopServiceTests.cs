using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheShop.Domain.Exceptions;
using TheShop.Domain.Helpers;
using TheShop.Domain.Model;
using TheShop.Domain.Repositories;
using TheShop.Domain.Service;

namespace TheShop.Domain.Tests
{
    public class ShopServiceTests
    {
        private IFixture _fixture;
        private Mock<ICatalogService> _catalogService;
        private Mock<IBasketRepository> _basketRepository;
        private Mock<IBasketReader> _basketReader;
        private Mock<IOrderRepository> _orderRepository;
        private ShopService _sut;
        private Guid _customerRef = Guid.Parse("fae20b38-5186-482b-82f3-0af196374a54");

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            _catalogService = new Mock<ICatalogService>();
            _basketRepository = new Mock<IBasketRepository>();
            _basketReader = new Mock<IBasketReader>();
            _orderRepository = new Mock<IOrderRepository>();

            _fixture.Inject(_catalogService);
            _fixture.Inject(_basketRepository);
            _fixture.Inject(_basketReader);
            _fixture.Inject(_orderRepository);

            _sut = _fixture.Create<ShopService>();
        }

        [Test]
        public void AddArticleToBasketCallsBasketRepositoryAsExpected()
        {
            var article = CreateArticle();

            _sut.AddArticleToTheBasket(article, 5, _customerRef);

            _basketRepository.Verify(x => x.CreateBasketItem(It.IsAny<BasketItem>()));
        }

        [Test]
        public void PlacingOrderWhenBasketIsEmptyThrowsException()
        {
            var basket = new Basket();
            basket.BasketItems = new List<BasketItem>();

            Assert.Throws<BasketIsEmptyException>(() => _sut.PlaceOrder(basket, _customerRef));
        }

        [Test]
        public void PlacingOrderCallsOrderRepositoryToSaveOrder()
        {
            Basket basket = PrepareBasketWithOneItem();
            _orderRepository.Setup(x => x.CreateOrder(It.IsAny<Order>())).Returns(new Order());

            _sut.PlaceOrder(basket, _customerRef);

            _orderRepository.Verify(x => x.CreateOrder(It.IsAny<Order>()));
        }

        [Test]
        public void PlacingOrderCallsOrderRepositoryToSaveOrderItem()
        {
            Basket basket = PrepareBasketWithOneItem();
            _orderRepository.Setup(x => x.CreateOrder(It.IsAny<Order>())).Returns(new Order());

            _sut.PlaceOrder(basket, _customerRef);

            _orderRepository.Verify(x => x.CreateOrderItem(It.IsAny<OrderItem>()));
        }

        [Test]
        public void PlacingOrderCallsClearBasket()
        {
            Basket basket = PrepareBasketWithOneItem();
            _orderRepository.Setup(x => x.CreateOrder(It.IsAny<Order>())).Returns(new Order());

            _sut.PlaceOrder(basket, _customerRef);

            _basketRepository.Verify(x => x.RemoveAllBasketItems(_customerRef));
        }

        [Test]
        public void GetBasketCallsBasketReader()
        {
            _sut.GetBasket(_customerRef);

            _basketReader.Verify(x => x.GetBasketByCustomerRef(_customerRef));
        }

        [Test]
        public void RemoveBasketItemsCallsBasketRepository()
        {
            var basketItemRef = Guid.NewGuid();

            _sut.RemoveBasketItem(basketItemRef);

            _basketRepository.Verify(x => x.RemoveBasketItem(basketItemRef));
        }

        [Test]
        public void EditBasketItemCallsBasketRepository()
        {
            var basketItem = CreateBasketItem();

            _sut.EditBasketItem(basketItem);

            _basketRepository.Verify(x => x.UpdateBasketItem(basketItem));
        }

        private Article CreateArticle()
        {
            return new Article()
            {
                ArticleRef = Guid.Parse("6092fd54-95af-443e-a057-e5d1d00b4ccb"),
                Name = "Test Article",
                Price = 6.99
            };
        }

        private BasketItem CreateBasketItem()
        {
            return new BasketItem()
            {
                BasketItemRef = Guid.NewGuid(),
                ArticleRef = Guid.NewGuid(),
                CustomerRef = _customerRef,
                Name = "Test Article",
                UnitPrice = 6.99,
                Count = 2
            };
        }

        private Basket PrepareBasketWithOneItem()
        {
            var basket = new Basket();
            var basketItem = CreateBasketItem();
            var list = new List<BasketItem>();
            list.Add(basketItem);
            basket.BasketItems = list;
            return basket;
        }
    }
}