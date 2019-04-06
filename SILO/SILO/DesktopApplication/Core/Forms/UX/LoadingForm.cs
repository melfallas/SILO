using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Forms.UX
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            this.loadingPictureBox.Image = Image.FromFile("C:\\Users\\Melvin\\Documents\\Projects\\Tiempos\\img\\program\\gif\\cargando.gif");
            this.loadingPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
