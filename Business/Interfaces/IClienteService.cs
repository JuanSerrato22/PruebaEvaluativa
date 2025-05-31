using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Dtos.ClientDTO;

namespace Business.Interfaces
{
    public interface IClienteService
    {
        Task<List<ClientDto>> GetAllAsync();
        Task<ClientDto> GetByIdAsync(int id);
        Task<ClientDto> CreateAsync(ClientDto clienteDto);
        Task<ClientDto> UpdateAsync(int id, ClientDto clienteDto);
        Task<bool> DeleteAsync(int id);
    }
}   
