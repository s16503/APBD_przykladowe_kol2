using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_przykladowe_kol2.Models;
using APBD_przykladowe_kol2.Requests;
using APBD_przykladowe_kol2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_przykladowe_kol2.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class ZamowieniaController : ControllerBase
    {
        private readonly IDbService _service;

        public ZamowieniaController(IDbService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetClientOrders(NazwiskoRequest req)
        {                    
            try
            {

                return Ok(_service.GetClientOrders(req));

            }catch(Exception ex)
            {
                return Ok(ex.Message);
            }

        }



       




    }
}