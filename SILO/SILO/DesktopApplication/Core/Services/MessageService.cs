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
        public static DialogResult displayInfoMessage(string pMessage, string pTitle = "")
        {
            return MessageBox.Show(new Form { TopMost = true, MinimizeBox = false }, pMessage, pTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult displayWarningMessage(string pMessage, string pTitle = "")
        {
            return MessageBox.Show(new Form { TopMost = true, MinimizeBox = false }, pMessage, pTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult displayErrorMessage(string pMessage, string pTitle = "")
        {
            return MessageBox.Show(new Form { TopMost = true, MinimizeBox = false }, pMessage, pTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*
        public static DialogResult displayErrorMessage(string pMessage, string pTitle = "", Form pOwner = null)
        {
            return MessageBox.Show(pOwner, pMessage, pTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        */

        public static DialogResult displayConfirmMessage(string pMessage, string pTitle = "")
        {
            return MessageBox.Show(new Form { TopMost = true, MinimizeBox = false }, pMessage, pTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        public static DialogResult displayConfirmWarningMessage(string pMessage, string pTitle = "")
        {
            return MessageBox.Show(new Form { TopMost = true, MinimizeBox = false }, pMessage, pTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }
}
