using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;
using EN = System.Environment;


namespace J3D_BCK_Editor.File_Edit
{
    class Plot : BCK_State
    {
        public void Draw(PictureBox pictureBox1, Chart chart1)
        {
            chart1.Series.Clear();  // ← 最初からSeriesが1つあるのでクリアします
            chart1.ChartAreas.Clear();

            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);
            int pl_sfn,pl_cfn,pl_tan, pl_tan2;
            pl_sfn = Plot_List_Rot_Combo[com1.SelectedIndex][0];
            pl_cfn = Plot_List_Rot_Combo[com1.SelectedIndex][1];
            pl_tan = Plot_List_Rot_Combo[com1.SelectedIndex][2];
            Console.WriteLine(pl_sfn + "_" + pl_cfn + "_" + pl_tan);
            int dgv3_fn;
            float dgv3_va, dgv3_ta, dgv3_ta2;


            Pen penB = new Pen(Color.Blue, 1);
            Pen penR = new Pen(Color.Red, 3);

            penR.EndCap = LineCap.ArrowAnchor;
            if (pl_cfn == 1) 
            {
                float lineF = float.Parse(string.Format("{0:0.##########}", dgv3.Rows[pl_sfn].Cells["Rotation_Value"].Value, CultureInfo.InvariantCulture.NumberFormat));
                PointF p_line = new PointF(0,lineF);
                PointF p_line2 = new PointF(Int32.Parse(Txt_Total_Frame.Text),lineF);
                g.ResetTransform();
                //ワールド変換行列を下に10平行移動する
                g.TranslateTransform(0, canvas.Height / 2);
                g.ScaleTransform(3F, 0.5F);
                g.DrawLine(penR, new PointF(0, 0), new PointF(Int32.Parse(Txt_Total_Frame.Text), 0));
                g.DrawLine(penB,p_line,p_line2);
                
                pictureBox1.Image = canvas;
                //pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
                pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                return;
            }
            //pl_tan2 = Plot_List_Rot_Combo[com1.SelectedIndex][3];
            
            PointF[] p = { };
            List<PointF> l2pf = new List<PointF>();
            for (int i = pl_sfn; i < pl_sfn + (pl_cfn * (3 + pl_tan)); i += (3 + pl_tan))
            {
                Console.WriteLine("!_!_!_!_!_!_!_!");
                dgv3_fn = Convert.ToInt16(dgv3.Rows[i].Cells["Rotation_Value"].Value);
                dgv3_va =float.Parse(string.Format("{0:0.##########}", dgv3.Rows[i+1].Cells["Rotation_Value"].Value , CultureInfo.InvariantCulture.NumberFormat));
                dgv3_ta = float.Parse(string.Format("{0:0.##########}", dgv3.Rows[i + 2].Cells["Rotation_Value"].Value, CultureInfo.InvariantCulture.NumberFormat));
                PointF p0 =new PointF(dgv3_fn, dgv3_va - (dgv3_ta / 92) / 3);
                PointF p1 = new PointF(dgv3_fn, dgv3_va);
                

                if ((3 + pl_tan) == 3) {
                    PointF p2 = new PointF(dgv3_fn, dgv3_va + (dgv3_ta / 92) / 3);
                    if (pl_sfn == i)
                    {
                        l2pf.Add(p1);
                        l2pf.Add(p2);
                        Console.WriteLine("F");
                        p.Append(p1);
                        p.Append(p2);
                    }
                    else if (pl_sfn + (pl_cfn * (3 + pl_tan)) - 3 > i)
                    {
                        l2pf.Add(p0);

                        l2pf.Add(p1);
                        l2pf.Add(p2);

                        Console.WriteLine("M");
                        p.Append(p0);
                        p.Append(p1);
                        p.Append(p2);
                    }
                    else
                    {
                        l2pf.Add(p0);

                        l2pf.Add(p1);

                        Console.WriteLine("E");
                        p.Append(p0);
                        p.Append(p1);
                    }
                }
                else if ((3 + pl_tan)==4) 
                {
                    
                    dgv3_ta2 = float.Parse(string.Format("{0:0.##########}", dgv3.Rows[i + 3].Cells["Rotation_Value"].Value, CultureInfo.InvariantCulture.NumberFormat));
                    PointF p2 = new PointF(dgv3_fn, dgv3_va + (dgv3_ta2 / 92) / 3);
                    if (pl_sfn == i)
                    {
                        l2pf.Add(p1);
                        l2pf.Add(p2);
                        Console.WriteLine("F");
                        p.Append(p1);
                        p.Append(p2);
                    }
                    else if (pl_sfn + (pl_cfn * (3 + pl_tan)) - 4 > i)
                    {
                        l2pf.Add(p0);

                        l2pf.Add(p1);
                        l2pf.Add(p2);

                        Console.WriteLine("M");
                        p.Append(p0);
                        p.Append(p1);
                        p.Append(p2);
                    }
                    else
                    {
                        l2pf.Add(p0);

                        l2pf.Add(p1);

                        Console.WriteLine("E");
                        p.Append(p0);
                        p.Append(p1);
                    }

                }

                




                debug.AppendText(EN.NewLine + dgv3_fn);
                debug.AppendText(EN.NewLine + dgv3_va);
                debug.AppendText(EN.NewLine + dgv3_ta);
            }
            Console.WriteLine(p.ToString());
            Console.WriteLine(p.Count());
            //PointF[] p = {

            //new PointF(0, 0),   // start point of first spline
            //new PointF(0,0+(227/92)/3),    // first control point of first spline

            //new PointF(4-(4/3),5),    // second control point of first spline
            //new PointF(4,5),    // endpoint of first spline and
            //new PointF(4+(4/3),5),   // first control point of second spline


            //new PointF(14-(14/3),5),    // second control point of first spline
            //new PointF(14,5),    // endpoint of first spline and
            //                    // start point of second spline
            //new PointF(14+(14/3),5 ),   // first control point of second spline


            //new PointF(179-(179/3),91-(93/92)/3),  // second control point of second spline
            //new PointF(179, 91)};  // endpoint of second spline

            


            PointF[] point2 = l2pf.ToArray();
            Console.WriteLine(point2[0]);
            //g.DrawLine(penR, p[0],p[1]);
            //g.DrawLine(penR, p[8], p[9]);
            g.ResetTransform();
            //ワールド変換行列を下に10平行移動する
            g.TranslateTransform(0, canvas.Height /2);
            g.ScaleTransform(2F, 1F);
            //g.RotateTransform(180F);
            //フォントオブジェクトの作成
            //Font fnt = new Font("MS UI Gothic", 8);
            //文字列を位置(0,0)、青色で表示

            g.DrawLine(penR, new PointF(0, 0), new PointF(Int32.Parse(Txt_Total_Frame.Text), 0));

            g.DrawBeziers(penB, point2);
            
            //g.DrawString("(0,0)", fnt, Brushes.Blue, 0, 0);
            //g.DrawString("(0,"+ Int32.Parse(Txt_Total_Frame.Text) + ")".ToString(), fnt, Brushes.Blue, Int32.Parse(Txt_Total_Frame.Text),0 );
            pictureBox1.Image = canvas;
            //pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            

            //    Bitmap bmp = new Bitmap(
            //canvas,
            //canvas.Width*2,
            //canvas.Height);

            //pictureBox1.Image = bmp;
            //pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            // ChartにChartAreaを追加します
            //////string chart_area1 = "Area1";
            //////var ch1 = chart1.ChartAreas.Add((chart_area1));
            //////ch1.AxisX.Interval = 10;
            //////ch1.AxisY.Interval = 10;
            //////// ChartにSeriesを追加します
            //////string legend1 = "Graph1";
            //////chart1.Series.Add(legend1);
            //////// グラフの種別を指定
            //////chart1.Series[legend1].ChartType = SeriesChartType.Spline; // 折れ線グラフを指定してみます

            //////chart1.Series[legend1].SetCustomProperty("LineTension", "0.1");

            //////chart1.BorderlineWidth = 10;
            //////for (int i = 0; i < p.Length; i++)
            //////{


            //////    chart1.Series[legend1].Points.AddXY(p[i].X, p[i].Y);
            //////}


        }
    }

    }

