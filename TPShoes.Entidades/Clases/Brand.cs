using TPShoes.Entidades.Clases;

namespace TPShoes.Entidades
{
    public class Brand:ICloneable
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;
        public bool Active { get; set; } = true;
        public ICollection<Shoe> Shoes { get; set; } = new List<Shoe>();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
