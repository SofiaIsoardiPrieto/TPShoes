using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmStock : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private int stock;
        private SizeShoe sizeShoe;
        public FrmStock(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
           
        }
      
      

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
               
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(StocktextBox.Text) || string.IsNullOrWhiteSpace(StocktextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(StocktextBox, "Stock requerido");
            }

            // Validar que el stock sea un entero válido y mayor o igual que cero
            if (!int.TryParse(StocktextBox.Text, out int stock) || stock < 0)
            {
                valido = false;
                errorProvider1.SetError(StocktextBox, "Stock no válido o mal ingresado. Debe ser un número entero positivo.");
            }

            // Validar que el stock esté dentro del rango permitido (opcional, si tienes un límite superior)
            if (stock > 99999) // Cambia 99999 por el valor máximo permitido si es diferente
            {
                valido = false;
                errorProvider1.SetError(StocktextBox, "El stock debe estar entre 0 y 99999.");
            }
            return valido;
        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal void SetSizShoe(SizeShoe sizeShoeOriginal)
        {
            sizeShoe = sizeShoeOriginal;
        }

        internal SizeShoe GetSizeShoe()
        {
            return sizeShoe;
        }
    }
}
