using Core.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int? id);
        Task<ProductDTO> GetProductCategoryAsync(int? id);
        Task AddAsync(ProductDTO productDTO);
        Task UpdateAsync(ProductDTO productDTO);
        Task RemoveAsync(int? id);
    }
}
