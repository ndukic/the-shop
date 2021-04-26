using TheShop.Domain.Model;

namespace TheShop.Services
{
    public class SupplierGatewayMock1 : ISupplierGateway
    {
        public bool IsArticleInInventory(int id)
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

    public class SupplierGatewayMock2 : ISupplierGateway
    {
        public bool IsArticleInInventory(int id)
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

    public class SupplierGatewayMock3 : ISupplierGateway
    {
        public bool IsArticleInInventory(int id)
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

    public class SupplierGatewayMock4 : ISupplierGateway
    {
        public bool IsArticleInInventory(int id)
        {
            return true;
        }

        public Article GetArticle(int id)
        {
            return new Article()
            {
                ID = 1,
                Name = "Article from supplier4",
                Price = 4
            };
        }
    }
}
