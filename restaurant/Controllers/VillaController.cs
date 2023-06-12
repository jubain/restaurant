using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restaurant.Models;
using restaurant.Models.Dto;
using restaurant.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace restaurant.Controllers
{
    [Route("api/[controller]")] // Dynamic controler name 
    [ApiController]
    public class VillaController : Controller
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVillaById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = VillaStore.villaList.FirstOrDefault(u => u.id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (villaDto == null)
            {
                return BadRequest(villaDto);

            }
            if (villaDto.id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDto.id = VillaStore.villaList.OrderByDescending(u => u.id).FirstOrDefault().id + 1;
            VillaStore.villaList.Add(villaDto);

            return CreatedAtRoute("GetVilla", new { id = villaDto.id }, villaDto);
        }
    }
}

