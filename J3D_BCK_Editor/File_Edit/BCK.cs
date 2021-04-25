using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using EN = System.Environment;
using CS = J3D_BCK_Editor.File_Edit.Calculation_System;

namespace J3D_BCK_Editor.File_Edit
{
    class BCK_State
    {
        public static TextBox debug = Form1.Form1Instance.デバッグ;
        public static TextBox Txt_Bone_Num = Form1.Form1Instance.Bone_Num;
        public static TextBox Txt_Rot_Frac = Form1.Form1Instance.Txt_Rot_Frac;
        public static TextBox Txt_Roop_Mode = Form1.Form1Instance.Txt_Roop_Mode;
        public static TextBox Txt_Total_Frame = Form1.Form1Instance.Total_Frame;
        public static DataGridView dgv1 = Form1.Form1Instance.dataGridView1;
        public static DataGridView dgv2 = Form1.Form1Instance.dataGridView2;
        public static DataGridView dgv3 = Form1.Form1Instance.dataGridView3;
        public static DataGridView dgv4 = Form1.Form1Instance.dataGridView4;
        public static PictureBox pic1 = Form1.Form1Instance.pictureBox1;
        public static ComboBox com1 = Form1.Form1Instance.comboBox1;

        public static List<string> Anim_scale_str = new List<string>();
        public static List<string> Anim_rotation_str = new List<string>();

        //▽宣言
        protected byte[] BinaryRead;

        //▽J3Dヘッダー
        protected static string Magic_1;
        protected static string Magic_2;
        protected static int File_Size;
        protected static int Chunk_Count;
        protected static string Subversion;
        protected static string padding;

        //public string Magic_1
        //{
        //    set { magic_1 = value; }
        //    get { return magic_1; }
        //}


        //▽ANK1ヘッダー
        protected static string Chunk_Type;
        protected static int Anim_Size;
        protected static int Roop_Mode;
        protected static int Rotation_Frac;
        protected static int Frame_Num;
        protected static int Bone_Num;
        protected static int Scale_Table_Count;
        protected static int Rotation_Table_Count;
        protected static int Translation_Table_Count;
        protected static int Animation_Data_Table_Offset;
        protected static int Scale_Table_Offset;
        protected static int Rotation_Table_Offset;
        protected static int Translation_Table_Offset;
        protected static string Padding_Data_1;

        protected static int padnum;
        protected static int padcount;

        protected static string[] debugstr = { "_animtable_","__" };
        protected static int debugnum = 0;


        protected static string Frame_Num_String, Start_Frame_String, Tangent_String;
        protected static int Frame_Num_Int, Start_Frame_Int, Tangent_Int;

        protected static List<List<int>> Plot_List_Rot_Combo = new List<List<int>>();
        
        //protected static List<int> Plot_List_AnimNum = new List<int>();
        
        //protected static List<int> Plot_List_AnimData = new List<int>();

        protected static int[] rotList_Num, rotList_Start, rotList_Tangent;
    }

    class BCK:BCK_State
    {
        /// <summary>
        /// BCKを読み込む
        /// <remarks>Filecheck(<param name="filepath">対象のファイルのパス</param>)</remarks>
        /// </summary>
        /// 
        /// <returns>なし</returns>
        public  void Reader(string filepath)
        {
         //初期化
            dgv1.Rows.Clear();
            dgv2.Rows.Clear();
            dgv3.Rows.Clear();
            dgv4.Rows.Clear();
            debugnum = 0;

         //★処理開始
         //★バイナリ読み込み
            FileStream fs = new FileStream(filepath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
         //★J3Dヘッダー
            Magic_1 = CS.Byte2Char(br);
            Magic_2 = CS.Byte2Char(br);
            File_Size = CS.Byte2Int(br);
            Chunk_Count = CS.Byte2Int(br);
            Subversion = CS.Byte2Char(br);
            padding = CS.Byte2Char(br,12);
         //★ANK1ヘッダー
            Chunk_Type = CS.Byte2Char(br);
            Anim_Size  = CS.Byte2Int(br);
            Roop_Mode = CS.Byte2Int(br,1);
            Rotation_Frac = CS.Byte2Int(br, 1);
            Frame_Num = CS.Byte2Int(br, 2);
            Bone_Num = CS.Byte2Int(br, 2);
            Scale_Table_Count = CS.Byte2Int(br, 2);
            Rotation_Table_Count = CS.Byte2Int(br, 2);
            Translation_Table_Count = CS.Byte2Int(br, 2);
            Animation_Data_Table_Offset = CS.Byte2Int(br);
            Scale_Table_Offset = CS.Byte2Int(br);
            Rotation_Table_Offset = CS.Byte2Int(br);
            Translation_Table_Offset = CS.Byte2Int(br);
            Padding_Data_1 = CS.Byte2Char(br,28);
            //★値をテキストボックスに
            Txt_Roop_Mode.Text = Roop_Mode.ToString();
            Txt_Bone_Num.Text = Bone_Num.ToString();
            Txt_Rot_Frac.Text = Rotation_Frac.ToString();
            Txt_Total_Frame.Text = Frame_Num.ToString();


         //★デバッガー
            //j3d
            debug.AppendText ( "マジック1："+ Magic_1);
            debug.AppendText("\r\n" + "マジック2：" + Magic_2);
            debug.AppendText("\r\n" + "ファイルサイズ：" + File_Size);
            debug.AppendText("\r\n" + "チャンクカウント：" + Chunk_Count);
            debug.AppendText("\r\n" + "サブバージョン：" + Subversion);
            debug.AppendText("\r\n" + "パディング：" + padding);
            //ank1
            debug.AppendText("\r\n" + "チャンクタイプ：" + Chunk_Type);
            debug.AppendText("\r\n" + "アニメーションサイズ：" + Anim_Size);
            debug.AppendText("\r\n" + "ループモード：" + Roop_Mode);
            debug.AppendText("\r\n" + "回転フラク？：" + Rotation_Frac);
            debug.AppendText("\r\n" + "フレーム数：" + Frame_Num);
            debug.AppendText("\r\n" + "ボーン数：" + Bone_Num);
            debug.AppendText("\r\n" + "スケールテーブルカウント：" + Scale_Table_Count);
            debug.AppendText("\r\n" + "ローテーションテーブルカウント：" + Rotation_Table_Count);
            debug.AppendText("\r\n" + "トランスレートテーブルカウント：" + Translation_Table_Count);
            debug.AppendText("\r\n" + "アニメーションオフセット：" + Animation_Data_Table_Offset);
            debug.AppendText("\r\n" + "スケールテーブルオフセット：" + Scale_Table_Offset);
            debug.AppendText("\r\n" + "ローテーションテーブルオフセット：" + Rotation_Table_Offset);
            debug.AppendText("\r\n" + "トランスレートテーブルオフセット：" + Translation_Table_Offset);
            debug.AppendText("\r\n" + "paddingdata：" + Padding_Data_1);

            //BCKクラスインスタンス作成
            BCK_System bcksys = new BCK_System();
            bcksys.protecttest();
            //アニメーショングリッドに書き込み
            bcksys.Animation_Table_File_Reader(br);

            padnum = (Bone_Num * 9 * 6);
            padcount = 0;

         //★パディング2
            bcksys.Padding(br);

         //★scaletable
            for (int l = 0;l<Scale_Table_Count;l++) 
            {
                //dgv2.Rows.Add(l, string.Format("{0:f10}", CS.hex2float(br)));
                Console.WriteLine("▽現在"+fs.Position);
                dgv2.Rows.Add(l, string.Format("{0:}", CS.FromHexString(br)));
            }
            
            padnum =  padnum + 96+padcount;
            padcount = 0;
         //★パディング3
            debug.AppendText("\r\n");
            Console.WriteLine(padnum +((Scale_Table_Count)*4 )+"mmmmm");
            for (int k = padnum +((Scale_Table_Count)*4); (k % 32f) != 0; k++)
            {
                debug.AppendText(CS.Byte2Char(br, 1));
                padcount++;
                
            }

         //★rottable
            int rottes=0;
            string rotfnc;
            string rotsfc;
            string rottanc;
            int rotfnn;
            int rotsfn;
            int rottann;
            string dgv3str;
            int dgv3int;
            short dgv3short;
            float dgv3float;
            for (int l = 0; l < Rotation_Table_Count; l++)
            {
                //Start_Frame Tangent_Mode
                //rottes = CS.Byte2Int(br, 2);
                //Console.WriteLine(rottes);

                

                dgv3.Rows.Add(l, string.Format("{0}", CS.Byte2Short_noPI(br)));
                //debug.AppendText(EN.NewLine + "_?_?_?_"+ string.Format("{0}", CS.Byte2Short_noPI(br)));

            }
            bcksys.Mode_Checker(Bone_Num,1,true);
            bcksys.Mode_Checker(Bone_Num, 1, true ,true);

            //for (int m = 1; (Bone_Num*9) > m;　m=m+3)
            //{
            //    rotfnc  = dgv1.Rows[m].Cells["Frame_Num"].Value.ToString();
            //    rotsfc  = dgv1.Rows[m].Cells["Start_Frame"].Value.ToString();
            //    rottanc = dgv1.Rows[m].Cells["Tangent_Mode"].Value.ToString();
            //    rotfnn = Convert.ToInt32(rotfnc);
            //    rotsfn = Convert.ToInt32(rotsfc);
            //    rottann = Convert.ToInt32(rottanc);
            //    Console.WriteLine(rotfnc+"★"+rotsfc+"★"+rottanc+"チェッカー");

            //    if (rottanc == "0" && rotfnc == "1")
            //    {
            //        Console.WriteLine("if01");
            //        dgv3float = Convert.ToSingle(dgv3.Rows[rotsfn].Cells["Rotation_Value"].Value.ToString());
            //        dgv3float = dgv3float / 182;
            //        dgv3.Rows[rotsfn].Cells["Rotation_Value"].Value = dgv3float;
            //    }
            //    else if (rottanc == "0" && (rotsfn  >0) && (rotfnn > 1))
            //    {
            //        Console.WriteLine("if02");
            //        Console.WriteLine(rotfnn + "★" + rotsfn + "★" + rottann + "チェッカー");

            //        for (int i = (rotsfn+1 ); (rotsfn+1 ) + (rotfnn*3) > i; i = i +3)
            //        {
            //            Console.WriteLine("if02");
            //            Console.WriteLine(i+"num");
            //            Console.WriteLine(rottanc + "＼(^o^)／ｵﾜﾀ" + rotsfn + "＼(^o^)／ｵﾜﾀ" + rotfnn+"★"+ dgv3.Rows[i].Cells["Rotation_Value"].Value.ToString());
            //            dgv3float = Convert.ToSingle(dgv3.Rows[i].Cells["Rotation_Value"].Value.ToString());
            //            dgv3float = dgv3float / 182;
            //            dgv3.Rows[i].Cells["Rotation_Value"].Value = Convert.ToSingle( dgv3float);
            //            dgv3.Rows[i].Cells["Rot_Element"].Value = "値_Sym";
            //        }

            //    }
            //    else if (rottanc == "1" && rotfnc != "1")
            //    {
            //        for (int j = (rotsfn + 1); (rotsfn + 1) + (rotfnn * 4) > j; j = j + 4)
            //        {
            //            Console.WriteLine(rotsfn + "＼(^o^)／" + rotfnn);
            //            dgv3float = Convert.ToSingle(dgv3.Rows[j].Cells["Rotation_Value"].Value.ToString());
            //            dgv3float = dgv3float / 182;
            //            dgv3.Rows[j].Cells["Rotation_Value"].Value = dgv3float;
            //            dgv3.Rows[j].Cells["Rot_Element"].Value = "値_Tan";

            //        }
            //    }
            //    else { Console.WriteLine(rottanc + "／(^o^)＼ﾅﾝﾃｺｯﾀｲ" + rotsfn + "＼(^o^)／ｵﾜﾀ" + rotfnn); }

            //}

            //if (rottanc == "0" && rotfnc == "1")
            //{

            //}
            


            Console.WriteLine(padnum);
            padnum = padnum  + padcount+ Scale_Table_Count*4;
            padcount = 0;
         //★パディング4
            debug.AppendText("\r\n");
            Console.WriteLine(padnum + ((Rotation_Table_Count) * 2) + "mmmmm");
            for (int k = padnum + ((Rotation_Table_Count) * 2); (k % 32f) != 0; k++)
            {
                debug.AppendText(CS.Byte2Char(br, 1));
                padcount++;
            }

         //★transtable
            for (int l = 0; l < Translation_Table_Count; l++)
            {
                dgv4.Rows.Add(l, string.Format("{0:f}", CS.Byte2Float(br)));
                padcount = padcount + 4;
            }


            //bcksys.Mode_Checker(Bone_Num, 2, true);

            padnum = padnum + padcount;
            padcount = 0;
            debug.AppendText("\r\n");
            Console.WriteLine(padnum + ((Rotation_Table_Count) * 2) + "mmmmm");
            for (int k = padnum + ((Rotation_Table_Count) * 2); (k % 32f) != 0; k++)
            {
                debug.AppendText(CS.Byte2Char(br, 1));
                padcount++;
            }

            fs.Close();
            br.Close();
        }
        public void Create() 
        {
            
        }
        public void Write(string filepath) 
        {
            FileStream fs = new FileStream(filepath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            //J3Dヘッダー
            bw.Write(Encoding.ASCII.GetBytes("J3D1"));
            bw.Write(Encoding.ASCII.GetBytes("bck1"));
            bw.Write(CS.StringToBytes((0).ToString("X8")));//チャンクサイズ
            bw.Write(CS.StringToBytes((1).ToString("X8")));//chunc count 1固定
            bw.Write(BitConverter.GetBytes(0xFFFFFFFF));//padding 16byte すべてFF 固定
            bw.Write(BitConverter.GetBytes(0xFFFFFFFF));
            bw.Write(BitConverter.GetBytes(0xFFFFFFFF));
            bw.Write(BitConverter.GetBytes(0xFFFFFFFF));
            //チャンクヘッダー
            int Ank1_pos = Convert.ToInt32(fs.Position);
            bw.Write(Encoding.ASCII.GetBytes("ANK1"));
            
            bw.Write(BitConverter.GetBytes(0x00000000));
            bw.Write(CS.StringToByte(Txt_Roop_Mode.Text));//roopmode
            bw.Write(CS.StringToByte(Txt_Rot_Frac.Text));//rotfrac
            bw.Write(CS.StringToShort_byte(Txt_Total_Frame.Text));//フレーム数
            bw.Write(CS.StringToShort_byte(Txt_Bone_Num.Text));//ボーン数
            bw.Write(CS.StringToShort_byte((dgv2.Rows.Count-1).ToString()));//sca count
            bw.Write(CS.StringToShort_byte((dgv3.Rows.Count-1).ToString()));//rot count
            bw.Write(CS.StringToShort_byte((dgv4.Rows.Count - 1).ToString()));//tra count
            bw.Write(CS.StringToBytes((0x40).ToString("X8")));//anim offset
            bw.Write(BitConverter.GetBytes(0x00000000));//sca offset
            bw.Write(BitConverter.GetBytes(0x00000000));//rot offsett
            bw.Write(BitConverter.GetBytes(0x00000000));//tra offsett
            bw.Write(Encoding.ASCII.GetBytes("This is padding data to alig"));
            //anmtable
            long fs_pos;// = fs.Position;
            BCK_System bcksys = new BCK_System();
            bcksys.Anim_Writer(bw);

            fs_pos = fs.Position;
            bcksys.Padding_Writer(bw,fs_pos);

            //bw.Write(CS.Float_ToHexString());
            int scale_pos = Convert.ToInt32(fs.Position);
            //bcksys.Mode_Checker(Bone_Num, 0, false);
            bcksys.Scale_Trans_Writer(bw,dgv2, "Scale_Value");
            //bcksys.Mode_Checker(Bone_Num, 0, true);
            fs_pos = fs.Position;

            bcksys.Padding_Writer(bw, fs_pos);

            bcksys.Mode_Checker((Int16.Parse(Txt_Bone_Num.Text)),1,false);
            int rotation_pos = Convert.ToInt32(fs.Position);
            bcksys.Rotate_Writer(bw,dgv3, "Rotation_Value");
            bcksys.Mode_Checker((Int16.Parse(Txt_Bone_Num.Text)), 1, true);

            fs_pos = fs.Position;
            bcksys.Padding_Writer(bw, fs_pos);


            //bcksys.Mode_Checker(Bone_Num, 2, false);
            int trans_pos = Convert.ToInt32(fs.Position);
            //bcksys.Scale_Trans_Writer(bw, dgv4, "Translation_Value");
            bcksys.Mode_Checker(Bone_Num, 2, true);

            fs_pos = fs.Position;
            bcksys.Padding_Writer(bw, fs_pos);

            int Ank_Last = Convert.ToInt32(fs.Position);
            
            

            //追記
            bw.Seek(0x8,SeekOrigin.Begin);
            bw.Write(CS.StringToBytes((Ank_Last).ToString("X8")));

            bw.Seek(0x38, SeekOrigin.Begin);
            bw.Write(CS.StringToBytes((scale_pos-Ank1_pos).ToString("X8")));

            bw.Seek(0x3C, SeekOrigin.Begin);
            bw.Write(CS.StringToBytes((rotation_pos - Ank1_pos).ToString("X8")));

            bw.Seek(0x40, SeekOrigin.Begin);
            bw.Write(CS.StringToBytes((trans_pos - Ank1_pos).ToString("X8")));

            //書き込みの終了処理
            bw.Close();
            fs.Close();
        }

     


        

        
    }
}
