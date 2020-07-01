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
    public class PayTypeController : Controller
    {
        private FoodContext _context = new FoodContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new FoodContext());

        [HttpGet]
        public IActionResult GetAllPayType()
        {
            var payTypes = _unitOfWork.PayType.Get();
            if (payTypes != null)
            {
                return Ok(payTypes);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetPayTypeById(int id)
        {
            PayType payType = _unitOfWork.PayType.GetByID(id);
            if (payType != null)
            {
                return Ok(payType);
            }
            else
            {
                return BadRequest("No se ha encontrado un registro con ese ID");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PayType payType )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    payType.FechaIngreso = DateTime.Now;
                    _unitOfWork.PayType.Insert(payType);
                    _unitOfWork.Save();
                    return Created("FoodApi/Create", payType);
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
            return BadRequest(payType);
        }

        [HttpPut]
        public IActionResult UpdatePayType([FromBody] PayType payType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.PayType.Update(payType);
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
        public IActionResult DeletePayType([FromHeader] int id)
        {
            if (id != 0)
            {
                _unitOfWork.PayType.Delete(id);
                _unitOfWork.Save();
                return Ok("PayType eliminada");
            }
            else
            {
                return BadRequest("PayType con id invalido.");
            }
        }


    }
}