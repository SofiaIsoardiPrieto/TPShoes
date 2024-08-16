using TPShoes.Entidades;
using TPShoes.Servicios.Interfaces;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmBrands : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IBrandsServicio _servicio;
        private List<Brand>? lista;
        private Brand? brand = null;

        public FrmBrands(IBrandsServicio servicio, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _servicio = servicio;
            _serviceProvider = serviceProvider;
        }
        private void frmBrands_Load(object sender, EventArgs e)
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

            GridHelper.LimpiarGrilla(BranddataGridView);
            foreach (var brand in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(BranddataGridView);
                GridHelper.SetearFila(r, brand);
                GridHelper.AgregarFila(BranddataGridView, r);
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

                try
                {
                    if (!_servicio.EstaRelacionado(brand))
                    {
                        _servicio.Borrar(brand);

                        GridHelper.QuitarFila( BranddataGridView, r);
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