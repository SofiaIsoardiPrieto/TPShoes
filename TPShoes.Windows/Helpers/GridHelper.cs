using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;

namespace TPShoes.Windows.Helpers
{

    public static class GridHelper
    {
        public static void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }

        public static DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;
        }

        public static void QuitarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Remove(r);
        }
        public static void SetearFila(DataGridViewRow r, object item)
        {
            switch (item)
            {
                case ShoeDto shoeDto:
                    r.Cells[0].Value = shoeDto.Brand;
                    r.Cells[1].Value = shoeDto.Colour;
                    r.Cells[2].Value = shoeDto.Genre;
                    r.Cells[3].Value = shoeDto.Sport;
                    r.Cells[4].Value = shoeDto.Price;
                    r.Cells[5].Value = shoeDto.Description;
                    r.Cells[6].Value = shoeDto.Model;
                    break;
                //case TipoDeEnvase tipoEnvase:
                //    r.Cells[0].Value = tipoEnvase.Descripcion;
                //    break;
                //case PlantaListDto planta:
                //    r.Cells[0].Value = planta.Nombre;
                //    r.Cells[1].Value = planta.Tipo;
                //    r.Cells[2].Value = planta.Envase;
                //    r.Cells[3].Value = planta.Precio.ToString("C");
                //    r.Cells[4].Value = planta.CantidadProveedores;
                //    break;
                //case Planta planta:
                //    r.Cells[0].Value = planta.Descripcion;
                //    r.Cells[1].Value = planta.TipoDePlanta?.Descripcion;
                //    r.Cells[2].Value = planta.TipoDeEnvase?.Descripcion;
                //    r.Cells[3].Value = planta.PrecioVenta.ToString("C");
                //    break;
                //case Proveedor proveedor:
                //    r.Cells[0].Value = proveedor.Nombre;
                //    break;
                //default:
                //    break;

            }
            r.Tag = item;
        }

        public static void AgregarFila(DataGridView dgv, DataGridViewRow r)
        {
            dgv.Rows.Add(r);
        }

        public static void MostrarDatosEnGrilla<T>(List<T> lista, DataGridView dgvDatos) where T : class
        {
            LimpiarGrilla(dgvDatos);
            foreach (T t in lista)
            {
                var r = ConstruirFila(dgvDatos);
                SetearFila(r, t);
                AgregarFila(dgvDatos, r);
            }
        }
    }

}
