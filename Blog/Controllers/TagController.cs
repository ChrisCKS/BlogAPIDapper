using Blog.API.Models.DTOs;
using Blog.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private TagService _tagService;

        public TagController(TagService service)
        {
            _tagService = service;
        }

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<TagResponseDTO>>> GetAllTagsAsync()
        {
            var tags = await _tagService.GetAllTagsAsync();

            return Ok(tags);
        }


        [HttpPost("Create")]
        public async Task<ActionResult> CreateTag(TagRequestDTO tag)
        {
            await _tagService.CreateTagAsync(tag);

            return Created();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagResponseDTO>> GetTagIdAsync(int id)
        {
            var tag = await _tagService.GetTagIdAsync(id);

            if (tag == null)
                return NotFound("Tag não encontrada");
            return Ok(tag);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTagAsync(int id, TagRequestDTO tag)
        {
            try
            {
                await _tagService.UpdateTagAsync(id, tag);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTagAsync(int id)
        {
            try
            {
                await _tagService.DeleteTagAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
