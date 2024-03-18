using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _11902_WAD_CW_backend.Data;
using _11902_WAD_CW_backend.Models;
using _11902_WAD_CW_backend.Repository;

namespace _11902_WAD_CW_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IBlogRepository<Post> _postRepository;

        public PostsController(IBlogRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> GetAllPosts() => await _postRepository.GetAll();

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetByIDPost(int id)
        {
            var post = await _postRepository.GetByID(id);
            return post == null ? NotFound() : Ok(post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(Post post)
        {
            await _postRepository.Update(post);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            await _postRepository.Add(post);
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postRepository.Delete(id);
            return NoContent();
        }

        //private bool PostExists(int id)
        //{
        //    return _postRepository.Posts.Any(e => e.ID == id);
        //}
    }
}
