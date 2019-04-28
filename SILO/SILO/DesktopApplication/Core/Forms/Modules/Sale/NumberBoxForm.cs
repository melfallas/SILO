using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Forms.Modules.ModuleForm;
using SILO.DesktopApplication.Core.Integration;
using SILO.DesktopApplication.Core.Repositories;
using SILO.DesktopApplication.Core.Services;
using SILO.DesktopApplication.Core.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Forms.Modules.Sale
{
    public partial class NumberBoxForm : MainModuleForm
    {

        private long lastGroup;
        private BoxNumberUnit[] boxArray;
        public ApplicationMediator appMediator { get; set; }

        public NumberBoxForm(ApplicationMediator pMediator)
        {
            InitializeComponent();
            this.type = SystemConstants.NUMBER_BOX_CODE;
            this.contentPanel.Visible = false;
            this.erasePanels();
            this.loadControls();
            this.createBoxNumber();
            // Establecer el ApplicationMediator
            this.appMediator = pMediator;
            this.lastGroup = 0;

            //Thread.Sleep(5000);
            //this.contentPanel.Visible = true;
        }

        private void erasePanels() {
            this.titlePanel.Visible = false;
        }

        public void loadControls() {
            // TODO: Encapsular con Delegados para ThreadSafe
            this.drawTypeBox.ValueMember = GeneralConstants.DISPLAY_DRAWTYPE_KEY_LABEL;
            this.drawTypeBox.DisplayMember = GeneralConstants.DISPLAY_DRAWTYPE_VALUE_LABEL;
            this.drawTypeBox.DataSource = UtilityService.drawTypeDataTable(this.drawTypeBox.ValueMember, this.drawTypeBox.DisplayMember);
            this.drawTypeBox.SelectedIndex = 0;
        }

        public void createBoxNumber()
        {
            // Generar el array de controles
            boxArray = new BoxNumberUnit[100];
            // Obtener detalle de los números prohibidos
            bool[] prohibitedNumbers = UtilityService.getProhibitedArray();
            this.buildBoxNumber(prohibitedNumbers);
            //MessageBox.Show("Mostrando");
            this.contentPanel.Visible = true;
        }

        public void buildBoxNumber(bool[] prohibitedNumbers)
        {
            // Establecer coordenadas para la caja
            int INI_X = 40;
            int INI_Y = 10;
            int SPACING_X = 90;
            int SPACING_Y = 22;
            int posX = INI_X;
            int posY = INI_Y;
            // Iterar por el panel creando las 100 casillas
            for (int i = 0; i < 100; i++)
            {
                if (i != 0 && i % 17 == 0)
                {
                    posX += SPACING_X;
                    posY = INI_Y;
                }
                // Crear el Label para la casilla
                Label numberLabel = new Label();
                numberLabel.Text = i.ToString();
                numberLabel.Top = posY;
                numberLabel.Left = posX;
                numberLabel.Width = 20;
                numberLabel.Height = 20;
                // Marcar los números prohibidos
                this.markProhibitedNumber(prohibitedNumbers[i], numberLabel);
                this.numberBoxPanel.Controls.Add(numberLabel);
                // Crear el TextBox para la casilla
                TextBox txbImport = new TextBox();
                txbImport.Text = "0";
                txbImport.Top = posY;
                txbImport.Left = posX + 20;
                txbImport.Width = 50;
                txbImport.Height = 20;
                txbImport.TextAlign = HorizontalAlignment.Right;
                txbImport.ReadOnly = true;
                this.numberBoxPanel.Controls.Add(txbImport);
                // Agregar el Label y el Texbox al array de controles
                this.boxArray[i] = new BoxNumberUnit(numberLabel, txbImport);
                posY += SPACING_Y;
            }
        }

        // Método para marcado de números prohibidos
        public void markProhibitedNumber(bool pIsProhibitedNumber, Label pLabelControl)
        {
            if (pIsProhibitedNumber)
            {
                pLabelControl.ForeColor = Color.FromArgb(255, 0, 0);
            }
            else
            {
                pLabelControl.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }

        // Delegados para seteo de propiedades desde otros hilos
        delegate void SetNumberBoxTextCallback(int pElementIndex, string pText);
        delegate int GetSelectedGroupCallback();
        delegate void SetSelectedGroupCallback(int pGroupId);
        delegate void SetTotalImportCallback(string pText);
        delegate void SetSyncImportCallback(string pText);
        delegate void SetPendingImportCallback(string pText);
        delegate void SetMaxToReceiveCallback(string pText);


        // Evento para setear el BoxNumber desde otro hilo
        public void setNumberBoxText(int pElementIndex, string pText)
        {
            this.setTextBoxWithThread(this.boxArray[pElementIndex].textbox, pText);
            /*
            if (this.boxArray[pElementIndex].textbox.InvokeRequired)
            {
                SetNumberBoxTextCallback callBack = new SetNumberBoxTextCallback(setNumberBoxText);
                this.Invoke(callBack, new object[] { pElementIndex, pText });
            }
            else
            {
                this.boxArray[pElementIndex].textbox.Text = pText;
            }
            */
        }
        // Evento para obtener el SelectedGroup desde otro hilo
        public int getSelectedGroup()
        {
            int selectedIndex = 0;
            if (this.drawTypeBox.InvokeRequired)
            {
                /*
                GetSelectedGroupCallback callBack = new GetSelectedGroupCallback(getSelectedGroup);
                selectedIndex = (int)this.Invoke(callBack, new object[] { });
                */

                this.drawTypeBox.BeginInvoke(new MethodInvoker(delegate {
                    selectedIndex = this.drawTypeBox.SelectedIndex;
                }));

            }
            else
            {
                selectedIndex = this.drawTypeBox.SelectedIndex;
            }
            Console.WriteLine("selectedIndex: " + selectedIndex);
            return selectedIndex;
        }

        // Evento para setear el SelectedGroup desde otro hilo
        public void setSelectedGroup(int pGroupId)
        {
            if (this.drawTypeBox.InvokeRequired)
            {
                this.drawTypeBox.BeginInvoke(new MethodInvoker(delegate {
                    this.drawTypeBox.SelectedIndex = pGroupId;
                }));
            }
            else
            {
                this.drawTypeBox.SelectedIndex = pGroupId;
            }
        }

        // Evento para setear un TextBox desde otro hilo
        public void setTextBoxWithThread(TextBox pTextBox, string pText)
        {
            if (pTextBox.InvokeRequired)
            {
                pTextBox.BeginInvoke(new MethodInvoker(delegate {
                    pTextBox.Text = pText;
                }));
            }
            else
            {
                pTextBox.Text = pText;
            }
        }

        // Evento para setear el TotalImport desde otro hilo
        public void setTotalImport(string pText)
        {
            this.setTextBoxWithThread(this.txbTotalImport, pText);
        }
        // Evento para setear el SyncImport desde otro hilo
        public void setSyncImport(string pText)
        {
            this.setTextBoxWithThread(this.txbSyncImport, pText);
        }
        // Evento para setear el PendingImport desde otro hilo
        public void setPendingImport(string pText)
        {
            this.setTextBoxWithThread(this.txbPendingImport, pText);
        }
        // Evento para setear el MaxToReceive desde otro hilo
        public void setMaxToReceive(string pText)
        {
            this.setTextBoxWithThread(this.txbMaxToReceive, pText);
        }

        /*
        // Evento para setear el BoxNumber desde otro hilo
        public void setNumberBoxText(int pElementIndex, string pText)
        {
            if (this.boxArray[pElementIndex].textbox.InvokeRequired)
            {
                SetNumberBoxTextCallback callBack = new SetNumberBoxTextCallback(setNumberBoxText);
                this.Invoke(callBack, new object[] { pElementIndex, pText });
            }
            else
            {
                this.boxArray[pElementIndex].textbox.Text = pText;
            }            
        }
        // Evento para obtener el SelectedGroup desde otro hilo
        public int getSelectedGroup()
        {
            int selectedIndex = 0;
            if (this.drawTypeBox.InvokeRequired)
            {
                GetSelectedGroupCallback callBack = new GetSelectedGroupCallback(getSelectedGroup);
                selectedIndex = (int)this.Invoke(callBack, new object[] { });
            }
            else
            {
                selectedIndex = this.drawTypeBox.SelectedIndex;
            }
            Console.WriteLine("selectedIndex: " + selectedIndex);
            return selectedIndex;
        }
        // Evento para setear el SelectedGroup desde otro hilo
        public void setSelectedGroup(int pGroupId)
        {
            if (this.drawTypeBox.InvokeRequired)
            {
                SetSelectedGroupCallback callBack = new SetSelectedGroupCallback(setSelectedGroup);
                this.Invoke(callBack, new object[] { pGroupId });
            }
            else
            {
                this.drawTypeBox.SelectedIndex = pGroupId;
            }
        }
        // Evento para setear el TotalImport desde otro hilo
        public void setTotalImport(string pText)
        {
            if (this.txbTotalImport.InvokeRequired)
            {
                SetTotalImportCallback callBack = new SetTotalImportCallback(setTotalImport);
                this.Invoke(callBack, new object[] { pText });
            }
            else
            {
                this.txbTotalImport.Text = pText;
            }
        }
        // Evento para setear el SyncImport desde otro hilo
        public void setSyncImport(string pText)
        {
            if (this.txbSyncImport.InvokeRequired)
            {
                SetSyncImportCallback callBack = new SetSyncImportCallback(setSyncImport);
                this.Invoke(callBack, new object[] { pText });
            }
            else
            {
                this.txbSyncImport.Text = pText;
            }
        }
        // Evento para setear el PendingImport desde otro hilo
        public void setPendingImport(string pText)
        {
            if (this.txbPendingImport.InvokeRequired)
            {
                SetPendingImportCallback callBack = new SetPendingImportCallback(setPendingImport);
                this.Invoke(callBack, new object[] { pText });
            }
            else
            {
                this.txbPendingImport.Text = pText;
            }
        }
        // Evento para setear el MaxToReceive desde otro hilo
        public void setMaxToReceive(string pText)
        {
            if (this.txbMaxToReceive.InvokeRequired)
            {
                SetMaxToReceiveCallback callBack = new SetMaxToReceiveCallback(setMaxToReceive);
                this.Invoke(callBack, new object[] { pText });
            }
            else
            {
                this.txbMaxToReceive.Text = pText;
            }
        }
        */

        //--------------------------------------- Métodos de Actualización --------------------------------------//

        private void updateBoxArray(long pGroupId)
        {
            int totalImport = 0;
            int pendingImport = 0;
            ListService listService = new ListService();
            // Calcular importe sincronizado con el server
            int[] syncTotalImportArray = listService.getDrawTotals(this.datePickerList.Value.Date, pGroupId);
            for (int i = 0; i < syncTotalImportArray.Length; i++)
            {
                totalImport += syncTotalImportArray[i];
                //this.boxArray[i].textbox.Text = FormatService.formatInt(syncTotalImportArray[i]);
                this.setNumberBoxText(i, FormatService.formatInt(syncTotalImportArray[i]));
            }
            this.setTotalImport(FormatService.formatInt(totalImport));
            // Calcular importe pendiente de sincronización
            int[] pendingSyncImportArray = listService.getDrawPendingSyncTotals(this.datePickerList.Value.Date, pGroupId);
            for (int i = 0; i < syncTotalImportArray.Length; i++)
            {
                pendingImport += pendingSyncImportArray[i];
            }
            this.setSyncImport(FormatService.formatInt(totalImport - pendingImport));
            this.setPendingImport(FormatService.formatInt(pendingImport));
            int maxToReceive = (int) (totalImport * 0.03);
            this.setMaxToReceive(maxToReceive == 0 ? "" : FormatService.formatInt(maxToReceive));
        }

        private void cleanBoxNumber()
        {
            if (this.boxArray != null)
            {
                for (int i = 0; i < this.boxArray.Length; i++)
                {
                    //this.boxArray[i].textbox.Text = "0";
                    this.setNumberBoxText(i, "0");
                }
                this.setTotalImport("0");
                this.setSyncImport("0");
                this.setPendingImport("0");
                this.setMaxToReceive("0");
            }
        }

        private void displayNewListInstance() {
            bool displayInstance = ValidationService.isNotPreviousDate(this.datePickerList.Value.Date);
            // Desplegar control de instancia si cumple las validaciones
            if (displayInstance)
            {
                LotteryDrawTypeRepository typeRepository = new LotteryDrawTypeRepository();
                ListInstanceForm listInstance = new ListInstanceForm(
                    this.appMediator,
                    this,
                    UtilityService.getPointSale(),
                    typeRepository.getById(this.drawTypeBox.SelectedIndex),
                    this.datePickerList.Value.Date
                    );
                listInstance.StartPosition = FormStartPosition.CenterParent;
                //listInstance.ShowDialog();
                listInstance.ShowDialog(this);
                //listInstance.Show(this);
                //listInstance.resetCurrentListCell();
            }
            else
            {
                MessageService.displayErrorMessage(GeneralConstants.NOT_ALLOWED_PREVIOUS_DATE_SALE_MESSAGE, GeneralConstants.NOT_ALLOWED_PREVIOUS_DATE_SALE_TITLE);
            }
        }

        private void updateTotalBoxes(long pGroupId)
        {
            int totalImport = 0;
            int pendingImport = 0;
            ListService listService = new ListService();
            // Calcular importe sincronizado con el server
            int[] syncTotalImportArray = listService.getDrawTotals(this.datePickerList.Value.Date, pGroupId);
            for (int i = 0; i < syncTotalImportArray.Length; i++)
            {
                totalImport += syncTotalImportArray[i];
            }
            this.setTotalImport(FormatService.formatInt(totalImport));
            // Calcular importe pendiente de sincronización
            int[] pendingSyncImportArray = listService.getDrawPendingSyncTotals(this.datePickerList.Value.Date, pGroupId);
            for (int i = 0; i < syncTotalImportArray.Length; i++)
            {
                pendingImport += pendingSyncImportArray[i];
            }
            this.setSyncImport(FormatService.formatInt(totalImport - pendingImport));
            this.setPendingImport(FormatService.formatInt(pendingImport));
            int maxToReceive = (int)(totalImport * 0.03);
            this.setMaxToReceive(maxToReceive == 0 ? "" : FormatService.formatInt(maxToReceive));
        }

        public void updateTotalBoxes() {
            //long groupId = this.getSelectedGroup();
            long groupId = this.lastGroup;
            this.updateTotalBoxes(groupId);
            //this.updateNumberBox(null, 1);
        }

        public void updateNumberBox()
        {
            long groupId = this.getSelectedGroup();
            //long groupId = this.drawTypeBox.SelectedIndex;
            this.updateNumberBox(groupId);
        }

        public void updateNumberBox(DateTime? pDrawDate, long pGroupId)
        {
            if (pDrawDate == null) {
                this.datePickerList.Value = DateTime.Today;
            }
            else
            {
                this.datePickerList.Value = (DateTime) pDrawDate;
            }
            this.updateNumberBox(pGroupId);
        }

        /*
        public void updateNumberBox(long pGroupId)
        {
            // Si no hay número de grupo se debe limpiar el boxNumber
            if (pGroupId == 0)
            {
                this.cleanBoxNumber();
            }
            else
            {
                // Actualizar importes sólo si el grupo es distinto de cero
                //long groupId = Convert.ToInt64(this.drawTypeBox.SelectedValue);
                this.updateBoxArray(pGroupId);
            }
            // Actualizar números prohibidos siempre
            bool[] prohibitedNumbers = UtilityService.getProhibitedArray();
            for (int i = 0; i < prohibitedNumbers.Length; i++)
            {
                this.markProhibitedNumber(prohibitedNumbers[i], this.boxArray[i].label);
            }
            // Actualizar el drawType ComboBox al id de grupo especificado
            this.drawTypeBox.SelectedIndex = (int)pGroupId;
            //this.updateBoxArray(lotteryListRepository.getDrawListTotals(this.datePickerList.Value.Date, pGroupId));
        }
        */

        public Task updateNumberBox(long pGroupId)
        {
            return Task.Run(() => {
                // Si no hay número de grupo se debe limpiar el boxNumber
                if (pGroupId == 0)
                {
                    this.cleanBoxNumber();
                }
                else
                {
                    // Actualizar importes sólo si el grupo es distinto de cero
                    //long groupId = Convert.ToInt64(this.drawTypeBox.SelectedValue);
                    this.updateBoxArray(pGroupId);
                }
                // Actualizar números prohibidos siempre
                bool[] prohibitedNumbers = UtilityService.getProhibitedArray();
                for (int i = 0; i < prohibitedNumbers.Length; i++)
                {
                    this.markProhibitedNumber(prohibitedNumbers[i], this.boxArray[i].label);
                }
                // Actualizar el drawType ComboBox al id de grupo especificado
                //this.drawTypeBox.SelectedIndex = (int)pGroupId;
                this.setSelectedGroup((int)pGroupId);
                //this.updateBoxArray(lotteryListRepository.getDrawListTotals(this.datePickerList.Value.Date, pGroupId));
            });
            
        }


        //--------------------------------------- Eventos de Controles --------------------------------------//

        private void drawTypeBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                //this.drawTypeBox
            }
        }

        private void datePickerList_ValueChanged(object sender, EventArgs e)
        {
            this.setSelectedGroup(0);
            //this.cleanBoxNumber();
        }

        private void drawTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            long groupId = Convert.ToInt64(this.drawTypeBox.SelectedValue);
            if (groupId == 0)
            {
                this.cleanBoxNumber();
            }
            else
            {
                SaleValidator saleValidator = new SaleValidator();
                bool existingFactor = saleValidator.validatePrizeFactorAsync(groupId);
                if (existingFactor)
                {
                    this.updateBoxAndDisplayListInstance(groupId);
                }
                else
                {
                    ConcreteMessageService.displayPrizeFactorNotFoundMessage();
                    this.appMediator.updateBoxNumber(0);
                    this.appMediator.setApplicationFocus();
                }
            }
        }

        public bool updateBoxAndDisplayListInstance(long pGroupId)
        {
            bool result = true;
            this.lastGroup = pGroupId;
            Console.WriteLine("lastGroup: " + lastGroup);
            this.updateNumberBox(pGroupId);
            this.displayNewListInstance();
            return result;
        }

        /*
        public async Task<bool> updateBoxAndDisplayListInstance(long pGroupId)
        {
            bool result = true;
            this.lastGroup = pGroupId;
            Console.WriteLine("lastGroup: " + lastGroup);
            await this.updateNumberBox(pGroupId);
            this.displayNewListInstance();
            return result;
            //return Task.Run(() => result);
        }
        */

    }
}
