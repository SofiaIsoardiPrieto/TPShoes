using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Servicios.Interfaces;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmGenres : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IGenresServicio _servicio;
        private List<Genre>? lista;


        private Genre? genre = null;



        int paginaActual = 1;//private int pageNum = 0;
        int registro;//private int recordCount;
        int paginas;//private int pageCount;
        int registrosPorPagina = 5; //private int pageSize = 15; 

        public FrmGenres(IGenresServicio servicio, IServiceProvider serviceProvider)
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

            GridHelper.LimpiarGrilla(GenredataGridView);
            foreach (var genre in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(GenredataGridView);
                GridHelper.SetearFila(r, genre);
                GridHelper.AgregarFila(GenredataGridView, r);
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
            FrmGenreAE frm = new FrmGenreAE(_serviceProvider);
            DialogResult df = frm.ShowDialog(this);
            if (df == DialogResult.Cancel) { return; }
            try
            {
                genre = frm.GetGenre();
                if (genre is null) return;
                if (!_servicio.Existe(genre))
                {
                    _servicio.Guardar(genre);

                    MessageBox.Show("Genre agregado!!!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Genre existente!!!", "Error",
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
            if (GenredataGridView.SelectedRows.Count == 0) return;

            var filaSeleccionada = GenredataGridView.SelectedRows[0];
            if (filaSeleccionada.Tag is null) return;

            Genre genreOriginal = (Genre)filaSeleccionada.Tag;

            if (genreOriginal is null) return;


            Genre genreCopia = (Genre)genreOriginal.Clone();

            FrmGenreAE frm = new FrmGenreAE(_serviceProvider) { Text = "Editar Genre" };
            frm.SetGenre(genreOriginal);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                GridHelper.SetearFila(filaSeleccionada, genreOriginal);
                return;
            }

            try
            {

                Genre genreEditado = frm.GetGenre();
                if (genreEditado == null) return;

                if (!_servicio.Existe(genreEditado))
                {
                    _servicio.Guardar(genreEditado);
                    MessageBox.Show("¡Genre editado exitosamente!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridHelper.SetearFila(filaSeleccionada, genreEditado);
                }
                else
                {
                    MessageBox.Show("¡Genre existente!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridHelper.SetearFila(filaSeleccionada, genreOriginal);

                }
            }
            catch (Exception ex)
            {

                GridHelper.SetearFila(filaSeleccionada, genreOriginal);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RecargarGrilla();
        }

        private void BorrartoolStripButton_Click(object sender, EventArgs e)
        {
            if (GenredataGridView.SelectedRows.Count == 0) return;
            var r = GenredataGridView.SelectedRows[0];
            Genre? genre = r.Tag as Genre;//LO MISMO?
            try
            {
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }

                try
                {
                    if (!_servicio.EstaRelacionado(genre))
                    {
                        _servicio.Borrar(genre);

                        GridHelper.QuitarFila( GenredataGridView, r);
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