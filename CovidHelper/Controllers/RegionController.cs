using CovidHelper.Models;
using CovidHelper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly RegionService _regionService;

        public RegionController(RegionService regionService)
        {
            _regionService = regionService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDetailDTO>>> GetAll()
        {
            var result = await _regionService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<RegionDetailDTO>>> GetAllByProvincee([FromBody]Region region)
        {
            var result = await _regionService.GetAllByProvince(region.Name,region.Iso);
            return Ok(result);
        }
    }
}
