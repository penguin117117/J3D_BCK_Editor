using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN = System.Environment;

using System.Windows.Forms;
using J3D_BCK_Editor.File_Edit;


namespace J3D_BCK_Editor
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            
            InitializeComponent();

            // dataGridView1 の すべてのカラムで ソート を 無効化
            foreach (DataGridViewColumn column in this.dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in this.dataGridView2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in this.dataGridView3.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in this.dataGridView4.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
            dataGridView4.AutoGenerateColumns = false;

            
        }

        //インスタンスの作成
        private static Form1 _form1Instance;
        public static Form1 Form1Instance
        {
            get
            {
                return _form1Instance;
            }
            set
            {
                _form1Instance = value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form1のインスタンスの作成
            Form1 f = new Form1();
            Form1.Form1Instance = f;
            Form1.Form1Instance = this;

            debugger.Enabled = false;
            tabControl1.TabPages.Remove(tabPage6);

            //コマンドライン引数を配列で取得する
            string[] files = System.Environment.GetCommandLineArgs();

            if (files.Length > 1) File_Select.Filecheck(files[1]);

            FormReload();

        }

        private void FormReload() 
        {
            
            

            if (Properties.Settings.Default.language == "English")
            {
                English();
            }
            else 
            {
                if (Controls.Count > 0)
                {
                    Controls.Clear();
                }
                InitializeComponent();
                // dataGridView1 の すべてのカラムで ソート を 無効化
                foreach (DataGridViewColumn column in this.dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                foreach (DataGridViewColumn column in this.dataGridView2.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                foreach (DataGridViewColumn column in this.dataGridView3.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                foreach (DataGridViewColumn column in this.dataGridView4.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                dataGridView1.AutoGenerateColumns = false;
                dataGridView2.AutoGenerateColumns = false;
                dataGridView3.AutoGenerateColumns = false;
                dataGridView4.AutoGenerateColumns = false;
            }
            
        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File_Select.Dialog();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File_Select.file_save();
        }

        private void Add_Bone_Click(object sender, EventArgs e)
        {
            //string[] xyzstate = { "scaleX", "rotateX", "transX", "scaleY", "rotateY", "transY", "scaleZ", "rotateZ", "transZ" };
            
                for (int j = 0; j < 9; j++)
                { 
                    dataGridView1.Rows.Add(BCK_System.joint_name_str, BCK_System.xyzstate[j], 1, 0, 0);
                }

            for (int k =0;k < dataGridView1.Rows.Count; k+=9) 
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1.Rows[k+j].Cells["BoneNum"].Value = BCK_System.joint_name_str + (k/9);
                }
            }
        }

        private void BoneDelete_Click(object sender, EventArgs e)
        {
            if ((dataGridView1.Rows.Count  > 8))
            {
                for (int j = 0; j < 9; j++)
                {

                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                }
            }
        }

        private void ScaleAdd_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(dataGridView2.Rows.Count,string.Format("{0:f1}",1.0));
        }

        private void ScaleDelete_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count>0)
            dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count -1);
        }

        private void RotatinAdd_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Add(dataGridView3.Rows.Count, string.Format("{0:}", 0));
        }

        private void RotationDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
                dataGridView3.Rows.RemoveAt(dataGridView3.Rows.Count - 1);
        }

        private void TranslationAdd_Click(object sender, EventArgs e)
        {
            dataGridView4.Rows.Add(dataGridView4.Rows.Count, string.Format("{0:f1}", 1.0));
        }

        private void TranslationDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count > 0)
                dataGridView4.Rows.RemoveAt(dataGridView4.Rows.Count - 1);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if ((dataGridView1.Rows.Count ==0)|| (dataGridView2.Rows.Count == 0) || (dataGridView3.Rows.Count == 0) || (dataGridView4.Rows.Count == 0)) 
            {
                return;
            }
            //★BCKクラスインスタンス作成
            BCK_System bcksys = new BCK_System();
            bcksys.Mode_Checker(Int16.Parse(Bone_Num.Text), 0, true, true);
            bcksys.Mode_Checker(Int16.Parse(Bone_Num.Text), 1, true, true);
            bcksys.Mode_Checker(Int16.Parse(Bone_Num.Text), 2, true, true);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((dataGridView1.Rows.Count == 0) || (dataGridView2.Rows.Count == 0) || (dataGridView3.Rows.Count == 0) || (dataGridView4.Rows.Count == 0))
            {
                return;
            }
            
            
            Plot pt = new Plot();
            textBox3.Text = "アニメーションテーブルの" + EN.NewLine + comboBox1.Text + EN.NewLine + "を参照" + EN.NewLine + EN.NewLine;
            pt.Draw(pictureBox1,dataGridView2 , "Scale_Value", float.Parse(textBox1.Text), float.Parse(textBox2.Text));
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


        }

       

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((dataGridView1.Rows.Count == 0) || (dataGridView2.Rows.Count == 0) || (dataGridView3.Rows.Count == 0) || (dataGridView4.Rows.Count == 0))
            {
                return;
            }
            
            
            Plot pt = new Plot();
            textBox3.Text = "アニメーションテーブルの" + EN.NewLine + comboBox2.Text + EN.NewLine +"を参照" +EN.NewLine+EN.NewLine;
            pt.Draw(pictureBox1, dataGridView3, "Rotation_Value", float.Parse(textBox1.Text), float.Parse(textBox2.Text));
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((dataGridView1.Rows.Count == 0) || (dataGridView2.Rows.Count == 0) || (dataGridView3.Rows.Count == 0) || (dataGridView4.Rows.Count == 0))
            {
                return;
            }
            
            Plot pt = new Plot();
            textBox3.Text ="アニメーションテーブルの" + EN.NewLine + comboBox3.Text + EN.NewLine + "を参照" + EN.NewLine + EN.NewLine;
            pt.Draw(pictureBox1, dataGridView4, "Translation_Value", float.Parse(textBox1.Text), float.Parse(textBox2.Text));
        }
        protected int testnum = 0;
        private void debugger_Click(object sender, EventArgs e)
        {
            if (BCK_System.Joint_Data.Count == 0 ) return ;
            if (Int32.Parse(Bone_Num.Text) - 1 < testnum) return;

            Debugger.Append(EN.NewLine);
            Debugger.Append(EN.NewLine);
            Debugger.Append("ジョイント"+ testnum + EN.NewLine);
            
            Debugger.Append("X_倍率"+EN.NewLine);

            Debugger.Append(BCK_System.Joint_Data[testnum].X.sca.key_frame.ToString()+"_");
            Debugger.Append(BCK_System.Joint_Data[testnum].X.sca.start_frame.ToString() + "_");
            Debugger.Append(BCK_System.Joint_Data[testnum].X.sca.tangent_mode.ToString());

            Debugger.Append(EN.NewLine);
            Debugger.Append("X_回転"+EN.NewLine);

            Debugger.Append(BCK_System.Joint_Data[testnum].X.rot.key_frame.ToString() + "_");
            Debugger.Append(BCK_System.Joint_Data[testnum].X.rot.start_frame.ToString() + "_");
            Debugger.Append(BCK_System.Joint_Data[testnum].X.rot.tangent_mode.ToString());

            Debugger.Append(EN.NewLine);
            Debugger.Append("X_位置"+EN.NewLine);

            Debugger.Append(BCK_System.Joint_Data[testnum].X.tra.key_frame.ToString() + "_");
            Debugger.Append(BCK_System.Joint_Data[testnum].X.tra.start_frame.ToString() + "_");
            Debugger.Append(BCK_System.Joint_Data[testnum].X.tra.tangent_mode.ToString());

            testnum++;
        }

        private void 言語ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.LanguageSettingForm language = new UI.LanguageSettingForm();
            language.ShowDialog(this);
            language.Dispose();
            FormReload();
        }
    }
}
