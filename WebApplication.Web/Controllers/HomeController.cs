using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        RotaryDbContext _context = new RotaryDbContext();
        public ActionResult Index()
        {
            List<BasketMaster> _baskets = new List<BasketMaster>();
            _baskets = _context.BasketMasters.ToList();
            return View(_baskets);
        }

        public PartialViewResult GetAllBasket()
        {
            List<BasketMaster> _baskets = new List<BasketMaster>();
            _baskets = _context.BasketMasters.ToList();
            return PartialView("_BasketsPartialView", _baskets);
        }
        public PartialViewResult GetBasketDetails(int basketId)
        {
            List<BasketItemDetails> _basketDetails = new List<BasketItemDetails>();
            _basketDetails = _context.BasketItemDetails.Where(b => b.BasketID == basketId).ToList();
            return PartialView("_BasketDetailPartialView", _basketDetails);
        }


        [HttpPost]
        public JsonResult PlaceBasketOrder(int basketId)
        {
            int result = 0;
            string pcIp = GetIp();
            BasketMaster _basketMaster = new BasketMaster();
            _basketMaster = _context.BasketMasters.Where(bi => bi.BasketID == basketId).FirstOrDefault();

            OrderBasket oBasket = new OrderBasket();
            oBasket.BasketID = _basketMaster.BasketID;
            oBasket.BasketName = _basketMaster.BasketName;
            oBasket.SKUID = _basketMaster.SKUID;
            oBasket.OrderDate = DateTime.Now;
            oBasket.OrderBy = pcIp;
            _context.OrderBaskets.Add(oBasket);
            result = _context.SaveChanges();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public string GetIp()
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }

        public ActionResult PlacedOrders()
        {
            return View();
        }

        public ActionResult OrderDetails(int basketId)
        {
            List<BasketItemDetails> _basketitems = new List<BasketItemDetails>();
            _basketitems = _context.BasketItemDetails.Where(b=>b.BasketID== basketId).ToList();
            return PartialView("_OrderedBasketsPartialView", _basketitems);
        }

    }
}