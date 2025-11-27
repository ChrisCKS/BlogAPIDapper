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
        public async Task<ActionResult<List<CategoryResponseDTO>>> GetAllCategoriesAsync()
        {
            //Chama o Service, que chama o repository, que roda o SELECT no banco
            //O resultado volta como List<CategoryResponseDTO>
            var categories = await _categoryService.GetAllCategoriesAsync();

            return Ok(categories);
        }


        [HttpPost("Create")]
        public async Task<ActionResult> CreateCategory(CategoryRequestDTO category)
        {
            //Controller recebe DTO, envia para o Service, que cria um Category e chama o Repository
            //Repository insere no banco e controller retorna resposta
            await _categoryService.CreateCategoryAsync(category);

            return Created();
        }

        //buscando a categoria pelo Id
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseDTO>> GetCategoryIdAsync(int id) 
        {
            //Chama o service para buscar a categoria
            var category = await _categoryService.GetCategoryIdAsync(id);   

            if (category == null)
                return NotFound("Categoria não encontrada");
            return Ok(category);
        }

        //atualizando a categoria
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoryAsync(int id, CategoryRequestDTO category) 
        {
            try
            {
                //Chama o service para atualizar a categoria
                await _categoryService.UpdateCategoryAsync(id, category);   
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); 
            }
        }

        //deletando a categoria
        [HttpDelete("{id}")] 
        public async Task<ActionResult> DeleteCategoryAsync(int id) 
        {
            try
            {
                //Chama o service para deletar a categoria
                await _categoryService.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
