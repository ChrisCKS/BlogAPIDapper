using System.Text.Json.Serialization;

namespace Blog.API.Models
{
    //representa a tabela do banco
    //recebe dados internos(Service/Repository)
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public string Slug { get; private set; }

        //construtor vazio para mapeamento
        public Category() { }

        //Diz ao sistema de JSON que este construtor deve ser usado quando o JSON for transformado em objeto.
        [JsonConstructor]
        public Category(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }
    }
}
