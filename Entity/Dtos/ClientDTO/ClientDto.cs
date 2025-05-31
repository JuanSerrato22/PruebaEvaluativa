using Entity.Dtos.ProductDTO;
using Entity.Model;
using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dtos.ClientDTO
{
    public class ClientDto : BaseEntity
    {
        public string Name { get; set; }
        public bool Active { get; set; }

        // Relación Detalle
        public List<PedidoDto> Pedidos { get; set; }
    }
}