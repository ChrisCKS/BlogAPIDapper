namespace Blog.API.Models.DTOs
{
    //O que o servidor devolve
    //classe que representa o JSON de resposta da API.
    //retorna informações do cliente

    public class CategoryResponseDTO
    {
        public string Name { get; private set; }
        public string Slug { get; private set; }
    }
}
