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
    private static IShoesServicio? shoesServicio;
    private static IBrandsServicio? brandsServicio;
    private static IColoursServicio? coloursServicio;
    private static IGenresServicio? genresServicio;
    private static ISportsServicio? sportsServicio;
    private static ISizeShoesServicio? sizeShoesServicio;
    private static ISizesServicio? sizesServicio;

    static int paginaActual = 1;//private int pageNum = 0;
    static int registro;//private int recordCount;
    static int paginas;//private int pageCount;
    static int registrosPorPagina = 5; //private int pageSize = 15; 

    static void Main(string[] args)
    {
        serviceProvider = DI.ConfigurarServicios();
        shoesServicio = serviceProvider?.GetService<IShoesServicio>();
        brandsServicio = serviceProvider?.GetService<IBrandsServicio>();
        coloursServicio = serviceProvider?.GetService<IColoursServicio>();
        genresServicio = serviceProvider?.GetService<IGenresServicio>();
        sportsServicio = serviceProvider?.GetService<ISportsServicio>();
        sizeShoesServicio = serviceProvider?.GetService<ISizeShoesServicio>();
        sizesServicio = serviceProvider?.GetService<ISizesServicio>();
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
                    ListaDeShoesDtoPaginado();
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
    /// <summary>
    /// Muestra lista de Brands completa
    /// </summary>
    private static void ListaDeBrands()//1
    {
        Console.Clear();
        if (brandsServicio is null)
        {
            Console.WriteLine("Servicio de Brands no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Listado de Brands");

        var listaBrands = brandsServicio.GetLista();

        if (listaBrands is null)
        {
            Console.WriteLine("No hay lista de Brands disponible.");
            return;
        }

        ConsoleExtensions.MostrarTabla(listaBrands, "BrandId", "BrandName");
    }
    /// <summary>
    /// Agregar un nuevo Brand
    /// </summary>
    private static void InsertarUnBrand()//2
    {
        Console.Clear();
        if (brandsServicio is null)
        {
            Console.WriteLine("Servicio de Brands no disponible. Por favor, verifica la configuración.");
            return;
        }

        Console.WriteLine("Nuevo Brand");
        var brandNombre = ConsoleExtensions.ReadString("Ingrese un nuevo brand:");

        var brand = new Brand { BrandName = brandNombre };


        if (brandsServicio.Existe(brand))
        {
            Console.WriteLine("Brand existente!!!");
        }
        else
        {
            brandsServicio.Guardar(brand);
            Console.WriteLine("Brand agregado!!!");
        }
    }
    /// <summary>
    /// Borrar un brand por Id seleccionado de la lista
    /// </summary>
    private static void BorrarUnBrand()//3
    {
        Console.Clear();
        if (brandsServicio is null)
        {
            Console.WriteLine("Servicio de Brands no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Ingreso de Brand a borrar");

        ListaDeBrands();

        var brandId = ConsoleExtensions.ReadInt("Ingrese el Id del brand: ");
        try
        {
            var brand = brandsServicio?.GetBrandPorId(brandId);

            if (brand is null)
            {
                Console.WriteLine("Registro inexistente!!!");
            }
            else
            {

                if (brandsServicio.EstaRelacionado(brand))
                {
                    Console.WriteLine("Brand relacionado!!! Baja denegada");
                }
                else
                {
                    brandsServicio.Borrar(brand);
                    Console.WriteLine("Registro borrado!!!");
                }
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
    }
    /// <summary>
    /// Edita un Brand por Id seleccionado de una lista
    /// </summary>
    private static void EditarUnBrand()//4
    {
        Console.Clear();
        if (brandsServicio is null)
        {
            Console.WriteLine("Servicio de Brands no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Ingreso de brand a editar");

        ListaDeBrands();

        var brandId = ConsoleExtensions.ReadInt("Ingrese Id del brand: ");

        try
        {
            Brand brand = brandsServicio?.GetBrandPorId(brandId);

            if (brand is null)
            {
                Console.WriteLine("Registro inexistente!!!");
            }
            else
            {
                Console.WriteLine($"Brand: {brand.BrandName}");

                brand.BrandName = ConsoleExtensions.ReadString("Ingrese el nuevo nombre de Brand: ");

                if (brandsServicio.Existe(brand))
                {
                    Console.WriteLine("Registro duplicado!!!");
                }
                else
                {
                    brandsServicio.Guardar(brand);
                    Console.WriteLine("Registro editado!!!");

                }
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
    }
    /// <summary>
    /// Muestra lista de Colours completa
    /// </summary>
    private static void ListaDeColours()//5
    {
        Console.Clear();
        if (coloursServicio is null)
        {
            Console.WriteLine("Servicio de Colours no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Listado de Colours");

        var listaColours = coloursServicio.GetLista();

        if (listaColours is null)
        {
            Console.WriteLine("No hay lista de Colour disponible.");
            return;
        }

        ConsoleExtensions.MostrarTabla(listaColours, "ColourId", "ColourName");
    }
    /// <summary>
    /// Agregar un nuevo Colour
    /// </summary>
    private static void InsertarUnColour()//6
    {
        Console.Clear();
        if (coloursServicio is null)
        {
            Console.WriteLine("Servicio de Colours no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Nuevo Colour");

        var colourNombre = ConsoleExtensions.ReadString("Ingrese un nuevo colour:");

        Colour colour = new Colour { ColourName = colourNombre };


        if (coloursServicio.Existe(colour))
        {
            Console.WriteLine("Colour existente!!!");
        }
        else
        {
            coloursServicio.Guardar(colour);
            Console.WriteLine("Colour agregado!!!");
        }

    }
    /// <summary>
    /// Borrar un Colour por Id seleccionado de la lista
    /// </summary>
    private static void BorrarUnColour()//7
    {
        Console.Clear();
        if (coloursServicio is null)
        {
            Console.WriteLine("Servicio de Colours no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Ingreso de colour a borrar");

        ListaDeColours();

        var colourId = ConsoleExtensions.ReadInt("Ingrese el Id del colour: ");
        try
        {
            var colour = coloursServicio?.GetColourPorId(colourId);

            if (colour is null)
            {
                Console.WriteLine("Registro inexistente!!!");
            }
            else
            {
                if (coloursServicio.EstaRelacionado(colour))
                {
                    Console.WriteLine("Colour relacionado!!! Baja denegada");
                }
                else
                {
                    coloursServicio.Borrar(colour);
                    Console.WriteLine("Registro borrado!!!");

                }
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
    }
    /// <summary>
    /// Edita un Colour por Id seleccionado de una lista
    /// </summary>
    private static void EditarUnColour()//8
    {
        Console.Clear();
        if (coloursServicio is null)
        {
            Console.WriteLine("Servicio de Colours no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Ingreso de colour a editar");

        ListaDeColours();

        var colourId = ConsoleExtensions.ReadInt("Ingrese Id del colour: ");

        try
        {
            var colour = coloursServicio?.GetColourPorId(colourId);

            if (colour is null)
            {
                Console.WriteLine("Registro inexistente!!!");
            }
            else
            {
                Console.WriteLine($"Brand: {colour.ColourName}");

                colour.ColourName = ConsoleExtensions.ReadString("Ingrese el nuevo nombre de colour: ");

                if (coloursServicio.Existe(colour))
                {
                    Console.WriteLine("Registro duplicado!!!");
                }
                else
                {
                    coloursServicio.Guardar(colour);
                    Console.WriteLine("Registro editado!!!");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);
    }
    /// <summary>
    /// Muestra lista de Genre completa
    /// </summary>
    private static void ListaDeGenres()//9
    {

        Console.Clear();
        if (genresServicio is null)
        {
            Console.WriteLine("Servicio de Genre no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Listado de Genres");

        List<Genre> listaGenre = genresServicio?.GetLista();

        if (listaGenre is null)
        {
            Console.WriteLine("No hay lista de Genres disponible.");
            return;
        }

        ConsoleExtensions.MostrarTabla(listaGenre, "GenreId", "GenreName");
    }
    /// <summary>
    /// Agregar un nuevo Genre
    /// </summary>
    private static void InsertarUnGenre()//10
    {

        Console.Clear();
        if (genresServicio is null)
        {
            Console.WriteLine("Servicio de Genre no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Nuevo Genre");

        var genreNombre = ConsoleExtensions.ReadString("Ingrese un nuevo genre:");

        var genre = new Genre { GenreName = genreNombre };

        if (genresServicio is null)
        {
            Console.WriteLine("Servicio no disponible, que hice mal Marta!? Que hice mal!!???'");
        }
        else
        {
            if (genresServicio.Existe(genre))
            {
                Console.WriteLine("Genre existente!!!");
            }
            else
            {
                genresServicio.Guardar(genre);
                Console.WriteLine("Genre agregado!!!");
            }
        }
    }
    /// <summary>
    /// Borrar un Genre por Id seleccionado de la lista
    /// </summary>
    private static void BorrarUnGenre()//11
    {
        Console.Clear();
        if (genresServicio is null)
        {
            Console.WriteLine("Servicio de Genre no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Ingreso de genre a borrar");

        ListaDeGenres();

        var genreId = ConsoleExtensions.ReadInt("Ingrese el Id del genre: ");
        try
        {
            var genre = genresServicio?.GetGenrePorId(genreId);

            if (genre is null)
            {
                Console.WriteLine("Registro inexistente!!!");
            }
            else
            {
                if (genresServicio.EstaRelacionado(genre))
                {
                    Console.WriteLine("Genre relacionado!!! Baja denegada");
                }
                else
                {
                    genresServicio.Borrar(genre);
                    Console.WriteLine("Registro borrado!!!");
                }
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
    }
    /// <summary>
    /// Edita un Genre por Id seleccionado de una lista
    /// </summary>
    private static void EditarUnGenre()//12
    {

        Console.Clear();
        if (genresServicio is null)
        {
            Console.WriteLine("Servicio de Genre no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Ingreso de genre a editar");

        ListaDeGenres();

        var genreId = ConsoleExtensions.ReadInt("Ingrese Id del genre: ");

        try
        {
            var genre = genresServicio?.GetGenrePorId(genreId);

            if (genre is null)
            {
                Console.WriteLine("Registro inexistente!!!");
            }
            else
            {
                Console.WriteLine($"Genre: {genre.GenreName}");
                genre.GenreName = ConsoleExtensions.ReadString("Ingrese el nuevo nombre de genre:");

                if (genresServicio.Existe(genre))
                {
                    Console.WriteLine("Registro duplicado!!!");
                }
                else
                {
                    genresServicio.Guardar(genre);
                    Console.WriteLine("Registro editado!!!");
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); ;
        }
    }
    /// <summary>
    /// Muestra lista de Sports completa
    /// </summary>
    private static void ListaDeSports()//13
    {

        Console.Clear();
        if (sportsServicio is null)
        {
            Console.WriteLine("Servicio de Sport no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Listado de Sport");

        List<Sport> listaSport = sportsServicio?.GetLista();

        if (listaSport is null)
        {
            Console.WriteLine("No hay lista de Sport disponible.");
            return;
        }

        ConsoleExtensions.MostrarTabla(listaSport, "SportId", "SportName");
    }
    /// <summary>
    /// Agregar un nuevo Sport
    /// </summary>
    private static void InsertarUnSport()//14
    {

        Console.Clear();
        if (sportsServicio is null)
        {
            Console.WriteLine("Servicio de Sport no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Nuevo Sport");
        var sportNombre = ConsoleExtensions.ReadString("Ingrese un nuevo sport:");
        var sport = new Sport { SportName = sportNombre };

        if (sportsServicio is null)
        {
            Console.WriteLine("Servicio no disponible, que hice mal Marta!? Que hice mal!!???'");
        }
        else
        {
            if (sportsServicio.Existe(sport))
            {
                Console.WriteLine("Sport existente!!!");
            }
            else
            {
                sportsServicio.Guardar(sport);
                Console.WriteLine("Sport agregado!!!");
            }
        }
        Thread.Sleep(2000);

    }
    /// <summary>
    /// Borrar un Sport por Id seleccionado de la lista
    /// </summary>
    private static void BorrarUnSport()//15
    {
        Console.Clear();
        if (sportsServicio is null)
        {
            Console.WriteLine("Servicio de Sport no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Ingreso de sport a borrar");

        ListaDeSports();

        var sportId = ConsoleExtensions.ReadInt("Ingrese el Id del sport: ");
        try
        {
            var sport = sportsServicio?.GetSportPorId(sportId);

            if (sport is null)
            {
                Console.WriteLine("Registro inexistente!!!");
            }
            else
            {

                if (sportsServicio.EstaRelacionado(sport))
                {
                    Console.WriteLine("Genre relacionado!!! Baja denegada");
                }
                else
                {
                    sportsServicio.Borrar(sport);
                    Console.WriteLine("Registro borrado!!!");
                }

            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
        }

    }
    /// <summary>
    /// Edita un Sport por Id seleccionado de una lista
    /// </summary>
    private static void EditarUnSport()//16
    {

        Console.Clear();
        if (sportsServicio is null)
        {
            Console.WriteLine("Servicio de Sport no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Ingreso de sport a editar");

        ListaDeSports();


        var sportId = ConsoleExtensions.ReadInt("Ingrese Id del sport: ");

        try
        {
            var sport = sportsServicio?.GetSportPorId(sportId);

            if (sport is null)
            {
                Console.WriteLine("Registro inexistente!!!");
            }
            else
            {
                Console.WriteLine($"Sport: {sport.SportName}");

                var nuevoNombre = ConsoleExtensions.ReadString("Ingrese el nuevo nombre de sport:");

                sport.SportName = nuevoNombre;

                if (sportsServicio.Existe(sport))
                {
                    Console.WriteLine("Registro duplicado!!!");
                }
                else
                {
                    sportsServicio.Guardar(sport);
                    Console.WriteLine("Registro editado!!!");
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); ;
        }
        Thread.Sleep(5000);

    }
    ///   /// <summary>
    /// Muestra lista los ShoesDto paginados.
    /// /// </summary>
    private static void ListaDeShoesDtoPaginado()//17 checked
    {
        Console.Clear();

        if (shoesServicio is null)
        {
            Console.WriteLine("Servicio Shoe no responde");
            return;
        }
        registro = shoesServicio.GetCantidad();
        paginas = CalcularCantidadPaginas(registro, registrosPorPagina);

        for (int page = 0; page < paginas; page++)
        {
            Console.Clear();
            Console.WriteLine("Listado de Shoes");
            Console.WriteLine($"Página: {page + 1}");
            List<ShoeDto>? listaPaginada = shoesServicio?
                .GetListaPaginadaOrdenadaFiltrada(registrosPorPagina, page + 1, null, null, null);
            ConsoleExtensions.MostrarTabla(listaPaginada, "ShoeId", "Brand", "Sport", "Genre", "Colour", "Model", "Description", "Price");
            ConsoleExtensions.EsperaEnter();
        }
    }
    /// <summary>
    /// Muestra los Shoes que tiene precios entre un rango seleccionados y ordenados por Marca.
    /// /// </summary>
    private static void ListaDeShoesPorMarcaEntreRangoPrecios()//18 checked
    {
        Console.Clear();
        if (shoesServicio is null)
        {
            Console.WriteLine("Servicio de Shoes no disponible.");
            return;
        }
        //
        // CUIDADO: NO USAR LA TABLA DE "ConsoleExtensions"
        //
        decimal rangoMin = ConsoleExtensions.ReadDecimal("Ingresar menor precio: ");
        decimal rangoMax = ConsoleExtensions.ReadDecimal("Ingresar mayor precio: ");
        var agrupaciones = shoesServicio.GetShoesPorMarcaEntreRangoPrecios(rangoMin, rangoMax);
        if (agrupaciones is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible.");
            return;
        }
        foreach (var grupo in agrupaciones)
        {
            Console.Clear();
            Console.WriteLine($"Brand: {grupo.Key} {brandsServicio?.GetBrandPorId(grupo.Key).BrandName}");
            foreach (var shoe in grupo)
            {
                Console.WriteLine($"  - Shoe Id: {shoe.ShoeId} Modelo: {shoe.Model}, Brand: {shoe.Brand.BrandName}");
            }

            ConsoleExtensions.EsperaEnter();

        }
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
    }
    /// <summary>
    /// Muestra los Shoes asociados a cada Genre que hay en Shoe.
    /// /// </summary>
    private static void ListaDeShoesPorGenre()//19 checked
    {
        Console.Clear();

        if (shoesServicio is null)
        {
            Console.WriteLine("Servicio de Shoes no disponible.");
            return;
        }

        //
        // CUIDADO: NO USAR LA TABLA DE "ConsoleExtensions"
        //
        var agrupaciones = shoesServicio.GetShoesAgrupadosPorGenre();
        if (agrupaciones is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible.");
            return;
        }
        foreach (var grupo in agrupaciones)
        {
            Console.Clear();
            Console.WriteLine($"Genre: {grupo.Key} {genresServicio?.GetGenrePorId(grupo.Key).GenreName}");
            foreach (var shoe in grupo)
            {
                Console.WriteLine($"  - Shoe Id: {shoe.ShoeId} Modelo: {shoe.Model}, Genre: {shoe.Genre.GenreName}");
            }

            ConsoleExtensions.EsperaEnter();

        }
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
    }
    /// <summary>
    /// Muestra los Shoes asociados a cada Sport que hay en Shoe.
    /// </summary>
    private static void ListaDeShoesPorSport()//20 checked
    {
        Console.Clear();

        if (shoesServicio is null)
        {
            Console.WriteLine("Servicio de Shoes no disponible.");
            return;
        }
        Console.WriteLine("Listado de Shoes");
        var agrupaciones = shoesServicio.GetShoesAgrupadosPorSport();
        if (agrupaciones is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible.");
            return;
        }
        foreach (var grupo in agrupaciones)
        {
            Console.Clear();
            Console.WriteLine($"Sport: {grupo.Key} {sportsServicio?.GetSportPorId(grupo.Key).SportName}");
            foreach (var shoe in grupo)
            {
                Console.WriteLine($"  - Shoe Id: {shoe.ShoeId} Modelo: {shoe.Model}, Sport: {shoe.Sport.SportName}");
            }

            ConsoleExtensions.EsperaEnter();

        }
        Console.WriteLine("Fin del listado");
        ConsoleExtensions.EsperaEnter();
    }
    /// <summary>
    /// Se ingresa el Id de un Brand y un Color para filtrar la lista de Shoes con esos Id.
    /// </summary>
    private static void ListaDeShoesPorColourYBrand()//21 checked
    {
        Console.Clear();
        if (shoesServicio is null)
        {
            Console.WriteLine("Servicio de Shoes no disponible.");
            return;
        }
        ListaDeBrands();

        int brandId = ConsoleExtensions.ReadInt("Ingrese el ID del Brand: ");

        ListaDeColours();


        int colourId = ConsoleExtensions.ReadInt("Ingrese el ID del Colour: ");

        // Obtener los Shoes filtrados
        var shoesFiltrados = shoesServicio.GetShoesFiltradosPorBrandYColour(brandId, colourId);
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
    /// <summary>
    /// Agregar un nuevo Shoe
    /// </summary>
    private static void InsertarUnShoe()//22 checked
    {
        Console.Clear();
        if (shoesServicio == null)
        {
            Console.WriteLine("Servicio no disponible, que hice mal Marta!? Que hice mal!!???'");
            return;
        }
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

        if (shoesServicio.Existe(shoe))
        {
            Console.WriteLine("Shoe existente!!!");
        }
        else
        {
            shoesServicio.Guardar(shoe);
            Console.WriteLine("Shoe agregado!!!");
        }
    }
    /// <summary>
    /// Borra un Shoe seleccionado por Id
    /// </summary>
    private static void BorrarUnShoe()//23
    {
        Console.Clear();

        if (shoesServicio is null)
        {
            Console.WriteLine("Servicio caido");
            return;
        }
        var ListaShoesDto = shoesServicio.GetListaDto();
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
            var shoe = shoesServicio?.GetShoePorId(shoeId);
            if (shoe is null)
            {
                Console.WriteLine("Shoe inexistente!!!");
            }
            else
            {
                shoesServicio.Borrar(shoe.ShoeId);
                Console.WriteLine("Registro borrado!!!");
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex.Message); ;
        }
    }
    /// <summary>
    /// Edita el Shoe seleccionado por Id
    /// </summary>
    private static void EditarUnShoe()//24 
    {
        Console.Clear();

        ListaDeShoesDtoPaginado();

        int shoeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Shoe: ");
        Shoe shoe = shoesServicio.GetShoePorId(shoeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        if (shoe is null)
        {
            Console.WriteLine("Shoe no encontrada.");
            return;
        }

        Console.Clear();

        //Mostrar los atributos a editar del Shoe seleccionado
        Console.WriteLine("Shoe a editar:");
        Console.WriteLine($"ShoeId: {shoe.ShoeId}");
        Console.WriteLine($"Brand: {shoe.Brand.BrandName}");
        Console.WriteLine($"Genre: {shoe.Genre.GenreName}");
        Console.WriteLine($"Colour: {shoe.Colour.ColourName}");
        Console.WriteLine($"Sport: {shoe.Sport.SportName}");
        Console.WriteLine($"Model: {shoe.Model}");
        Console.WriteLine($"Precio: {shoe.Price}");
        Console.WriteLine($"Descripción: {shoe.Description}");

        // Editar los detalles del shoe
        Console.WriteLine("Editar:");
        shoe.Brand.BrandName = ConsoleExtensions.ReadString($"Ingrese nombre Brand: ");
        shoe.Genre.GenreName = ConsoleExtensions.ReadString("Ingrese nombre Genre: ");
        shoe.Colour.ColourName = ConsoleExtensions.ReadString("Ingrese nombre Colour: ");
        shoe.Sport.SportName = ConsoleExtensions.ReadString("Ingrese nombre Sport: ");
        shoe.Model = ConsoleExtensions.ReadString("Ingrese nombre Model: ");
        shoe.Price = ConsoleExtensions.ReadDecimal("Ingrese Precio: ");
        shoe.Description = ConsoleExtensions.ReadString("Ingrese Descripcion: ");

        if (!shoesServicio.Existe(shoe))
        {
            shoesServicio.Editar(shoe);//probar
            Console.WriteLine("Shoe editado exitosamente!");
        }
        else
        {
            Console.WriteLine("Shoe ya existe");
            return;
        }
    }
    /// <summary>
    /// Agregar en la tabla SizeShoes una nueva relacion entre un Shoe y un Size.
    /// </summary>
    private static void AsignarUnSizeAUnShoe()//25 checked
    {
        Console.Clear();
        Console.WriteLine("Listado de Shoes:");
        if (shoesServicio is null)
        {
            Console.WriteLine("Servicio de Shoe no disponible.");
            return;
        }
        if (sizesServicio is null)
        {
            Console.WriteLine("Servicio de Size no disponible.");
            return;
        }
        //Shoes

        List<ShoeDto> ListaShoesDto = shoesServicio.GetListaDto();

        if (ListaShoesDto is null)
        {
            Console.WriteLine("No hay lista de Shoes disponible.");
            return;
        }
        ConsoleExtensions.MostrarTabla(ListaShoesDto, "ShoeId", "Brand", "Sport", "Genre", "Colour", "Model", "Description", "Price");

        int shoeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Shoe: ");
        Shoe shoe = shoesServicio.GetShoePorId(shoeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        //Size
        var ListaSizes = sizesServicio.GetLista();
        if (ListaSizes is null)
        {
            Console.WriteLine("No hay lista de Sizes disponible.");
            return;
        }

        ConsoleExtensions.MostrarTabla(ListaSizes, "SizeId", "SizeNumber");

        int sizeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Size para agregar al Shoe: ");
        Size size = sizesServicio.GetSizePorId(sizeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        if (shoesServicio.ExisteRelacion(shoe, size))
        {
            Console.WriteLine("Relación existente");
            return;
        }
        else
        {
            shoesServicio.AsignarSizeAShoe(shoe, size);
            Console.WriteLine("Relación agregada");
        }
        ConsoleExtensions.EsperaEnter();
    }
    /// <summary>
    /// Permite cambiar el stock de shoes por size, stock=0 por default cuando se crea un Shoe.
    /// </summary>
    private static void AgregarStockAUnSizeShoe()//26 checked
    {
        Console.Clear();
        if (shoesServicio is null)
        {
            Console.WriteLine("Servicio de Shoe no disponible.");
            return;
        }
        if (sizeShoesServicio is null)
        {
            Console.WriteLine("Servicio de SizeShoe no disponible.");
            return;
        }
        if (sizesServicio is null)
        {
            Console.WriteLine("Servicio de SizeShoe no disponible.");
            return;
        }
        //Shoe
        ListaDeShoesDtoPaginado();

        int shoeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Shoe: ");
        Shoe shoe = shoesServicio.GetShoePorId(shoeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        //Size

        ListaDeSize();

        int sizeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Size: ");
        var size = sizesServicio.GetSizePorId(sizeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        if (!shoesServicio.ExisteRelacion(shoe, size))
        {
            Console.WriteLine("Relación no existente, desea agregar?");
            var agregarrealacion = ConsoleExtensions.ReadString("S para si, N para no: ").ToUpper();
            if (agregarrealacion != "S") { return; }

            shoesServicio.AsignarSizeAShoe(shoe, size);
            Console.WriteLine("Relación agregada");
        }
        else
        {
            SizeShoe sizeShoe = sizeShoesServicio.GetSizeShoePorId(shoe.ShoeId, size.SizeId);
            if (sizeShoe is null)
            {
                Console.WriteLine("Error, no hay relacion.");
                return;
            }
            Console.WriteLine($"stock:{sizeShoe.Stok}");
            int stock = ConsoleExtensions.ReadInt("Agregar/cambiar stock: ");
            sizeShoe.Stok = stock;
            sizeShoesServicio.Guardar(sizeShoe);
            Console.WriteLine("Stock agregado exitosamente!!!");
        }
    }
    /// <summary>
    /// Muestra los Shoes que hay segun un Size
    /// </summary>
    private static void ListarShoesSegunSize()//27 - checked
    {
        Console.Clear();
        if (sizesServicio is null)
        {
            Console.WriteLine("Servicio de Size no disponible.");
            return;
        }
        if (sizeShoesServicio is null)
        {
            Console.WriteLine("Servicio de SizeShoe no disponible.");
            return;
        }

        ListaDeSize();

        int sizeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Size a filtrar: ");
        //
        // no poner el otro metodo de listaShoe
        //
        List<ShoeDto> shoeList = sizeShoesServicio.GetListaShoeDtoPorSize(sizeIdSeleccionado);
        if (shoeList is null)
        {
            Console.WriteLine("No hay lista de Sizes disponible.");
            return;
        }
        ConsoleExtensions.MostrarTabla(shoeList, "ShoeId", "Brand", "Sport", "Genre", "Colour", "Model", "Description", "Price");
    }
    /// <summary>
    /// Muestra una tabla con los Sizes de un Shoe seleccionado y su stock.
    /// </summary>
    private static void ListarSizeShoes()//28 checked
    {
        Console.Clear();
        if (shoesServicio is null)
        {
            Console.WriteLine("Servicio de Shoe no disponible.");
            return;
        }
        if (sizeShoesServicio is null)
        {
            Console.WriteLine("Servicio de SizeShoe no disponible.");
            return;
        }

        //Shoe
        ListaDeShoesDtoPaginado();

        int shoeIdSeleccionado = ConsoleExtensions.ReadInt("Ingrese el numero Id del Shoe: ");
        Shoe shoe = shoesServicio.GetShoePorId(shoeIdSeleccionado);
        ConsoleExtensions.EsperaEnter();

        //SizeShoe
        ListaDeSizeShoe(shoeIdSeleccionado);


    }
    /// <summary>
    /// Obtiene la lista de la tabla SizeShoes según el Id se Shoe elegido
    /// </summary>
    /// <param name="shoeIdSeleccionado"></param> el Shoe elegido
    private static void ListaDeSizeShoe(int shoeIdSeleccionado)//interno
    {
        Console.Clear();
        if (sizeShoesServicio is null)
        {
            Console.WriteLine("Servicio de Brands no disponible. Por favor, verifica la configuración.");
            return;
        }
        Console.WriteLine("Listado de SizeShoes");

        var listaSizeShoe = sizeShoesServicio.GetSizeShoeDtoPorId(shoeIdSeleccionado);

        if (listaSizeShoe is null)
        {
            Console.WriteLine("No hay lista de SizeShoe disponible.");
            return;
        }

        ConsoleExtensions.MostrarTabla(listaSizeShoe, "SizeShoeId", "Size", "Stok");
    }
    /// <summary>
    /// Lista todos los Sizes que tengo en la base de datos
    /// </summary>
    private static void ListaDeSize()//interno
    {
        Console.Clear();
        if (sizesServicio is null)
        {
            Console.WriteLine("Servicio de Genre no disponible. Por favor, verifica la configuración.");
            return;
        }

        Console.WriteLine("Listado de Sizes");

        List<Size> listaSizes = sizesServicio?.GetLista();

        if (listaSizes is null)
        {
            Console.WriteLine("No hay lista de Genres disponible.");
            return;
        }

        ConsoleExtensions.MostrarTabla(listaSizes, "SizeId", "SizeNumber");
    }
    /// <summary>
    /// Calcula la cantidad de paginas segun la cantidad de objects que me traigo y cuantos muestro por pagina.
    /// </summary>
    /// <param name="cantidadRegistros"></param>: cantidad de objects que trae de base de datos
    /// <param name="cantidadPorPagina"></param>: cat¿ntidad de registro se muestran por pagina
    /// <returns></returns>
    ///   /// <summary>
    /// Ingresar un nuevo Shoe
    /// </summary>
    private static int CalcularCantidadPaginas(int cantidadRegistros, int cantidadPorPagina)//interno
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
    /// <summary>
    /// Selecciona un Colour para agregar al nuevo Shoe, incluye crear un nuevo Colour si necesitase.
    /// </summary>
    /// <returns>Colour</returns>
    private static Colour SeleccionarUnColour()//para nuevo Shoe
    {
        ListaDeColours();
        Colour? colour;
        var listaColour = coloursServicio?
                .GetLista()
                .Select(b => b.ColourId.ToString()).ToList();
        var colourId = ConsoleExtensions
                 .GetValidOptions("Seleccione un Colour (N para nuevo):", listaColour);
        if (colourId == "N")
        {
            colourId = "0";
            Console.WriteLine("Ingreso de nuevo Colour");
            var nombreBrand = ConsoleExtensions.ReadString("Ingrese nombre del nuevo Colour: ");

            colour = new Colour()
            {
                ColourId = 0,
                ColourName = nombreBrand
            };
        }
        else
        {
            colour = coloursServicio?
                .GetColourPorId(Convert.ToInt32(colourId));

        }
        return colour;
    }
    /// <summary>
    /// Selecciona un Sport para agregar al nuevo Shoe, incluye crear un nuevo Sport si necesitase.
    /// </summary>
    /// <returns>Sport</returns>
    private static Sport SeleccionarUnSport()//para nuevo shoe
    {
        Sport? sport;

        ListaDeSports();

        var listaSport = sportsServicio?.GetLista().Select(b => b.SportId.ToString()).ToList();

        var sportId = ConsoleExtensions.GetValidOptions("Seleccione un Sport (N para nuevo):", listaSport);
        if (sportId == "N")
        {
            sportId = "0";
            Console.WriteLine("Ingreso de nuevo Sport");

            var nombreBrand = ConsoleExtensions.ReadString("Ingrese nombre del nuevo Sport: ");

            sport = new Sport()
            {
                SportId = 0,
                SportName = nombreBrand
            };

        }
        else
        {
            sport = sportsServicio?
                .GetSportPorId(Convert.ToInt32(sportId));

        }
        return sport;
    }
    /// <summary>
    /// Selecciona un Genre para agregar al nuevo Shoe, incluye crear un nuevo GEnre si necesitase.
    /// </summary>
    /// <returns>Genre</returns>
    private static Genre SeleccionarUnGenre()//para nuevo shoe
    {
        ListaDeGenres();
        Genre? genre;
        var listaGenre = genresServicio?.GetLista()
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
            genre = genresServicio?
                .GetGenrePorId(Convert.ToInt32(genreId));
        }
        return genre;
    }
    /// <summary>
    /// Selecciona un Brand para agregar al nuevo Shoe, incluye crear un nuevo BRand si necesitase.
    /// </summary>
    /// <returns>Brand</returns>
    private static Brand SeleccionarUnBrand()//para nuevo shoe
    {
        Console.Clear();
        if (brandsServicio is null)
        {
            Console.WriteLine("Servicio de Brand no disponible. Por favor, verifica la configuración.");
            return null;
        }

        ListaDeBrands();

        Brand? brand;

        var listaBrand = brandsServicio?
                .GetLista()
                .Select(b => b.BrandId.ToString()).ToList();
        var brandId = ConsoleExtensions
                 .GetValidOptions("Seleccione un Brand (N para nuevo):", listaBrand);

        if (brandId == "N")
        {
            brandId = "0";
            Console.WriteLine("Ingreso de nuevo Brand");

            var nombreBrand = ConsoleExtensions.ReadString("Ingrese nombre del nuevo Brand: ");

            brand = new Brand()
            {
                BrandId = 0,
                BrandName = nombreBrand
            };

        }
        else
        {
            brand = brandsServicio?
                .GetBrandPorId(Convert.ToInt32(brandId));

        }
        return brand;
    }
}
