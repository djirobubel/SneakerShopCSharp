using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Dto;
using SneakerShop.Interface;
using SneakerShop.Models;
using System.Diagnostics;

namespace SneakerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SneakerController : Controller
    {
        private readonly ISneakerRepository _sneakerRepository; private readonly IMapper _mapper;
        private readonly ISizeRepository _sizeRepository;

        public SneakerController(ISneakerRepository sneakerRepository, IMapper mapper,
            ISizeRepository sizeRepository)
        {
            _sneakerRepository = sneakerRepository;
            _mapper = mapper;
            _sizeRepository = sizeRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Sneaker>))]
        public IActionResult GetSneakers()
        {
            var sneakers = _mapper.Map<List<SneakerDto>>(_sneakerRepository.GetSneakers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(sneakers);
        }

        [HttpGet("{sneakerId}")]
        [ProducesResponseType(200, Type = typeof(Sneaker))]
        [ProducesResponseType(400)]
        public IActionResult GetSneaker(int sneakerId)
        {
            if (!_sneakerRepository.SneakerExists(sneakerId))
                return NotFound();

            var sneaker = _mapper.Map<SneakerDto>(_sneakerRepository.GetSneaker(sneakerId));
            var sizes = _mapper.Map<List<SizeDto>>(_sizeRepository.GetSizesOfASneaker(sneakerId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(new {sneaker, sizes});
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult CreateSneaker([FromQuery] List<int> sizeIds, 
            [FromBody] SneakerDto sneakerCreate)
        {
            bool isUnique = sizeIds.Distinct().Count() == sizeIds.Count();

            if (!isUnique)
                ModelState.AddModelError("", "You cannot enter one size ID more thn once.");

            if (sneakerCreate == null)
                return BadRequest(ModelState);

            var sneakers = _sneakerRepository.GetSneakers().Where(s => s.Model.Trim().ToUpper()
                == sneakerCreate.Model.TrimEnd().ToUpper()).FirstOrDefault();

            if (sneakers != null)
            {
                ModelState.AddModelError("", "Sneaker already exists.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sneakerMap = _mapper.Map<Sneaker>(sneakerCreate);

            if (!_sneakerRepository.CreateSneaker(sneakerMap, sizeIds))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created.");
        }

        [HttpPut("{sneakerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateSneaker(int sneakerId, [FromBody] SneakerDto updatedSneaker)
        {
            if(updatedSneaker == null)
                return BadRequest(ModelState);

            if(sneakerId != updatedSneaker.Id)
                return BadRequest(ModelState);

            if (!_sneakerRepository.SneakerExists(sneakerId))
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var sneakerMap = _mapper.Map<Sneaker>(updatedSneaker);

            if(!_sneakerRepository.UpdateSneaker(sneakerMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated.");
        }

        [HttpDelete("{sneakerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSneaker(int sneakerId)
        {
            if (!_sneakerRepository.SneakerExists(sneakerId))
                return NotFound();

            var deletedSneaker = _sneakerRepository.GetSneaker(sneakerId);
            var deletedSneakerSizes = _sneakerRepository.GetSneakerSizes(sneakerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_sneakerRepository.DeleteSneaker(deletedSneaker, deletedSneakerSizes))
            {
                ModelState.AddModelError("", "Something went wrong while deleting.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted.");
        }
    }
}
