using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J3D_BCK_Editor.File_Edit.FormControlSys
{
    public class Frames
    {
        public static readonly Dictionary<string, int> AnimInfo = new Dictionary<string, int>()
        {
            { "StartFrame", 0},
            { "DataCount", 1 },
            { "Tan", 2}
        };
        public static int FetchMaxFrame(DataGridView dgv, List<List<int>> plot_List) 
        {
            var MaxVal = 0;
            foreach (var rotAnimTable in plot_List)
            {
                if (rotAnimTable[AnimInfo["DataCount"]] == 1) continue;

                var adder = 3;
                if (rotAnimTable[AnimInfo["Tan"]] == 1) adder = 4;

                if (rotAnimTable[AnimInfo["DataCount"]] > 1)
                {
                    var lastFramePos = (rotAnimTable[AnimInfo["DataCount"]] * adder) - adder;
                    var str = dgv.Rows[rotAnimTable[AnimInfo["StartFrame"]] + lastFramePos].Cells[1].Value.ToString();
                    //Console.WriteLine(str);
                    var num = int.Parse(str);
                    if (num > MaxVal) MaxVal = num;

                }
            }
            return MaxVal;
        }
    }
}
