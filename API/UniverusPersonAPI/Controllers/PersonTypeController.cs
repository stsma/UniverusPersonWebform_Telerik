using Application.Interfaces;
using Application.IO;
using Microsoft.AspNetCore.Mvc;
using Application.Extensions;

namespace UniverusPersonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonTypeController : ControllerBase
    {
        private readonly IPersonTypeRepository _personTypeRepository;
        public PersonTypeController(IPersonTypeRepository personTypeRepository)
        {
            _personTypeRepository = personTypeRepository;
        }

        /// <summary>
        /// Get all person types
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result = await _personTypeRepository.GetItemsAsync();
            var response = new PersonTypeIO.Get.Response() { PersonTypes = result.ToList().ToPersonTypeDtos() };

            return Ok(response);
        }

        /// <summary>
        /// Add a new type of person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromQuery] PersonTypeIO.Post.Request request)
        {
            var result = await _personTypeRepository.AddItemAsync(request.PersonType.ToPersonType());
            var response = new PersonTypeIO.Post.Response() { PersonType = result.ToPersonTypeDto() };
            return Ok(result);
        }
    }
}
