﻿using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Integration;
using SILO.DesktopApplication.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Forms.Modules.Parameters
{
    public partial class ServerParamForm : Form
    {

        public ApplicationMediator appMediator { get; set; }

        public ServerParamForm(ApplicationMediator pMediator)
        {
            this.appMediator = pMediator;
            InitializeComponent();
            this.fillParameterBoxes();
        }

        public void fillParameterBoxes()
        {
            this.txbServiceName.Text = ServerParameterService.getServerParameterValue(ParameterConstants.SERVICE_DENOMINATION_PARAM_NAME);
        }

    }
}