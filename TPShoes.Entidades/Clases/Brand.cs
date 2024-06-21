using TPShoes.Entidades.Clases;

namespace TPShoes.Entidades
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();
    }
}
