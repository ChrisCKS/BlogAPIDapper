using Blog.API.Models;
using Blog.API.Models.DTOs;
using Blog.API.Repositories;

namespace Blog.API.Services
{
    public class TagService
    {
        private TagRepository _tagRepository;

        public TagService(TagRepository tagrepository)
        {
            _tagRepository = tagrepository;
        }

        public async Task<List<TagResponseDTO>> GetAllTagsAsync()
        {
            return await _tagRepository.GetAllTagsAsync();
        }

        public async Task CreateTagAsync(TagRequestDTO tag)
        {
            var newTag = new Tag(tag.Name, tag.Name.ToLower().Replace(" ", "-"));

            await _tagRepository.CreateTagAsync(newTag);
        }

        public async Task<TagResponseDTO> GetTagIdAsync(int id)
        {
            return await _tagRepository.GetTagIdAsync(id);
        }

        public async Task UpdateTagAsync(int id, TagRequestDTO tag)
        {
            var tagExist = await _tagRepository.GetTagIdAsync(id);
            if (tagExist == null)
                throw new Exception("Tag não encontrada.");

            var updateTag = new Tag(tag.Name, tag.Name.ToLower().Replace(" ", "-"));

            await _tagRepository.UpdateTagAsync(id, updateTag);
        }

        public async Task DeleteTagAsync(int id)
        {
            var tagExist = await _tagRepository.GetTagIdAsync(id);
            if (tagExist == null)
                throw new Exception("Tag não encontrada.");

            await _tagRepository.DeleteTagAsync(id);
        }
    }
}
