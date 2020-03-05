using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IProductService _productService;

        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
        }

        public IActionResult AddToCart(int productId)
        {
            //ürünü çek
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart("cart");

            _cartService.AddToCart(cart, product);

            _cartSessionHelper.SetCart("cart", cart);

            TempData.Add("message", product.ProductName + " sepete eklendi.");

            return RedirectToAction("Index", "cart");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart("cart");

            _cartService.RemoveFromCart(cart, productId);
            
            _cartSessionHelper.SetCart("cart", cart);

            TempData.Add("message", product.ProductName + " sepeten silindi.");

            return RedirectToAction("Index", "cart");
        }
        public IActionResult Index()
        {
            var model = new CartListViewModel()
            {
                Cart = _cartSessionHelper.GetCart("cart")
            };

            return View(model);
        }

        public IActionResult Complete()
        {
            var model = new ShippingDetailsViewModel
            {
                ShippingDetail = new ShippingDetail()
            };
            return View();
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            TempData.Add("message", "Siparişiniz Başarıyla Tamamlandı");
            
            _cartSessionHelper.Clear();

            return RedirectToAction("Index", "Cart");
        }
    }
}
