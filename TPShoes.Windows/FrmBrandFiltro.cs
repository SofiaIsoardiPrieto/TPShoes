using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmBrandFiltro : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Brand? brand;
        public FrmBrandFiltro(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboBrand(_serviceProvider, ref BrandcomboBox);
           
        }
        public Brand GetBrand()
        {
            return brand;
        }
       
        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                brand = (Brand?)BrandcomboBox.SelectedValue;
                brand.BrandId =BrandcomboBox.SelectedIndex;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (BrandcomboBox.SelectedIndex == 0 && brand is null)
            {
                valido = false;
                errorProvider1.SetError(BrandcomboBox, "Debe seleccionar un Brand");
            }
            return valido;
        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BrandcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BrandcomboBox.SelectedIndex > 0)
            {
                brand = (Brand?)BrandcomboBox.SelectedItem;
            }
            else { brand = null; }
        }
    }
}
