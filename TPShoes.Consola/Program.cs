using ConsoleTables;
using Microsoft.Extensions.DependencyInjection;
using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Herramientas;
using TPShoes.IoC;
using TPShoes.Servicios.Interfaces;

class Program
{

    private static IServiceProvider? serviceProvider;
    static int pageSize = 10;
    static void Main(string[] args)
    {
        serviceProvider = DI.ConfigurarServicios();
        bool exit = false;


        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Menú Principal:");

            Console.WriteLine("1. Listado de Brands");
            Console.WriteLine("2. Ingresar un Brand");
            Console.WriteLine("3. Borrar un Brand");
            Console.WriteLine("4. Editar un Brand");

            Console.WriteLine("===============================");

            Console.WriteLine("5. Listado de Colours");
            Console.WriteLine("6. Ingresar un Colour");
            Console.WriteLine("7. Borrar un Colour");
            Console.WriteLine("8. Editar un Colour");

            Console.WriteLine("===============================");

            Console.WriteLine("9. Listado de Genres");
            Console.WriteLine("10. Ingresar un Genre");
            Console.WriteLine("11. Borrar un Genre");
            Console.WriteLine("12. Editar un Genre");

            Console.WriteLine("===============================");

            Console.WriteLine("13. Listado de Sports");
            Console.WriteLine("14. Ingresar un Sport");
            Console.WriteLine("15. Borrar un Sport");
            Console.WriteLine("16. Editar un Sport");

            Console.WriteLine("===============================");
            //aun no puestos
            Console.WriteLine("17. Listado de Shoes Paginado");
            Console.WriteLine("18. Listado de Shoes Filtrado por brand, 2 precios de rango");
            Console.WriteLine("19. Listado de Shoes Filtrado por genre");
            Console.WriteLine("20. Listado de Shoes Filtrado por sport");
            Console.WriteLine("21. Listado de Shoes Filtrado por colour y brand");
            Console.WriteLine("22. Ingresar un Shoe");
            Console.WriteLine("23. Borrar un Shoe");
            Console.WriteLine("24. Editar un Shoes");
            Console.WriteLine("===============================");

            Console.WriteLine("25.Asignar un Size a un Shoe  ");
            Console.WriteLine("26.Agregar Stock a un SizeShoe");
            Console.WriteLine("27.Listar Shoes según Size");
            Console.WriteLine("x. Salir");

            Console.Write("Por favor, seleccione una opción: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    ListaDeBrands();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "2":
                    InsertarUnBrand();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "3":
                    BorrarUnBrand();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "4":
                    EditarUnBrand();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "5":
                    ListaDeColours();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "6":
                    InsertarUnColour();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "7":
                    BorrarUnColour();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "8":
                    EditarUnColour();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "9":
                    Console.Clear();
                    ListaDeGenres();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "10":
                    InsertarUnGenre();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "11":
                    BorrarUnGenre();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "12":
                    EditarUnGenre();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "13":
                    Console.Clear();
                    ListaDeSports();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "14":
                    InsertarUnSport();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "15":
                    BorrarUnSport();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "16":
                    EditarUnSport();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "17":
                    Console.Clear();
                    ListaDeShoesPaginado();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "18":
                    Console.Clear();
                    ListaDeShoesPorMarcaEntreRangoPrecios();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "19":
                    Console.Clear();
                    ListaDeShoesPorGenre();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "20":
                    Console.Clear();
                    ListaDeShoesPorSport();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "21":
                    Console.Clear();
                    ListaDeShoesPorColourYBrand();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "22":
                    Console.Clear();
                    InsertarUnShoe();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "23":
                    Console.Clear();
                    BorrarUnShoe();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "24":
                    Console.Clear();
                    EditarUnShoe();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "25":
                    Console.Clear();
                    AsignarUnSizeAUnShoe();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "26":
                    Console.Clear();
                    AgregarStockAUnSizeShoe();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "27":
                    Console.Clear();
                    ListarShoesSegunSize();
                    ConsoleExtensions.EsperaEnter();
                    break;
                case "x":
                    exit = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }

            Console.WriteLine(); // Añade una línea en blanco para mejorar la legibilidad
        }

    }
    //Listo, sin probar
    private static void ListarShoesSegunSize()
    {
        Console.Clear();
        Console.WriteLine("Listado de Size, seleccione para ver disponibles");

        var servicioSize = serviceProvider?.GetService<ISizesServicio>();
        var servicioSizeShoe = serviceProvider?.GetService<ISizeShoesServicio>();

        if (servicioSize is null)
        {
            Console.WriteLine("Servicio de Size no disponible.");
            return;
        }
        if (servicioSizeShoe is null)
        {
            Console.WriteLine("Servicio de SizeShoe no disponible.");
            return;
        }
        var ListaSizes = servicioSize.GetLista();
        if (ListaSizes is null)
        {
            Console.WriteLine("No hay lista de Sizes disponible.");
            return;
        }

        var tabla = new ConsoleTable("ID", "Size");
        foreach (var size in ListaSizes)
        {
            Console.Clear();
            tabla.AddRow(size.SizeId, size.SizeNumber);
        }

        tabla.Options.EnableCount = false;
        tabla.Write();
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
        int sizeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Size a filtrar");
        ConsoleExtensions.EsperaEnter();

        List<ShoeDto> sizeList = servicioSizeShoe.GetListaShoeDtoPorSize(sizeIdSeleccionado);

        foreach (var shoe in sizeList)
        {
            Console.WriteLine($" - Shoe modelo: {shoe.Model}, color: {shoe.Colour}, marca: {shoe.Brand}, " +
                $"deporte: {shoe.Sport}, género: {shoe.Genre}, precio: {shoe.Price}, descripción: {shoe.Description}");
        }
        Console.WriteLine($"Cantidad: {sizeList.Count()}");
        Console.WriteLine($"Precio promedio:{sizeList.Average(p => p.Price)}");

        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();


    }
    //Listo, sin probar
    private static void AgregarStockAUnSizeShoe()
    {
        Console.Clear();
        Console.WriteLine("Listado de Size, seleccione para ver disponibles");

        var servicioShoe = serviceProvider?.GetService<IShoesServicio>();
        var servicioSizeShoe = serviceProvider?.GetService<ISizeShoesServicio>();
        var servicioSize = serviceProvider?.GetService<ISizesServicio>();

        if (servicioShoe is null)
        {
            Console.WriteLine("Servicio de Shoe no disponible.");
            return;
        }
        if (servicioSizeShoe is null)
        {
            Console.WriteLine("Servicio de SizeShoe no disponible.");
            return;
        }
        var ListaShoes = servicioShoe.GetLista();
        if (ListaShoes is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible.");
            return;
        }

        var tablaShoe = new ConsoleTable("ID", "Brand", "Genre", "Colour", "Sport");

        foreach (var item in ListaShoes)
        {
            tablaShoe.AddRow(item.ShoeId, item.Brand, item.Genre, item.Colour, item.Sport);
        }
        tablaShoe.Options.EnableCount = false;
        tablaShoe.Write();
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();

        int shoeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Shoe");
        Shoe shoe = servicioShoe.GetShoePorId(shoeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        var ListaSizes = servicioSize.GetLista();
        if (ListaSizes is null)
        {
            Console.WriteLine("No hay lista de Sizes disponible.");
            return;
        }
        var tablaSize = new ConsoleTable("ID", "Size");
        foreach (var item in ListaSizes)
        {
            Console.Clear();
            tablaShoe.AddRow(item.SizeId, item.SizeNumber);
        }

        tablaShoe.Options.EnableCount = false;
        tablaShoe.Write();
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
        int sizeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Size");
        Size size = servicioSize.GetSizePorId(sizeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        if (!servicioShoe.ExisteRelacion(shoe, size))
        {
            Console.WriteLine("Relación no existente, desea agregar?");
            var agregarrealacion = ConsoleExtensions.ReadString("S para si, N para no").ToUpper();
            if (agregarrealacion == "S")
            {
                servicioShoe.AsignarSizeAShoe(shoe, size);
                Console.WriteLine("Relación agregada");
            }
            else
            {
                return;
            }

        }
        else
        {
            SizeShoe sizeShoe = servicioSizeShoe.GetSizeShoePorId(shoe.ShoeId,size.SizeId);
            if (sizeShoe is null)
            {
                Console.WriteLine("Error, no hay relacion.");
                return;
            }
            Console.WriteLine($"stock:{sizeShoe.Stok}");
            int stock = ConsoleExtensions.ReadInt("Agregar/cambiar stock");
            sizeShoe.Stok = stock;
            servicioSizeShoe.Guardar(sizeShoe);
          

        }

    }
    //Listo, sin probar
    private static void AsignarUnSizeAUnShoe()
    {
        Console.Clear();
        Console.WriteLine("Listado de Size, seleccione para ver disponibles");

        var servicioShoe = serviceProvider?.GetService<IShoesServicio>();
        var servicioSizeShoe = serviceProvider?.GetService<ISizeShoesServicio>();
        var servicioSize = serviceProvider?.GetService<ISizesServicio>();

        if (servicioShoe is null)
        {
            Console.WriteLine("Servicio de Shoe no disponible.");
            return;
        }
        if (servicioSizeShoe is null)
        {
            Console.WriteLine("Servicio de SizeShoe no disponible.");
            return;
        }
        var ListaShoes = servicioShoe.GetLista();
        if (ListaShoes is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible.");
            return;
        }

        var tablaShoe = new ConsoleTable("ID", "Brand", "Genre", "Colour", "Sport");

        foreach (var item in ListaShoes)
        {
            tablaShoe.AddRow(item.ShoeId, item.Brand, item.Genre, item.Colour, item.Sport);
        }
        tablaShoe.Options.EnableCount = false;
        tablaShoe.Write();
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();

        int shoeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Shoe");
        Shoe shoe = servicioShoe.GetShoePorId(shoeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        var ListaSizes = servicioSize.GetLista();
        if (ListaSizes is null)
        {
            Console.WriteLine("No hay lista de Sizes disponible.");
            return;
        }
        var tablaSize = new ConsoleTable("ID", "Size");
        foreach (var item in ListaSizes)
        {
            Console.Clear();
            tablaShoe.AddRow(item.SizeId, item.SizeNumber);
        }

        tablaShoe.Options.EnableCount = false;
        tablaShoe.Write();
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
        int sizeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Size para agregar al Shoe");
        Size size = servicioSize.GetSizePorId(sizeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();
        if (servicioShoe.ExisteRelacion(shoe, size))
        {
            Console.WriteLine("Relación existente");
            return;
        }
        else
        {
            servicioShoe.AsignarSizeAShoe(shoe, size);
            Console.WriteLine("Relación agregada");
        }
        ConsoleExtensions.EsperaEnter();
    }

    private static void ListaDeShoesPorColourYBrand()
    {
        Console.Clear();
        Console.WriteLine("Listado de Shoes");

        var servicioShoes = serviceProvider?.GetService<IShoesServicio>();
        var servicioColour = serviceProvider?.GetService<IColoursServicio>();
        var servicioBrand = serviceProvider?.GetService<IBrandsServicio>();
        if (servicioShoes is null)
        {
            Console.WriteLine("Servicio de Shoes no disponible.");
            return;
        }
        var agrupaciones = servicioShoes.GetShoesAgrupadosPorColourYBrand();
        foreach (var grupo in agrupaciones)
        {
            Console.Clear();
            Console.WriteLine($"Colour: {grupo.Key} {servicioColour?.GetColourPorId(grupo.Key).ColourName}");
            Console.WriteLine($"Brand: {grupo.Key} {servicioBrand?.GetBrandPorId(grupo.Key).BrandName}");
            foreach (var shoe in grupo)
            {
                Console.WriteLine($"  - Shoe modelo: {shoe.Model}, Colour: {shoe.Colour.ColourName}, Brand: {shoe.Brand.BrandName}");
            }
            Console.WriteLine($"Cantidad: {grupo.Count()}");
            Console.WriteLine($"Precio promedio:{grupo.Average(p => p.Price)}");
            ConsoleExtensions.EsperaEnter();

        }
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
    }

    private static void ListaDeShoesPorSport()
    {
        Console.Clear();
        Console.WriteLine("Listado de Shoes");

        var servicioShoes = serviceProvider?.GetService<IShoesServicio>();
        var servicioSport = serviceProvider?.GetService<ISportsServicio>();
        if (servicioShoes is null)
        {
            Console.WriteLine("Servicio de Shoes no disponible.");
            return;
        }
        var agrupaciones = servicioShoes.GetShoesAgrupadosPorSport();
        foreach (var grupo in agrupaciones)
        {
            Console.Clear();
            Console.WriteLine($"Sport: {grupo.Key} {servicioSport?.GetSportPorId(grupo.Key).SportName}");
            foreach (var shoe in grupo)
            {
                Console.WriteLine($"  - Shoe modelo: {shoe.Model}, Genre: {shoe.Sport.SportName}");
            }
            Console.WriteLine($"Cantidad: {grupo.Count()}");
            Console.WriteLine($"Precio promedio:{grupo.Average(p => p.Price)}");
            ConsoleExtensions.EsperaEnter();

        }
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
    }

    private static void ListaDeShoesPorGenre()
    {
        Console.Clear();
        Console.WriteLine("Listado de Shoes");

        var servicioShoes = serviceProvider?.GetService<IShoesServicio>();
        var servicioGenre = serviceProvider?.GetService<IGenresServicio>();
        if (servicioShoes is null)
        {
            Console.WriteLine("Servicio de Shoes no disponible.");
            return;
        }

        var agrupaciones = servicioShoes.GetShoesAgrupadosPorGenre();

        foreach (var grupo in agrupaciones)
        {
            Console.Clear();
            Console.WriteLine($"Genre: {grupo.Key} {servicioGenre?.GetGenrePorId(grupo.Key).GenreName}");
            foreach (var shoe in grupo)
            {
                Console.WriteLine($"  - Shoe modelo: {shoe.Model}, Genre: {shoe.Genre.GenreName}");
            }
            Console.WriteLine($"Cantidad: {grupo.Count()}");
            Console.WriteLine($"Precio promedio:{grupo.Average(p => p.Price)}");
            ConsoleExtensions.EsperaEnter();

        }
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
    }

    private static void ListaDeShoesPorMarcaEntreRangoPrecios()
    {
        Console.Clear();
        Console.WriteLine("Listado de Shoes");

        var servicioShoes = serviceProvider?.GetService<IShoesServicio>();
        var servicioBrand = serviceProvider?.GetService<IBrandsServicio>();
        if (servicioShoes is null)
        {
            Console.WriteLine("Servicio de Shoes no disponible.");
            return;
        }

        var agrupaciones = servicioShoes.GetShoesAgrupadosPorGenre();

        foreach (var grupo in agrupaciones)
        {
            Console.Clear();
            Console.WriteLine($"Genre: {grupo.Key} {servicioBrand?.GetBrandPorId(grupo.Key).BrandName}");
            foreach (var shoe in grupo)
            {
                Console.WriteLine($"  - Shoe modelo: {shoe.Model}, Brand: {shoe.Brand.BrandName}");
            }
            Console.WriteLine($"Cantidad: {grupo.Count()}");
            Console.WriteLine($"Precio promedio:{grupo.Average(p => p.Price)}");
            ConsoleExtensions.EsperaEnter();

        }
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();

        /*
          private static void ListaPlantasFiltrado()
        {
            Console.Clear();
            Console.WriteLine("Listado de Plantas Filtrada por Tipo de Planta");
            var servicioTipoPlanta = servicioProvider?.GetService<ITiposDePlantasService>();
            var listaTipos = servicioTipoPlanta?.GetLista();
            ListaDeTiposDePlantas();
            var listaCharac = listaTipos?.Select(x => x.TipoDePlantaId.ToString()).ToList();

            var tipoFiltroID = ConsoleExtensions.GetValidOptions("Seleccione Tipo: ", listaCharac);

            TipoDePlanta? tipoFiltro = servicioTipoPlanta?.GetTipoDePlantaPorId(Convert.ToInt32(tipoFiltroID));
            var servicio = servicioProvider?.GetService<IPlantasService>();
            MostrarListaPlantas(servicio?.GetListaPaginadaOrdenadaFiltrada(0, int.MaxValue, null, tipoFiltro));
        }
         */
    }

    private static void ListaDeShoesPaginado()
    {
        Console.Clear();
        Console.WriteLine("Listado de Shoes");

        var servicio = serviceProvider?.GetService<IShoesServicio>();
        var recordCount = servicio?.GetCantidad() ?? 0;
        var pageCount = CalcularCantidadPaginas(recordCount, pageSize);
        for (int page = 0; page < pageCount; page++)
        {
            Console.Clear();
            Console.WriteLine("Listado de Shoes");
            Console.WriteLine($"Página: {page + 1}");
            List<ShoeDto>? listaPaginada = servicio?
                .GetListaPaginadaOrdenadaFiltrada(page, pageSize, null, null, null);
            MostrarListaShoes(listaPaginada);
        }
    }

    private static void MostrarListaShoes(List<ShoeDto>? lista)
    {
        var tabla = new ConsoleTable("ID", "Brand", "Genre", "Colour", "Sport");
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.ShoeId, item.Brand, item.Genre, item.Colour, item.Sport);
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
            ConsoleExtensions.EsperaEnter();
        }
    }

    private static int CalcularCantidadPaginas(int cantidadRegistros, int cantidadPorPagina)
    {
        if (cantidadRegistros < cantidadPorPagina)
        {
            return 1;
        }
        else if (cantidadRegistros % cantidadPorPagina == 0)
        {
            return cantidadRegistros / cantidadPorPagina;
        }
        else
        {
            return cantidadRegistros / cantidadPorPagina + 1;
        }
    }

    //------------------------------------------//
    //falta editra shoe
    private static void EditarUnShoe()
    {

        //Console.Clear();
        //var servicioPlantas = servicioProvider?.GetService<IPlantasService>();
        //var servicioProveedores = servicioProvider?.GetService<IProveedoresService>();

        //// Obtener la planta a editar
        //var plantaId = ConsoleExtensions.ReadInt("Ingrese el ID de la planta a editar:");
        //var planta = servicioPlantas?.GetPlantaPorId(plantaId);

        //if (planta == null)
        //{
        //    Console.WriteLine("Planta no encontrada.");
        //    return;
        //}
        //Console.WriteLine($"Planta: {planta.Descripcion}");
        //Console.WriteLine($"Tipo de Planta: {planta.TipoDePlanta.Descripcion}");
        //Console.WriteLine($"Tipo de Envase: {planta.TipoDeEnvase.Descripcion}");
        //Console.WriteLine($"Precio: {planta.PrecioVenta}");
        //// Editar los detalles de la planta
        //planta.Descripcion = ConsoleExtensions.ReadString("Ingrese la nueva descripción:");
        //planta.PrecioCosto = ConsoleExtensions.ReadDecimal("Ingrese el nuevo precio de costo:");
        //planta.PrecioVenta = ConsoleExtensions.ReadDecimal("Ingrese el nuevo precio de venta:");
        //// Agregar más propiedades si es necesario

        //// Listar proveedores existentes
        //var listaProveedores = servicioProveedores?.GetLista();
        //Console.WriteLine("Proveedores disponibles:");
        //foreach (var proveedor in listaProveedores)
        //{
        //    Console.WriteLine($"ID: {proveedor.ProveedorId}, Nombre: {proveedor.Nombre}");
        //}

        //// Asignar un nuevo proveedor
        //var proveedorId = ConsoleExtensions
        //    .ReadInt("Ingrese el ID del nuevo proveedor (0 para omitir):");

        //try
        //{
        //    if (proveedorId == 0)
        //    {
        //        servicioPlantas?.Editar(planta, null);
        //    }
        //    else
        //    {
        //        servicioPlantas?.Editar(planta, proveedorId);
        //    }

        //    Console.WriteLine("Planta actualizada exitosamente.");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine($"Error: {ex.Message}");
        //}



    }

    private static void BorrarUnShoe()
    {
        var servicio = serviceProvider?.GetService<IShoesServicio>();
        Console.Clear();
        Console.WriteLine("Ingreso Shoe a borrar");
        ListaDeShoesPaginado();
        var listaChar = servicio?
                .GetLista()
                .Select(x => x.ShoeId.ToString()).ToList();
        var shoeId = ConsoleExtensions
            .GetValidOptions("Ingrese un ID de Shoe:", listaChar);


        try
        {
            var shoe = servicio?.GetShoePorId(Convert.ToInt32(shoeId));
            if (shoe != null)
            {
                if (servicio != null)
                {

                    servicio.Borrar(shoe.ShoeId);
                    Console.WriteLine("Registro borrado!!!");

                }

                else
                {
                    throw new Exception("Servicio no disponible");
                }
            }
            else
            {
                Console.WriteLine("Shoe inexistente!!!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);
    }

    private static void InsertarUnShoe()
    {
        Console.Clear();
        var servicio = serviceProvider?.GetService<IShoesServicio>();


        Console.WriteLine("Nuevo Shoe");

        var brandSeleccionado = SeleccionarUnBrand();
        var genreSeleccionado = SeleccionarUnGenre();
        var sportSeleccionado = SeleccionarUnSport();
        var colourSeleccionado = SeleccionarUnColour();


        var descripcionSeleccionada = ConsoleExtensions.ReadString("Ingrese descripción del Shoe:");
        var modelSeleccionado = ConsoleExtensions.ReadString("Ingrese el modelo del Shoe:");
        decimal priceSeleccionado = ConsoleExtensions.ReadDecimal("Ingrese el precio del Shoe:");
        //--------------------------------------------------//

        var shoe = new Shoe
        {
            ShoeId = 0,
            Brand = brandSeleccionado,
            BrandId = brandSeleccionado.BrandId,
            Genre = genreSeleccionado,
            GenreId = genreSeleccionado.GenreId,
            Sport = sportSeleccionado,
            SportId = sportSeleccionado.SportId,
            Colour = colourSeleccionado,
            ColourId = colourSeleccionado.ColourId,
            Description = descripcionSeleccionada,
            Model = modelSeleccionado,
            Price = priceSeleccionado
        };
        if (servicio != null)
        {
            if (!servicio.Existe(shoe))
            {
                servicio.Guardar(shoe);
                Console.WriteLine("Shoe agregado!!!");
            }
            else
            {
                Console.WriteLine("Shoe existente!!!");
            }
        }
        else
        {
            Console.WriteLine("Servicio no disponible, que hice mal Marta!? Que hice mal!!???'");
        }
    }

    private static Colour SeleccionarUnColour()
    {
        var servicioColour = serviceProvider?.GetService<IColoursServicio>();
        ListaDeColours();
        Colour? colour;
        var listaColour = servicioColour?
                .GetLista()
                .Select(b => b.ColourId.ToString()).ToList();
        var colourId = ConsoleExtensions
                 .GetValidOptions("Seleccione un Colour (N para nuevo):", listaColour);
        if (colourId == "N")
        {
            colourId = "0";
            Console.WriteLine("Ingreso de nuevo Colour");
            var nombreBRand = ConsoleExtensions.ReadString("Ingrese nombre del nuevo Colour:");

            colour = new Colour()
            {
                ColourId = 0,
                ColourName = nombreBRand
            };

        }
        else
        {
            colour = servicioColour?
                .GetColourPorId(Convert.ToInt32(colourId));

        }
        return colour;
    }

    private static Sport SeleccionarUnSport()
    {
        var servicioSport = serviceProvider?.GetService<ISportsServicio>();
        ListaDeSports();
        Sport? sport;
        var listaSport = servicioSport?
                .GetLista()
                .Select(b => b.SportId.ToString()).ToList();
        var sportId = ConsoleExtensions
                 .GetValidOptions("Seleccione un Sport (N para nuevo):", listaSport);
        if (sportId == "N")
        {
            sportId = "0";
            Console.WriteLine("Ingreso de nuevo Sport");
            var nombreBRand = ConsoleExtensions.ReadString("Ingrese nombre del nuevo Sport:");

            sport = new Sport()
            {
                SportId = 0,
                SportName = nombreBRand
            };

        }
        else
        {
            sport = servicioSport?
                .GetSportPorId(Convert.ToInt32(sportId));

        }
        return sport;
    }

    private static Genre SeleccionarUnGenre()
    {
        var servicioGenre = serviceProvider?.GetService<IGenresServicio>();
        ListaDeGenres();
        Genre? genre;
        var listaGenre = servicioGenre?
                .GetLista()
                .Select(b => b.GenreId.ToString()).ToList();
        var genreId = ConsoleExtensions
                 .GetValidOptions("Seleccione un Genre (N para nuevo):", listaGenre);
        if (genreId == "N")
        {
            genreId = "0";
            Console.WriteLine("Ingreso de nuevo Genre");
            var nombreBRand = ConsoleExtensions.ReadString("Ingrese nombre del nuevo Genre:");

            genre = new Genre()
            {
                GenreId = 0,
                GenreName = nombreBRand
            };

        }
        else
        {
            genre = servicioGenre?
                .GetGenrePorId(Convert.ToInt32(genreId));

        }
        return genre;
    }

    private static Brand SeleccionarUnBrand()
    {
        var servicioBrand = serviceProvider?.GetService<IBrandsServicio>();
        ListaDeBrands();
        Brand? brand;
        var listaBrand = servicioBrand?
                .GetLista()
                .Select(b => b.BrandId.ToString()).ToList();
        var brandId = ConsoleExtensions
                 .GetValidOptions("Seleccione un Brand (N para nuevo):", listaBrand);
        if (brandId == "N")
        {
            brandId = "0";
            Console.WriteLine("Ingreso de nuevo Brand");
            var nombreBRand = ConsoleExtensions.ReadString("Ingrese nombre del nuevo Brand:");

            brand = new Brand()
            {
                BrandId = 0,
                BrandName = nombreBRand
            };

        }
        else
        {
            brand = servicioBrand?
                .GetBrandPorId(Convert.ToInt32(brandId));

        }
        return brand;
    }



    //---------------------------------------//
    private static void EditarUnSport()
    {

        Console.Clear();
        Console.WriteLine("Ingreso de sport a editar");
        var tipoNombre = ConsoleExtensions.ReadString("Ingrese nombre del sport:");
        try
        {
            var servicio = serviceProvider?.GetService<ISportsServicio>();
            Sport sport = servicio?.GetSportPorNombre(tipoNombre);
            if (sport != null)
            {
                Console.WriteLine($"Brand: {sport.SportName}");
                var nuevoNombre = ConsoleExtensions.ReadString("Ingrese el nuevo nombre de sport:");
                sport.SportName = nuevoNombre;
                if (servicio != null)
                {
                    if (!servicio.Existe(sport))
                    {
                        servicio.Guardar(sport);
                        Console.WriteLine("Registro editado!!!");
                    }
                    else
                    {
                        Console.WriteLine("Registro duplicado!!!");
                    }
                }
                else
                {
                    throw new Exception("Servicio no disponible!!");
                }
            }
            else
            {
                Console.WriteLine("Registro inexistente!!!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);

    }

    private static void BorrarUnSport()
    {

        Console.Clear();
        Console.WriteLine("Ingreso de sport a borrar");
        var sportNombre = ConsoleExtensions.ReadString("Ingrese el nombre del sport:");
        try
        {
            var servicio = serviceProvider?.GetService<ISportsServicio>();
            var sport = servicio?
                .GetSportPorNombre(sportNombre);
            if (sport != null)
            {
                if (servicio != null)
                {
                    if (!servicio.EstaRelacionado(sport))
                    {
                        servicio.Borrar(sport);
                        Console.WriteLine("Registro borrado!!!");

                    }
                    else
                    {
                        Console.WriteLine("Genre relacionado!!! Baja denegada");
                    }

                }
                else
                {
                    throw new Exception("Servicio no disponible");
                }
            }
            else
            {
                Console.WriteLine("Registro inexistente!!!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);

    }

    private static void InsertarUnSport()
    {
        var servicio = serviceProvider?
                 .GetService<ISportsServicio>();
        Console.Clear();
        Console.WriteLine("Nuevo Sport");
        var sportNombre = ConsoleExtensions
           .ReadString("Ingrese un nuevo sport:");
        var sport = new Sport
        {
            SportName = sportNombre
        };
        if (servicio != null)
        {
            if (!servicio.Existe(sport))
            {
                servicio.Guardar(sport);
                Console.WriteLine("Sport agregado!!!");
            }
            else
            {
                Console.WriteLine("Sport existente!!!");
            }
        }
        else
        {
            Console.WriteLine("Servicio no disponible, que hice mal Marta!? Que hice mal!!???'");
        }
        Thread.Sleep(2000);

    }

    private static void ListaDeSports()
    {

        Console.Clear();
        Console.WriteLine("Listado de Sport");
        var servicio = serviceProvider?.GetService<ISportsServicio>();
        List<Sport> lista = servicio?.GetLista();
        var tabla = new ConsoleTable("ID", "Sport");
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.SportId,
                    item.SportName);
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
        }

    }

    //----------------------------------------//
    private static void EditarUnGenre()
    {

        Console.Clear();
        Console.WriteLine("Ingreso de colour a editar");
        var tipoNombre = ConsoleExtensions.ReadString("Ingrese nombre del genre:");
        try
        {
            var servicio = serviceProvider?.GetService<IGenresServicio>();
            Genre genre = servicio?.GetGenrePorNombre(tipoNombre);
            if (genre != null)
            {
                Console.WriteLine($"Brand: {genre.GenreName}");
                var nuevoNombre = ConsoleExtensions.ReadString("Ingrese el nuevo nombre de genre:");
                genre.GenreName = nuevoNombre;
                if (servicio != null)
                {
                    if (!servicio.Existe(genre))
                    {
                        servicio.Guardar(genre);
                        Console.WriteLine("Registro editado!!!");
                    }
                    else
                    {
                        Console.WriteLine("Registro duplicado!!!");
                    }
                }
                else
                {
                    throw new Exception("Servicio no disponible!!");
                }
            }
            else
            {
                Console.WriteLine("Registro inexistente!!!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);

    }

    private static void BorrarUnGenre()
    {

        Console.Clear();
        Console.WriteLine("Ingreso de genre a borrar");
        var genreNombre = ConsoleExtensions.ReadString("Ingrese el nombre del genre:");
        try
        {
            var servicio = serviceProvider?.GetService<IGenresServicio>();
            var genre = servicio?
                .GetGenrePorNombre(genreNombre);
            if (genre != null)
            {
                if (servicio != null)
                {
                    if (!servicio.EstaRelacionado(genre))
                    {
                        servicio.Borrar(genre);
                        Console.WriteLine("Registro borrado!!!");

                    }
                    else
                    {
                        Console.WriteLine("Genre relacionado!!! Baja denegada");
                    }

                }
                else
                {
                    throw new Exception("Servicio no disponible");
                }
            }
            else
            {
                Console.WriteLine("Registro inexistente!!!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);

    }

    private static void InsertarUnGenre()
    {
        var servicio = serviceProvider?
                 .GetService<IGenresServicio>();
        Console.Clear();
        Console.WriteLine("Nuevo Genre");
        var genreNombre = ConsoleExtensions
            .ReadString("Ingrese un nuevo genre:");
        var genre = new Genre
        {
            GenreName = genreNombre
        };
        if (servicio != null)
        {
            if (!servicio.Existe(genre))
            {
                servicio.Guardar(genre);
                Console.WriteLine("Brand agregado!!!");
            }
            else
            {
                Console.WriteLine("Brand existente!!!");
            }
        }
        else
        {
            Console.WriteLine("Servicio no disponible, que hice mal Marta!? Que hice mal!!???'");
        }
        Thread.Sleep(2000);

    }

    private static void ListaDeGenres()
    {

        Console.Clear();
        Console.WriteLine("Listado de Genres");
        var servicio = serviceProvider?.GetService<IGenresServicio>();
        List<Genre> lista = servicio?.GetLista();
        var tabla = new ConsoleTable("ID", "Genre");
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.GenreId,
                    item.GenreName);
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
        }

    }
    //--------------------------------------//
    private static void EditarUnColour()
    {
        Console.Clear();
        Console.WriteLine("Ingreso de colour a editar");
        var tipoNombre = ConsoleExtensions.ReadString("Ingrese nombre del colour:");
        try
        {
            var servicio = serviceProvider?.GetService<IColoursServicio>();
            var colour = servicio?.GetColourPorNombre(tipoNombre);
            if (colour != null)
            {
                Console.WriteLine($"Brand: {colour.ColourName}");
                var nuevoNombre = ConsoleExtensions.ReadString("Ingrese el nuevo nombre de colour:");
                colour.ColourName = nuevoNombre;
                if (servicio != null)
                {
                    if (!servicio.Existe(colour))
                    {
                        servicio.Guardar(colour);
                        Console.WriteLine("Registro editado!!!");
                    }
                    else
                    {
                        Console.WriteLine("Registro duplicado!!!");
                    }
                }
                else
                {
                    throw new Exception("Servicio no disponible!!");
                }
            }
            else
            {
                Console.WriteLine("Registro inexistente!!!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);
    }

    private static void BorrarUnColour()
    {
        Console.Clear();
        Console.WriteLine("Ingreso de colour a borrar");
        var colourNombre = ConsoleExtensions.ReadString("Ingrese el nombre del colour:");
        try
        {
            var servicio = serviceProvider?.GetService<IColoursServicio>();
            var colour = servicio?
                .GetColourPorNombre(colourNombre);
            if (colour != null)
            {
                if (servicio != null)
                {
                    if (!servicio.EstaRelacionado(colour))
                    {
                        servicio.Borrar(colour);
                        Console.WriteLine("Registro borrado!!!");

                    }
                    else
                    {
                        Console.WriteLine("Brand relacionado!!! Baja denegada");
                    }

                }
                else
                {
                    throw new Exception("Servicio no disponible");
                }
            }
            else
            {
                Console.WriteLine("Registro inexistente!!!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);
    }

    private static void InsertarUnColour()
    {
        var servicio = serviceProvider?
                 .GetService<IColoursServicio>();
        Console.Clear();
        Console.WriteLine("Nuevo Brand");
        var colourNombre = ConsoleExtensions
            .ReadString("Ingrese un nuevo colour:");
        var colour = new Colour
        {
            ColourName = colourNombre
        };
        if (servicio != null)
        {
            if (!servicio.Existe(colour))
            {
                servicio.Guardar(colour);
                Console.WriteLine("Brand agregado!!!");
            }
            else
            {
                Console.WriteLine("Brand existente!!!");
            }

        }
        else
        {
            Console.WriteLine("Servicio no disponible, que hice mal Marta!? Que hice mal!!???'");
        }
        Thread.Sleep(2000);
    }

    private static void ListaDeColours()
    {
        Console.Clear();
        Console.WriteLine("Listado de Colours");
        var servicio = serviceProvider?.GetService<IColoursServicio>();
        var lista = servicio?.GetLista();
        var tabla = new ConsoleTable("ID", "Brand");
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.ColourId,
                    item.ColourName);
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
        }
    }

    //----------------------------------------//
    private static void EditarUnBrand()
    {
        Console.Clear();
        Console.WriteLine("Ingreso de brand a editar");
        var tipoNombre = ConsoleExtensions.ReadString("Ingrese nombre del brand:");
        try
        {
            var servicio = serviceProvider?.GetService<IBrandsServicio>();
            var brand = servicio?.GetBrandPorNombre(tipoNombre);
            if (brand != null)
            {
                Console.WriteLine($"Brand: {brand.BrandName}");
                var nuevoNombre = ConsoleExtensions.ReadString("Ingrese el nuevo nombre de Brand:");
                brand.BrandName = nuevoNombre;
                if (servicio != null)
                {
                    if (!servicio.Existe(brand))
                    {
                        servicio.Guardar(brand);
                        Console.WriteLine("Registro editado!!!");

                    }
                    else
                    {
                        Console.WriteLine("Registro duplicado!!!");
                    }

                }
                else
                {
                    throw new Exception("Servicio no disponible!!");
                }
            }
            else
            {
                Console.WriteLine("Registro inexistente!!!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);
    }

    private static void BorrarUnBrand()
    {
        Console.Clear();
        Console.WriteLine("Ingreso de Brand a borrar");
        var brandNombre = ConsoleExtensions.ReadString("Ingrese el nombre del brand:");
        try
        {
            var servicio = serviceProvider?.GetService<IBrandsServicio>();
            var brand = servicio?
                .GetBrandPorNombre(brandNombre);
            if (brand != null)
            {
                if (servicio != null)
                {
                    if (!servicio.EstaRelacionado(brand))
                    {
                        servicio.Borrar(brand);
                        Console.WriteLine("Registro borrado!!!");

                    }
                    else
                    {
                        Console.WriteLine("Brand relacionado!!! Baja denegada");
                    }

                }
                else
                {
                    throw new Exception("Servicio no disponible");
                }
            }
            else
            {
                Console.WriteLine("Registro inexistente!!!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);
    }

    private static void InsertarUnBrand()
    {
        var servicio = serviceProvider?
                .GetService<IBrandsServicio>();
        Console.Clear();
        Console.WriteLine("Nuevo Brand");
        var brandNombre = ConsoleExtensions
            .ReadString("Ingrese un nuevo brand:");
        var brand = new Brand
        {
            BrandName = brandNombre
        };
        if (servicio != null)
        {
            if (!servicio.Existe(brand))
            {
                servicio.Guardar(brand);
                Console.WriteLine("Brand agregado!!!");
            }
            else
            {
                Console.WriteLine("Brand existente!!!");
            }

        }
        else
        {
            Console.WriteLine("Servicio no disponible, que hice mal Marta!? Que hice mal!!???'");
        }
        Thread.Sleep(2000);
    }

    private static void ListaDeBrands()
    {
        Console.Clear();
        Console.WriteLine("Listado de Brands");

        var servicio = serviceProvider?.GetService<IBrandsServicio>();
        var lista = servicio?.GetLista();
        var tabla = new ConsoleTable("ID", "Brand");
        if (lista != null)
        {
            foreach (var item in lista)
            {
                tabla.AddRow(item.BrandId,
                    item.BrandName);

            }
            tabla.Options.EnableCount = false;
            tabla.Write();

        }
    }
}
