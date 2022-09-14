using CKK.Logic.Models;
//using CKK.Logic.Repository.Implementation;
using CKK.Logic.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;


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
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Remove(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var id = (Id ?? 0);
            _items.RemoveFromCart(2, id);

            return RedirectToAction(nameof(Cart));

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
            var cartListtemp = _items.GetProducts(2).ToList();

            Order ordertemp = new Order
            {
                OrderNumber = "Trob2",
                ShoppingCartId = 2
            };




            CKK.Client.ClientConnection c = new CKK.Client.ClientConnection(ordertemp);


            string message = c.OrderProcess();

            message = message.TrimEnd('\0');



            if (message != "Error, Could not process order")
            {

                foreach (var prod in cartListtemp)
                {
                    _order.Add(ordertemp);
                    _items.Ordered(ordertemp.ShoppingCartId);
                    var prodId = prod.ProductId;
                    var cartQty = prod.Quantity;
                    var prodtemp = _products.Find(prodId);
                    prodtemp.Quantity = prodtemp.Quantity - cartQty;
                    _products.Update(prodtemp);
                }
            }
            else
            {
                message = "Error, Could not process order. Please return to cart";
            }




            return RedirectToAction("OrderComplete", new { message = message });

        }
        public ActionResult OrderComplete(string message)
        {
            return View((object)message);
        }
    }
}
