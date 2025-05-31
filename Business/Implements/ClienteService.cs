using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.ClientDTO;
using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<List<ClientDto>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return _mapper.Map<List<ClientDto>>(clientes);
        }

        public async Task<ClientDto> GetByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            return _mapper.Map<ClientDto>(cliente);
        }

        public async Task<ClientDto> CreateAsync(ClientDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            var clienteCreado = await _clienteRepository.CreateAsync(cliente);
            return _mapper.Map<ClientDto>(clienteCreado);
        }

        public async Task<ClientDto> UpdateAsync(int id, ClientDto clienteDto)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return null;

            cliente.Nombre = clienteDto.Name;
            cliente.Activo = clienteDto.Active;

            var actualizado = await _clienteRepository.UpdateAsync(cliente);
            return _mapper.Map<ClientDto>(actualizado);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _clienteRepository.DeleteAsync(id);
        }
    }
}
