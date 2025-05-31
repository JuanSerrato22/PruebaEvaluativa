using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Entity.Dtos.ProductDTO;
using Entity.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<List<PedidoDto>> GetAllAsync()
        {
            var pedidos = await _pedidoRepository.GetAllAsync();
            return _mapper.Map<List<PedidoDto>>(pedidos);
        }

        public async Task<PedidoDto> GetByIdAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            return _mapper.Map<PedidoDto>(pedido);
        }

        public async Task<PedidoDto> CreateAsync(PedidoDto pedidoDto)
        {
            var pedido = _mapper.Map<Pedido>(pedidoDto);
            var createdPedido = await _pedidoRepository.CreateAsync(pedido);
            return _mapper.Map<PedidoDto>(createdPedido);
        }

        public async Task<PedidoDto> UpdateAsync(int id, PedidoDto pedidoDto)
        {
            var existingPedido = await _pedidoRepository.GetByIdAsync(id);
            if (existingPedido == null) return null;

            existingPedido.Producto = pedidoDto.Producto;
            existingPedido.Precio = pedidoDto.Precio;

            var updatedPedido = await _pedidoRepository.UpdateAsync(existingPedido);
            return _mapper.Map<PedidoDto>(updatedPedido);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _pedidoRepository.DeleteAsync(id);
        }
    }
}
