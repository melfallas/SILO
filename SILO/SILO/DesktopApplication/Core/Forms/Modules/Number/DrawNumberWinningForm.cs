using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Repositories;
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

namespace SILO.DesktopApplication.Core.Forms.Modules.Number
{
    public partial class DrawNumberWinningForm : Form
    {
        private TicketPrintService ticketPrintService;

        public DrawNumberWinningForm()
        {
            InitializeComponent();
            this.loadControls();
            this.ticketPrintService = new TicketPrintService();
        }

        private void loadControls() {
            this.groupLabel.Text = GeneralConstants.SELECT_GROUP_LABEL;
            this.drawTypeBox.ValueMember = GeneralConstants.DISPLAY_DRAWTYPE_KEY_LABEL;
            this.drawTypeBox.DisplayMember = GeneralConstants.DISPLAY_DRAWTYPE_VALUE_LABEL;
            this.drawTypeBox.DataSource = UtilityService.drawTypeDataTable(this.drawTypeBox.ValueMember, this.drawTypeBox.DisplayMember);
            this.drawTypeBox.SelectedIndex = 0;
            this.dateLabel.Text = UtilityService.getLargeDate(this.datePickerList.Value);
            this.actionPanel.Hide();
            this.datePickerList.Focus();
        }

        private void cleanTextBoxes() {
            this.txbFirst.Text = "";
            this.txbSecond.Text = "";
            this.txbThird.Text = "";
        }

        //---------------------------------- Métodos de lógica de aplicación -------------------------------//

        public void fillTextBoxes()
        {
            LTD_LotteryDraw draw = new LTD_LotteryDraw();
            draw.LDT_LotteryDrawType = Convert.ToInt64(this.drawTypeBox.SelectedValue);
            draw.LTD_CreateDate = this.datePickerList.Value.Date;
            LotteryDrawRepository drawRepository = new LotteryDrawRepository();
            draw = drawRepository.getDrawRegister(draw);
            // Validar si existe el sorteo para realizar la búsqueda de los ganadores
            if(draw != null)
            {
                DrawNumberWinningRepository winningRepository = new DrawNumberWinningRepository();
                DNW_DrawNumberWinning winningDraw = winningRepository.getById(draw.LTD_Id);
                // Verificar ganadores para llenar los textboxes
                if (winningDraw != null)
                {
                    MessageBox.Show("Los ganadores para el sorteo ya fueron agregados previamente. Puede sobre escribirlos digitando los nuevos números y presionando el botón 'Guardar'.");
                    this.txbFirst.Text = winningDraw.DNW_FirtsNumber;
                    this.txbSecond.Text = winningDraw.DNW_SecondNumber;
                    this.txbThird.Text = winningDraw.DNW_ThirdNumber;
                }
            }

        }

        //---------------------------------- Eventos de los controles -------------------------------//

        private void DrawNumberWinningForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void datePickerList_ValueChanged(object sender, EventArgs e)
        {
            this.drawTypeBox.SelectedIndex = 0;
            this.dateLabel.Text = UtilityService.getLargeDate(this.datePickerList.Value);
            this.groupLabel.Text = GeneralConstants.SELECT_GROUP_LABEL;
            this.cleanTextBoxes();
        }

        private void drawTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.groupLabel.Text = this.drawTypeBox.Text;
            this.cleanTextBoxes();
            this.actionPanel.Show();
            this.fillTextBoxes();
            this.txbFirst.Focus();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            long groupId = Convert.ToInt64(this.drawTypeBox.SelectedValue);
            if (groupId == 0)
            {
                MessageBox.Show("Debe elegir un grupo válido");
            }
            else
            {
                if (this.txbFirst.Text.Trim() == "")
                {
                    MessageBox.Show("Debe ingresar al menos el primer número ganador");
                    this.txbFirst.Focus();
                }
                else {
                    LTD_LotteryDraw selectedDraw = new LTD_LotteryDraw();
                    selectedDraw.LDT_LotteryDrawType = Convert.ToInt64(this.drawTypeBox.SelectedValue);
                    selectedDraw.LTD_CreateDate = this.datePickerList.Value.Date;
                    LotteryDrawRepository lotteryDrawRepository = new LotteryDrawRepository();
                    selectedDraw = lotteryDrawRepository.getDrawRegister(selectedDraw);
                    // Validar si existe el sorteo seleccionado
                    if (selectedDraw == null)
                    {
                        //TODO: Sincronizar con el servidor central
                        MessageBox.Show("El sorteo seleccionado no existe y no puede ser ingresado");
                    }
                    else
                    {
                        // Crear y completar nuevo registro de números ganadores
                        DNW_DrawNumberWinning drawNumberWinning = new DNW_DrawNumberWinning();
                        drawNumberWinning.LTD_LotteryDraw = selectedDraw.LTD_Id;
                        drawNumberWinning.DNW_FirtsNumber = this.txbFirst.Text;
                        drawNumberWinning.DNW_SecondNumber = this.txbSecond.Text;
                        drawNumberWinning.DNW_ThirdNumber = this.txbThird.Text;
                        drawNumberWinning.DNW_CreateDate = DateTime.Now;
                        drawNumberWinning.SYS_SynchronyStatus = SystemConstants.SYNC_STATUS_PENDING_TO_SERVER;
                        DrawNumberWinningRepository drawNumberWinningRepository = new DrawNumberWinningRepository();
                        drawNumberWinningRepository.save(ref drawNumberWinning);
                        // Imprimir tiquete de premios / ganadores
                        if (this.ckbPrint.Checked)
                        {
                            string[] winningNumberArray = new string[3];
                            winningNumberArray[0] = this.txbFirst.Text.Trim() == "" ? "NA" : this.txbFirst.Text;
                            winningNumberArray[1] = this.txbSecond.Text.Trim() == "" ? "NA" : this.txbSecond.Text;
                            winningNumberArray[2] = this.txbThird.Text.Trim() == "" ? "NA" : this.txbThird.Text;
                            this.ticketPrintService.printPrizeTicket(selectedDraw, winningNumberArray);
                            //UtilityService.printPrizeTicket(selectedDraw, winningNumberArray);
                        }
                        //PC: MessageBox.Show(selectedDraw.LTD_Id.ToString());
                        this.Dispose();
                    }
                }
            }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
