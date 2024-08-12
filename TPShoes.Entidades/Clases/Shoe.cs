namespace TPShoes.Entidades.Clases
{
    public class Shoe : ICloneable
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

        public object Clone()
        {
            return new Shoe
            {
                ShoeId = this.ShoeId,
                BrandId = this.BrandId,
                ColourId = this.ColourId,
                GenreId = this.GenreId,
                SportId = this.SportId,
                Model = this.Model,
                Description = this.Description,
                Price = this.Price,
                Active = this.Active,

                Brand = this.Brand,
                Colour = this.Colour,
                Genre = this.Genre,
                Sport = this.Sport

            };
        }

        //public object Clone()
        //{
        //    return this.MemberwiseClone();
        //}
    }
}
