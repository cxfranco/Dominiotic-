using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FoodApi.Entities.DTOs;
using FoodApi.Entities.Models;
using FoodApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodApi.Controllers
{
    [Route("api/v1/FoodApi/[controller]")]
    public class ProductController : Controller
    {
        private FoodContext _context = new FoodContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new FoodContext());

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var products = _unitOfWork.Product.Get();
            if (products != null)
            {
                return Ok(products);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetProductById(int id)
        {
            Product product = _unitOfWork.Product.GetByID(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest("No se ha encontrado un registro con ese ID");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    product.FechaIngreso = DateTime.Now;
                    _unitOfWork.Product.Insert(product);
                    _unitOfWork.Save();
                    return Created("FoodApi/Create", product);
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
            return BadRequest(product);
        }



        [HttpGet("{idCategory}")]
        public IActionResult GetProductByIdCategory(int idCategory)
        {
            Category category = _unitOfWork.Category.GetByID(idCategory);
            if (category != null)
            {
                var products = _unitOfWork.Product.Get(x => x.IdCategory == idCategory);
                var result = CreateMappedObjects(products, idCategory);

                var serializedlist = JsonConvert.SerializeObject(result, Formatting.Indented,
                              new JsonSerializerSettings()
                              {
                                  ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                              });


                return Ok(serializedlist);
            }
            else
            {
                return BadRequest("No se ha encontrado un registro con ese ID");
            }
        }
         
        private ProductList CreateMappedObjects(IEnumerable<Product> products, int idCategory)
        {
            ProductList listFriends = new ProductList();
            foreach (var item in products)
            {
                Product product = _unitOfWork.Product.GetByID(item.IdCategory);
                listFriends.products.Add(product);
            }
            return listFriends;
        }

        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Product.Update(product);
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
        public IActionResult DeleteProduct([FromHeader] int id)
        {
            if (id != 0)
            {
                _unitOfWork.Product.Delete(id);
                _unitOfWork.Save();
                return Ok("Product eliminada");
            }
            else
            {
                return BadRequest("Producto con id invalido.");
            }
        }


    }
}