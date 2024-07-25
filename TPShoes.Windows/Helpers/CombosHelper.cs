using Microsoft.Extensions.DependencyInjection;
using TPShoes.Servicios.Interfaces;
using TPShoes.Entidades;
using TPShoes.Entidades.Clases;

namespace TPShoes.Windows.Helpers
{

    public static class CombosHelper
    {

        public static void CargarCombosPaginas(int paginaActual, ref ComboBox cbo)
        {
            cbo.Items.Clear();
            for (int pagina = 1; pagina <= paginaActual; pagina++)
            {
                cbo.Items.Add(pagina.ToString());
            }
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboBrand(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IBrandsServicio>();

            var lista = servicio?.GetLista();
            var defaultBrand = new Brand
            {
                BrandName = "Seleccione"
            };
            lista?.Insert(0, defaultBrand);
            cbo.DataSource = lista;
            cbo.DisplayMember = "BrandName";
            cbo.ValueMember = "BrandId";
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboGenre(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IGenresServicio>();

            var lista = servicio?.GetLista();
            var defaultGenre = new Genre
            {
                GenreName = "Seleccione"
            };
            lista?.Insert(0, defaultGenre);
            cbo.DataSource = lista;
            cbo.DisplayMember = "GenreName";
            cbo.ValueMember = "GenreId";
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboColour(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IColoursServicio>();

            var lista = servicio?.GetLista();
            var defaultColour = new Colour
            {
                ColourName = "Seleccione"
            };
            lista?.Insert(0, defaultColour);
            cbo.DataSource = lista;
            cbo.DisplayMember = "ColourName";
            cbo.ValueMember = "ColourId";
            cbo.SelectedIndex = 0;
        }
        public static void CargarComboSport(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<ISportsServicio>();

            var lista = servicio?.GetLista();
            var defaultSport = new Sport
            {
                SportName = "Seleccione"
            };
            lista?.Insert(0, defaultSport);
            cbo.DataSource = lista;
            cbo.DisplayMember = "SportName";
            cbo.ValueMember = "SportId";
            cbo.SelectedIndex = 0;
        }
        //public static void CargarComboProveedores(IServiceProvider serviceProvider, ref ComboBox cbo)
        //{
        //    var servicio = serviceProvider.GetService<IProveedoresService>();

        //    var lista = servicio?.GetLista();
        //    var defaultProveedor = new Proveedor
        //    {
        //        Nombre = "Seleccione"
        //    };
        //    lista?.Insert(0, defaultProveedor);
        //    cbo.DataSource = lista;
        //    cbo.DisplayMember = "Nombre";
        //    cbo.ValueMember = "ProveedorId";
        //    cbo.SelectedIndex = 0;
        //}

    }

}
