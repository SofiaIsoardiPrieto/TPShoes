using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPShoes.Entidades.Clases
{
    public class Colour:ICloneable
    {
        public int ColourId { get; set; }
        public string ColourName { get; set; }
        public bool Active { get; set; } = true;
        public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
