using TPShoes.Entidades;
using TPShoes.Entidades.Enum;
using TPShoes.Servicios.Interfaces;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmBrands : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IBrandsServicio _servicio;
        private List<Brand>? lista;
        private Orden orden = Orden.SinOrden;

        private Brand? brand = null;

        private Color colorOriginal;

        int paginaActual = 1;//private int pageNum = 0;
        int registro;//private int recordCount;
        int paginas;//private int pageCount;
        int registrosPorPagina = 5; //private int pageSize = 15; 

        public FrmBrands(IBrandsServicio servicio, IServiceProvider serviceProvider)
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
            CombosHelper.CargarCombosPaginas(paginas, ref PaginaActualcomboBox);
            lista = _servicio.GetLista();
            MostrarDatosEnGrilla();
        }

        private void ListarPaginadaOrden(Orden? orden = null)
        {
            throw new NotImplementedException();
        }
        private void MostrarDatosEnGrilla()
        {

            GridHelper.LimpiarGrilla(BranddataGridView);
            foreach (var shoe in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(BranddataGridView);
                GridHelper.SetearFila(r, shoe);
                GridHelper.AgregarFila(BranddataGridView, r);
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
            if (paginaActual == 1)
            {
                Primerobutton.Enabled = false;
                Anteriorbutton.Enabled = false;
                Siguientebutton.Enabled = true;
                Ultimobutton.Enabled = true;
            }
        }

        private void NuevotoolStripButton_Click(object sender, EventArgs e)
        {
            FrmBrandAE frm = new FrmBrandAE(_serviceProvider);
            DialogResult df = frm.ShowDialog(this);
            if (df == DialogResult.Cancel) { return; }
            try
            {
                brand = frm.GetBrand();
                if (brand is null) return;
                if (!_servicio.Existe(brand))
                {
                    _servicio.Guardar(brand);

                    MessageBox.Show("Brand agregado!!!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Brand existente!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RecargarGrilla();
        }

        private void EditartoolStripButton_Click(object sender, EventArgs e)
        {
            if (BranddataGridView.SelectedRows.Count == 0) return;

            var filaSeleccionada = BranddataGridView.SelectedRows[0];
            if (filaSeleccionada.Tag is null) return;

            Brand brandOriginal = (Brand)filaSeleccionada.Tag;

            if (brandOriginal is null) return;


            Brand brandCopia = (Brand)brandOriginal.Clone();

            FrmBrandAE frm = new FrmBrandAE(_serviceProvider) { Text = "Editar Brand" };
            frm.SetBrand(brandOriginal);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                GridHelper.SetearFila(filaSeleccionada, brandOriginal);
                return;
            }

            try
            {

                Brand brandEditado = frm.GetBrand();
                if (brandEditado == null) return;

                if (!_servicio.Existe(brandEditado))
                {
                    _servicio.Guardar(brandEditado);
                    MessageBox.Show("¡Brand editado exitosamente!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridHelper.SetearFila(filaSeleccionada, brandEditado);
                }
                else
                {
                    MessageBox.Show("¡Brand existente!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridHelper.SetearFila(filaSeleccionada, brandOriginal);

                }
            }
            catch (Exception ex)
            {

                GridHelper.SetearFila(filaSeleccionada, brandOriginal);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RecargarGrilla();
        }

        private void BorrartoolStripButton_Click(object sender, EventArgs e)
        {
            if (BranddataGridView.SelectedRows.Count == 0) return;
            var r = BranddataGridView.SelectedRows[0];
            Brand? brand = r.Tag as Brand;//LO MISMO?
            try
            {
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }

                _servicio.Borrar(brand);
                GridHelper.QuitarFila(BranddataGridView, r);
                MessageBox.Show("Brand borrado exitosamente", "Mensaje",
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

            aZToolStripMenuItem.BackColor = colorOriginal;
            zAToolStripMenuItem.BackColor = colorOriginal;

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
                ListarPaginadaOrden(orden);
            }
        }

   

        private void aZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orden = Orden.AZ;
            ListarPaginadaOrden(orden);
            colorOriginal = OrdenartoolStripButton.BackColor;
        }

        private void zAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orden = Orden.ZA;
            ListarPaginadaOrden(orden);
            colorOriginal = OrdenartoolStripButton.BackColor;
        }

        private void SalirtoolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}