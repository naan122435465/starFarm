using StarFarm.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;

namespace StarFarm.Controllers
{
    public class ProductsController : Controller
    {
        StarFarmProjectModels db = new StarFarmProjectModels();
        /* StarFarmProjectModels db = new StarFarmProjectModels();
          GET: Products
         public ActionResult Index()
         {

             IEnumerable<Product> products = db.Products.ToList();
             return View();

         }*/


        public ActionResult Index()
        {
            int categoryId = 0;
            List<Product> products;
            // Dungf Request.Params.Get() ddeer laays tham so tu query string
            if (! int.TryParse(Request.Params.Get("category"), out categoryId) && categoryId > 0)
            {
                // hien thi du lieu cua category chi dnh
                products = db.Products.Include(p => p.Category)
                    
                    .Where(p => p.Category_Id == categoryId).ToList();
                return View(products);
            }
            else
            {
                // hien thi all san pham
                products = db.Products.Include(productStarFarm => productStarFarm.Category).ToList();

                
            }
            return View(products);
            //return View(products.ToList());


        }
    }
}