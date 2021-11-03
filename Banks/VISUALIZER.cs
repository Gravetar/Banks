using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Banks
{
    class VISUALIZER
    {

        public void DisplayWelcome(ref Panel Display)
        {
            Panel DISPLAY_Welcome = new Panel();
            DISPLAY_Welcome.Name = "DISPLAY";
            DISPLAY_Welcome.Location = new Point(100, 100);
            DISPLAY_Welcome.Size = SETTINGS.DISPLAY_SIZE;
            DISPLAY_Welcome.BorderStyle = BorderStyle.Fixed3D;

            Label DISPLAY_Welcome_MainText = new Label();
            DISPLAY_Welcome_MainText.Name = "DISPLAY_Welcome_MainText";
            DISPLAY_Welcome_MainText.Text = SETTINGS.WELCOME_TEXT;
            DISPLAY_Welcome_MainText.TextAlign = ContentAlignment.MiddleCenter;
            DISPLAY_Welcome_MainText.AutoSize = true;
            DISPLAY_Welcome_MainText.Location = new Point((DISPLAY_Welcome.Width / 2) - DISPLAY_Welcome_MainText.Size.Width, (DISPLAY_Welcome.Height / 2) - DISPLAY_Welcome_MainText.Size.Height);

            DISPLAY_Welcome.Controls.Add(DISPLAY_Welcome_MainText);
            Display = DISPLAY_Welcome;
        }

        public void DisplayInputPIN(ref Panel Display)
        {
            Panel DISPLAY_Pin = new Panel();
            DISPLAY_Pin.Name = "DISPLAY";
            DISPLAY_Pin.Location = new Point(100, 100);
            DISPLAY_Pin.Size = SETTINGS.DISPLAY_SIZE;
            DISPLAY_Pin.BorderStyle = BorderStyle.Fixed3D;

            TableLayoutPanel DISPLAY_Pin_TLP = new TableLayoutPanel();
            DISPLAY_Pin_TLP.Name = "DISPLAY_PIN_FLP";
            DISPLAY_Pin_TLP.ColumnCount = 3;
            DISPLAY_Pin_TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            DISPLAY_Pin_TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            DISPLAY_Pin_TLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            DISPLAY_Pin_TLP.Padding = new Padding(0, 50, 0, 0);

            Label DISPLAY_Pin_MainText = new Label();
            DISPLAY_Pin_MainText.Name = "DISPLAY_Pin_MainText";
            DISPLAY_Pin_MainText.Text = "Введите пин-код!";
            DISPLAY_Pin_MainText.AutoSize = true;
            DISPLAY_Pin_MainText.Anchor = AnchorStyles.None;

            TextBox DISPLAY_Pin_InputText = new TextBox();
            DISPLAY_Pin_InputText.Name = "DISPLAY_Pin_InputText";
            DISPLAY_Pin_InputText.ReadOnly = true;
            DISPLAY_Pin_InputText.Size = new Size(150, 100);
            DISPLAY_Pin_InputText.Anchor = AnchorStyles.None;

            DISPLAY_Pin_TLP.Controls.Add(DISPLAY_Pin_MainText, 1, 1);
            DISPLAY_Pin_TLP.Controls.Add(DISPLAY_Pin_InputText, 1, 2);
            DISPLAY_Pin.Controls.Add(DISPLAY_Pin_TLP);
            Display = DISPLAY_Pin;
        }
    }
}
