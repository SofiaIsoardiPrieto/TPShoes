using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPShoes.Entidades.Clases
{
    public class Size
    {
        public int SizeId { get; set; }
        public decimal SizeNumber { get; set; }

        public ICollection<SizeShoe> SizeShoe { get; set; } = new List<SizeShoe>();
    }
}
