using AutoMapper;
using LibApp_Gr3.Models;
using LibApp_Gr3.Models.DTO;
using LibApp_Gr3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibApp_Gr3.Controllers.API
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersApiController : ControllerBase
    {
        protected CustomerService CustomerService { get; }
        protected IMapper Mapper { get; }
        public CustomersApiController(CustomerService customerService, IMapper mapper)
        {
            CustomerService = customerService;
            Mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "StoreManager, Owner")]
        public ActionResult<List<CustomerDTO>> GetList()
        {
            var _customerList = CustomerService.GetList();

            if (_customerList == null || _customerList.Count() == 0)
                return NotFound();

            return Ok(Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(_customerList));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "StoreManager, Owner")]
        public ActionResult<CustomerDTO> GetItem([FromRoute] int id)
        {
            var _item = CustomerService.GetItem(id);

            if (_item == null)
                return NotFound();

            return Ok(_item);
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        public ActionResult Insert([FromBody] CustomerDTO insert)
        {
            try
            {
                var _insert = Mapper.Map<Customer>(insert);
                CustomerService.Insert(_insert);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Owner")]
        public ActionResult Update([FromRoute] int id, [FromBody] CustomerDTO update)
        {
            try
            {
                var _update = Mapper.Map<Customer>(update);
                CustomerService.Update(id, _update);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Owner")]
        public ActionResult Remove([FromRoute] int id)
        {
            try
            {
                CustomerService.Remove(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
