using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.EntityFramework;
using WebTruyen.Models;
namespace WebTruyen.Controllers
{
    public class TruyenController : Controller
    {
        WebTruyenDBContext context = new WebTruyenDBContext();
        // GET: Truyen
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChiTietTruyen()
        {
            var data = context.Truyen.ToList();
            return View();
        }
    }
}