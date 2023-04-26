using System;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string Username { get; set; }
        public List<ShoppingCardItem> Items { get; set; } = new List<ShoppingCartItem>();
        public ShoppingCart() { }
        public ShoppingCart(string username)
        {
            Username = username;
        }
    }
}
