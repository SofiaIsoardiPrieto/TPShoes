using TPShoes.Entidades;
using TPShoes.Entidades.Clases;
using TPShoes.Servicios.Interfaces;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmColours : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IColoursServicio _servicio;
        private List<Colour>? lista;
        private Colour? colour = null;
        public FrmColours(IColoursServicio servicio, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _servicio = servicio;
            _serviceProvider = serviceProvider;
        }
     
        private void frmColours_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
        private void RecargarGrilla()
        {
            lista = _servicio.GetLista();
            MostrarDatosEnGrilla();
        }
        private void MostrarDatosEnGrilla()
        {

            GridHelper.LimpiarGrilla(ColourdataGridView);
            foreach (var colour in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(ColourdataGridView);
                GridHelper.SetearFila(r, colour);
                GridHelper.AgregarFila(ColourdataGridView, r);
            }
        }

        private void NuevotoolStripButton_Click(object sender, EventArgs e)
        {
            FrmColourAE frm = new FrmColourAE(_serviceProvider);
            DialogResult df = frm.ShowDialog(this);
            if (df == DialogResult.Cancel) { return; }
            try
            {
                colour = frm.GetColour();
                if (colour is null) return;
                if (!_servicio.Existe(colour))
                {
                    _servicio.Guardar(colour);

                    MessageBox.Show("Colour agregado!!!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Colour existente!!!", "Error",
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
            if (ColourdataGridView.SelectedRows.Count == 0) return;

            var filaSeleccionada = ColourdataGridView.SelectedRows[0];
            if (filaSeleccionada.Tag is null) return;

            Colour colourOriginal = (Colour)filaSeleccionada.Tag;

            if (colourOriginal is null) return;


            Colour colourCopia = (Colour)colourOriginal.Clone();

            FrmColourAE frm = new FrmColourAE(_serviceProvider) { Text = "Editar Colour" };
            frm.SetColour(colourOriginal);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                GridHelper.SetearFila(filaSeleccionada, colourOriginal);
                return;
            }

            try
            {

                Colour colourEditado = frm.GetColour();
                if (colourEditado == null) return;

                if (!_servicio.Existe(colourEditado))
                {
                    _servicio.Guardar(colourEditado);
                    MessageBox.Show("¡Colour editado exitosamente!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridHelper.SetearFila(filaSeleccionada, colourEditado);
                }
                else
                {
                    MessageBox.Show("¡Colour existente!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridHelper.SetearFila(filaSeleccionada, colourOriginal);

                }
            }
            catch (Exception ex)
            {

                GridHelper.SetearFila(filaSeleccionada, colourOriginal);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RecargarGrilla();
        }

        private void BorrartoolStripButton_Click(object sender, EventArgs e)
        {
            if (ColourdataGridView.SelectedRows.Count == 0) return;
            var r = ColourdataGridView.SelectedRows[0];
            Colour? colour = r.Tag as Colour;//LO MISMO?
            try
            {
                DialogResult dr = MessageBox.Show("¿Desea borrar el registro seleccionado?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }

                try
                {
                    if (!_servicio.EstaRelacionado(colour))
                    {
                        _servicio.Borrar(colour);

                        GridHelper.QuitarFila(ColourdataGridView, r);
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

                RecargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SalirtoolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}