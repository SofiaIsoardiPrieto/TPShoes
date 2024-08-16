using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmGenreAE : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private Genre? genre;
        private bool EsEdition = false;

        public FrmGenreAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if (genre is not null)
            {
                GenretextBox.Text = genre.GenreName.ToLower();
                EsEdition = true;
            }
        }
        public Genre GetGenre()
        {
            return genre;
        }
        public void SetGenre(Genre genre)
        {
            this.genre = genre;
        }
        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (genre is null)
                {
                    genre = new Genre();
                }

                genre.GenreId = genre?.GenreId ?? 0;
                genre.GenreName = GenretextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(GenretextBox.Text) || string.IsNullOrWhiteSpace(GenretextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(GenretextBox, "Nombre requerido");
            }
            return valido;
        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
