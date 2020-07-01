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
    public class CustomerController : Controller
    {
        private FoodContext _context = new FoodContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new FoodContext());

        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            var customers = _unitOfWork.Customer.Get();
            if (customers != null)
            {
                return Ok(customers);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetCustomerById(int id)
        {
            Customer customer = _unitOfWork.Customer.GetByID(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return BadRequest("No se ha encontrado un registro con ese ID");
            }
        }


        [HttpPost]
        public IActionResult Create([FromBody] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customer.FechaIngreso = DateTime.Now;
                    _unitOfWork.Customer.Insert(customer);
                    _unitOfWork.Save();
                    return Created("FoodApi/Create", customer);
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
            return BadRequest(customer);
        }


        [HttpPut]
        public IActionResult UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Customer.Update(customer);
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
        public IActionResult DeleteCustomer([FromHeader] int id)
        {
            if (id != 0)
            {
                _unitOfWork.Customer.Delete(id);
                _unitOfWork.Save();
                return Ok("Customer eliminada");
            }
            else
            {
                return BadRequest("Customer con id invalido.");
            }
        }


    }
}