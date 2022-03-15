using libraryAPI.BLL;
using libraryAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public List<Books> Get()
        {
            BooksBLL booksBLL = new BooksBLL();
            List<Books> lstResult = booksBLL.Get();
            return lstResult;
        }

        [HttpGet("{id}")]
        public Books Get(int id)
        {
            BooksBLL booksBLL = new BooksBLL();
            Books result = booksBLL.Get(id);
            return result;
        }

        [HttpPost]
        public IActionResult Create(List<Books> lstBooks)
        {
            BooksBLL booksBLL = new BooksBLL();
            booksBLL.Insert(lstBooks);
            return StatusCode(StatusCodes.Status200OK, lstBooks);
        }
    }
}
