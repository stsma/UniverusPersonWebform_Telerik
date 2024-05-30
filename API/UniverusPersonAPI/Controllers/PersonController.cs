using Application.Interfaces;
using Application.IO;
using Microsoft.AspNetCore.Mvc;
using Application.Extensions;

namespace UniverusPersonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        /// <summary>
        /// Get all persons
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var result = await _personRepository.GetItemsAsync();
            var response = new PersonsIO.Get.Response() { People = result.ToList().ToPeopleDto() };

            return Ok(response);
        }

        /// <summary>
        /// Get a specific person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("id")]
        public async Task<IActionResult> Get([FromQuery] PersonIO.Get.Request request)
        {
            var result = await _personRepository.GetItemByIdAsync(request.Id);
            var response = new PersonIO.Get.Response() { Person = result.ToPersonDto() };

            return Ok(response);
        }

        /// <summary>
        /// Deletes a specific person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _personRepository.DeleteItemByIdAsync(Id);
            return Ok(new PersonIO.Delete.Response() { Deleted = result });
        }

        /// <summary>
        /// Updates the person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] PersonIO.Post.Request request)
        {
            var result = await _personRepository.UpdateItemAsync(request.Person.ToPerson());
            return Ok(result);
        }

        /// <summary>
        /// Add new person
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] PersonIO.Post.Request request)
        {
            var result = await _personRepository.AddItemAsync(request.Person.ToPerson());
            return Ok(result);
        }
    }
}
