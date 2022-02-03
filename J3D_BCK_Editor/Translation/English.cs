using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J3D_BCK_Editor.Translation
{
    public class English : ITranslation
    {
        public void FormControlTextChange(Control control)
        {
            control.Text = "";
        }
    }
}
