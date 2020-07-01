using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FoodApi.Entities.Models;
using FoodApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers
{
    [Route("api/v1/FoodApi/[controller]")] 
    public class CategoryController : Controller
    {
        private FoodContext _context = new FoodContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new FoodContext());

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var categorys = _unitOfWork.Category.Get();
            if (categorys != null)
            {
                return Ok(categorys);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetCategoryById(int id)
        {
            Category category = _unitOfWork.Category.GetByID(id);
            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return BadRequest("No se ha encontrado un registro con ese ID");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    category.FechaIngreso = DateTime.Now;
                    _unitOfWork.Category.Insert(category);
                    _unitOfWork.Save();
                    return Created("FoodApi/Create", category);
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
            return BadRequest(category);
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Category.Update(category);
                    _unitOfWork.Save();
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (DataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpDelete("id")] 
        [HttpDelete]
        public IActionResult DeleteCategory([FromHeader] int id)
        {
            if (id != 0)
            {
                _unitOfWork.Category.Delete(id);
                _unitOfWork.Save();
                return Ok("Category eliminada");
            }
            else
            {
                return BadRequest("Categoria con id invalido.");
            }
        }


    }
}
