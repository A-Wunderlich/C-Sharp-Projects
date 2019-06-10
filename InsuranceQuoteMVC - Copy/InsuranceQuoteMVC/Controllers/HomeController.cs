using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceQuoteMVC.Models;

namespace InsuranceQuoteMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Submit(string firstName, string lastName, string emailAddress, string carMake, string carModel, int carYear, int tickets, string insType, DateTime dOB, string dUI)
        {
            try
            {
                using (InsuranceEntities4 db = new InsuranceEntities4())
                {
                    var quotee = new QuoteeInfo
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        EmailAddress = emailAddress,
                        CarMake = carMake,
                        CarModel = carModel,
                        CarYear = carYear,
                        Tickets = tickets,
                        DOB = dOB,
                        DUI = dUI,
                        InsType = insType

                    };
                    db.QuoteeInfoes.Add(quotee);
                    db.SaveChanges();
                    return RedirectToAction("Quote", quotee);
                }
            }
            catch (Exception)
            {

                return View("~/Views/Shared/Error.cshtml");
            }
            
        }
        public ActionResult Quote(QuoteeInfo quotee)
        {
            decimal decSum = 0.00m;
            int sum = 50;
            var today = DateTime.Today;
            var age = today.Year - quotee.DOB.Year;
            if (quotee.DOB.Date > today.AddYears(-age)) age--;
            if (age < 25) sum += 25;
            if (age < 18) sum += 75;
            if (age > 100) sum += 25;
            if (quotee.CarYear < 2000) sum += 25;
            if (quotee.CarYear > 2015) sum += 25;
            if (quotee.CarMake.ToLower() == "porsche") sum += 25;
            if (quotee.CarMake.ToLower() == "porsche" && quotee.CarModel.ToLower() == "911 carrera") sum += 25;
            int ticketFee = quotee.Tickets * 10;
            sum += ticketFee;
            if (quotee.DUI == "Yes")
            {
                double duiFee = Convert.ToDouble(sum) * .25;
                decSum += Convert.ToDecimal(duiFee);
            }
            if (quotee.InsType == "Full")
            {
                double typeFee = Convert.ToDouble(sum + decSum) * .5;
                decSum += Convert.ToDecimal(typeFee);
            }
            var quote = sum + decSum;
            quote = Math.Round(quote, 2);
            quotee.Quote = quote;
            using (InsuranceEntities4 db = new InsuranceEntities4())
            {
                var result = (from c in db.QuoteeInfoes
                              where c.Id == quotee.Id
                              select c);
                foreach (var user in result)
                {
                    user.Quote = quote;
                }
                db.SaveChanges();

            }

            return View(quotee);
        }
    }
}