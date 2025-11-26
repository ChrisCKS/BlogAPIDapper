using Blog.API.Models.DTOs;
using Blog.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //conversa diretamente com o Postman
    public class CategoryController : ControllerBase
    { 
        
        private CategoryService _categoryService; //Injeção de dependência

        //criado automaticamente o CategoryService e injetado aqui.
        public CategoryController(CategoryService service)   
        {
            _categoryService = service;
        } 

        //teste para verificar se a API está no ar.
        [HttpGet]
        public ActionResult HeartBeat()
        {
            return Ok("Online");
        }

        
        [HttpGet("GetAll")]
        public async Task< ActionResult <List<CategoryResponseDTO>>> GetAllCategoriesAsync()
        {
            //Chama o Service, que chama o repository, que roda o SELECT no banco
            //O resultado volta como List<CategoryResponseDTO>
            var categories = await _categoryService.GetAllCategoriesAsync();

           return Ok(categories);
        }


        [HttpPost("Create")]
        public async Task <ActionResult> CreateCategory(CategoryRequestDTO category)
        {
            //Controller recebe DTO, envia para o Service, que cria um Category e chama o Repository
            //Repository insere no banco e controller retorna resposta HTTP
            await _categoryService.CreateCategoryAsync(category);

            return Created();
        }
    }
}
