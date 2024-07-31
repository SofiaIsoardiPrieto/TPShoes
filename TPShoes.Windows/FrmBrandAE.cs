using TPShoes.Entidades;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmBrandAE : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Brand? brand;
        private bool EsEdition = false;

        public FrmBrandAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if (brand is not null)
            {
                BrandtextBox.Text = brand.BrandName;
                EsEdition = true;
            }
        }
        public Brand GetBrand()
        {
            return brand;
        }
        public void SetBrand(Brand brand)
        {
            this.brand = brand;
        }
        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (brand is null)
                {
                    brand = new Brand();
                }

                brand.BrandId = brand?.BrandId ?? 0;
                brand.BrandName = BrandtextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(BrandtextBox.Text) || string.IsNullOrWhiteSpace(BrandtextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(BrandtextBox, "Stock requerido");
            }
            return valido;
        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
