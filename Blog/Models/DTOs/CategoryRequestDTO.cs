namespace Blog.API.Models.DTOs
{
    //O que o cliente envia
    //classe que representa o JSON que chega no POST
    //Recebe dados da requisição

    public class CategoryRequestDTO
    {
        public string Name { get; private set; }

        public CategoryRequestDTO(string name)
        {
            Name = name;
        }
    }
}
