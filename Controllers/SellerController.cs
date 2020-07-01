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
    public class SellerController : Controller
    {
        private FoodContext _context = new FoodContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new FoodContext());

        [HttpGet]
        public IActionResult GetAllSeller()
        {
            var sellers = _unitOfWork.Seller.Get();
            if (sellers != null)
            {
                return Ok(sellers);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetSellerById(int id)
        {
            Seller seller = _unitOfWork.Seller.GetByID(id);
            if (seller != null)
            {
                return Ok(seller);
            }
            else
            {
                return BadRequest("No se ha encontrado un registro con ese ID");
            }
        }


        [HttpPost]
        public IActionResult Create([FromBody] Seller seller)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    seller.FechaIngreso = DateTime.Now;
                    _unitOfWork.Seller.Insert(seller);
                    _unitOfWork.Save();
                    return Created("FoodApi/Create", seller);
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
            return BadRequest(seller);
        }


        [HttpPut]
        public IActionResult UpdateSeller([FromBody] Seller seller)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Seller.Update(seller);
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
        public IActionResult DeleteSeller([FromHeader] int id)
        {
            if (id != 0)
            {
                _unitOfWork.Seller.Delete(id);
                _unitOfWork.Save();
                return Ok("Seller eliminada");
            }
            else
            {
                return BadRequest("Seller con id invalido.");
            }
        }


    }
}