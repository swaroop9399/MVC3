using Dapper;
using Microsoft.AspNetCore.Mvc;
using MyProject3.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MyProject3.Controllers
{
    public class HomeController : Controller
    {
        string conString = "Data Source = LTP_RD_411; Initial Catalog = test; Integrated Security = True;";
        public IActionResult AllData()
        {
            string query = "select * from Users3";
            SqlConnection con = new SqlConnection(conString);
            var list = con.Query<Student>(query).ToList();
            
            return View(list);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Student s)
        {
            if (s.isChecked == "on")
            {
                string Insert = $"Insert into Users3(Name, Email, Password, Gender, Course) values('{s.Name}', '{s.Email}', '{s.Password}', '{s.Gender}', '{s.Course}')";
                IDbConnection con = new SqlConnection(conString);
                con.Execute(Insert);
                return new JsonResult("Inserted");
            }
            else
            {
                Console.WriteLine("Not working");
                return new JsonResult("Failed");
            }
            
        }
        
    }
}