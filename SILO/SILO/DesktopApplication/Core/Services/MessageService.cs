using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Services
{
    public static class MessageService
    {
        public static DialogResult displayErrorMessage(string pMessage, string pTitle = "")
        {
            return MessageBox.Show(pMessage, pTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult displayConfirmMessage(string pMessage, string pTitle = "")
        {
            return MessageBox.Show(pMessage, pTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
    }
}
