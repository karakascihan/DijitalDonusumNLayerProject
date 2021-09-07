using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService:Service<Category> ,ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork,IRepository<Category> repository) :base (unitOfWork,repository)
        {

        }

        //Category nesnesine özgü servis
        public async Task<Category> GetWithProductByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
