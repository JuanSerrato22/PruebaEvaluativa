using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;

namespace Entity.Dtos.ProductDTO
{
    public class PedidoDto : BaseEntity
    {
        public string Producto { get; set; }
        public double Precio { get; set; }

        // Relación con el cliente
        public int ClienteId { get; set; }
    }
}