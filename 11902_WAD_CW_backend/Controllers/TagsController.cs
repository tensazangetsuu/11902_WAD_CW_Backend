using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _11902_WAD_CW_backend.Data;
using _11902_WAD_CW_backend.Models;
using _11902_WAD_CW_backend.Repository;

namespace _11902_WAD_CW_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IBlogRepository<Tag> _blogRepository;
        public TagsController(IBlogRepository<Tag> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Tag>> GetTags() => await _blogRepository.GetAll();

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(int id)
        {
            var tag = await _blogRepository.GetByID(id);
            if (tag == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(tag);
            }
        }

        [HttpPut]
        public async Task<IActionResult> PutTag(Tag tag)
        {
            //if(id!=items.ID) return BadRequest();
            await _blogRepository.Update(tag);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag(Tag tag)
        {
            await _blogRepository.Add(tag);
            return CreatedAtAction(nameof(GetTag), new { id = tag.ID }, tag);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _blogRepository.Delete(id);
            return NoContent();
        }

        //private bool TagExists(int id)
        //{
        //    return _blogRepository.Tags.Any(e => e.ID == id);
        //}
    }
}