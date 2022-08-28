using CKK.Logic.Interfaces;
using CKK.Logic.Models;
//using CKK.Logic.Repository.Implementation;
using CKK.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CKK.Client;


namespace CKK.Online.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _products;
        private readonly IShoppingCartItemRepository _items;
        private readonly IOrderRepository _order;
        


        public ProductController(IProductRepository products, IShoppingCartItemRepository items, IOrderRepository order)
        {
            _products = products;
            _items = items;
            _order = order;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var productList = _products.GetAll().ToList();
            return View(productList);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _products.Find(id ?? 0);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IFormCollection collection)
        {
            try
            {
                var id = Convert.ToInt32(collection["id"]);
                var quantity = Convert.ToInt32(collection["cartCount"]);
                var shoppingCartItem = new ShoppingCartItem
                {
                    CustomerId = 1,
                    ProductId = id,
                    Quantity = quantity,
                };
                _items.AddToCart(shoppingCartItem);
                return RedirectToAction(nameof(Cart));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public ActionResult Cart()
        {
            var cartList = _items.GetProducts(2).ToList();

            foreach (var product in cartList)
            {
                product.Product = _products.Find(product.ProductId);
            }
            return View(cartList);
            //return View();
        }

        public ActionResult Order(int? cartId)
        {
            //throw new NotImplementedException();

            var cartListtemp = _items.GetProducts(2).ToList();

            Order ordertemp = new Order
            {
                OrderNumber = "Trob2",
                ShoppingCartId = 2
            };

            _order.Add(ordertemp);
            _items.Ordered(ordertemp.ShoppingCartId);

            CKK.Client.ClientConnection c = new CKK.Client.ClientConnection(ordertemp);

            c.OrderProcess();
            


            foreach (var prod in cartListtemp)
            {
                var prodId = prod.ProductId;
                var cartQty = prod.Quantity;
                var prodtemp = _products.Find(prodId);
                prodtemp.Quantity = prodtemp.Quantity - cartQty;
                _products.Update(prodtemp);
            }


            


            return RedirectToAction(nameof(Index));
            /*try
            {
                OrderSummary ordersummary = new OrderSummary(_items);
                _order.
            }
            return View();
            */
        }
    }
}
