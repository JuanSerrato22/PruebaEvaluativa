using Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Entity.Dtos.ClientDTO;
using System.Threading.Tasks;

namespace Web.Controllers.Interface
{
    public interface IClientesController
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Create(ClientDto clienteDto);
        Task<IActionResult> Update(int id, ClientDto clienteDto);
        Task<IActionResult> Delete(int id);
    }
}