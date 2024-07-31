namespace TPShoes.Entidades.Clases
{
    public class Size :ICloneable
    { 
        public int SizeId { get; set; }
        public decimal SizeNumber { get; set; }

        public ICollection<SizeShoe> SizeShoe { get; set; } = new List<SizeShoe>();
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
