using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERP.Data;
using ERP.Models;
using ERP.Repositories.Base;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ERP.Controllers
{
        [Authorize]
    public class ItemsController : Controller
    {
        public ItemsController(IUnitOfWork unitOfWork, IHostingEnvironment host)
        {
            _unitOfWork = unitOfWork;
            _host = host;
        }

        private readonly IHostingEnvironment _host;
        private readonly IUnitOfWork _unitOfWork;

        public IActionResult Index()
        {
            IEnumerable<Item> itemsList = _unitOfWork.Items.FindAll();
            foreach(var Item in itemsList)
            {
                Item.Category = _unitOfWork.Categories.FindById(Item.CategoryId);
            }
            return View(itemsList);
        }

        //GET
        public IActionResult New()
        {
            createSelectList();
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if (item.Name == "100")
            {
                ModelState.AddModelError("Name", "Name can't equal 100");
            }
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (item.ClientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "images");
                    fileName = item.ClientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    item.ClientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    item.ImagePath = fileName;
                }
                _unitOfWork.Items.AddOne(item);
                TempData["successData"] = "Item has been added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        public void createSelectList(int selectId = 1)
        {
            //List<Category> categories = new List<Category> {
            //  new Category() {Id = 0, Name = "Select Category"},
            //  new Category() {Id = 1, Name = "Computers"},
            //  new Category() {Id = 2, Name = "Mobiles"},
            //  new Category() {Id = 3, Name = "Electric machines"},
            //};
            List<Category> categories = _unitOfWork.Categories.FindAll().ToList();
            SelectList listItems = new SelectList(categories, "Id", "Name", selectId);
            ViewBag.CategoryList = listItems;
        }

        //GET
        public IActionResult Edit(int Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _unitOfWork.Items.FindById(Id);
            if (item == null)
            {
                return NotFound();
            }
            createSelectList(item.CategoryId);
            return View(item);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (item.Name == "100")
            {
                ModelState.AddModelError("Name", "Name can't equal 100");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Items.UpdateOne(item);
                TempData["successData"] = "Item has been updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        //GET
        public IActionResult Delete(int Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _unitOfWork.Items.FindById(Id);
            if (item == null)
            {
                return NotFound();
            }
            createSelectList(item.CategoryId);
            return View(item);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int Id)
        {
            var item = _unitOfWork.Items.FindById(Id);
            if (item == null)
            {
                return NotFound();
            }
            _unitOfWork.Items.DeleteOne(item);
            
            TempData["successData"] = "Item has been deleted successfully";
            return RedirectToAction("Index");
        }
    }
}