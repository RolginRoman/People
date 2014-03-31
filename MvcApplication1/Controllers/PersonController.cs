using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class PersonController : Controller
    {
        private PersonDBContext db = new PersonDBContext();
        //
        // GET: /Person/

        //public ActionResult Index()
        //{
        //    return View(db.Persons.ToList());
        //}
        public ActionResult Index(string srch = null, string birthdate = null , string surnameSort = null, string birthdaySort = null, string nameSort = null, string emailSort = null)
        {
            var searched = db.Persons.Where(r => srch == null || r.Name.Contains(srch) || r.Surname.Contains(srch));
            if (birthdate != null && birthdate != "")
            {
                DateTime date = DateTime.Parse(birthdate);
                searched = searched.Where(r => r.Birthday == date);
            }
            if (surnameSort != null && birthdaySort == null && nameSort == null && emailSort == null)
            {
                if (!Boolean.Parse(surnameSort))
                {
                    searched = searched.OrderBy(r => r.Surname);
                    return View(searched);
                }
                else
                {
                    searched = searched.OrderByDescending(r => r.Surname);
                    return View(searched);
                }
            }
            else if (surnameSort == null && birthdaySort != null && nameSort == null && emailSort == null)
            {
                if (!Boolean.Parse(birthdaySort))
                {
                    searched = searched.OrderBy(r => r.Birthday);
                    return View(searched);
                }
                else
                {
                    searched = searched.OrderByDescending(r => r.Birthday);
                    return View(searched);
                }
            }
            else if (surnameSort == null && birthdaySort == null && nameSort != null && emailSort == null)
            {
                if (!Boolean.Parse(nameSort))
                {
                    searched = searched.OrderBy(r => r.Name);
                    return View(searched);
                }
                else
                {
                    searched = searched.OrderByDescending(r => r.Name);
                    return View(searched);
                }
            }
            else if (surnameSort == null && birthdaySort == null && nameSort == null && emailSort != null)
            {
                if (!Boolean.Parse(emailSort))
                {
                    searched = searched.OrderBy(r => r.Email);
                    return View(searched);
                }
                else
                {
                    searched = searched.OrderByDescending(r => r.Email);
                    return View(searched);
                }
            }
            return View(searched);
        }

        //protected string FindSortParam(string surnameSort, string birthdaySort, string nameSort, string emailSort)
        //{
        //    string res = null;
        //    if (surnameSort != null && birthdaySort == null && nameSort == null && emailSort == null)
        //    {
        //        res = "surnameSort";
        //        return res;
        //    }
        //    else if (surnameSort == null && birthdaySort != null && nameSort == null && emailSort == null)
        //    {
        //        res = "birthdaySort";
        //        return res;
        //    }
        //    else if (surnameSort == null && birthdaySort == null && nameSort != null && emailSort == null)
        //    {
        //        res = "nameSort";
        //        return res;
        //    }
        //    else if (surnameSort == null && birthdaySort == null && nameSort == null && emailSort != null)
        //    {
        //        res = "emailSort";
        //        return res;
        //    }
        //    return res;
        //}
        //
        // GET: /Person/Details/5

        public ActionResult Details(int id = 0)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // GET: /Person/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Person/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        //
        // GET: /Person/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        //
        // GET: /Person/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Person/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            db.Persons.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}