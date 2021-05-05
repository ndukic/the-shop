using Microsoft.Extensions.Logging;
using System;
using TheShop.Domain;
using TheShop.Domain.Model;

namespace TheShop.TheClient
{
    public class TestClient
    {
		private readonly ILogger<TestClient> _logger;
		private readonly IShopService _shopService;

		public TestClient(ILogger<TestClient> logger, IShopService shopService)
        {
			_logger = logger;
			_shopService = shopService;
        }

        public void UseShopService()
        {
            try
            {
				var articles = _shopService.GetArticles(null);
            }
            catch (Exception ex)
            {
				_logger.LogWarning(ex, "Couldn't get articles");
            }

            try
            {
                var article = new Article();
                article.Name = "MyArticle";
                article.Price = 2.33;
                article.ArticleRef = Guid.NewGuid();
                var myRef = Guid.NewGuid();
                _shopService.AddArticleToTheBasket(article, 3, myRef);
                var basket = _shopService.GetBasket(myRef);
                _shopService.PlaceOrder(basket, myRef);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Order failed");
            }
        }
    }
}
