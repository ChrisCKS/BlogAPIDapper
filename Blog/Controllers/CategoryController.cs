using Blog.API.Models;
using Blog.API.Services;
using Microsoft.AspNetCore.Mvc;
using Blog.API.Data;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Blog.API.Models.DTOs;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    { 
        
        private CategoryService _categoryService;

        public CategoryController(CategoryService service)   
        {
            _categoryService = service;
        } 

        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        [HttpGet("GetAll")]
        public async Task< ActionResult <List<CategoryResponseDTO>>> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            return Ok(categories);
        }

        [HttpPost("Create")]
        public async Task <ActionResult> CreateCategory(CategoryRequestDTO category)
        {
            await _categoryService.CreateCategoryAsync(category);

            return Created();
        }
    }
}
