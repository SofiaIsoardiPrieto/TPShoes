using TPShoes.Entidades.Clases;
using TPShoes.Servicios.Interfaces;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmSports : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISportsServicio _servicio;
        private List<Sport>? lista;


        private Sport? sport = null;



        int paginaActual = 1;//private int pageNum = 0;
        int registro;//private int recordCount;
        int paginas;//private int pageCount;
        int registrosPorPagina = 5; //private int pageSize = 15; 

        public FrmSports(ISportsServicio servicio, IServiceProvider serviceProvider)
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
            lista = _servicio.GetLista();
            CombosHelper.CargarCombosPaginas(paginas, ref PaginaActualcomboBox);
            MostrarDatosEnGrilla();
        }


        private void MostrarDatosEnGrilla()
        {

            GridHelper.LimpiarGrilla(SportdataGridView);
            foreach (var sport in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(SportdataGridView);
                GridHelper.SetearFila(r, sport);
                GridHelper.AgregarFila(SportdataGridView, r);
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
            FrmSportAE frm = new FrmSportAE(_serviceProvider);
            DialogResult df = frm.ShowDialog(this);
            if (df == DialogResult.Cancel) { return; }
            try
            {
                sport = frm.GetSport();
                if (sport is null) return;
                if (!_servicio.Existe(sport))
                {
                    _servicio.Guardar(sport);

                    MessageBox.Show("Sport agregado!!!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Sport existente!!!", "Error",
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
            if (SportdataGridView.SelectedRows.Count == 0) return;

            var filaSeleccionada = SportdataGridView.SelectedRows[0];
            if (filaSeleccionada.Tag is null) return;

            Sport sportOriginal = (Sport)filaSeleccionada.Tag;

            if (sportOriginal is null) return;


            Sport sportCopia = (Sport)sportOriginal.Clone();

            FrmSportAE frm = new FrmSportAE(_serviceProvider) { Text = "Editar Sport" };
            frm.SetSport(sportOriginal);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                GridHelper.SetearFila(filaSeleccionada, sportOriginal);
                return;
            }

            try
            {

                Sport sportEditado = frm.GetSport();
                if (sportEditado == null) return;

                if (!_servicio.Existe(sportEditado))
                {
                    _servicio.Guardar(sportEditado);
                    MessageBox.Show("¡Sport editado exitosamente!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridHelper.SetearFila(filaSeleccionada, sportEditado);
                }
                else
                {
                    MessageBox.Show("¡Sport existente!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridHelper.SetearFila(filaSeleccionada, sportOriginal);

                }
            }
            catch (Exception ex)
            {

                GridHelper.SetearFila(filaSeleccionada, sportOriginal);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RecargarGrilla();
        }

        private void BorrartoolStripButton_Click(object sender, EventArgs e)
        {
            if (SportdataGridView.SelectedRows.Count == 0) return;
            var r = SportdataGridView.SelectedRows[0];
            Sport? sport = r.Tag as Sport;//LO MISMO?
            try
            {
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }

                try
                {
                    if (!_servicio.EstaRelacionado(sport))
                    {
                        _servicio.Borrar(sport);

                        GridHelper.QuitarFila(SportdataGridView, r);
                        MessageBox.Show("Registro Borrado Satisfactoriamente!!!",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


                    }
                    else
                    {
                        MessageBox.Show("Registro Relacionado...Baja denegada!!!",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }


                RecargarGrilla();//evitar errores

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje",
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
                MostrarDatosEnGrilla();
            }
        }

        private void SalirtoolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}