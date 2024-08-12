using TPShoes.Entidades.Clases;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmSizeCombo : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Entidades.Clases.Size? size;
        int shoeId;
        bool esAgregar;
        public FrmSizeCombo(IServiceProvider serviceProvider, int shoeId, bool esAgregar)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            this.shoeId=shoeId;
            this.esAgregar = esAgregar;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboSizePorShoe(_serviceProvider, ref SizecomboBox, shoeId, esAgregar);

        }
        public Entidades.Clases.Size GetSize()
        {
            return size;
        }

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                //size = (Size?)SizecomboBox.SelectedItem;
                //size.SizeId =SizecomboBox.SelectedIndex;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (SizecomboBox.SelectedIndex == 0 && size is null)
            {
                valido = false;
                errorProvider1.SetError(SizecomboBox, "Debe seleccionar un Size");
            }
            return valido;
        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void SizecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SizecomboBox.SelectedIndex > 0)
            {
                size = (Entidades.Clases.Size?)SizecomboBox.SelectedItem;
            }
            else { size = null; }
        }
    }
}
