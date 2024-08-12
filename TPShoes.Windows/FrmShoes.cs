using Microsoft.Extensions.DependencyInjection;
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
        private List<ShoeDto>? lista;
        private Orden orden = Orden.SinOrden;
        private Shoe? shoe = null;
        private Brand? brand = null;
        private Sport? sport = null;
        private Genre? genre = null;
        private Colour? colour = null;

        private Color colorOriginal;

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
            registro = _servicio.GetCantidad();
            paginas = FormHelper.CalcularPaginas(registro, registrosPorPagina);
            PaginasTotalestextBox.Text = registro.ToString();
            //que está pasando aca!??
            CombosHelper.CargarCombosPaginas(paginas, ref PaginaActualcomboBox);
            //lista = GetListaSinFiltrar();
            //MostrarDatosEnGrilla();
        }
        //private List<ShoeDto> GetListaSinFiltrar()
        //{
        //    //Sin flitrar ni ordenar
        //    return _servicio.GetListaPaginadaOrdenadaFiltrada
        //       (registrosPorPagina,paginaActual, null, null, null);
        //}
        private void ActualizarListaPaginada(Orden? orden = null, Brand? brand = null, Colour? colour = null)
        {
            if (brand is not null)
            {//no anda registro
                registro = _servicio.GetCantidad(s => s.Brand == brand);
                paginas = FormHelper.CalcularPaginas(registro, registrosPorPagina);
            }
            if (colour is not null)
            {
                registro = _servicio.GetCantidad(s => s.Colour == colour);
                paginas = FormHelper.CalcularPaginas(registro, registrosPorPagina);
            }
            // Actualizar la lista paginada según la página actual y tamaño de página
            lista = _servicio.GetListaPaginadaOrdenadaFiltrada(registrosPorPagina, paginaActual, orden, brand, colour);

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
            ActualizarBotonesPaginado();


        }
        private void ActualizarBotonesPaginado()
        {
            PaginasTotalestextBox.Text = paginas.ToString();

            if (paginaActual == paginas)
            {
                Primerobutton.Enabled = true;
                Anteriorbutton.Enabled = true;
                Siguientebutton.Enabled = false;
                Ultimobutton.Enabled = false;

            }
            if (paginaActual < paginas)
            {
                Primerobutton.Enabled = true;
                Anteriorbutton.Enabled = true;
                Siguientebutton.Enabled = true;
                Ultimobutton.Enabled = true;
            }
            if (paginaActual > paginas)
            {
                Primerobutton.Enabled = true;
                Anteriorbutton.Enabled = true;
                Siguientebutton.Enabled = true;
                Ultimobutton.Enabled = true;

            }
            if (paginaActual == 1 && registro != registrosPorPagina)//podria plantearlo mejor??
            {
                Primerobutton.Enabled = false;
                Anteriorbutton.Enabled = false;
                Siguientebutton.Enabled = true;
                Ultimobutton.Enabled = true;
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

                    MessageBox.Show("Shoe agregado!!!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);


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
            RecargarGrilla();// para evitar algun error
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
            Shoe? shoeOriginal = null;
            shoeOriginal = _servicio.GetShoePorId(shoeDto.ShoeId);
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

                GridHelper.SetearFila(filaSeleccionada, shoeDto);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RecargarGrilla();
        }
        private void BorrartoolStripButton_Click(object sender, EventArgs e)
        {
            if (ShoesdataGridView.SelectedRows.Count == 0) return;
            var r = ShoesdataGridView.SelectedRows[0];
            ShoeDto? shoeDto = r.Tag as ShoeDto;
            try
            {
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }

                _servicio.Borrar(shoeDto.ShoeId);
                GridHelper.QuitarFila(ShoesdataGridView, r);
                MessageBox.Show("Shoe borrado exitosamente", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);


                RecargarGrilla();//evitar errores

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizartoolStripButton_Click(object sender, EventArgs e)
        {
            LimpiarBotonesYActualizarLista();
        }
        private void LimpiarBotonesYActualizarLista()
        {
            orden = Orden.SinOrden;
            brand = null;
            colour = null;
            FiltrotoolStripButton.Enabled = true;
            ActualizarListaPaginada(orden, brand, colour);
            brandToolStripMenuItem.BackColor = colorOriginal;
            colourToolStripMenuItem.BackColor = colorOriginal;
            aZToolStripMenuItem.BackColor = colorOriginal;
            zAToolStripMenuItem.BackColor = colorOriginal;
            menorPercioToolStripMenuItem.BackColor = colorOriginal;
            mayorPrecioToolStripMenuItem.BackColor = colorOriginal;

        }
        private void SizestoolStripButton_Click(object sender, EventArgs e)
        {
            if (ShoesdataGridView.SelectedRows.Count == 0) return;

            var filaSeleccionada = ShoesdataGridView.SelectedRows[0];
            if (filaSeleccionada.Tag is null) return;

            ShoeDto shoeDto = (ShoeDto)filaSeleccionada.Tag;
            FrmSizeShoes frm = new FrmSizeShoes(_serviceProvider, shoeDto.ShoeId);
            frm.ShowDialog();
        }
        private void AddSizestoolStripButton_Click(object sender, EventArgs e)
        {
            var _servicioSize = _serviceProvider?.GetService<ISizesServicio>();
            
            if (ShoesdataGridView.SelectedRows.Count == 0) { return; }
            var r = ShoesdataGridView.SelectedRows[0];
            if (r.Tag is null) return;
            var shoeDto = (ShoeDto)r.Tag;
            Shoe? shoe = _servicio.GetShoePorId(shoeDto?.ShoeId ?? 0);
            if (shoe is null) return;
            FrmSizeCombo frm = new FrmSizeCombo(_serviceProvider, shoe.ShoeId, true) { Text = "Agregar Size" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                Entidades.Clases.Size? size = frm.GetSize();
                if (size is null) return;
                if (!_servicio.ExisteRelacion(shoe, size))
                {
                    _servicio.AsignarSizeAShoe(shoe, size);
                    if (shoeDto is not null)
                    {

                        GridHelper.SetearFila(r, shoeDto);
                    }
                    MessageBox.Show("Size asignado a la Shoe!!!",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Asignación Existente!!!",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                            "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void DeleteSizestoolStripButton_Click(object sender, EventArgs e)
        {
           
            var _servicioSizeShoe = _serviceProvider?.GetService<ISizeShoesServicio>();


            if (ShoesdataGridView.SelectedRows.Count == 0) { return; }
            var r = ShoesdataGridView.SelectedRows[0];
            if (r.Tag is null) return;
            var shoeDto = (ShoeDto)r.Tag;
            if (shoeDto is null) return;

            Shoe? shoe = _servicio.GetShoePorId(shoeDto?.ShoeId ?? 0);
            if (shoe is null) return;

            FrmSizeCombo frm = new FrmSizeCombo(_serviceProvider, shoeDto.ShoeId, false) { Text = "Borrar Size" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }

            try
            {
              
                Entidades.Clases.Size? size = frm.GetSize();
                if (size is null) return;

                if (_servicio.ExisteRelacion(shoe, size))
                {
                    SizeShoe sizeShoe = _servicioSizeShoe.GetSizeShoePorId(shoeDto.ShoeId, size.SizeId);
                    _servicioSizeShoe.Borrar(sizeShoe);
                }
                else
                {
                    MessageBox.Show("No Existe relación!!!",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                            "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Primerobutton_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            PaginaActualcomboBox.SelectedIndex = paginaActual - 1;
        }
        private void Anteriorbutton_Click(object sender, EventArgs e)
        {
            paginaActual--;
            if (paginaActual == 1)
            {
                Anteriorbutton.Enabled = false;
                Primerobutton.Enabled = false;
            }
            PaginaActualcomboBox.SelectedIndex = paginaActual - 1;
        }
        private void Siguientebutton_Click(object sender, EventArgs e)
        {
            paginaActual++;
            if (paginaActual == paginas)
            {
                Siguientebutton.Enabled = false;
                Ultimobutton.Enabled = false;

            }
            PaginaActualcomboBox.SelectedIndex = paginaActual - 1;
        }
        private void Ultimobutton_Click(object sender, EventArgs e)
        {
            paginaActual = paginas;
            PaginaActualcomboBox.SelectedIndex = paginaActual - 1;
        }
        private void PaginaActualcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaginaActualcomboBox.SelectedIndex >= 0)
            {
                paginaActual = PaginaActualcomboBox.SelectedIndex + 1;
                ActualizarListaPaginada(orden, brand, colour);
            }
        }
        private void aZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orden = Orden.AZ;
            ActualizarListaPaginada(orden, brand, colour);
            colorOriginal = OrdenartoolStripButton.BackColor;
        }
        private void zAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orden = Orden.ZA;
            ActualizarListaPaginada(orden, brand, colour);
            colorOriginal = OrdenartoolStripButton.BackColor;
        }
        private void menorPercioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            orden = Orden.MenorPrecio;
            ActualizarListaPaginada(orden, brand, colour);
            colorOriginal = OrdenartoolStripButton.BackColor;
        }
        private void mayorPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orden = Orden.MayorPrecio;
            ActualizarListaPaginada(orden, brand, colour);
            colorOriginal = OrdenartoolStripButton.BackColor;
        }
        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorOriginal = brandToolStripMenuItem.BackColor;
            try
            {
                FrmBrandFiltro frm = new FrmBrandFiltro(_serviceProvider) { Text = "Buscar Brand" };
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) { return; }
                brand = frm.GetBrand();
                paginaActual = 1;
                ActualizarListaPaginada(orden, brand, colour);
                brandToolStripMenuItem.BackColor = Color.Gray;
            }

            catch (Exception)
            {

                throw;
            }
        }
        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorOriginal = colourToolStripMenuItem.BackColor;

            try
            {
                FrmColourFiltro frm = new FrmColourFiltro(_serviceProvider) { Text = "Buscar Colour" };
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel) { return; }

                colour = frm.GetColour();
                paginaActual = 1;
                colourToolStripMenuItem.BackColor = Color.Gray;

                ActualizarListaPaginada(orden, brand, colour);
            }

            catch (Exception)
            {

                throw;
            }
        }
        private void SalirtoolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}