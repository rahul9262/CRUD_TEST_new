using CRUD_TEST.DB_RAHUL;
using CRUD_TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CRUD_TEST.Controllers
{
    /*   [Authorize]*/
    public class HomeController : Controller
    {
        public ActionResult dashboard()
        {
            return View();
        }

        public ActionResult Index()
        {
            NKHSEntities nkhs = new NKHSEntities();
            Emp_Table emp = new Emp_Table();
            var res = nkhs.Emp_Table.ToList();

            return View(res);
        }
        public ActionResult Index1()
        {
            NKHSEntities nkhs = new NKHSEntities();
            Emp_Table emp = new Emp_Table();
            var res = nkhs.Emp_Table.ToList();

            return View(res);
        }
        [HttpGet]
        public ActionResult AddEmp()
        {


            return View();
        }
        [HttpPost]
        public ActionResult AddEmp(EmpModel obj)
        {
            NKHSEntities nkhs = new NKHSEntities();
            Emp_Table emp = new Emp_Table();
            emp.Emp_Id = obj.Emp_Id;
            emp.Emp_Name = obj.Emp_Name;
            emp.Emp_Dept_Name = obj.Emp_Dept_Name;
            emp.Emp_Comp_Name = obj.Emp_Comp_Name;
            emp.Emp_Mob = obj.Emp_Mob;
            emp.Emp_Sal = obj.Emp_Sal;

            if (emp.Emp_Id == 0)
            {
                nkhs.Emp_Table.Add(emp);
                nkhs.SaveChanges();

            }
            else
            {

         

                nkhs.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                nkhs.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Emp_Id)
        {
            NKHSEntities nkhs = new NKHSEntities();
            var del = nkhs.Emp_Table.Where(n => n.Emp_Id == Emp_Id).First();
            nkhs.Emp_Table.Remove(del);
            nkhs.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Emp_Id)
        {
            NKHSEntities nkhs = new NKHSEntities();
            EmpModel emp = new EmpModel();
            var edit = nkhs.Emp_Table.Where(n => n.Emp_Id == Emp_Id).First();
            emp.Emp_Id = edit.Emp_Id;
            emp.Emp_Name = edit.Emp_Name;
            emp.Emp_Dept_Name = edit.Emp_Dept_Name;
            emp.Emp_Comp_Name = edit.Emp_Comp_Name;
            emp.Emp_Sal = edit.Emp_Sal;
            emp.Emp_Mob = edit.Emp_Mob;
            ViewBag.edit = "Edit";
            return View("AddEmp", emp);
        }
        [HttpGet]
        public ActionResult forget( )
        {
            return View();
        }

        [HttpPost]
        public ActionResult forget(string Email)
        {
            NKHSEntities nkhs = new NKHSEntities();
            UserModel um = new UserModel();
            var edit = nkhs.User_Table.Where(n => n.Email == Email).First();
            um.Password = edit.Password;
            um.Userid = edit.Userid;
            um.Name = edit.Name;
            um.MobIle = edit.MobIle;
            um.Email = edit.Email;
            ViewBag.forget = "Forget";

            um.ForgetPassword = 1;


            return View("Register", um);
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(UserModel obj)
        {
            NKHSEntities nkhs = new NKHSEntities();
            User_Table ut = new User_Table();
            ut.Userid = obj.Userid;
            ut.Name = obj.Name;
            ut.Email = obj.Email;
            ut.MobIle = obj.MobIle;
            ut.Password = obj.Password;

            if (ut.Userid == 0)
            {
                nkhs.User_Table.Add(ut);
                nkhs.SaveChanges();

            }
            else
            {

                if (obj.ForgetPassword == 1)
                {

                    var edit = nkhs.User_Table.Where(n => n.Userid == obj.Userid).First();

                    if(edit != null)
                    {
                        ut.Name = edit.Name;
                        ut.MobIle = edit.MobIle;


                    }


                    nkhs.Entry(ut).State = System.Data.Entity.EntityState.Modified;
                    nkhs.SaveChanges();
                }

                else
                {

                    nkhs.Entry(ut).State = System.Data.Entity.EntityState.Modified;
                    nkhs.SaveChanges();
                }


             
            }
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]

        public ActionResult Login(UserModel obj)
        {
            NKHSEntities nkhs = new NKHSEntities();
            var res = nkhs.User_Table.Where(a => a.Email == obj.Email).FirstOrDefault();
            if (res == null)
            {
                TempData["EmailnotFound"] = "Email Does Not Found";
            }
            else
            {
                if (res.Email == obj.Email && res.Password == obj.Password)
                {
                    FormsAuthentication.SetAuthCookie(obj.Email, false);
                    Session["Mail"] = obj.Email.ToString();
                    return RedirectToAction("dashboard");
                }
                else
                {
                    TempData["password"] = "Password Does Not Found";

                }
            }
            return View();

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}
