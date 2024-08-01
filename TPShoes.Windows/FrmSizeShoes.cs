using Microsoft.Extensions.DependencyInjection;
using TPShoes.Entidades.Clases;
using TPShoes.Entidades.Dtos;
using TPShoes.Entidades.Enum;
using TPShoes.Servicios.Interfaces;
using TPShoes.Servicios.Servicios;
using TPShoes.Windows.Helpers;

namespace TPShoes.Windows
{
    public partial class FrmSizeShoes : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISizeShoesServicio _servicio;
        private List<SizeShoeDto>? lista;
        private Orden orden = Orden.SinOrden;
        private Shoe? shoe = null;

        private int _shoeId = 0;

        int paginaActual = 1;//private int pageNum = 0;
        int registro;//private int recordCount;
        int paginas;//private int pageCount;
        int registrosPorPagina = 5; //private int pageSize = 15; 

        public FrmSizeShoes(IServiceProvider serviceProvider,int shoeId)
        {
            InitializeComponent(); 
            _serviceProvider = serviceProvider;
            _servicio = _serviceProvider?
                               .GetService<ISizeShoesServicio>();
          
            _shoeId = shoeId;
        }
        private void frmShoes_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
        private void RecargarGrilla()
        {

            lista = _servicio.GetSizeShoeDtoPorId
               (_shoeId);
            MostrarDatosEnGrilla();
        }
        private void MostrarDatosEnGrilla()
        {

            GridHelper.LimpiarGrilla(SizeShoedataGridView);
            foreach (var sizeShoeDto in lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(SizeShoedataGridView);
                GridHelper.SetearFila(r, shoe);
                GridHelper.AgregarFila(SizeShoedataGridView, r);
            }

        }
        private void EditartoolStripButton_Click(object sender, EventArgs e)
        {
            if (SizeShoedataGridView.SelectedRows.Count == 0) return;

            var filaSeleccionada = SizeShoedataGridView.SelectedRows[0];
            if (filaSeleccionada.Tag is null) return;

            SizeShoeDto sizeShoeDto = (SizeShoeDto)filaSeleccionada.Tag;

            SizeShoe sizeShoeOriginal = _servicio.GetSizeShoePorId(sizeShoeDto.SizeShoeId);//revisar
            if (sizeShoeOriginal is null) return;

            SizeShoe sizeShoeCopia = (SizeShoe)sizeShoeOriginal.Clone();

            FrmStock frm = new FrmStock(_serviceProvider) { Text = "Editar Stock" };
            frm.SetSizShoe(sizeShoeOriginal);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                GridHelper.SetearFila(filaSeleccionada, sizeShoeDto);
                return;
            }
            try
            {

                SizeShoe sizeShoeEditado = frm.GetSizeShoe();
                if (sizeShoeEditado == null) return;

                if (!_servicio.Existe(sizeShoeEditado))
                {
                    _servicio.Guardar(sizeShoeEditado);
                    MessageBox.Show("¡Stock editado exitosamente!", "Confirmación",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GridHelper.SetearFila(filaSeleccionada, sizeShoeEditado);
                }
                else
                {
                    MessageBox.Show("¡Stock existente!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GridHelper.SetearFila(filaSeleccionada, sizeShoeDto);

                }
            }
            catch (Exception ex)
            {

                GridHelper.SetearFila(filaSeleccionada, sizeShoeDto);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RecargarGrilla();
        }

        private void SalirtoolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}