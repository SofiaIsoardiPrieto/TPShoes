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

        public FrmSports(ISportsServicio servicio, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _servicio = servicio;
            _serviceProvider = serviceProvider;
        }
        private void frmSports_Load(object sender, EventArgs e)
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
            GridHelper.LimpiarGrilla(SportdataGridView);
            foreach (var sport in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(SportdataGridView);
                GridHelper.SetearFila(r, sport);
                GridHelper.AgregarFila(SportdataGridView, r);
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
        private void SalirtoolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}