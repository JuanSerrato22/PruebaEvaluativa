using Entity.Dtos.ProductDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPedidoService
    {
        Task<List<PedidoDto>> GetAllAsync();
        Task<PedidoDto> GetByIdAsync(int id);
        Task<PedidoDto> CreateAsync(PedidoDto pedidoDto);
        Task<PedidoDto> UpdateAsync(int id, PedidoDto pedidoDto);
        Task<bool> DeleteAsync(int id);
    }
}
