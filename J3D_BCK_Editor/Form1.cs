﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.DataVisualization.Charting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            //Form1Instanceに代入
            Form1.Form1Instance = f;
            //Form1の表示
            //f.Show();

            Form1.Form1Instance = this;
            
            
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
            string[] xyzstate = { "scaleX", "rotateX", "transX", "scaleY", "rotateY", "transY", "scaleZ", "rotateZ", "transZ" };
            
                for (int j = 0; j < 9; j++)
                { 
                    dataGridView1.Rows.Add("Bone", xyzstate[j], 1, 0, 0);
                }

            for (int k =0;k < dataGridView1.Rows.Count; k+=9) 
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView1.Rows[k+j].Cells["BoneNum"].Value = "Bone" +(k/9);
                }
            }
        }

        private void BoneDelete_Click(object sender, EventArgs e)
        {
            //int dgvcount = dataGridView1.Rows.Count -9;
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

        private void button1_Click(object sender, EventArgs e)
        {
            

            chart1.Series.Clear();  // ← 最初からSeriesが1つあるのでクリアします
            chart1.ChartAreas.Clear();

            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            //0
            //0
            //227
            //4
            //5
            //0
            //14
            //5
            //0
            //179
            //90.01649
            //93

            PointF[] p = {
                
            new PointF(0, 0),   // start point of first spline
            new PointF(0,0+(227/92)/3),    // first control point of first spline

            new PointF(4-(4/3),5),    // second control point of first spline
            new PointF(4,5),    // endpoint of first spline and
            new PointF(4+(4/3),5),   // first control point of second spline


            new PointF(14-(14/3),5),    // second control point of first spline
            new PointF(14,5),    // endpoint of first spline and
                                // start point of second spline
            new PointF(14+(14/3),5 ),   // first control point of second spline


            new PointF(179-(179/3),91-(93/92)/3),  // second control point of second spline
            new PointF(179, 91)};  // endpoint of second spline

            Pen penB = new Pen(Color.Blue, 1);
            Pen penR = new Pen(Color.Red, 3);
            
            penR.EndCap = LineCap.ArrowAnchor;

            
            
            
            //g.DrawLine(penR, p[0],p[1]);
            //g.DrawLine(penR, p[8], p[9]);
            g.DrawBeziers(penB,p);
             
            pictureBox1.Image = canvas;
            //pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);

            Bitmap bmp = new Bitmap(
        canvas,
        canvas.Width*2,
        canvas.Height);

            pictureBox1.Image = bmp;
            pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            // ChartにChartAreaを追加します
            string chart_area1 = "Area1";
            var ch1= chart1.ChartAreas.Add((chart_area1));
            ch1.AxisX.Interval = 10;
            ch1.AxisY.Interval = 10;
            // ChartにSeriesを追加します
            string legend1 = "Graph1";
            chart1.Series.Add(legend1);
            // グラフの種別を指定
            chart1.Series[legend1].ChartType = SeriesChartType.Spline; // 折れ線グラフを指定してみます
            
            chart1.Series[legend1].SetCustomProperty("LineTension", "0.1");
            
            chart1.BorderlineWidth = 10;
            for (int i = 0; i < p.Length; i++)
            {
                
                
                chart1.Series[legend1].Points.AddXY(p[i].X,p[i].Y);
            }

            
        }

       

        
    }
}
