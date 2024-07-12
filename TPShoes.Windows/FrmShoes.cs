using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Entidades.Enum;
using TPShoes.Servicios.Interfaces;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmShoes : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IShoesServicio _servicio;
        private List<ShoeDto>? lista;//Dto????
        private Orden orden = Orden.SinOrden;
        private Shoe? shoe = null;
        private Brand? brand = null;
        private Sport? sport = null;
        private Genre? genre = null;
        private Colour? colour = null;

        string textoFiltro = null;
        private Color colorOriginal;

        private bool filtroOn = false;

        int paginaActual = 1;//private int pageNum = 0;
        int registro;//private int recordCount;
        int paginas;//private int pageCount;
        int registrosPorPagina = 5; //private int pageSize = 15; 

        public FrmShoes(IShoesServicio servicio, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _servicio = servicio;
            _serviceProvider = serviceProvider;
        }
        private void frmShoes_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
        private void RecargarGrilla()
        {
            try
            {
                registro = _servicio.GetCantidad();
                paginas = FormHelper.CalcularPaginas(registro, registrosPorPagina);
                PaginasTotalestextBox.Text = registro.ToString();
                CombosHelper.CargarCombosPaginas(paginas, ref PaginaActualcomboBox);

                lista = _servicio.GetListaPaginadaOrdenadaFiltrada(registrosPorPagina, paginaActual, null, null, null);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MostrarPaginado()
        {
            lista = _servicio.GetListaPaginadaOrdenadaFiltrada(registrosPorPagina, paginaActual);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {

            GridHelper.LimpiarGrilla(ShoesdataGridView);
            foreach (var shoe in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(ShoesdataGridView);
                GridHelper.SetearFila(r, shoe);
                GridHelper.AgregarFila(ShoesdataGridView, r);
            }


            //PaginascomboBox.SelectedIndex = paginaActual;


            PaginasTotalestextBox.Text = paginas.ToString();

            if (paginaActual == paginas)
            {
                Siguientebutton.Enabled = false;
                Ultimobutton.Enabled = false;

            }
            if (paginaActual < paginas)
            {
                Siguientebutton.Enabled = true;
                Ultimobutton.Enabled = true;

            }
            if (paginaActual == 1)
            {
                Anteriorbutton.Enabled = false;
                Primerobutton.Enabled = false;
            }
        }

        private void NuevotoolStripButton_Click(object sender, EventArgs e)
        {
            FrmShoeAE frm = new FrmShoeAE(_serviceProvider);
            DialogResult df = frm.ShowDialog(this);
            if (df == DialogResult.Cancel) { return; }
            try
            {
                shoe=frm.GetShoe();
                if (shoe is null) return;
                if (!_servicio.Existe(shoe))
                {
                    _servicio.Guardar(shoe);

                    //// Actualizar la lista después de agregar la planta
                    //ActualizarListaDespuesAgregar(p.planta);

                    MessageBox.Show("Shoe agregado!!!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RecargarGrilla();
                }
                else
                {
                    MessageBox.Show("Shoe existente!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void EditartoolStripButton_Click(object sender, EventArgs e)
        {
            if (ShoesdataGridView.SelectedRows.Count == 0) { return; }
            var r = ShoesdataGridView.SelectedRows[0];
            if (r.Tag is null) return;
            ShoeDto shoeDto = (ShoeDto)r.Tag;
            Shoe? shoeAEditar = _servicio.GetShoePorId(shoeDto.ShoeId);
            if (shoeAEditar == null) return;
            //List<Proveedor>? proveedores = _servicio
            //    .GetProveedoresPorPlanta(shoeAEditar.PlantaId);
            //(Planta? planta, List<Proveedor>? proveedores) p = (shoeAEditar, proveedores);

            FrmShoeAE frm = new FrmShoeAE(_serviceProvider) { Text = "Editar Shoe" };
            DialogResult dr = frm.ShowDialog(this);

            //frm.SetPlantaProveedores(p);

            if (dr == DialogResult.Cancel)
            {
                GridHelper.SetearFila(r, shoeAEditar);
                return;
            }

            try
            {
                //  p = frm.GetPlantaProveedores();
                Shoe shoeEditado = frm.GetShoe();
                if (shoeEditado is null) return;
                if (!_servicio.Existe(shoeEditado))
                {
                    _servicio.Guardar(shoe);

                    if (shoe != null)
                    {
                        GridHelper.SetearFila(r, shoeAEditar);
                    }
                    else
                    {
                        GridHelper.SetearFila(r, shoeEditado);
                    }
                    RecargarGrilla();
                    MostrarDatosEnGrilla();
                }
                else
                {
                    MessageBox.Show("Shoe existente!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void BorrartoolStripButton_Click(object sender, EventArgs e)
        {
            if (ShoesdataGridView.SelectedRows.Count == 0) return;
            var r = ShoesdataGridView.SelectedRows[0];
            Shoe shoe = (Shoe)r.Tag;
            try
            {
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }
                _servicio.Borrar(shoe.ShoeId);
                GridHelper.QuitarFila(ShoesdataGridView, r);
                registro = _servicio.GetCantidad();
                //esta bien?
                PaginaActualcomboBox.SelectedIndex = paginaActual;
                PaginasTotalestextBox.Text = paginas.ToString();
                //
                MessageBox.Show("Shoe borrado exitosamente", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RecargarGrilla();
                MostrarDatosEnGrilla();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrotoolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void ActualizartoolStripButton_Click(object sender, EventArgs e)
        {
            filtroOn = false;
            FiltrotoolStripButton.Enabled = true;
            RecargarGrilla();
            FiltrotoolStripButton.BackColor = Color.FromArgb(180, 210, 170);
        }

        private void SizestoolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void AddSizestoolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteSizestoolStripButton_Click(object sender, EventArgs e)
        {

        }
        private void SalirtoolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Primerobutton_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            Anteriorbutton.Enabled = false;
            Primerobutton.Enabled = false;
            Siguientebutton.Enabled = true;
            Ultimobutton.Enabled = true;
            MostrarPaginado();
        }

        private void Anteriorbutton_Click(object sender, EventArgs e)
        {
            Siguientebutton.Enabled = true;
            Ultimobutton.Enabled = true;
            paginaActual--;
            if (paginaActual == 1)
            {
                Anteriorbutton.Enabled = false;
                Primerobutton.Enabled = false;
            }
            MostrarPaginado();
        }

        private void Siguientebutton_Click(object sender, EventArgs e)
        {
            Anteriorbutton.Enabled = true;
            Primerobutton.Enabled = true;
            paginaActual++;
            if (paginaActual == paginas)
            {
                Siguientebutton.Enabled = false;
                Ultimobutton.Enabled = false;

            }
            MostrarPaginado();

        }

        private void Ultimobutton_Click(object sender, EventArgs e)
        {
            paginaActual = paginas;
            Siguientebutton.Enabled = false;
            Ultimobutton.Enabled = false;
            Anteriorbutton.Enabled = true;
            Primerobutton.Enabled = true;
            MostrarPaginado();
        }
        private void MostrarOrdenado(Orden orden)
        {
            lista = _servicio.GetListaPaginadaOrdenadaFiltrada(paginaActual, paginas, orden);
            MostrarDatosEnGrilla();
        }

        private void aZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarOrdenado(Orden.AZ);
        }

        private void zAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarOrdenado(Orden.ZA);
        }

        private void menorPercioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarOrdenado(Orden.MenorPrecio);
        }

        private void mayorPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarOrdenado(Orden.MayorPrecio);
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorOriginal = FiltrotoolStripButton.BackColor;
            if (!filtroOn)
            {
                try
                {
                    FrmBrandFiltro frm = new FrmBrandFiltro(_serviceProvider) { Text = "Buscar Brand" };
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.Cancel) { return; }

                    brand = frm.GetBrand();
                    registro = _servicio.GetCantidad();
                    paginas = FormHelper.CalcularPaginas(registro, registrosPorPagina);
                    paginaActual = 1;
                    lista = _servicio.GetListaPaginadaOrdenadaFiltrada(registrosPorPagina, paginaActual, null, brand, null);
                    if (lista.Count == 0)
                    {
                        MessageBox.Show("No hay Pacientes con esa letra/texto", "Informacion",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    FiltrotoolStripButton.BackColor = Color.Gray;
                    filtroOn = true;
                    MostrarDatosEnGrilla();
                }

                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Limpie el filtro activo (Actualizar)", "Adevertencia",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorOriginal = FiltrotoolStripButton.BackColor;
            if (!filtroOn)
            {
                try
                {
                    FrmColourFiltro frm = new FrmColourFiltro(_serviceProvider) { Text = "Buscar Colour" };
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.Cancel) { return; }

                    colour = frm.GetColour();

                    registro = _servicio.GetCantidad();
                    paginas = FormHelper.CalcularPaginas(registro, registrosPorPagina);
                    paginaActual = 1;

                    lista = _servicio.GetListaPaginadaOrdenadaFiltrada(registrosPorPagina, paginaActual, null, null, colour);
                    if (lista.Count == 0)
                    {
                        MessageBox.Show("No hay Pacientes con esa letra/texto", "Informacion",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    FiltrotoolStripButton.BackColor = Color.Gray;
                    filtroOn = true;
                    MostrarDatosEnGrilla();
                }

                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("Limpie el filtro activo (Actualizar)", "Adevertencia",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
