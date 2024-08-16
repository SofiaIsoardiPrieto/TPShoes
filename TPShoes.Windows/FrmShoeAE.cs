using Microsoft.Extensions.DependencyInjection;
using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Servicios.Interfaces;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmShoeAE : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IBrandsServicio _servicioBrand;
        private readonly IGenresServicio _servicioGenre;
        private readonly IColoursServicio _servicioColour;
        private readonly ISportsServicio _servicioSport;

        private Shoe? shoe;
        private Brand? brand;
        private Genre? genre;
        private Colour? colour;
        private Sport? sport;

        private bool EsEdition = false;

        public FrmShoeAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _servicioBrand = _serviceProvider.GetService<IBrandsServicio>();
            _servicioGenre = _serviceProvider.GetService<IGenresServicio>();
            _servicioColour = _serviceProvider.GetService<IColoursServicio>();
            _servicioSport = _serviceProvider.GetService<ISportsServicio>();
        }
        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
            CombosHelper.CargarComboBrand(_serviceProvider, ref BrandcomboBox);
            CombosHelper.CargarComboGenre(_serviceProvider, ref GenrecomboBox);
            CombosHelper.CargarComboColour(_serviceProvider, ref ColourcomboBox);
            CombosHelper.CargarComboSport(_serviceProvider, ref SportcomboBox);

            if (shoe is not null)
            {
                DescripciontextBox.Text = shoe.Description;
                PricetextBox.Text = shoe.Price.ToString();
                ModeltextBox.Text = shoe.Model.ToString();
                BrandcomboBox.SelectedValue = shoe.BrandId;
                SportcomboBox.SelectedValue = shoe.SportId;
                ColourcomboBox.SelectedValue = shoe.ColourId;
                GenrecomboBox.SelectedValue = shoe.GenreId;
                sport = shoe.Sport;
                brand = shoe.Brand;
                colour = shoe.Colour;
                genre = shoe.Genre;


                EsEdition = true;
            }
        }
        public Shoe GetShoe()
        {
            return shoe;
        }
        public void SetShoe(Shoe shoe)
        {
            // this.shoe =(Shoe) shoe.Clone();
            this.shoe = shoe;
        }
        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (shoe is null)
                {
                    shoe = new Shoe();
                }

                shoe.BrandId = brand?.BrandId ?? 0;
                shoe.ColourId = colour?.ColourId ?? 0;
                shoe.SportId = sport?.SportId ?? 0;
                shoe.GenreId = genre?.GenreId ?? 0;

                shoe.Brand = brand;
                shoe.Brand.Active = true;
                shoe.Sport = sport;
                shoe.Sport.Active = true;
                shoe.Colour = colour;
                shoe.Colour.Active = true;
                shoe.Genre = genre;
              
                shoe.Model = ModeltextBox.Text;
                shoe.Price = decimal.Parse(PricetextBox.Text);
                shoe.Description = DescripciontextBox.Text;
                DialogResult = DialogResult.OK;
                
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            //combos
            if (BrandcomboBox.SelectedIndex == 0 && brand is null)
            {
                valido = false;
                errorProvider1.SetError(BrandcomboBox, "Debe seleccionar un Brand");
            }
            if (GenrecomboBox.SelectedIndex == 0 && genre is null)
            {
                valido = false;
                errorProvider1.SetError(GenrecomboBox, "Debe seleccionar un Genre");
            }
            if (SportcomboBox.SelectedIndex == 0 && sport is null)
            {
                valido = false;
                errorProvider1.SetError(SportcomboBox, "Debe seleccionar un Sport");
            }
            if (ColourcomboBox.SelectedIndex == 0 && colour is null)
            {
                valido = false;
                errorProvider1.SetError(ColourcomboBox, "Debe seleccionar un Colour");
            }          
            if (string.IsNullOrEmpty(ModeltextBox.Text) ||
                string.IsNullOrWhiteSpace(ModeltextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(ModeltextBox, "Model requerido");
            }
            // Validar que el precio sea un decimal válido y mayor que cero
            if (!decimal.TryParse(PricetextBox.Text, out decimal price) || price <= 0)
            {
                valido = false;
                errorProvider1.SetError(PricetextBox, "Precio no válido o mal ingresado. Debe ser un número positivo.");
                return valido;
            }
            // Validar que el precio esté dentro del rango permitido (0.00 a 99999999.99) y tenga como máximo dos decimales
            if (price > 99999999.99M || decimal.Round(price, 2) != price)
            {
                valido = false;
                errorProvider1.SetError(PricetextBox, "El precio debe estar entre 0.00 y 99999999.99 con hasta dos decimales.");
            }
            if (string.IsNullOrEmpty(DescripciontextBox.Text) ||
                 string.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                valido = false;
                errorProvider1.SetError(DescripciontextBox, "Descripcion requerido");
            }

            return valido;
        }
        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NuevoBrandbutton_Click(object sender, EventArgs e)
        {
            FrmBrandAE frm = new FrmBrandAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                brand = frm.GetBrand();
                if (brand is null) return;
                if (_servicioBrand is null)
                {
                    MessageBox.Show("Servicio de Brand inhabilitado", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (_servicioBrand.Existe(brand))
                {
                    MessageBox.Show("Brand existente!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _servicioBrand.Guardar(brand);

                    MessageBox.Show("Brand agregado!!!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CombosHelper.CargarComboBrand(_serviceProvider, ref BrandcomboBox);
        }

        private void NuevoGenrebutton_Click(object sender, EventArgs e)
        {
            FrmGenreAE frm = new FrmGenreAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                genre = frm.GetGenre();
                if (genre is null) return;
                if (_servicioGenre is null)
                {
                    MessageBox.Show("Servicio de Genre inhabilitado", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (_servicioGenre.Existe(genre))
                {
                    MessageBox.Show("Genre existente!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _servicioGenre.Guardar(genre);

                    MessageBox.Show("Genre agregado!!!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CombosHelper.CargarComboGenre(_serviceProvider, ref GenrecomboBox); 
        }

        private void NuevoSportbutton_Click(object sender, EventArgs e)
        {
            FrmSportAE frm = new FrmSportAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                sport = frm.GetSport();
                if (sport is null) return;
                if (_servicioSport is null)
                {
                    MessageBox.Show("Servicio de Sport inhabilitado", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (_servicioSport.Existe(sport))
                {
                    MessageBox.Show("Genre existente!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _servicioSport.Guardar(sport);

                    MessageBox.Show("Sport agregado!!!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CombosHelper.CargarComboSport(_serviceProvider, ref SportcomboBox);
        }

        private void NuevoColourbutton_Click(object sender, EventArgs e)
        {
            FrmColourAE frm = new FrmColourAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                colour = frm.GetColour();
                if (colour is null) return;
                if (_servicioColour is null)
                {
                    MessageBox.Show("Servicio de Colour inhabilitado", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (_servicioColour.Existe(colour))
                {
                    MessageBox.Show("Colour existente!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _servicioColour.Guardar(colour);

                    MessageBox.Show("Colour agregado!!!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CombosHelper.CargarComboColour(_serviceProvider, ref ColourcomboBox);
        }

        private void BrandcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BrandcomboBox.SelectedIndex > 0)
            {
                brand = (Brand?)BrandcomboBox.SelectedItem;
            }
            else { brand = null; }
        }
        private void GenrecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenrecomboBox.SelectedIndex > 0)
            {
                genre = (Genre?)GenrecomboBox.SelectedItem;
            }
            else { genre = null; }
        }
        private void SportcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SportcomboBox.SelectedIndex > 0)
            {
                sport = (Sport?)SportcomboBox.SelectedItem;
            }
            else { sport = null; }
        }
        private void ColourcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ColourcomboBox.SelectedIndex > 0)
            {
                colour = (Colour?)ColourcomboBox.SelectedItem;
            }
            else { colour = null; }
        }
    }
}
