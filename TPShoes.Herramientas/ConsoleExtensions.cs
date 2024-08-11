using ConsoleTables;
using TPShoes.Entidades;
using TPShoes.Entidades.Clases;

namespace TPShoes.Herramientas
{
    public static class ConsoleExtensions
    {
        public static string ReadString(string message)
        {
            string? stringVar = string.Empty;
            while (true)
            {

                Console.Write(message);
                stringVar = Console.ReadLine();
                if (stringVar == null)
                {
                    Console.WriteLine("Debe ingresar algo!!!");
                }
                else
                {
                    break;
                }
            }
            return stringVar;
        }

        public static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número entero válido.");
                }
            }
        }

        public static decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número decimal válido.");
                }
            }
        }
        public static decimal ReadDecimal(string message, decimal min, decimal max)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal result))
                {
                    if (result >= min && result <= max)
                    {
                        return result;

                    }
                    else
                    {
                        Console.WriteLine($"Selección fuera de rango ({min}-{max}");
                    }

                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número decimal válido.");
                }
            }
        }

        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static void EsperaEnter()
        {
            Console.WriteLine("ENTER para continuar");
            Console.ReadLine();

        }

        public static string GetValidOptions(string message, List<string>? options)
        {
            string answer = string.Empty;
            if (options != null)
            {
                options.Insert(0, "N");
                do
                {
                    answer = ReadString(message);

                    if (!options.Any(x => x.Equals(answer)))
                    {
                        Console.WriteLine("\nIngreso no válido... Otra vez!!!");
                    }
                    else
                    {
                        /*
                         * Si la opción tipiada es alguna de la lista, salgo del ciclo
                         */
                        break;

                    }

                } while (!options.Any(x => x.Equals(answer)));// mientras no sea un caracter válido me quedo esperando

            }
            return answer; //retorno el caracter ingresado y validado.

        }

        public static int SelectFromList<T>(List<T> lista, int minValue, int maxValue) where T : class
        {
            int seleccion = 0;
            Console.Write("Seleccione de la lista");
            foreach (var item in lista)
            {
                switch (item)
                {
                    case Brand brand:
                        Console.WriteLine($"{brand.BrandId} - {brand.BrandName}");
                        break;
                    case Genre genre:
                        Console.WriteLine($"{genre.GenreId} - {genre.GenreName}");
                        break;
                    case Colour colour:
                        Console.WriteLine($"{colour.ColourId} - {colour.ColourName}");
                        break;
                    case Shoe shoe:
                        Console.WriteLine($"{shoe.Brand.BrandName} - {shoe.Colour.ColourName} " +
                            $"- {shoe.Sport.SportName} - {shoe.Genre.GenreName} " +
                            $"- {shoe.Model} - {shoe.Description} - {shoe.Price}");
                        break;
                    case Sport sport:
                        Console.WriteLine($"{sport.SportId} - {sport.SportName}");
                        break;
                    default:
                        throw new ArgumentException("Tipo no compatible.");
                }
                Console.WriteLine(); // Agregar una línea en blanco entre los elementos
            }

            seleccion = ReadInt("Selecciona una opción del listado:", minValue, maxValue);

            return seleccion; // Devolver un valor por defecto

        }
        public static int ReadInt(string message, int min, int max)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    if (result >= min && result <= max)
                    {
                        return result;

                    }
                    else
                    {
                        Console.WriteLine($"Selección fuera de rango ({min}-{max}");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número entero válido.");
                }
            }
        }

      
        public static void MostrarTabla<T>(List<T> lista, params string[] nombresColumnas)
        {
            if (lista == null || !lista.Any())
            {
                Console.WriteLine("No hay datos disponibles.");
                return;
            }

            var tabla = new ConsoleTable(nombresColumnas);

            foreach (var item in lista)
            {
                var valores = new List<object>();

                for (int i = 0; i < nombresColumnas.Length; i++)
                {
                    var property = item.GetType().GetProperty(nombresColumnas[i]);
                    if (property != null)
                    {
                        var valor = property.GetValue(item, null) ?? "N/A";
                        valores.Add(valor);
                    }
                    else
                    {
                        valores.Add("N/A");
                    }
                }

                tabla.AddRow(valores.ToArray());
            }

            tabla.Options.EnableCount = false;
            tabla.Write();
            Console.WriteLine("Fin del listado");
        }

    }
}
