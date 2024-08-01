using Microsoft.Extensions.DependencyInjection;
using TPShoes.Servicios.Interfaces;

namespace TPShoes.Windows
{
    public partial class FrmPrincipal : Form
    {

        private readonly IServiceProvider _serviceProvider;
        public FrmPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void Sportsbutton_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSports frm = new FrmSports(_serviceProvider
                               .GetService<ISportsServicio>(), _serviceProvider);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}");
            }
        }

        private void Coloursbutton_Click(object sender, EventArgs e)
        {
            try
            {
                FrmColours frm = new FrmColours(_serviceProvider
                               .GetService<IColoursServicio>(), _serviceProvider);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}");
            }
        }

        private void Genresbutton_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGenres frm = new FrmGenres(_serviceProvider
                               .GetService<IGenresServicio>(), _serviceProvider);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}");
            }
        }

        private void Brandsbutton_Click(object sender, EventArgs e)
        {
            try
            {
                FrmBrands frm = new FrmBrands(_serviceProvider
                               .GetService<IBrandsServicio>(), _serviceProvider);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}");
            }
        }

        private void Shoesbutton_Click(object sender, EventArgs e)
        {
            try
            {
                FrmShoes frm = new FrmShoes(_serviceProvider
                               .GetService<IShoesServicio>(), _serviceProvider);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se produjo un error: {ex.Message}");
            }

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
