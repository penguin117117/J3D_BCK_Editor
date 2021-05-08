using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using EN = System.Environment;
using CS = J3D_BCK_Editor.File_Edit.Calculation_System;

namespace J3D_BCK_Editor.File_Edit
{
    class BCK_State
    {
        
        protected static TextBox Txt_Bone_Num = Form1.Form1Instance.Bone_Num;
        protected static TextBox Txt_Rot_Frac = Form1.Form1Instance.Txt_Rot_Frac;
        protected static TextBox Txt_Roop_Mode = Form1.Form1Instance.Txt_Roop_Mode;
        protected static TextBox Txt_Total_Frame = Form1.Form1Instance.Total_Frame;
        protected static DataGridView dgv1 = Form1.Form1Instance.dataGridView1;
        protected static DataGridView dgv2 = Form1.Form1Instance.dataGridView2;
        protected static DataGridView dgv3 = Form1.Form1Instance.dataGridView3;
        protected static DataGridView dgv4 = Form1.Form1Instance.dataGridView4;
        protected static PictureBox pic1 = Form1.Form1Instance.pictureBox1;
        protected static ComboBox com1 = Form1.Form1Instance.comboBox1;
        protected static ComboBox com2 = Form1.Form1Instance.comboBox2;
        protected static ComboBox com3 = Form1.Form1Instance.comboBox3;
        protected static ToolStripStatusLabel tssl2 = Form1.Form1Instance.toolStripStatusLabel2;
        protected static List<string> Anim_scale_str = new List<string>();
        protected static List<string> Anim_rotation_str = new List<string>();
        protected static TextBox txt3 = Form1.Form1Instance.textBox3;
        
        
        //▽宣言
        private static string _magic_1 { get; set; }
        private static string _magic_2 { get; set; }
        private static int _file_size { get; set; }
        
        //▽J3Dヘッダー
        protected string Magic_1
        {
            set
            {
                if (value != "J3D1")value = "J3D1" ;
                _magic_1 = value;
            }
            get { return _magic_1; }
        }

        protected string Magic_2
        {
            set
            {
                if (value != "bck1") value = "bck1";
                _magic_2 = value;
            }
            get { return _magic_2; }
        }

        protected int File_Size 
        {
            set 
            {
                if (value < 0) 
                {
                    value = 1;
                    Debugger.Append("ファイルサイズが 1 以下です");
                }
                _file_size = value;
            }
            get { return _file_size; }
        }


        //protected static string Magic_1;
        //protected static string Magic_2;
        //protected static int File_Size;
        protected static int Chunk_Count;
        protected static string Subversion;
        protected static string padding;

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
        protected static string[] debugstr = { "_animtable_","__" };
        protected static int debugnum = 0;
        protected static string Frame_Num_String, Start_Frame_String, Tangent_String;
        protected static int Frame_Num_Int, Start_Frame_Int, Tangent_Int;
        protected static List<List<int>> Plot_List_Scale_Combo = new List<List<int>>();
        protected static List<List<int>> Plot_List_Rot_Combo = new List<List<int>>();
        protected static List<List<int>> Plot_List_Trans_Combo = new List<List<int>>();
        protected static int[] rotList_Num, rotList_Start, rotList_Tangent;
        protected static int[] scaleList_Num, scaleList_Start, scaleList_Tangent;
        protected static int[] transList_Num, transList_Start, transList_Tangent;
    }

    class BCK:BCK_State
    {
        /// <summary>
        /// BCKファイルを読み込む<br/>
        /// <remarks>Reader(<param name="filepath">対象のファイルのパス</param>)</remarks>
        /// </summary>
        /// 
        /// <returns>なし</returns>
        public void Reader(string filepath)
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
            

         //☆デバッガー
            //☆j3d
            Debugger.Append ( "マジック1："+ Magic_1);
            Debugger.Append("\r\n" + "マジック2：" + Magic_2);
            Debugger.Append("\r\n" + "ファイルサイズ：" + File_Size);
            Debugger.Append("\r\n" + "チャンクカウント：" + Chunk_Count);
            Debugger.Append("\r\n" + "サブバージョン：" + Subversion);
            Debugger.Append("\r\n" + "パディング：" + padding);
            //☆ank1
            Debugger.Append("\r\n" + "チャンクタイプ：" + Chunk_Type);
            Debugger.Append("\r\n" + "アニメーションサイズ：" + Anim_Size);
            Debugger.Append("\r\n" + "ループモード：" + Roop_Mode);
            Debugger.Append("\r\n" + "回転フラク？：" + Rotation_Frac);
            Debugger.Append("\r\n" + "フレーム数：" + Frame_Num);
            Debugger.Append("\r\n" + "ボーン数：" + Bone_Num);
            Debugger.Append("\r\n" + "スケールテーブルカウント：" + Scale_Table_Count);
            Debugger.Append("\r\n" + "ローテーションテーブルカウント：" + Rotation_Table_Count);
            Debugger.Append("\r\n" + "トランスレートテーブルカウント：" + Translation_Table_Count);
            Debugger.Append("\r\n" + "アニメーションオフセット：" + Animation_Data_Table_Offset);
            Debugger.Append("\r\n" + "スケールテーブルオフセット：" + Scale_Table_Offset);
            Debugger.Append("\r\n" + "ローテーションテーブルオフセット：" + Rotation_Table_Offset);
            Debugger.Append("\r\n" + "トランスレートテーブルオフセット：" + Translation_Table_Offset);
            Debugger.Append("\r\n" + "paddingdata：" + Padding_Data_1);

            //★BCKクラスインスタンス作成
            BCK_System bcksys = new BCK_System();

            //★アニメーショングリッドに書き込み
            bcksys.Animation_Table_File_Reader(br);

            //★パディング2
            bcksys.Padding(br,fs.Position);

            //★スケールテーブルグリッドに書き込み
            for (int l = 0;l<Scale_Table_Count;l++) 
            {
                dgv2.Rows.Add(l, string.Format("{0:0.##########}", CS.FromHexString(br)));
                //dgv2.Rows.Add(l, string.Format("{0:F}", CS.Byte2Float(br)));
            }
            //bcksys.Mode_Checker(Bone_Num, 0, true);
            bcksys.Mode_Checker(Bone_Num, 0, true, true);

            //★パディング3
            bcksys.Padding(br,fs.Position);

            //★ローテーションテーブルグリッドに書き込み
            for (int l = 0; l < Rotation_Table_Count; l++)
            {
                dgv3.Rows.Add(l, string.Format("{0}", CS.Byte2Short_noPI(br)));
            }

            bcksys.Mode_Checker(Bone_Num,1,true);
            bcksys.Mode_Checker(Bone_Num, 1, true ,true);

            //★パディング4
            bcksys.Padding(br,fs.Position);

            //★トランスレートテーブルグリッドに書き込み
            for (int l = 0; l < Translation_Table_Count; l++)
            {
                dgv4.Rows.Add(l, string.Format("{0:0.##########}", CS.Byte2Float(br)));
            }
            bcksys.Mode_Checker(Bone_Num, 2, true, true);

            //★パディング5
            bcksys.Padding(br, fs.Position);
         
            //★ファイルストリーム、バイナリリード終了
            fs.Close();
            br.Close();

            //ステータスバー設定
            tssl2.Text = Path.GetFileName(filepath) + "を開きました";
        }

        /// <summary>
        /// BCKファイルにエディタのデータを書き込む<br/>
        /// <remarks>Write(<param name="filepath">対象のファイルのパス</param>)</remarks>
        /// </summary>
        /// <returns>なし</returns>
        public void Write(string filepath) 
        {
            FileStream fs = new FileStream(filepath, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);

            //J3Dヘッダー書き込み
            bw.Write(Encoding.ASCII.GetBytes("J3D1"));
            bw.Write(Encoding.ASCII.GetBytes("bck1"));
            bw.Write(CS.StringToBytes((0).ToString("X8")));//チャンクサイズ
            bw.Write(CS.StringToBytes((1).ToString("X8")));//chunc count 1固定
            bw.Write(BitConverter.GetBytes(0xFFFFFFFF));//padding 16byte すべてFF 固定
            bw.Write(BitConverter.GetBytes(0xFFFFFFFF));
            bw.Write(BitConverter.GetBytes(0xFFFFFFFF));
            bw.Write(BitConverter.GetBytes(0xFFFFFFFF));

            //チャンクヘッダー位置を保存
            int Ank1_pos = Convert.ToInt32(fs.Position);

            //ANK1ヘッダー書き込み
            bw.Write(Encoding.ASCII.GetBytes("ANK1"));
            bw.Write(BitConverter.GetBytes(0x00000000));
            bw.Write(CS.StringToByte(Txt_Roop_Mode.Text));//roopmode
            bw.Write(CS.StringToByte(Txt_Rot_Frac.Text));//rotfrac
            bw.Write(CS.StringToShort_byte(Txt_Total_Frame.Text));//フレーム数
            bw.Write(CS.StringToShort_byte(Txt_Bone_Num.Text));//ボーン数
            bw.Write(CS.StringToShort_byte((dgv2.Rows.Count).ToString()));//sca count
            bw.Write(CS.StringToShort_byte((dgv3.Rows.Count).ToString()));//rot count
            bw.Write(CS.StringToShort_byte((dgv4.Rows.Count).ToString()));//tra count
            bw.Write(CS.StringToBytes((0x40).ToString("X8")));//anim offset
            bw.Write(BitConverter.GetBytes(0x00000000));//sca offset
            bw.Write(BitConverter.GetBytes(0x00000000));//rot offsett
            bw.Write(BitConverter.GetBytes(0x00000000));//tra offsett
            bw.Write(Encoding.ASCII.GetBytes("Made by Penguin Made by J3DB"));
            
            //BCK_Systemクラスのインスタンス作成
            BCK_System bcksys = new BCK_System();

            //ｱﾆﾒｰｼｮﾝﾃｰﾌﾞﾙを書き込む
            bcksys.Anim_Writer(bw);

            //パディングを書き込む
            bcksys.Padding_Writer(bw, fs.Position);

            //ｽｹｰﾙﾃｰﾌﾞﾙを書き込む
            int scale_pos = Convert.ToInt32(fs.Position);
            bcksys.Scale_Trans_Writer(bw,dgv2, "Scale_Value");
            
            //パディングを書き込む
            bcksys.Padding_Writer(bw, fs.Position);

            //ﾛｰﾃｰｼｮﾝﾃｰﾌﾞﾙの書き込みと設定
            bcksys.Mode_Checker((Int16.Parse(Txt_Bone_Num.Text)),1,false);
            int rotation_pos = Convert.ToInt32(fs.Position);
            bcksys.Rotate_Writer(bw,dgv3, "Rotation_Value");
            bcksys.Mode_Checker((Int16.Parse(Txt_Bone_Num.Text)), 1, true);

            //パディングを書き込む
            bcksys.Padding_Writer(bw, fs.Position);

            //ﾄﾗﾝｽﾚｰﾄﾃｰﾌﾞﾙの書き込み
            int trans_pos = Convert.ToInt32(fs.Position);
            bcksys.Scale_Trans_Writer(bw, dgv4, "Translation_Value");
            
            //パディングを書き込み
            bcksys.Padding_Writer(bw, fs.Position);

            //チャンク末尾を記録
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

            //ステータスバー設定
            tssl2.Text = Path.GetFileName(filepath)+"を保存しました";
        }

     


        

        
    }
}
