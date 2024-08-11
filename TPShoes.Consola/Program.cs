using ConsoleTables;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing;
using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Herramientas;
using TPShoes.IoC;
using TPShoes.Servicios.Interfaces;

class Program
{

    private static IServiceProvider? serviceProvider;
    static int paginaActual = 1;//private int pageNum = 0;
    static int registro;//private int recordCount;
    static int paginas;//private int pageCount;
    static int registrosPorPagina = 5; //private int pageSize = 15; 

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
            Console.WriteLine("28.Listar SizeShoes");
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
                case "28":
                    Console.Clear();
                    ListarSizeShoes();
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

    //Creacion de un metodo generico y estatico en la consolahelper para probar si las tablas se hacen todas ahi

    //Listo, testeado
    private static void ListarSizeShoes()//28
    {
        Console.Clear();
        Console.WriteLine("Listado de Shoes");

        var servicioShoe = serviceProvider?.GetService<IShoesServicio>();
        var servicioSizeShoe = serviceProvider?.GetService<ISizeShoesServicio>();

        if (servicioShoe is null)
        {
            Console.WriteLine("Servicio de Size no disponible.");
            return;
        }
        if (servicioSizeShoe is null)
        {
            Console.WriteLine("Servicio de SizeShoe no disponible.");
            return;
        }

        //Shoe
        List<ShoeDto> ListaShoesDto = servicioShoe.GetListaDto();
        if (ListaShoesDto is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible.");
            return;
        }

        ConsoleExtensions.MostrarTabla(ListaShoesDto, "ShoeId", "Brand", "Sport", "Genre", "Colour", "Model", "Description", "Price");

        int shoeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Shoe: ");
        Shoe shoe = servicioShoe.GetShoePorId(shoeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        //SizeSHoe
        var sizeShoeDtoList = servicioSizeShoe.GetSizeShoeDtoPorId(shoeIdSeleccionado);
        if (sizeShoeDtoList is null)
        {
            Console.WriteLine("No hay lista de SizeShoesDto disponible.");
            return;
        }

        ConsoleExtensions.MostrarTabla(sizeShoeDtoList, "SizeShoeId", "Size", "Stok");

    }

    //Listo, testeado, se podrá DRY??
    private static void ListarShoesSegunSize()//27
    {
        Console.Clear();
        Console.WriteLine("Listado de Size:");

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

        ConsoleExtensions.MostrarTabla(ListaSizes, "SizeId", "SizeNumber");

        int sizeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Size a filtrar: ");

        List<ShoeDto> shoeList = servicioSizeShoe.GetListaShoeDtoPorSize(sizeIdSeleccionado);
        if (shoeList is null)
        {
            Console.WriteLine("No hay lista de Sizes disponible.");
            return;
        }
        ConsoleExtensions.MostrarTabla(shoeList, "ShoeId", "Brand", "Sport", "Genre", "Colour", "Model", "Description", "Price");
    }

    //Listo, testeado, nuevamente DRY
    private static void AgregarStockAUnSizeShoe()//26
    {
        Console.Clear();
        Console.WriteLine("Listado de Shoe");

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

        //Shoe
        List<ShoeDto> ListaShoesDto = servicioShoe.GetListaDto();

        if (ListaShoesDto is null)
        {
            Console.WriteLine("No hay lista de Sizes disponible.");
            return;
        }
        ConsoleExtensions.MostrarTabla(ListaShoesDto, "ShoeId", "Brand", "Sport", "Genre", "Colour", "Model", "Description", "Price");

        int shoeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Shoe: ");
        Shoe shoe = servicioShoe.GetShoePorId(shoeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        //Size
        var ListaSizes = servicioSize.GetLista();
        if (ListaSizes is null)
        {
            Console.WriteLine("No hay lista de Sizes disponible.");
            return;
        }

        ConsoleExtensions.MostrarTabla(ListaSizes, "SizeId", "SizeNumber");

        int sizeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Size: ");
        var size = servicioSize.GetSizePorId(sizeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        if (!servicioShoe.ExisteRelacion(shoe, size))
        {
            Console.WriteLine("Relación no existente, desea agregar?");
            var agregarrealacion = ConsoleExtensions.ReadString("S para si, N para no: ").ToUpper();
            if (agregarrealacion != "S") { return; }


            servicioShoe.AsignarSizeAShoe(shoe, size);
            Console.WriteLine("Relación agregada");


        }
        else
        {
            SizeShoe sizeShoe = servicioSizeShoe.GetSizeShoePorId(shoe.ShoeId, size.SizeId);
            if (sizeShoe is null)
            {
                Console.WriteLine("Error, no hay relacion.");
                return;
            }
            Console.WriteLine($"stock:{sizeShoe.Stok}");
            int stock = ConsoleExtensions.ReadInt("Agregar/cambiar stock: ");
            sizeShoe.Stok = stock;
            servicioSizeShoe.Guardar(sizeShoe);
            Console.WriteLine("Stock agregado exitosamente!!!");

        }

    }
    //Listo,testeado, sameeeee DRY
    private static void AsignarUnSizeAUnShoe()//25
    {
        Console.Clear();
        Console.WriteLine("Listado de Shoes:");

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
        //Shoes

        List<ShoeDto> ListaShoesDto = servicioShoe.GetListaDto();

        if (ListaShoesDto is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible.");
            return;
        }
        ConsoleExtensions.MostrarTabla(ListaShoesDto, "ShoeId", "Brand", "Sport", "Genre", "Colour", "Model", "Description", "Price");

        int shoeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Shoe: ");
        Shoe shoe = servicioShoe.GetShoePorId(shoeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        //Size
        var ListaSizes = servicioSize.GetLista();
        if (ListaSizes is null)
        {
            Console.WriteLine("No hay lista de Sizes disponible.");
            return;
        }

        ConsoleExtensions.MostrarTabla(ListaSizes, "SizeId", "SizeNumber");

        int sizeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Size para agregar al Shoe: ");
        TPShoes.Entidades.Clases.Size size = servicioSize.GetSizePorId(sizeIdSeleccionado);
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
    //testado
    private static void ListaDeShoesPorColourYBrand()//21
    {
        Console.Clear();
        var servicioShoes = serviceProvider?.GetService<IShoesServicio>();
        var sevicioBrands = serviceProvider?.GetService<IBrandsServicio>();
        var sevicioColours = serviceProvider?.GetService<IColoursServicio>();

        if (servicioShoes is null)
        {
            Console.WriteLine("Servicio de Shoes no disponible.");
            return;
        }
        var listaBrands = sevicioBrands.GetLista();
        if (listaBrands is null)
        {
            Console.WriteLine("No hay lista de Brands disponible.");
            return;
        }
        Console.WriteLine("Listado de Brands:");
        ConsoleExtensions.MostrarTabla(listaBrands, "BrandId", "BrandName");

        int brandId = ConsoleExtensions.ReadInt("Ingrese el ID del Brand: ");

        var listaColours = sevicioColours.GetLista();
        if (listaColours is null)
        {
            Console.WriteLine("No hay lista de Colour disponible.");
            return;
        }
        Console.WriteLine("Listado de Colours:");
        ConsoleExtensions.MostrarTabla(listaColours, "ColourId", "ColourName");


        int colourId = ConsoleExtensions.ReadInt("Ingrese el ID del Colour: ");

        // Obtener los Shoes filtrados
        var shoesFiltrados = servicioShoes.GetShoesFiltradosPorBrandYColour(brandId, colourId);
        if (shoesFiltrados is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible con ese filtro.");
            return;
        }
        //
        // CUIDADO: NO USAR LA TABLA DE "ConsoleExtensions"
        //

        if (shoesFiltrados.Any())
        {
            var tablaShoe = new ConsoleTable("ID", "Brand", "Genre", "Colour", "Sport", "Price");

            foreach (var item in shoesFiltrados)
            {
                tablaShoe.AddRow(item.ShoeId, item.Brand, item.Genre, item.Colour, item.Sport, item.Price);
            }

            tablaShoe.Options.EnableCount = false;
            tablaShoe.Write();
        }
        else
        {
            Console.WriteLine("No se encontraron Shoes con los criterios seleccionados.");
        }

        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
    }
    //checked
    private static void ListaDeShoesPorSport()//20
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
        if (agrupaciones is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible.");
            return;
        }
        foreach (var grupo in agrupaciones)
        {
            Console.Clear();
            Console.WriteLine($"Sport: {grupo.Key} {servicioSport?.GetSportPorId(grupo.Key).SportName}");
            foreach (var shoe in grupo)
            {
                Console.WriteLine($"  - Shoe Id: {shoe.ShoeId} Modelo: {shoe.Model}, Sport: {shoe.Sport.SportName}");
            }

            ConsoleExtensions.EsperaEnter();

        }
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
    }
    //checked
    private static void ListaDeShoesPorGenre()//19
    {
        Console.Clear();


        var servicioShoes = serviceProvider?.GetService<IShoesServicio>();
        var servicioGenre = serviceProvider?.GetService<IGenresServicio>();
        if (servicioShoes is null)
        {
            Console.WriteLine("Servicio de Shoes no disponible.");
            return;
        }

        //
        // CUIDADO: NO USAR LA TABLA DE "ConsoleExtensions"
        //
        var agrupaciones = servicioShoes.GetShoesAgrupadosPorGenre();
        if (agrupaciones is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible.");
            return;
        }
        foreach (var grupo in agrupaciones)
        {
            Console.Clear();
            Console.WriteLine($"Genre: {grupo.Key} {servicioGenre?.GetGenrePorId(grupo.Key).GenreName}");
            foreach (var shoe in grupo)
            {
                Console.WriteLine($"  - Shoe Id: {shoe.ShoeId} Modelo: {shoe.Model}, Genre: {shoe.Genre.GenreName}");
            }

            ConsoleExtensions.EsperaEnter();

        }
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
    }
    //checked
    private static void ListaDeShoesPorMarcaEntreRangoPrecios()//18
    {
        Console.Clear();

        var servicioShoes = serviceProvider?.GetService<IShoesServicio>();
        var servicioBrand = serviceProvider?.GetService<IBrandsServicio>();
        if (servicioShoes is null)
        {
            Console.WriteLine("Servicio de Shoes no disponible.");
            return;
        }

        //
        // CUIDADO: NO USAR LA TABLA DE "ConsoleExtensions"
        //


        decimal rangoMin = ConsoleExtensions.ReadDecimal("Ingresar menor precio: ");
        decimal rangoMax = ConsoleExtensions.ReadDecimal("Ingresar mayor precio: ");
        var agrupaciones = servicioShoes.GetShoesPorMarcaEntreRangoPrecios(rangoMin, rangoMax);
        if (agrupaciones is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible.");
            return;
        }
        foreach (var grupo in agrupaciones)
        {
            Console.Clear();
            Console.WriteLine($"Brand: {grupo.Key} {servicioBrand?.GetBrandPorId(grupo.Key).BrandName}");
            foreach (var shoe in grupo)
            {
                Console.WriteLine($"  - Shoe Id: {shoe.ShoeId} Modelo: {shoe.Model}, Brand: {shoe.Brand.BrandName}");
            }

            ConsoleExtensions.EsperaEnter();

        }
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
    }
    //checked
    private static void ListaDeShoesPaginado()//17
    {
        Console.Clear();
        var servicio = serviceProvider?.GetService<IShoesServicio>();
        if (servicio is null)
        {
            Console.WriteLine("Servicio Shoe no responde");
            return;
        }
        registro = servicio.GetCantidad();
        paginas = CalcularCantidadPaginas(registro, registrosPorPagina);

        for (int page = 0; page < paginas; page++)
        {
            Console.Clear();
            Console.WriteLine("Listado de Shoes");
            Console.WriteLine($"Página: {page + 1}");
            List<ShoeDto>? listaPaginada = servicio?
                .GetListaPaginadaOrdenadaFiltrada(page, registrosPorPagina, null, null, null);
            MostrarListaShoes(listaPaginada);
            ConsoleExtensions.EsperaEnter();
        }
    }
    //checked
    private static void MostrarListaShoes(List<ShoeDto>? ListaShoesDto)
    {
        ConsoleExtensions.MostrarTabla(ListaShoesDto, "ShoeId", "Brand", "Sport", "Genre", "Colour", "Model", "Description", "Price");
    }
    //checked
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

    // no checked, pero confio...
    private static void EditarUnShoe()//24
    {

        Console.Clear();
        var servicioShoe = serviceProvider?.GetService<IShoesServicio>();
        var servicioBrand = serviceProvider?.GetService<IBrandsServicio>();
        var servicioColour = serviceProvider?.GetService<IColoursServicio>();
        var servicioGenre = serviceProvider?.GetService<IGenresServicio>();
        var servicioSport = serviceProvider?.GetService<ISportsServicio>();
        var servicioSizeShoe = serviceProvider?.GetService<ISizeShoesServicio>();
        var servicioSize = serviceProvider?.GetService<ISizesServicio>();
        List<ShoeDto> ListaShoesDto = servicioShoe.GetListaDto();
        if (ListaShoesDto is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible.");
            return;
        }

        ConsoleExtensions.MostrarTabla(ListaShoesDto, "ShoeId", "Brand", "Sport", "Genre", "Colour", "Model", "Description", "Price");

        int shoeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Shoe: ");
        Shoe shoe = servicioShoe.GetShoePorId(shoeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        if (shoe is null)
        {
            Console.WriteLine("Shoe no encontrada.");
            return;
        }

        // Editar los detalles del shoe

        shoe.Brand.BrandName = ConsoleExtensions.ReadString("Ingrese nombre Brand: ");
        shoe.Genre.GenreName = ConsoleExtensions.ReadString("Ingrese nombre Genre: ");
        shoe.Colour.ColourName = ConsoleExtensions.ReadString("Ingrese nombre Colour: ");
        shoe.Sport.SportName = ConsoleExtensions.ReadString("Ingrese nombre Sport: ");
        shoe.Model = ConsoleExtensions.ReadString("Ingrese nombre Model: ");
        shoe.Price = ConsoleExtensions.ReadDecimal("Ingrese Precio: ");
        shoe.Description = ConsoleExtensions.ReadString("Ingrese Descripcion: ");

        if (!servicioShoe.Existe(shoe))
        {
            servicioShoe.Guardar(shoe);
            Console.WriteLine("Shoe guardado exitosamente!");
            Console.WriteLine("Desea agragar todos los Size al nuevo Shoe?");
            var agregarrealacion = ConsoleExtensions.ReadString("S para si, N para no: ").ToUpper();
            if (agregarrealacion != "S") { return; }

            var listaSize = servicioSize.GetLista();
            if (listaSize is null)
            {
                Console.WriteLine("Lista Size no encontrada");
                return;
            }
            foreach (var size in listaSize)
            {
                servicioShoe.AsignarSizeAShoe(shoe, size);
            }

            Console.WriteLine("Relaciones agregadas");
        }
        else
        {
            Console.WriteLine("Shoe ya existe");
            return;
        }


    }

    //error en repositorio savechanges luego del metodo borrar
    private static void BorrarUnShoe()//23
    {
        Console.Clear();
        
        var servicio = serviceProvider?.GetService<IShoesServicio>();
        if (servicio is null)
        {
            Console.WriteLine("Servicio caido");
            return;
        }
        var ListaShoesDto = servicio.GetListaDto();
        if (ListaShoesDto is null)
        {
            Console.WriteLine("Lista Shoe no disponible");
            return;
        }
        ConsoleExtensions.MostrarTabla(ListaShoesDto, "ShoeId", "Brand", "Sport", "Genre", "Colour", "Model", "Description", "Price");
        Console.WriteLine("Ingrese Shoe a borrar");
        var shoeId = ConsoleExtensions.ReadInt("Ingrese un ID de Shoe: ");

        try
        {
            var shoe = servicio?.GetShoePorId(shoeId);
            if (shoe is not null)
            {
                if (servicio is not null)
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
    //checked
    private static void InsertarUnShoe()//22
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
