using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using CS = J3D_BCK_Editor.File_Edit.Calculation_System;
using EN = System.Environment;

namespace J3D_BCK_Editor.File_Edit
{

    class BCK_System : BCK_State
    {
        public void protecttest()
        {
            debug.AppendText(EN.NewLine + debugstr[debugnum] + EN.NewLine);
            debugnum++;
        }
        public void Animation_Table_File_Reader(BinaryReader br)
        {

            string[] xyzstate = { "scaleX", "rotateX", "transX", "scaleY", "rotateY", "transY", "scaleZ", "rotateZ", "transZ" };
            for (int i = 0; i < Bone_Num; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dgv1.Rows.Add("Bone" + i, xyzstate[j], CS.Byte2Int(br, 2), CS.Byte2Int(br, 2), CS.Byte2Int(br, 2));
                }
            }


        }
        public void Padding(BinaryReader br)
        {

            for (int k = padnum + 96; (k % 32f) != 0; k++)
            {
                debug.AppendText("\n\r" + CS.Byte2Char(br, 1));
                Console.WriteLine(padcount++);

            }
        }



        //以下ファイル書き込み専用
        public  void Anim_Writer(BinaryWriter bw )
        {
            int dgv1_row_total = dgv1.Rows.Count;
            //if (dgv1_row_total % 9  == 0)return ;
            for (int i = 0; i < dgv1_row_total; i++)
            {
                bw.Write(
                    CS.StringToShort_byte(dgv1.Rows[i].Cells["Frame_Num"].Value.ToString()));
                bw.Write(
                    CS.StringToShort_byte(dgv1.Rows[i].Cells["Start_Frame"].Value.ToString()));
                bw.Write(
                    CS.StringToShort_byte(dgv1.Rows[i].Cells["Tangent_Mode"].Value.ToString()));


            }
        }

        public void Scale_Trans_Writer(BinaryWriter bw , DataGridView dgv ,string Column_Name)
        {
            int dgv_row_total = dgv.Rows.Count;
            for (int i = 0; i < dgv_row_total ; i++)
            {
                //bw.Write(CS.StringToBytes(
                //    CS.Float_ToHexString_2(
                //        float.Parse(

                //       string.Format("{0:F6}",dgv.Rows[i].Cells[Column_Name].Value.ToString()))
                //            )
                //        )
                //    );
                bw.Write(CS.StringToBytes(
                    CS.Float_ToHexString_2(
                      float.Parse(

                       string.Format("{0:0.##########}", dgv.Rows[i].Cells[Column_Name].Value.ToString()),CultureInfo.InvariantCulture.NumberFormat)
                          )
                        )
                    );


            }
        }

        public void Rotate_Writer(BinaryWriter bw, DataGridView dgv, string Column_Name) 
        {
            int dgv_row_total = dgv.Rows.Count;
            for (int i = 0; i < dgv_row_total - 1; i++)
            {
                bw.Write(CS.StringToBytes(
                    CS.Int16_ToHexString(
                        Convert.ToInt16(

                        dgv.Rows[i].Cells[Column_Name].Value)
                            )
                        )
                    );



            }
        }




        public void Padding_Writer(BinaryWriter bw,long bw_pos)
        {
            int i = 0;
            byte[] pad = { 0x54, 0x68, 0x69, 0x73, 0x20, 0x69, 0x73, 0x20, 0x70, 0x61, 0x64, 0x64, 0x69, 0x6E, 0x67, 0x20, 0x64, 0x61, 0x74, 0x61, 0x20, 0x74, 0x6F, 0x20, 0x61, 0x6C, 0x69, 0x67, 0x6E, 0x6D, 0x65 };
            for (long k = bw_pos; (k % 32f) != 0; k++)
            {
                bw.Write(pad[i]);

                i++;
            }
        }


        /// <summary>
        /// ｱﾆﾒｰｼｮﾝﾃｰﾌﾞﾙのﾀﾝｼﾞｪﾝﾄﾓｰﾄﾞなどをチェック
        /// <remarks>Mode_Checker(ﾎﾞｰﾝ数、ﾀｲﾌﾟﾅﾝﾊﾞｰ)</remarks>
        /// <br/>
        /// ﾀｲﾌﾟﾅﾝﾊﾞｰ：0 ｽｹｰﾙ :1 ﾛｰﾃｰｼｮﾝ :3 ﾄﾗﾝｽﾚｰｼｮﾝ
        /// </summary>
        /// 
        public void Mode_Checker(int bones , int type_num　, bool dgv_write) 
        {
            
            for (int c = type_num; (bones * 9) > c; c = c + 3)
            {
                Frame_Num_String = dgv1.Rows[c].Cells["Frame_Num"].Value.ToString();
                Start_Frame_String = dgv1.Rows[c].Cells["Start_Frame"].Value.ToString();
                Tangent_String = dgv1.Rows[c].Cells["Tangent_Mode"].Value.ToString();
                Frame_Num_Int = Convert.ToInt32(Frame_Num_String);
                Start_Frame_Int = Convert.ToInt32(Start_Frame_String);
                Tangent_Int = Convert.ToInt32(Tangent_String);
                if (type_num == 1)
                {
                    bool write_read = dgv_write;
                    Rot_Mode(write_read);
                }
                else if (type_num == 0)
                {
                    Scale_Trans_Mode(dgv_write, dgv2, "Scale_Value");

                    //if (Tangent_String == "0" && Frame_Num_String == "1")
                    //{

                    //}
                    //else if (Tangent_String == "0" && (Start_Frame_Int > 0) && (Frame_Num_Int > 1))
                    //{


                    //}
                    //else if (Tangent_String == "1" && Frame_Num_String != "1")
                    //{

                    //}
                }
                else if (type_num == 2)
                {
                    Scale_Trans_Mode(dgv_write, dgv4, "Translation_Value");
                }
            }
        }
        public void Rot_Mode(bool dgv_write) 
        {
            int[] rotList = new int[dgv3.Rows.Count];
            float dgv3float;
            if (Tangent_String == "0" && Frame_Num_String == "1")
            {
                rotList[Start_Frame_Int] = Start_Frame_Int;
            }
            else if (Tangent_String == "0" && (Start_Frame_Int > 0) && (Frame_Num_Int > 1))
            {
                for (int i = (Start_Frame_Int + 1); (Start_Frame_Int + 1) + (Frame_Num_Int * 3) > i; i = i + 3)
                {
                    rotList[i] = i;
                }
            }
            else if (Tangent_String == "1" && Frame_Num_String != "1")
            {
                for (int j = (Start_Frame_Int + 1); (Start_Frame_Int + 1) + (Frame_Num_Int * 4) > j; j = j + 4)
                {
                    rotList[j] = j;
                }
            }
            rotList = rotList.Where(x => x != 0).ToArray();
            int frac = 1;
            
            for (int f = 0; f < Rotation_Frac;f++) 
            {
                if (f!=0) { frac = frac*10; }
                
            }


            foreach (int a in rotList)
            {
                if (dgv_write　== true)
                {
                    dgv3float = Convert.ToSingle(dgv3.Rows[a].Cells["Rotation_Value"].Value.ToString());
                    dgv3float = (dgv3float / 182)*frac;
                    
                    dgv3.Rows[a].Cells["Rotation_Value"].Value = dgv3float.ToString();
                }
                else
                {
                    dgv3float = float.Parse(dgv3.Rows[a].Cells["Rotation_Value"].Value.ToString());
                    dgv3float = (dgv3float /frac)*182;
                    dgv3.Rows[a].Cells["Rotation_Value"].Value = Convert.ToInt16(dgv3float);
                }

                debug.AppendText(EN.NewLine + a.ToString()+"リスト");
            }
        }

        public void Scale_Trans_Mode(bool dgv_write ,DataGridView dgv ,string cell_name)
        {
            int[] S_T_List = new int[dgv.Rows.Count];
            float dgvfloat;
            if (Tangent_String == "0" && (Start_Frame_Int > 0) && (Frame_Num_Int > 1))
            {
                for (int i = (Start_Frame_Int + 2); (Start_Frame_Int + 2) + (Frame_Num_Int * 3) > i; i = i + 3)
                {
                    S_T_List[i] = i;
                }
            }
            else if (Tangent_String == "1" && Frame_Num_String != "1")
            {
                for (int j = (Start_Frame_Int + 2); (Start_Frame_Int + 2) + (Frame_Num_Int * 4) > j; j = j + 3)
                {
                    S_T_List[j] = j;
                    j++;
                    S_T_List[j] = j;

                }
            }

            S_T_List = S_T_List.Where(x => x != 0).ToArray();
            int dgvint;
            foreach (int a in S_T_List)
            {
                if (dgv_write == true)
                {
                    dgvfloat = float.Parse(dgv.Rows[a].Cells[cell_name].Value.ToString());
                    Console.WriteLine(dgvfloat + "米");

                    //dgvint = Convert.ToInt32(dgvfloat);
                    //dgv.Rows[a].Cells[cell_name].Value = dgvint.ToString();
                    dgv.Rows[a].Cells[cell_name].Value = (string.Format("{0:f}",CS.Float_ToHexString(dgvfloat)));
                }
                else
                {
                    dgvfloat = Convert.ToSingle(dgv.Rows[a].Cells[cell_name].Value.ToString());
                    
                    dgv.Rows[a].Cells[cell_name].Value = Convert.ToInt16(dgvfloat);
                }

                debug.AppendText(EN.NewLine + a.ToString() + "リスト");
            }
        }
    }
}
