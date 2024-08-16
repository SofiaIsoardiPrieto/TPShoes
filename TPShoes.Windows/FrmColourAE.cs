using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmColourAE : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Colour? colour;
        private bool EsEdition = false;

        public FrmColourAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if (colour is not null)
            {
                ColourtextBox.Text = colour.ColourName.ToLower();
                EsEdition = true;
            }
        }
        public Colour GetColour()
        {
            return colour;
        }
        public void SetColour(Colour colour)
        {
            this.colour = colour;
        }
        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (colour is null)
                {
                    colour = new Colour();
                }

                colour.ColourId = colour?.ColourId ?? 0;
                colour.ColourName = ColourtextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(ColourtextBox.Text) || string.IsNullOrWhiteSpace(ColourtextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(ColourtextBox, "Nombre requerido");
            }
            return valido;
        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
