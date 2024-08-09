using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackPackTravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelToCategoryController : ControllerBase
    {
        private readonly ITravelToCategoryService _travelToCategoryService;

        public TravelToCategoryController(ITravelToCategoryService travelToCategoryService)
        {
            _travelToCategoryService = travelToCategoryService;
        }

        [HttpPost("AddTravelToCategory")]
        public IActionResult Add(TravelToCategory travelToCategory)
        {
            var result = _travelToCategoryService.Add(travelToCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("UpdateTravelToCategory")]
        public IActionResult Update(TravelToCategory travelToCategory)
        {
            var result = _travelToCategoryService.Update(travelToCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("DeleteTravelToCategory")]
        public IActionResult Delete(int id)
        {
            var result = _travelToCategoryService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetAllTravelToCategory")]
        public IActionResult GetAll()
        {
            var result = _travelToCategoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetTravelToCategoryById")]
        public IActionResult Get(int id)
        {
            var result = _travelToCategoryService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
