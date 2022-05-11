using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailAPI.Models;
using RetailAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository statusRepository;

        public StatusController(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        [HttpGet, Authorize]
        public async Task<ActionResult> GetStatus()
        {
            try
            {
                return Ok(await statusRepository.GetStatus());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
    }
}
