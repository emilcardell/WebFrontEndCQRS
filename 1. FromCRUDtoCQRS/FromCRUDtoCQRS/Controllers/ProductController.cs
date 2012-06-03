using System;
using System.Web.Mvc;
using FromCRUDtoCQRS.CQRS;
using FromCRUDtoCQRS.CRUD;

namespace FromCRUDtoCQRS.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            return RedirectToAction("Details", new { id = "Product ID"});
        }

        public ActionResult Details(int id)
        {
            return View("the product");
        } 
    }
}

/* Create
            product.Id = new Random().Next(1000);
            var createProductCommand = new CreateProduct();
            createProductCommand.CommandId = Guid.NewGuid();
            createProductCommand.Name = product.Name;
            createProductCommand.ProductId = product.Id;
            new CreateProductCommandHandler().Publish(createProductCommand);
 * return RedirectToAction("Details", new {Id = product.Id});
 * Details
             return View(new ProductProjections().GetProduct(id));
 */
