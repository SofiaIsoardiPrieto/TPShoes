using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmColourFiltro : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Colour? colour;
        public FrmColourFiltro(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboColour(_serviceProvider, ref ColourcomboBox);
           
        }
        public Colour GetColour()
        {
            return colour;
        }
       
        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                colour = (Colour?)ColourcomboBox.SelectedValue;
                colour.ColourId = ColourcomboBox.SelectedIndex;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (ColourcomboBox.SelectedIndex == 0 && colour is null)
            {
                valido = false;
                errorProvider1.SetError(ColourcomboBox, "Debe seleccionar un Colour");
            }
            return valido;
        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BrandcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ColourcomboBox.SelectedIndex > 0)
            {
                colour = (Colour?)ColourcomboBox.SelectedItem;
            }
            else { colour = null; }
        }
    }
}
