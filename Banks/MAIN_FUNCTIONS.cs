using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banks
{
    class MAIN_FUNCTIONS
    {
        public static void ChangeDisplay(VISUALIZER _VISUALIZER, Control.ControlCollection Controls, Displays Display)
        {
            RemoveItemByName<Panel>("DISPLAY", Controls);
            Panel DISPLAY = new Panel();

            if (Display == Displays.Welcome)
            _VISUALIZER.DisplayWelcome(ref DISPLAY);
            else if(Display == Displays.InputPIN)
            _VISUALIZER.DisplayInputPIN(ref DISPLAY);

            Controls.Add(DISPLAY);
        }

        public static void RemoveItemByName<T>(string name, Control.ControlCollection Controls)
        where T : Control
        {
            foreach (T item in Controls.OfType<T>().ToList().Where(
             item => item.Name == name))
                Controls.Remove(item);
        }
    }

    public enum Displays
    {
        Welcome,
        InputPIN
    }
}
