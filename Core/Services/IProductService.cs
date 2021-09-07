using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IProductService:IService<Product>
    {
        //iş süreçleri servvice katmanında kodlanırs
        Task<Product> GetWithCategoryByIdAsync(int ProductId);
    }
}
