using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSnack.Models;

namespace WebSnack.Controllers
{
    public class HomeController : Controller
    {
        SnackDBEntities db = new SnackDBEntities();

        public ActionResult Index()
        {
            var goods = db.z_bas_goods.ToList();

            if (Request.IsAuthenticated)
            {
                return View("Index", "_LayoutMember", goods);
            }
            return View("Index", "_Layout", goods);

        }

        public ActionResult ShoppingCar()
        {
            string userid = User.Identity.GetUserName();
            var orderDetails = db.z_bas_orders_d.Where(m => m.userid == userid && m.mIsApproved == "否").ToList();

            return View("ShoppingCar", "_LayoutMember", orderDetails);
        }

        [HttpPost]
        public ActionResult ShoppingCar(string mReceiver, string mEmail, string mAddress)
        {
            string userid = User.Identity.GetUserName();

            string guid = Guid.NewGuid().ToString();

            z_bas_orders order = new z_bas_orders();
            order.mno = guid;
            order.userid = userid;
            order.mReceiver = mReceiver;
            order.mEmail = mEmail;
            order.mAddress = mAddress;
            order.mdate = DateTime.Now.ToString();
            db.z_bas_orders.Add(order);

            var carList = db.z_bas_orders_d.Where(m => m.mIsApproved == "否" && m.userid == userid).ToList();

            foreach (var item in carList)
            {
                item.mno = guid;
                item.mIsApproved = "是";
            }

            db.SaveChanges();

            return RedirectToAction("orderList");
        }

        public ActionResult AddCar(string mno)
        {
            string userid = User.Identity.GetUserName();
            var currentCar = db.z_bas_orders_d.Where(m => m.gno == mno && m.mIsApproved == "否" && m.userid == userid).FirstOrDefault();

            if (currentCar == null)
            {
                var goods = db.z_bas_goods.Where(m => m.mno == mno).FirstOrDefault();

                z_bas_orders_d orderDetail = new z_bas_orders_d();
                orderDetail.userid = userid;
                orderDetail.gno = goods.mno;
                orderDetail.gname = goods.mname;
                orderDetail.price = goods.price_sale;
                orderDetail.qty = 1;
                orderDetail.mIsApproved = "否";
                db.z_bas_orders_d.Add(orderDetail);
            }
            else
            {
                currentCar.qty += 1;
            }
            db.SaveChanges();

            return RedirectToAction("ShoppingCar");
        }

        public ActionResult DeleteCar(int rowid)
        {
            var orderDetail = db.z_bas_orders_d.Where(m => m.rowid == rowid).FirstOrDefault();

            db.z_bas_orders_d.Remove(orderDetail);
            db.SaveChanges();

            return RedirectToAction("ShoppingCar");
        }

        public ActionResult OrderList()
        {
            string userid = User.Identity.GetUserName();

            var orders = db.z_bas_orders.Where(m => m.userid == userid).OrderByDescending(m => m.mdate).ToList();

            return View("OrderList", "_LayoutMember", orders);
        }

        public ActionResult OrderDetail(string mno)
        {
            var orderDetails = db.z_bas_orders_d.Where(m => m.mno == mno).ToList();

            return View("OrderDetail", "_LayoutMember", orderDetails);
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
    }
}