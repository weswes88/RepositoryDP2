using FluentValidation;
using RepositoryDP.DTO.CategoryDTO;
using RepositoryDP.Model;

namespace RepositoryDP.Validation
{
    public class CategoryValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CategoryValidator()
        {
            RuleFor(a => a.CatName).NotEmpty().WithMessage("Category Name Cant Be Empty")
                .MaximumLength(15);
            
        }
    }
}
