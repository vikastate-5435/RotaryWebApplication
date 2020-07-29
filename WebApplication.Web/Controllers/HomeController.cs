using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Web.Models;

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


        public ActionResult Indent()
        {

            var q = (from ob in _context.OrderBaskets
                     join bid in _context.BasketItemDetails on ob.BasketID equals bid.BasketID
                     orderby ob.OrderId
                     select new
                     {
                         ob.OrderId,
                         ob.OrderDate,
                         ob.BasketID,
                         ob.BasketName,
                         ob.SKUID,
                         bid.ProductID,
                         bid.ProductName,
                         bid.Quantity,
                         bid.ApplicableFrom,
                         bid.ApplicableTo,
                         bid.KG,
                     }).ToList();
            List<OrderQuantityViewModel> prodList = new List<OrderQuantityViewModel>();

            var baskTotals = from p in q
                             group p by p.ProductID into productgroup
                             select new
                             {
                                 ProductId = productgroup.Key,
                                 prodTotalQty = productgroup.Sum(x => x.Quantity),
                                 prodTotalKG = Convert.ToDecimal(productgroup.Sum(x => x.KG))
                             };


            var basketIndents = (from bd in q
                                 join tb in baskTotals on bd.ProductID equals tb.ProductId
                                 orderby bd.ProductID
                                 select new
                                 {
                                     bd.ProductID,
                                     bd.ProductName,
                                     bd.SKUID,
                                     tb.prodTotalQty,
                                     tb.prodTotalKG
                                 }).Distinct();

            List<OrderQuantityViewModel> vm = new List<OrderQuantityViewModel>();

            foreach (var item in basketIndents)
            {
                OrderQuantityViewModel vmi = new OrderQuantityViewModel();
                vmi.ProductID = item.ProductID;
                vmi.ProductName = item.ProductName;
                vmi.SKU = item.SKUID;
                vmi.Quantity = item.prodTotalQty;
                vmi.KG = item.prodTotalKG;
                vm.Add(vmi);
            }

            return View(vm);
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
            List<OrderBasket> _orders = new List<OrderBasket>();
            _orders = _context.OrderBaskets.ToList();

            return View(_orders);
        }

        public ActionResult OrderDetails(int basketId)
        {
            List<BasketItemDetails> _basketitems = new List<BasketItemDetails>();
            _basketitems = _context.BasketItemDetails.Where(b => b.BasketID == basketId).ToList();
            return PartialView("_OrderedBasketsPartialView", _basketitems);
        }

    }
}