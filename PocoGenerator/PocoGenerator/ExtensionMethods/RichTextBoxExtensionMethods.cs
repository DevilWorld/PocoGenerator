using PocoGenerator.Domain.Models.Dto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PocoGenerator.ExtensionMethods
{
    //Add all the UI related extension methods here
    public static partial class ExtensionMethods
    {
        public static void AppendColoredText(this RichTextBox box, string text, Color color)
        {
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            
            box.SelectionStart = 0;
            box.SelectionLength = box.TextLength;

            box.SelectionFont = new Font(new FontFamily("Consolas"), 10);
        }        
    }
}
