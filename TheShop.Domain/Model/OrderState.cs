namespace TheShop.Domain.Model
{
    public enum OrderState
    {
        ORDER_CREATED,
        PRODUCTS_ACQUIRING,
        PRODUCTS_ACQUIRED,
        SHIPPING_INITIATED,
        SHIPPING_COMPLETED,
        ORDER_COMPLETED,
        ORDER_CANCELED,
        ORDER_ERROR = 99
    }
}
