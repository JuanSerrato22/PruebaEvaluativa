using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Entity.Model
{
    public class Pedido : BaseEntity
    {
        public string Producto { get; set; }
        public double Precio { get; set; }
    }
}