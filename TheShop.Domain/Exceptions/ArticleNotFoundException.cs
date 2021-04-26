using System;

namespace TheShop.Domain.Exceptions
{
    public class ArticleNotFoundException : Exception
    {
        public ArticleNotFoundException()
        {
        }

        public ArticleNotFoundException(string message) : base(message)
        {
        }
    }
}
