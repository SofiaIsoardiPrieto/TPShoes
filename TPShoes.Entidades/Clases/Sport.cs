using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPShoes.Entidades.Clases
{
    public class Sport:ICloneable
    {
        public int SportId { get; set; }
        public string SportName { get; set; }
        public bool Active { get; set; } = true;
        public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

}
