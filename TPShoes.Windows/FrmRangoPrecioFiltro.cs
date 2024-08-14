using TPShoes.Entidades.Clases;

namespace TPShoes.Windows
{
    public partial class FrmRangoPrecioFiltro : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private decimal minPrice;
        private decimal maxPrice;
        public FrmRangoPrecioFiltro(IServiceProvider serviceProvider)
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
                minPrice = decimal.Parse(MinPricetextBox.Text);
                maxPrice = decimal.Parse(MaxPricetextBox.Text);
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            MaxPricetextBox.Enabled = false;
            if (string.IsNullOrEmpty(MinPricetextBox.Text) || string.IsNullOrWhiteSpace(MinPricetextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(MinPricetextBox, "Mínimo precio requerido");
                MaxPricetextBox.Enabled = true;
            }
            if (string.IsNullOrEmpty(MaxPricetextBox.Text) || string.IsNullOrWhiteSpace(MaxPricetextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(MaxPricetextBox, "Máximo precio requerido");
            }
            if (!decimal.TryParse(MinPricetextBox.Text, out decimal minimo) || minimo < 0)
            {
                valido = false;
                errorProvider1.SetError(MinPricetextBox, "Precio no válido o mal ingresado. Debe ser un número entero positivo.");

            }
            else
            {
                minPrice = minimo;
                MaxPricetextBox.Enabled = true;
            }
            if (!decimal.TryParse(MaxPricetextBox.Text, out decimal maximo) || minPrice >= maximo)
            {
                valido = false;
                errorProvider1.SetError(MaxPricetextBox, "Precio no válido o mal ingresado. Debe ser un número mayor al mínimo.");
            }
            else
            {
                maxPrice = maximo;
            }
         
            if (maxPrice > 99999999999) 
            {
                valido = false;
                errorProvider1.SetError(MinPricetextBox, "El precio debe estar entre 0 y 99999999999.");
            }
            return valido;
        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal decimal GetMaxPrice()
        {
            return maxPrice;
        }

        internal decimal GetMinPrice()
        {
            return minPrice;
        }
    }
}
