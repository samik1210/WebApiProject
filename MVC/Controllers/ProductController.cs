using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Net.Http;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<mvcProductModel> productlist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products").Result;
            productlist = response.Content.ReadAsAsync<IEnumerable<mvcProductModel>>().Result;

            return View(productlist);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            return View(new mvcProductModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Products/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcProductModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcProductModel product)
        {
            if (product.SN == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Products", product).Result;
                TempData["SuccessMessage"] = "Product data Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Products/"+product.SN, product).Result;
                TempData["SuccessMessage"] = "Product data Update Successfully";
            }
           
            return RedirectToAction("Index");


        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Products/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Product data Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}