using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APBD_przykladowe_kol2.Requests;
using APBD_przykladowe_kol2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBD_przykladowe_kol2.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IDbService _service;

        public ClientsController(IDbService service)
        {
            _service = service;
        }


        [HttpPost("{id}/orders")]
        public IActionResult AddZamowienie(int id, AddOrderRequest req)
        {

            try
            {
                return Ok(_service.AddZamowienie(req, id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}