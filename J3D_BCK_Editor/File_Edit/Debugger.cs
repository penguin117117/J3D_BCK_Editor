using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J3D_BCK_Editor.File_Edit
{
    public class Debugger
    {
        protected static TextBox debug = Form1.Form1Instance.デバッグ;

        //デバッグ文章の表示の有無
        protected static bool Debug_Text = true;

        public static void Append(string str)
        {
            if (Debug_Text == false) return;
            debug.AppendText(str);
            Console.WriteLine(str);
        }

        
    }
}
