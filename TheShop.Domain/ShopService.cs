using Microsoft.Extensions.Logging;
using System;
using TheShop.Domain.Model;

namespace TheShop.Domain
{
    public class ShopService : IShopService
	{
		private ILogger<ShopService> _logger;
		private IDatabaseDriver _databaseDriver;

		private Supplier1 Supplier1;
		private Supplier2 Supplier2;
		private Supplier3 Supplier3;

		public ShopService(ILogger<ShopService> logger,
			IDatabaseDriver databaseDriver)
		{
			_logger = logger;
			_databaseDriver = databaseDriver;
			Supplier1 = new Supplier1();
			Supplier2 = new Supplier2();
			Supplier3 = new Supplier3();
		}

		public void OrderAndSellArticle(int id, int maxExpectedPrice, int buyerId)
		{
			#region ordering article

			Article article = null;
			Article tempArticle = null;
			var articleExists = Supplier1.ArticleInInventory(id);
			if (articleExists)
			{
				tempArticle = Supplier1.GetArticle(id);
				if (maxExpectedPrice < tempArticle.Price)
				{
					articleExists = Supplier2.ArticleInInventory(id);
					if (articleExists)
					{
						tempArticle = Supplier2.GetArticle(id);
						if (maxExpectedPrice < tempArticle.Price)
						{
							articleExists = Supplier3.ArticleInInventory(id);
							if (articleExists)
							{
								tempArticle = Supplier3.GetArticle(id);
								if (maxExpectedPrice < tempArticle.Price)
								{
									article = tempArticle;
								}
							}
						}
					}
				}
			}

			article = tempArticle;
			#endregion

			#region selling article

			if (article == null)
			{
				throw new Exception("Could not order article");
			}

			_logger.LogDebug("Trying to sell article with id=" + id);

			article.IsSold = true;
			article.SoldDate = DateTime.Now;
			article.BuyerUserId = buyerId;

			try
			{
				_databaseDriver.Save(article);
				_logger.LogInformation("Article with id=" + id + " is sold.");
			}
			catch (ArgumentNullException ex)
			{
				_logger.LogError("Could not save article with id=" + id);
				throw new Exception("Could not save article with id");
			}
			catch (Exception)
			{
			}

			#endregion
		}

		public Article GetById(int id)
		{
			return _databaseDriver.GetById(id);
		}
	}

	public class Supplier1
	{
		public bool ArticleInInventory(int id)
		{
			return true;
		}

		public Article GetArticle(int id)
		{
			return new Article()
			{
				ID = 1,
				Name = "Article from supplier1",
				Price = 458
			};
		}
	}

	public class Supplier2
	{
		public bool ArticleInInventory(int id)
		{
			return true;
		}

		public Article GetArticle(int id)
		{
			return new Article()
			{
				ID = 1,
				Name = "Article from supplier2",
				Price = 459
			};
		}
	}

	public class Supplier3
	{
		public bool ArticleInInventory(int id)
		{
			return true;
		}

		public Article GetArticle(int id)
		{
			return new Article()
			{
				ID = 1,
				Name = "Article from supplier3",
				Price = 460
			};
		}
	}

}
