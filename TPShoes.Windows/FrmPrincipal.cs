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

        }

        private void Coloursbutton_Click(object sender, EventArgs e)
        {

        }

        private void Genresbutton_Click(object sender, EventArgs e)
        {

        }

        private void Brandsbutton_Click(object sender, EventArgs e)
        {

        }

        private void Shoesbutton_Click(object sender, EventArgs e)
        {
            FrmShoes frm = new FrmShoes(_serviceProvider
               .GetService<IShoesServicio>(), _serviceProvider);
            frm.ShowDialog();
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
