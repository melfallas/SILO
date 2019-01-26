using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO
{
    class BoxNumberUnit
    {
        public Label label { get; set; }
        public TextBox textbox { get; set; }

        public BoxNumberUnit(Label label, TextBox textbox)
        {
            this.label = label;
            this.textbox = textbox;
        }
    }
}
