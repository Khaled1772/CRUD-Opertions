using Microsoft.AspNetCore.Mvc;
using MVCProject1.BLL.InterFaces;
using MVCProject1.DAL.Models;
using System;

namespace MVCProject1.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartementRepository _departementRepository;

        public DepartmentController(IDepartementRepository departementRepository)
        {
            _departementRepository = departementRepository;
        }
        public IActionResult Index()
        {
            var department = _departementRepository.GetAll();
            return View(department);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) 
            {
                _departementRepository.Add(department);
                return RedirectToAction("Index");
            }
            return View(department);
            
        }

        public IActionResult Details(int? id,string ViewName= "Details") 
        {
            if (id is null)
                return BadRequest();
            var department = _departementRepository.GetById(id.Value);
            if (department == null)
                return NotFound();

            return View(ViewName, department);

        }

        public IActionResult Edit(int? id) 
        {
            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department ,[FromRoute] int id ) 
        {
            if (id != department.Id)
                return BadRequest();
            if (ModelState.IsValid) 
            {
                try 
                {
                    _departementRepository.Update(department);
                    return RedirectToAction("Index");
                }catch(Exception ex) 
                {//1Log Exception
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
               
            }
            return View(department);

        }
        public IActionResult Delete(int? id) 
        {
            return Details(id,"Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department , [FromRoute] int id )
        {
            if (id != department.Id)
                return BadRequest();
            try
            {
                _departementRepository.Delete(department);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {//1Log Exception
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(department);
            }
           
        }


    }
}
