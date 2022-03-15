using libraryAPI.BLL;
using libraryAPI.Data;
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
    public class AuthorsController : ControllerBase
    {
        
        [HttpGet]
        public List<Authors> Get() 
        {
            AuthorsBLL authorsBLL = new AuthorsBLL();
            List<Authors> lstResult = authorsBLL.Get();
            return lstResult;
        }

        [HttpGet("{id}")]
        public Authors Get(int id) 
        {
            AuthorsBLL authorsBLL = new AuthorsBLL();
            Authors result = authorsBLL.Get(id);
            return  result;
        }

        [HttpPost]
        public IActionResult Create(List<Authors> lstAuthors) 
        {
            AuthorsBLL authorsBLL = new AuthorsBLL();
            authorsBLL.Insert(lstAuthors);
            return StatusCode(StatusCodes.Status200OK, lstAuthors);
        }

    }
}
