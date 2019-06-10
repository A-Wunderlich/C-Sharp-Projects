using InsuranceQuoteMVC.Models;
using InsuranceQuoteMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceQuoteMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (InsuranceEntities4 db = new InsuranceEntities4())
            {

                var quotes = (from c in db.QuoteeInfoes
                              where c.Id > 0
                              select c).ToList();
                var quotesVms = new List<QuoteVM>();
                foreach (var quote in quotes)
                {
                    var quoteVm = new QuoteVM();
                    {
                        quoteVm.FirstName = quote.FirstName;
                        quoteVm.LastName = quote.LastName;
                        quoteVm.EmailAddress = quote.EmailAddress;
                        quoteVm.Quote = quote.Quote;
                    }
                    quotesVms.Add(quoteVm);

                }
                return View(quotesVms);

            }
        }
    }
}