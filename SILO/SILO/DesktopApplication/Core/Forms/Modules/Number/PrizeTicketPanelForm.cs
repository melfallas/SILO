﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Forms.Modules.Number
{
    public partial class PrizeTicketPanelForm : Form
    {
        public PrizeTicketPanelForm(string pTicketText)
        {
            InitializeComponent();
            this.prizeTextBox.Text = pTicketText;
        }
    }
}
