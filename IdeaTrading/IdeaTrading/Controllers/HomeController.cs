using IdeaTrading.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeaTrading.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetData()
        {
            using (MyContext db = new MyContext())
            {
                var user = db.Users.ToList();
                return Json(new { data = user }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrUpdate(int ID = 0)
        {
            if(ID == 0)
            {
                return View(new User());
            }
            else
            {
                using (MyContext db = new MyContext())
                {
                    return View(db.Users.FirstOrDefault(x => x.ID == ID));
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrUpdate(User user)
        {
            using (MyContext db = new MyContext())
            {
                if (ModelState.IsValid)
                {
                    if (user.ID == 0)
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        return Json(new { success = true, message = "User added successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json(new { success = true, message = "User updated successfully" }, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(new { success = false, message = "Opps. Something went wrong" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(int ID = 0)
        {
            using (MyContext db = new MyContext())
            {
                var user = db.Users.FirstOrDefault(e => e.ID == ID);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    return Json(new { success = true, message = "You have deleted user successfully" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { success = false, message = $"User not found. User ID = {ID}" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult City()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cities()
        {
            using (MyContext db = new MyContext())
            {
                var retVal = db.Users.GroupBy(e => e.City)
                    .Select(group => new               
                    {
                        City = group.Key,
                        UserCount = group.Count()
                     }).ToList();

                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
