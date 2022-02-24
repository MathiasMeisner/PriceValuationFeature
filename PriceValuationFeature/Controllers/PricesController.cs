using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriceValuationFeature.Models;
using PriceValuationFeature.Managers;

namespace PriceValuationFeature.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly PriceValuationFeatureManager _manager = new PriceValuationFeatureManager();

        // GET: api/<PricesController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<Home> GetAll([FromQuery] string sortBy)
        {
            List<Home> homes = _manager.GetAll(sortBy);
            return homes;
        }

        // GET: PricesController/Details/5
        [HttpGet("{id}")]
        public ActionResult<Home> GetById(int id)
        {
            Home home = _manager.GetById(id);
            if (home == null) return NotFound("No id: " + id);
            return home;
        }

        [HttpGet("/municipality/totalHomesForSale/{municipalityId}")]
        public int TotalHomesForSale(int municipalityId)
        {
            return _manager.TotalHomesForSaleInMunicipality(municipalityId);
        }

        [HttpGet("/municipality/avgKvmPrice/{municipalityId}")]
        public double AvgKvmPriceInMunicipality(int municipalityId)
        {
            return _manager.AvgKvmPriceInMunicipality(municipalityId);
        }

    }
}
