using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPShoes.Entidades.Clases
{
    public class Shoe
    {
        public int ShoeId { get; set; }
        public int BrandId { get; set; }
        public int ColourId { get; set; }
        public int GenreId { get; set; }
        public int SportId { get; set; }
        public string Model { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; } = true;

        public Brand Brand { get; set; } = null!;
        public Colour Colour { get; set; } = null!;
        public Genre Genre { get; set; } = null!;
        public Sport Sport { get; set; } = null!;

        public ICollection<SizeShoe> SizeShoe { get; set; } = new List<SizeShoe>();
    }
}
