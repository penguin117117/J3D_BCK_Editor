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
    
    public class BCK_System : BCK_State
    {//{ "scaleX", "rotateX", "transX", "scaleY", "rotateY", "transY", "scaleZ", "rotateZ", "transZ" } 翻訳専用
        public static string[] xyzstate = { "倍率X", "回転X", "位置X", "倍率Y", "回転Y", "位置Y", "倍率Z", "回転Z", "位置Z" };
        public static string joint_name_str = "ジョイント";

        public struct frame_data 
        {
            public int key_frame;
            public int start_frame;
            public int tangent_mode;
            public frame_data(int kf , int sf ,int tm) 
            {
                this.key_frame = kf;
                this.start_frame = sf;
                this.tangent_mode = tm;
            }
        }

        public struct SRT_data
        {
            public frame_data sca;
            public frame_data rot;
            public frame_data tra;
            public SRT_data(frame_data a , frame_data b ,frame_data c)
            {
                this.sca = a;
                this.rot = b;
                this.tra = c;
            }
        }

        public struct XYZ_data 
        {
            public SRT_data X;
            public SRT_data Y;
            public SRT_data Z;
            public XYZ_data(SRT_data x , SRT_data y , SRT_data z ) 
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }
        }

        public static List<XYZ_data> Joint_Data = new List<XYZ_data>();

        /// <summary>
        /// BCKファイルからアニメーションテーブルを読み込みます<br/>
        /// <remarks>Animation_Table_File_Reader(バイナリリード)</remarks>
        /// </summary>
        /// 
        public void Animation_Table_File_Reader(BinaryReader br)
        {
            
            for (int i = 0; i < Bone_Num; i++)
            {
                XYZ_data joint = new XYZ_data();
                frame_data[] fd = new frame_data[9];
                for (int j = 0; j < 9; j++)
                {
                    var cell_1 = joint_name_str + i;
                    var cell_3 = CS.Byte2Int(br, 2);
                    var cell_4 = CS.Byte2Int(br, 2);
                    var cell_5 = CS.Byte2Int(br, 2);
                    dgv1.Rows.Add(cell_1, xyzstate[j], cell_3, cell_4, cell_5);
                    fd[j] = new frame_data(cell_3,cell_4,cell_5);
                }
                joint.X = new SRT_data(fd[0], fd[1], fd[2]);
                joint.Y = new SRT_data(fd[3], fd[4], fd[5]);
                joint.Z = new SRT_data(fd[6], fd[7], fd[8]);
                Joint_Data.Add(joint);
                
            }
            
        }
        /// <summary>
        /// BCKファイルのパディング分ﾊﾞｲﾅﾘﾘｰﾄﾞｽﾄﾘｰﾑを進めます<br/>
        /// <remarks>Padding(進めたいﾊﾞｲﾅﾘﾘｰﾄﾞ、ﾌｧｲﾙｽﾄﾘｰﾑの位置(ling型))</remarks>
        /// </summary>
        /// 
        public void Padding(BinaryReader br,long fs)
        {
            string ps = "";
            for (long k = fs; (k % 32f) != 0; k++)
            {
                ps += CS.Byte2Char(br, 1);
            }
            Debugger.Append(EN.NewLine + ps);
        }



        /// <summary>
        /// ｱﾆﾒｰｼｮﾝﾃｰﾌﾞﾙをBCKバイナリに書き込む<br/>
        /// <remarks>Anim_Writer(ﾊﾞｲﾅﾘﾗｲﾀｰ)</remarks>
        /// </summary>
        /// 
        public void Anim_Writer(BinaryWriter bw )
        {
            int dgv1_row_total = dgv1.Rows.Count;
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
                CS.ToHexString(dgv.Rows[i].Cells[Column_Name].Value.ToString());
                bw.Write(
                    CS.StringToBytes(
                    CS.Float_ToHexString_2(
                      float.Parse(
                        string.Format("{0:0.##########}", dgv.Rows[i].Cells[Column_Name].Value.ToString()),CultureInfo.InvariantCulture.NumberFormat
                            )
                          )
                        )
                    );
            }
        }

        public void Rotate_Writer(BinaryWriter bw, DataGridView dgv, string Column_Name) 
        {
            int dgv_row_total = dgv.Rows.Count;
            for (int i = 0; i < dgv_row_total ; i++)
            {
                bw.Write(CS.StringToBytes(
                    CS.Int16_ToHexString(
                        Convert.ToInt16(
                           float.Parse(
                               string.Format("{0:0.##########}", dgv.Rows[i].Cells[Column_Name].Value.ToString()), CultureInfo.InvariantCulture.NumberFormat)
                               )
                            )
                        )
                    );
            }
        }




        public void Padding_Writer(BinaryWriter bw,long bw_pos)
        {
            int i = 0;
            byte[] pad = System.Text.Encoding.ASCII.GetBytes("Made by Penguin Made by J3DBCK ") ;
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
        /// ﾀｲﾌﾟﾅﾝﾊﾞｰ：0 ｽｹｰﾙ :1 ﾛｰﾃｰｼｮﾝ :2 ﾄﾗﾝｽﾚｰｼｮﾝ
        /// </summary>
        /// 
        public void Mode_Checker(int bones , int type_num　, bool dgv_write ,bool plot_reader = false) 
        {
            if (type_num == 0) com1.Items.Clear();
            if (type_num == 1) com2.Items.Clear();
            if (type_num == 2) com3.Items.Clear();
            rotList_Num = new int[bones*9];
            rotList_Start = new int[bones * 9];
            rotList_Tangent = new int[bones * 9];
            scaleList_Num = new int[bones * 9];
            scaleList_Start = new int[bones * 9];
            scaleList_Tangent = new int[bones * 9];
            transList_Num = new int[bones * 9];
            transList_Start = new int[bones * 9];
            transList_Tangent = new int[bones * 9];

            string Bone_Num_And_XYZ = "";
            for (int c = type_num; (bones * 9) > c; c = c + 3)
            {
                Bone_Num_And_XYZ = (dgv1.Rows[c].Cells["BoneNum"].Value.ToString()+"_"+ dgv1.Rows[c].Cells["XYZ_State"].Value.ToString());
                Debugger.Append(dgv1.Rows[c].Cells["BoneNum"].Value.ToString() + "_" + dgv1.Rows[c].Cells["XYZ_State"].Value.ToString());
                Frame_Num_String = dgv1.Rows[c].Cells["Frame_Num"].Value.ToString();
                Start_Frame_String = dgv1.Rows[c].Cells["Start_Frame"].Value.ToString();
                Tangent_String = dgv1.Rows[c].Cells["Tangent_Mode"].Value.ToString();
                Frame_Num_Int = Convert.ToInt32(Frame_Num_String);
                Start_Frame_Int = Convert.ToInt32(Start_Frame_String);
                Tangent_Int = Convert.ToInt32(Tangent_String);
                
                bool write_read = dgv_write;
                if (type_num == 1)
                {
                    
                    com2.Items.Add(Bone_Num_And_XYZ);
                    if (plot_reader == false) { Rot_Mode(write_read); }
                    else
                    {
                        rotList_Num[c] = Frame_Num_Int;
                        rotList_Start[c] = Start_Frame_Int;
                        rotList_Tangent[c] = Tangent_Int;
                        
                    }
                }
                else if (type_num == 0)
                {
                    
                    com1.Items.Add(Bone_Num_And_XYZ);
                    if (plot_reader == false)
                    {
                        Scale_Trans_Mode(dgv_write, dgv2, "Scale_Value");
                    }
                    else
                    {
                        scaleList_Num[c] = Frame_Num_Int;
                        scaleList_Start[c] = Start_Frame_Int;
                        scaleList_Tangent[c] = Tangent_Int;

                    }

                }
                else if (type_num == 2)
                {
                    com3.Items.Add(Bone_Num_And_XYZ);
                    if (plot_reader == false)
                    {
                        Scale_Trans_Mode(dgv_write, dgv4, "Translation_Value" ,2);
                    }
                    else
                    {
                        transList_Num[c] = Frame_Num_Int;
                        transList_Start[c] = Start_Frame_Int;
                        transList_Tangent[c] = Tangent_Int;

                    }
                }
            }
            if (plot_reader == true) 
            {
                int rc = 0;

                if (type_num == 1)
                {
                    Plot_List_Rot_Combo.Clear();
                    foreach (var y in rotList_Num.Select((value, index) => new { value, index }))
                    {
                        if ((y.value != 0) && (y.value > 0))
                        {
                            Plot_List_Rot_Combo.Add(new List<int>());
                            Plot_List_Rot_Combo[rc].Add(rotList_Start[y.index]);
                            Plot_List_Rot_Combo[rc].Add(rotList_Num[y.index]);
                            Plot_List_Rot_Combo[rc].Add(rotList_Tangent[y.index]);
                            rc++;
                        }
                    }
                }
                if (type_num == 0)
                {
                    Plot_List_Scale_Combo.Clear();
                    foreach (var y in scaleList_Num.Select((value, index) => new { value, index }))
                    {
                        if ((y.value != 0) && (y.value > 0))
                        {
                            Plot_List_Scale_Combo.Add(new List<int>());
                            Plot_List_Scale_Combo[rc].Add(scaleList_Start[y.index]);
                            Plot_List_Scale_Combo[rc].Add(scaleList_Num[y.index]);
                            Plot_List_Scale_Combo[rc].Add(scaleList_Tangent[y.index]);
                            rc++;
                        }
                    }
                }
                if (type_num == 2)
                {
                    Plot_List_Trans_Combo.Clear();
                    foreach (var y in transList_Num.Select((value, index) => new { value, index }))
                    {
                        if ((y.value != 0) && (y.value > 0))
                        {
                            Plot_List_Trans_Combo.Add(new List<int>());
                            Plot_List_Trans_Combo[rc].Add(transList_Start[y.index]);
                            Plot_List_Trans_Combo[rc].Add(transList_Num[y.index]);
                            Plot_List_Trans_Combo[rc].Add(transList_Tangent[y.index]);
                            rc++;
                        }
                    }
                }
            }
        }
        public void Rot_Mode(bool dgv_write) 
        {
            int[] rotList = new int[dgv3.Rows.Count];
            float dgv3float;
            if (Tangent_String == "0" && Frame_Num_String == "1")
            {
                rotList[Start_Frame_Int] = Start_Frame_Int ;
            }
            else if (Tangent_String == "0" && (Start_Frame_Int > 0) && (Frame_Num_Int > 1))
            {
                for (int i = (Start_Frame_Int +1); (Start_Frame_Int +1) + (Frame_Num_Int * 3) > i; i = i + 3)
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

            //int frac = 1;
            //int from_txt_frac= Int32.Parse( Txt_Rot_Frac.Text);
            //for (int f = 0; f < from_txt_frac; f++) 
            //{
            //    if (f!=0) { frac = frac*10; }
            //}

            
            foreach (int a in rotList)
            {
                if (dgv_write　== true)
                {
                    dgv3float = Convert.ToSingle(dgv3.Rows[a].Cells["Rotation_Value"].Value.ToString());
                    dgv3float = (dgv3float / 182);
                    dgv3.Rows[a].Cells["Rotation_Value"].Value = dgv3float.ToString("F10");

                    
                }
                else
                {
                    //Debugger.Append(dgv3.Rows[a].Cells["Rotation_Value"].Value.ToString());
                    dgv3float = float.Parse(dgv3.Rows[a].Cells["Rotation_Value"].Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);

                    dgv3float = (dgv3float )*182;
                    //dgv3.Rows[a].Cells["Rotation_Value"].Value = Convert.ToInt16(dgv3float);
                    dgv3.Rows[a].Cells["Rotation_Value"].Value = (Int16)dgv3float;
                }


            }
        }

        public void Scale_Trans_Mode(bool dgv_write ,DataGridView dgv ,string cell_name ,int dgvtype = 0)
        {
            int[] S_T_List = new int[dgv.Rows.Count];
            float dgvfloat;

            if (Tangent_String == "0" && Frame_Num_String == "1")
            {
                S_T_List[Start_Frame_Int] = Start_Frame_Int;
            }
            else if (Tangent_String == "0" && (Start_Frame_Int > 0) && (Frame_Num_Int > 1))
            {
                for (int j = (Start_Frame_Int + dgvtype); (Start_Frame_Int + dgvtype) + (Frame_Num_Int * 3) > j; j = j + 3)
                {
                    S_T_List[j] = j;
                    //j++;
                    //S_T_List[j] = j;

                }
            }
            else if (Tangent_String == "1" && Frame_Num_String != "1")
            {
                for (int j = (Start_Frame_Int + dgvtype); (Start_Frame_Int + dgvtype) + (Frame_Num_Int * 4) > j; j = j + 4)
                {
                    S_T_List[j] = j;
                    //j++;
                    //S_T_List[j] = j;
                }
            }

            S_T_List = S_T_List.Where(x => x != 0).ToArray();
            foreach (int a in S_T_List)
            {
                if (dgv_write == true)
                {
                    //dgvfloat = Convert.ToSingle(dgv.Rows[a].Cells[cell_name].Value.ToString());
                    //dgvfloat = float.Parse(dgv.Rows[a].Cells[cell_name].Value.ToString());
                    //dgv.Rows[a].Cells[cell_name].Value = (string.Format("{0}", CS.Float_ToHexString(dgvfloat)));
                    //dgv.Rows[a].Cells[cell_name].Value = dgvfloat.ToString("F10");
                }
                else
                {
                    dgvfloat = Convert.ToSingle(dgv.Rows[a].Cells[cell_name].Value.ToString());
                    //dgv.Rows[a].Cells[cell_name].Value = Convert.ToInt16(dgvfloat);
                    dgv.Rows[a].Cells[cell_name].Value = (Int16)dgvfloat;
                }

                //Debugger.Append(EN.NewLine + a.ToString() + "リスト");
            }
        }
    }
}
