using libraryAPI.BLL;
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
    [Authorize]
    public class SyncUpController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            SyncUpBLL syncUp = new SyncUpBLL();
            bool response = syncUp.Start();
            if (response)
            {
                return StatusCode(StatusCodes.Status200OK, true);

            }
            else 
            {
                return StatusCode(StatusCodes.Status404NotFound, false);
            }

        }
    }
}
