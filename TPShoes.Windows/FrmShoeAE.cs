using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmShoeAE : Form
    {
        private readonly IServiceProvider _serviceProvider;

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
            this.shoe =(Shoe) shoe.Clone();
            //this.shoe=shoe
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



                ////Se checka que la lista tenga algún item seleccionado
                //if (clstProveedores.CheckedItems.Count > 0)
                //{
                //    p.proveedores = new List<Proveedor>();
                //    //Se itera sobre los proveedores seleccionados
                //    foreach (var item in clstProveedores.CheckedItems)
                //    {
                //        //Se almacenan los proveedores seleccionados

                //        p.proveedores.Add((Proveedor)item);

                //    }
                //}
                DialogResult = DialogResult.OK;
                
            }
        }

      

        //public (Planta?, List<Proveedor>?) GetPlantaProveedores()
        //{
        //    return p;
        //}
        //public void SetPlantaProveedores(
        //   (Planta? planta, List<Proveedor>? proveedores) p)
        //{
        //    this.p = p;
        //}
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
            brand = frm.GetBrand();
            CombosHelper.CargarComboBrand(_serviceProvider, ref BrandcomboBox);
        }

        private void NuevoGenrebutton_Click(object sender, EventArgs e)
        {
            FrmGenreAE frm = new FrmGenreAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            genre = frm.GetGenre();
            CombosHelper.CargarComboGenre(_serviceProvider, ref GenrecomboBox);
          
        }

        private void NuevoSportbutton_Click(object sender, EventArgs e)
        {
            FrmSportAE frm = new FrmSportAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            sport = frm.GetSport();
            CombosHelper.CargarComboSport(_serviceProvider, ref SportcomboBox);
        }

        private void NuevoColourbutton_Click(object sender, EventArgs e)
        {
            FrmColourAE frm = new FrmColourAE(_serviceProvider);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            colour = frm.GetColour();
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
