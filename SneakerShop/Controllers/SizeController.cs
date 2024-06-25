using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SneakerShop.Dto;
using SneakerShop.Interface;
using SneakerShop.Models;

namespace SneakerShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : Controller
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;
        private readonly ISneakerRepository _sneakerRepository;

        public SizeController(ISizeRepository sizeRepository, IMapper mapper,
            ISneakerRepository sneakerRepository)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
            _sneakerRepository = sneakerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Size>))]
        public IActionResult GetSizes()
        {
            var sizes = _mapper.Map<List<SizeDto>>(_sizeRepository.GetSizes());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(sizes);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSize([FromBody] SizeDto sizeCreate)
        {
            if(sizeCreate == null)
                return BadRequest(ModelState);

            var sizes = _sizeRepository.GetSizes().Where(s => s.UsSize.Trim().ToUpper()
                == sizeCreate.UsSize.TrimEnd().ToUpper()).FirstOrDefault();

            if (sizes != null)
            {
                ModelState.AddModelError("", "Size already exists.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sizeMap = _mapper.Map<Size>(sizeCreate);

            if (!_sizeRepository.CreateSize(sizeMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }

            return Ok("Sucessfully created.");
        }

        [HttpPut("{sizeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateSize(int sizeId, [FromBody] SizeDto updatedSize)
        {
            if(updatedSize == null)
                return BadRequest(ModelState);

            if(sizeId != updatedSize.Id)
                return BadRequest(ModelState);

            if(!_sizeRepository.SizeExists(sizeId))
                return NotFound();

            var sizeMap = _mapper.Map<Size>(updatedSize);

            if (!_sizeRepository.UpdateSize(sizeMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated.");
        }

        [HttpDelete("{sizeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSize(int sizeId)
        {
            if (!_sizeRepository.SizeExists(sizeId))
                return NotFound();

            var deletedSize = _sizeRepository.GetSize(sizeId);
            var deletedSneakerSizes = _sizeRepository.GetSneakerSizes(sizeId);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_sizeRepository.DeleteSize(deletedSize, deletedSneakerSizes))
            {
                ModelState.AddModelError("", "Something went wrong while deleting.");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted.");
        }
    }
}
