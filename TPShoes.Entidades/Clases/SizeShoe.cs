namespace TPShoes.Entidades.Clases
{
    public class SizeShoe
    {
        public int SizeShoeId { get; set; }
        public int ShoeId { get; set; }
        public int SizeId { get; set; }

        public int Stok { get; set; }

        public Shoe Shoe { get; set; }
        public Size Size { get; set; }

    }
}
