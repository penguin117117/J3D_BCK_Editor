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
        protected static TabControl tc = Form1.Form1Instance.tabControl1;
        protected static TabPage tp = Form1.Form1Instance.tabPage6;
        
        //デバッグ文章の表示の有無
        public static bool Debug_Text = false;

        public static void Append(string str)
        {
            debug.Enabled = Debug_Text;
            if (Debug_Text == false)tc.TabPages.Remove(tp);
            if (Debug_Text == false) return;
            debug.AppendText(str);
            Console.WriteLine(str);
        }

        
    }
}
