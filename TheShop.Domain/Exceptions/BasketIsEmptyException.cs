using System;

namespace TheShop.Domain.Exceptions
{
    public class BasketIsEmptyException : Exception
    {
        public BasketIsEmptyException()
        {
        }

        public BasketIsEmptyException(string message) : base(message)
        {
        }
    }
}
