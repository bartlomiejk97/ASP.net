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
    [Route("api/books")]
    [ApiController]
    public class BookApiController : ControllerBase
    {
        protected BookService BookService { get; }
        protected IMapper Mapper { get; }
        public BookApiController(BookService bookService, IMapper mapper)
        {
            BookService = bookService;
            Mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "User, StoreManager, Owner")]
        public ActionResult<List<BookDTO>> GetList()
        {
            var _bookList = BookService.GetList();

            if (_bookList == null || _bookList.Count() == 0)
                return NotFound();

            return Ok(Mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(_bookList));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User, StoreManager, Owner")]
        public ActionResult<BookDTO> GetItem([FromRoute]int id)
        {
            var _item = BookService.GetItem(id);

            if (_item == null)
                return NotFound();

            return Ok(_item);
        }

        [HttpPost]
        [Authorize(Roles = "StoreManager, Owner")]
        public ActionResult Insert([FromBody]BookDTO insert)
        {
            try
            {
                var _insert = Mapper.Map<Book>(insert);
                BookService.Insert(_insert);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "StoreManager, Owner")]
        public ActionResult Update([FromRoute]int id, [FromBody]BookDTO update)
        {
            try
            {
                var _update = Mapper.Map<Book>(update);
                BookService.Update(id, _update);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "StoreManager, Owner")]
        public ActionResult Remove([FromRoute]int id)
        {
            try
            {
                BookService.Remove(id);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
