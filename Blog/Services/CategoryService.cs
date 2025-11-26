using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;

namespace Blog.API.Services
{
    //Aqui são feitas lógicas(validar dados, gerar slugs, impedir duplicações, montar objetos Category)
    public class CategoryService
    {
        //usado para acessar o banco de dados indiretamente
        private CategoryRepository _categoryRepository;

        //construtor(usa injeção de dependencias)
        //recebe o repository e permite que o service use-o sem criar diretamente
        public CategoryService(CategoryRepository categoryrepository)
        {
            _categoryRepository = categoryrepository;
        }

        //buscar todas as categorias
        //repassa a chamada ao repository e retorna os DTOs diretamente
        public async Task<List<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();
        }

        //recebe um DTO de entrada, enviado pelo usuário (Postman)
        public async Task CreateCategoryAsync(CategoryRequestDTO category) 
        {
            //Usa CategoryRequestDTO, converte para o modelo interno Category e gera o Slug automaticamente
            var newCategory = new Category(category.Name, category.Name.ToLower().Replace(" ", "-"));

            await _categoryRepository.CreateCategoryAsync(newCategory);
            //O Service envia o modelo Category já pronto para o Repository
            //O Repository faz o INSERT no banco
        }
    }
}
