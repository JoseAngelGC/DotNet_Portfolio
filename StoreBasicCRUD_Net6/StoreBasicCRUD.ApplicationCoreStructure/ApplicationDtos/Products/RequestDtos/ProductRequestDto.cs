using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBasicCRUD.ApplicationCoreStructure.ApplicationDtos.Products.RequestDtos
{
    public class ProductRequestDto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int IdCategory { get; set; }
    }
}
