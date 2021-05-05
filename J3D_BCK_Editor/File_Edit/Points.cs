using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace J3D_BCK_Editor.File_Edit
{
    class Points:BCK_State
    {
        public class Get
        {
            public static float fromgrid(DataGridView dgv,int rownum ,string cellname , int frac = 1) 
            {
                var str = string.Format("{0:0.##########}", dgv.Rows[rownum].Cells[cellname].Value, CultureInfo.InvariantCulture.NumberFormat);
                var floatnum = float.Parse(str)/frac;
                return floatnum;
            }

            public static PointF scale(PointF pf,float scalex , float scaley) 
            {
                pf.X *= scalex;
                pf.Y *= scaley;
                return pf;
            }

            


        }
    }
}
