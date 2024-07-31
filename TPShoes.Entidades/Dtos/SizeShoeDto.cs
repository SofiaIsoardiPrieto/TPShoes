using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPShoes.Entidades.Clases;

namespace TPShoes.Entidades.Dtos
{
    public class SizeShoeDto :ICloneable
    {
        public int SizeShoeId { get; set; }
        public string? Size { get; set; }
        public int Stok { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
