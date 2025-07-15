using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepositoryDP.Data;
using RepositoryDP.DTO.CategoryDTO;
using RepositoryDP.Model;

namespace RepositoryDP.Repository.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EFContext Context;
        private readonly IMapper mapper;
        public CategoryRepository(EFContext _Context , IMapper _mapper)
        {
                Context = _Context;
                mapper = _mapper;
        }
        public string CreateCategory(Category category)
        {
            try
            {
                Context.Categories.Add(category);
                Context.SaveChanges();
                return "Category Addedd Successfuly";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }
        public Category UpdateCategory(int id, UpdateCategoryDTO category)
        {
            var res = Context.Categories.AsNoTracking().FirstOrDefault(e => e.Id== id);

            if (res != null && res.Id == category.Id) 
            {
                var map = mapper.Map<Category>(category);
                Context.Categories.Update(map);
                Context.SaveChanges();
                return map;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public IList<Category> GetCategory()
        {
            var cat = Context.Categories.ToList();
            return cat;
        }
        public string DeleteCategory(int id)
        {
            var cat = Context.Categories.Find(id);
            if (cat != null) 
            {
                Context.Categories.Remove (cat);
                Context.SaveChanges();
                return ("Category Removed");
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
