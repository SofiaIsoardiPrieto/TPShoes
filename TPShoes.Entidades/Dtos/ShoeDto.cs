using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPShoes.Entidades.Dtos
{
    public class ShoeDto:ICloneable
    {
        public int ShoeId { get; set; }
        public string? Brand { get; set; }
        public string? Sport { get; set; }
        public string? Genre { get; set; }
        public string? Colour { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        // public int CantidadTalles { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }


    }
}
