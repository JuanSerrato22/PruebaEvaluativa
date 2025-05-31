using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.ProductDTO;
using System.Threading.Tasks;

namespace Web.Controllers.Interfaces
{
    public interface IPedidosController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(PedidoDto pedidoDto);
        Task<IActionResult> Update(int id, PedidoDto pedidoDto);
        Task<IActionResult> Delete(int id);
    }
}
