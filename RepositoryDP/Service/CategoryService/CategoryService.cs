using AutoMapper;
using RepositoryDP.DTO.CategoryDTO;
using RepositoryDP.Model;
using RepositoryDP.Repository.CategoryRepo;

namespace RepositoryDP.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper ;
        private readonly ICategoryRepository Repository;
        public CategoryService(IMapper _mapper, ICategoryRepository _Repository)
        {
            mapper = _mapper;
            Repository = _Repository;
        }
        public string CreateCategory(CreateCategoryDTO categoryDTO)
        {
            var map = mapper.Map<Category>(categoryDTO);
            return Repository.CreateCategory(map);
        }

        public UpdateCategoryDTO UpdateCategory(int id, UpdateCategoryDTO updateCategoryDTO)
        {
            //var map = mapper.Map<Category>(updateCategoryDTO);
            var repo = Repository.UpdateCategory(id, updateCategoryDTO);
            var res = mapper.Map<UpdateCategoryDTO>(repo);
            return res;
        }

        public IList<GetCategoryDTO> GetCategories()
        {
            var repo = Repository.GetCategory();
            var map = mapper.Map<IList<GetCategoryDTO>>(repo);
            return map;
        }

        public string DeleteCategory(int id)
        {
            var repo = Repository.DeleteCategory(id);
            return repo;
        }
    }
}
