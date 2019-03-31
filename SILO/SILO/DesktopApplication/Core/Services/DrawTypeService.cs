using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SILO.DesktopApplication.Core.Services
{
    class DrawTypeService
    {
        public List<LDT_LotteryDrawType> getActiveGroups()
        {
            LotteryDrawTypeRepository drawTypeRepository = new LotteryDrawTypeRepository();
            return drawTypeRepository.findActiveGroups();
        }

        public LDT_LotteryDrawType getById(long pGroupId)
        {
            LotteryDrawTypeRepository drawTypeRepository = new LotteryDrawTypeRepository();
            return drawTypeRepository.getById(pGroupId);
        }

        public void addRadioButtonList(ref Panel pObjectPanel)
        {
            LotteryDrawTypeRepository drawTypeRepository = new LotteryDrawTypeRepository();
            List<LDT_LotteryDrawType> drawTypeList = drawTypeRepository.findActiveGroups();
            // Establecer coordenadas iniciales
            int INI_X = 40;
            int INI_Y = 40;
            int SPACING_X = 300;
            int SPACING_Y = 30;
            int posX = INI_X;
            int posY = INI_Y;
            int CONTROL_WITH = 150;
            int CONTROL_HEIGHT = 20;
            // Iterar por los grupos, creando los radio
            for (int i = 0; i < drawTypeList.Count; i++)
            {
                if (i != 0 && i % 4 == 0)
                {
                    posX += SPACING_X;
                    posY = INI_Y;
                }
                RadioButton radioButton = new RadioButton();
                radioButton.Name = GeneralConstants.CHECKBOX_NAME_ID_LABEL + drawTypeList[i].LDT_Id;
                radioButton.Text = drawTypeList[i].LDT_DisplayName;
                //radioButton.ForeColor = Color.Red;
                //radioButton.Location = new Point(posX, posY);
                radioButton.Top = posY;
                radioButton.Left = posX + 20;
                radioButton.Width = CONTROL_WITH;
                radioButton.Height = CONTROL_HEIGHT;
                pObjectPanel.Controls.Add(radioButton);
                posY += SPACING_Y;
            }
        }

    }
}
