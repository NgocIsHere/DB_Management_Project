﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Management
{
    public class NavigationButtons
    {
        List<Button> buttons;
        Color defaultColor;
        Color selectedColor;

        public NavigationButtons(List<Button> buttons, Color defaultColor, Color selectedColor)
        {
            this.buttons = buttons;
            this.defaultColor = Color.Aqua;
            this.selectedColor = Color.Yellow;
            SetButtonColor();
        }

        private void SetButtonColor()
        {
            foreach (Button button in buttons)
            {
                button.BackColor = defaultColor;
            }
        }

        public void Highlight(Button selectedButton)
        {
            foreach (Button button in buttons)
            {
                if (button == selectedButton)
                {
                    selectedButton.BackColor = selectedColor;
                }
                else
                {
                    button.BackColor = defaultColor;
                }
            }
        }
    }
}
