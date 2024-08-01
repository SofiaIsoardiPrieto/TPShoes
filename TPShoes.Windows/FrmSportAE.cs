using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmSportAE : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Sport? sport;
        private bool EsEdition = false;

        public FrmSportAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if (sport is not null)
            {
                SporttextBox.Text = sport.SportName;
                EsEdition = true;
            }
        }
        public Sport GetSport()
        {
            return sport;
        }
        public void SetSport(Sport sport)
        {
            this.sport = sport;
        }
        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (sport is null)
                {
                    sport = new Sport();
                }

                sport.SportId = sport?.SportId ?? 0;
                sport.SportName = SporttextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(SporttextBox.Text) || string.IsNullOrWhiteSpace(SporttextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(SporttextBox, "Nombre requerido");
            }
            return valido;
        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
