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
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {

        }
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
           return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
