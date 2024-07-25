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
            PaginaActualcomboBox.SelectedIndex = paginaActual - 1;
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
                shoe = frm.GetShoe();
                if (shoe is null) return;
                if (!_servicio.Existe(shoe))
                {
                    _servicio.Guardar(shoe);

                    //// Actualizar la lista después de agregar la planta
                    //ActualizarListaDespuesAgregar(p.planta);

                    MessageBox.Show("Shoe agregado!!!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MostrarPaginado();
                   // RecargarGrilla(); //NO!!
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
            if (ShoesdataGridView.SelectedRows.Count == 0) return;

            var filaSeleccionada = ShoesdataGridView.SelectedRows[0];
            if (filaSeleccionada.Tag is null) return;

            ShoeDto shoeDto = (ShoeDto)filaSeleccionada.Tag;
            //tengo un problema con un FrmShoes SOlO COPIA,
            //pasa el punto de interupcion por un metodo viejo que estaba en forma de comentario
            //guardo cierro y veo que pasa
            Shoe? shoeOriginal = _servicio.GetShoePorId(shoeDto.ShoeId);
            if (shoeOriginal is null) return;

            // Crear una copia del objeto original para restaurar en caso de error
            Shoe shoeCopia = (Shoe)shoeOriginal.Clone();

            FrmShoeAE frm = new FrmShoeAE(_serviceProvider) { Text = "Editar Shoe" };
            frm.SetShoe(shoeOriginal); // Asegúrate de pasar el objeto original al formulario

            DialogResult dr = frm.ShowDialog(this);// ACA ME CAMBIA EL shoeOrignal!!!!!!!!

            if (dr == DialogResult.Cancel)
            {
                GridHelper.SetearFila(filaSeleccionada, shoeDto);
                return;
            }

            try
            {
                //DONDE ME TRAIGO LA INFO DE AE Y GUARDO EN EDITADO, CAMBIA TAMBIEN EL ORIGNAL PORQUE!!??
                // Obtener el shoe editado desde el formulario
                Shoe shoeEditado = frm.GetShoe();
                if (shoeEditado == null) return;

                if (!_servicio.Existe(shoeEditado))
                {
                    _servicio.Guardar(shoeEditado);
                    MessageBox.Show("¡Shoe editado exitosamente!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridHelper.SetearFila(filaSeleccionada, shoeEditado);
                }
                else
                {
                    MessageBox.Show("¡Shoe existente!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridHelper.SetearFila(filaSeleccionada, shoeDto);
                
                }
            }
            catch (Exception ex)
            {
                // Restaurar el original en caso de error
                shoeOriginal = shoeCopia;//PORQUE!!!!!!??

                GridHelper.SetearFila(filaSeleccionada, shoeDto);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MostrarPaginado();
        }



        private void BorrartoolStripButton_Click(object sender, EventArgs e)
        {
            if (ShoesdataGridView.SelectedRows.Count == 0) return;
            var r = ShoesdataGridView.SelectedRows[0];
            ShoeDto? shoe = r.Tag as ShoeDto;//LO MISMO?
            try
            {
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }

                _servicio.Borrar(shoe.ShoeId);
                GridHelper.QuitarFila(ShoesdataGridView, r);
                MessageBox.Show("Shoe borrado exitosamente", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //limpiar
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

        private void PaginaActualcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaginaActualcomboBox.SelectedIndex >= 0)
            {
                paginaActual = PaginaActualcomboBox.SelectedIndex + 1;
                MostrarPaginado();
            }

        }
    }
}
