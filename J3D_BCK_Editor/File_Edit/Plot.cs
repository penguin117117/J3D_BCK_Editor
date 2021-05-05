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
        public void Draw(PictureBox pictureBox1 , DataGridView dgv ,string dgvcellname , float scale = 1 , float scale2 = 0.8f )
        {
            //宣言
            int pl_sfn, pl_cfn, pl_tan;
            int dgv3_fn;
            int Max_Frame;
            int from_txt_frac;
            float dgv3_va, dgv3_ta, dgv3_ta2, lineF;
            PointF p_line, p_line2,p0,p1,p2;
            float plot_scale = scale;
            float plot_scaley = scale2;

            //初期化
            if (dgvcellname == "Rotation_Value")
            {
                pl_sfn = Plot_List_Rot_Combo[com2.SelectedIndex][0];
                pl_cfn = Plot_List_Rot_Combo[com2.SelectedIndex][1];
                pl_tan = Plot_List_Rot_Combo[com2.SelectedIndex][2];
            }
            else if (dgvcellname == "Scale_Value")
            {
                pl_sfn = Plot_List_Scale_Combo[com1.SelectedIndex][0];
                pl_cfn = Plot_List_Scale_Combo[com1.SelectedIndex][1];
                pl_tan = Plot_List_Scale_Combo[com1.SelectedIndex][2];
            }
            else
            {
                pl_sfn = Plot_List_Trans_Combo[com3.SelectedIndex][0];
                pl_cfn = Plot_List_Trans_Combo[com3.SelectedIndex][1];
                pl_tan = Plot_List_Trans_Combo[com3.SelectedIndex][2];
            }


            Max_Frame = Int32.Parse(Txt_Total_Frame.Text);
            from_txt_frac = Int32.Parse(Txt_Rot_Frac.Text);
            int frac = 1;


            if (0 >= scale) plot_scale = 1;
            if (0 >= scale2) plot_scaley = 0.8f;

            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(Convert.ToInt32( Max_Frame * plot_scale+20), Convert.ToInt32(360 * plot_scaley));
            
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);
            
            //ペンの設定
            Pen penB = new Pen(Color.Blue, 1);
            Pen penR = new Pen(Color.Red, 2);
            Pen penG = new Pen(Color.Green, 2);
            penR.EndCap = LineCap.ArrowAnchor;
            penG.EndCap = LineCap.ArrowAnchor;

            
            
            for (int f = 0; f < from_txt_frac; f++)
            {
                if (f != 0) { frac *= 10; }
            }
            if (dgvcellname != "Rotation_Value")frac = 1 ;
            
            
            //デバッグ
            Debugger.Append(pl_sfn + "_" + pl_cfn + "_" + pl_tan);

            //曲線がないパターン(直線で一定)
            if (pl_cfn == 1) 
            {
                //初期化
                lineF = Points.Get.fromgrid(dgv,pl_sfn, dgvcellname);
                //lineF = float.Parse(string.Format("{0:0.##########}", dgv.Rows[pl_sfn].Cells[dgvcellname].Value, CultureInfo.InvariantCulture.NumberFormat));
                p_line  = new PointF(0 ,lineF * plot_scaley);
                p_line2 = new PointF(Max_Frame * plot_scale ,lineF * plot_scaley);

                //ワールド設定
                g.ResetTransform();
                g.TranslateTransform(0, canvas.Height / 2);

                //線を描画
                g.DrawLine(penR, new PointF(0, 0), new PointF(Max_Frame*plot_scale, 0));
                g.DrawLine(penB,p_line,p_line2);
                
                //イメージをピクチャボックスに
                pictureBox1.Image = canvas;
                pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                //ステータスバー設定
                tssl2.Text = com1.Text +"を描画しました。";
                return;
            }


            List<PointF> l2pf = new List<PointF>();
            //曲線のあるパターン(エルミート曲線)
            for (int i = pl_sfn; i < pl_sfn + (pl_cfn * (3 + pl_tan)); i += (3 + pl_tan))
            {
                float dgv3_fn2 = 0;
                float dgv3_va2 = 0;
                float dgv3_ta_2 = 0;
                float dgv3_fn0 = 0;
                float dgv3_va_0 = 0;
                float dgv3_ta_0 = 0;
                //初期化
                Debugger.Append(dgv.Rows[i].Cells[dgvcellname].Value.ToString());
                    dgv3_fn = Convert.ToInt16(dgv.Rows[i].Cells[dgvcellname].Value);
                
                dgv3_fn2 = dgv3_fn;
                if (dgv.RowCount < i + (3 + pl_tan))
                {
                    dgv3_fn2 = Convert.ToInt16(dgv.Rows[i + (3 + pl_tan)].Cells[dgvcellname].Value);
                    dgv3_va2 = float.Parse(string.Format("{0:0.##########}", dgv.Rows[i + (3 + pl_tan) + 1].Cells[dgvcellname].Value, CultureInfo.InvariantCulture.NumberFormat));
                    dgv3_ta_2 = float.Parse(string.Format("{0:0.##########}", dgv.Rows[i + (3 + pl_tan) + 2].Cells[dgvcellname].Value, CultureInfo.InvariantCulture.NumberFormat))/frac;
                }

                if (pl_sfn + (3 + pl_tan) < i )

                {
                    Debugger.Append((i - (3 + pl_tan)).ToString());
                    Debugger.Append(dgv.Rows[i - (3 + pl_tan)].Cells[dgvcellname].Value.ToString() + "ほし★");
                    Console.WriteLine(i - (3 + pl_tan));
                    Console.WriteLine(dgv.Rows[i - (3 + pl_tan)].Cells[dgvcellname].Value+"ほし★");
                    dgv3_fn0 = Convert.ToInt16(dgv.Rows[i - (3 + pl_tan)].Cells[dgvcellname].Value);
                    dgv3_va_0 = float.Parse(string.Format("{0:0.##########}", dgv.Rows[i  - (3 + pl_tan)+1].Cells[dgvcellname].Value, CultureInfo.InvariantCulture.NumberFormat));
                    dgv3_ta_0 = float.Parse(string.Format("{0:0.##########}", dgv.Rows[i - (3 + pl_tan)+2].Cells[dgvcellname].Value, CultureInfo.InvariantCulture.NumberFormat))/frac;
                }
                dgv3_va =float.Parse(string.Format("{0:0.##########}", dgv.Rows[i+1].Cells[dgvcellname].Value , CultureInfo.InvariantCulture.NumberFormat));
                dgv3_ta = float.Parse(string.Format("{0:0.##########}", dgv.Rows[i + 2].Cells[dgvcellname].Value, CultureInfo.InvariantCulture.NumberFormat))/frac;
                p0 = new PointF(dgv3_fn - Math.Abs(dgv3_fn0-dgv3_fn)/3, dgv3_va - ((dgv3_ta/92)*((dgv3_fn - Math.Abs(dgv3_fn0 - dgv3_fn) / 3)) ) / 3);
                //p0 = new PointF(dgv3_fn - Math.Abs(dgv3_fn2 - dgv3_fn) / 3, dgv3_fn - Math.Abs(dgv3_fn2 - dgv3_fn) / 3 * (dgv3_ta/92)/3 );
                p1 = new PointF(dgv3_fn, dgv3_va);

                p0.X *= plot_scale;
                p0.Y *= plot_scaley;
                p1.X *= plot_scale;
                p1.Y *= plot_scaley;

                //ﾀﾝｼﾞｪﾝﾄﾓｰﾄﾞなし
                if ((3 + pl_tan) == 3) {
                    //タンジェントモード「なし」のポイント設定&初期化
                    p2 = new PointF(dgv3_fn + Math.Abs(dgv3_fn2 - dgv3_fn)/3, dgv3_va + ((dgv3_ta / 92)*((dgv3_fn + Math.Abs(dgv3_fn2 - dgv3_fn) / 3)) ) / 3);
                    p2.X *= plot_scale;
                    p2.Y *= plot_scaley;
                    //p2 = new PointF(dgv3_fn + Math.Abs(dgv3_fn2 - dgv3_fn) / 3, dgv3_fn + Math.Abs(dgv3_fn2 - dgv3_fn) / 3 * (dgv3_ta/92)/3 );

                    //先頭と末尾だけポイント数を減らす
                    if (pl_sfn == i)
                    {
                        l2pf.Add(p1);
                        l2pf.Add(p2);
                        Console.WriteLine("先頭");
                    }
                    else if (pl_sfn + (pl_cfn * (3 + pl_tan)) - 3 > i)
                    {
                        l2pf.Add(p0);
                        l2pf.Add(p1);
                        l2pf.Add(p2);
                        Console.WriteLine("中間");
                    }
                    else
                    {
                        l2pf.Add(p0);
                        l2pf.Add(p1);
                        Console.WriteLine("末尾");
                    }
                }
                //ﾀﾝｼﾞｪﾝﾄﾓｰﾄﾞあり
                else if ((3 + pl_tan)==4) 
                {
                    dgv3_ta2 = 0;
                    //タンジェントモード「あり」のポイント設定&初期化
                    if (dgv.RowCount < i + (3 + pl_tan))
                    {
                        dgv3_ta2 = float.Parse(string.Format("{0:0.##########}", dgv.Rows[i + (3 + pl_tan) + 3].Cells[dgvcellname].Value, CultureInfo.InvariantCulture.NumberFormat)) / frac;
                    }
                        p2 = new PointF(dgv3_fn + Math.Abs(dgv3_fn2 - dgv3_fn) / 3, dgv3_va + ((dgv3_ta2 / 92)*(dgv3_fn + Math.Abs(dgv3_fn2 - dgv3_fn) / 3)) / 3);
                    p2.X *= plot_scale;
                    p2.Y *= plot_scaley;
                    //p2 = new PointF(dgv3_fn, (dgv3_ta2 / 92) *3);

                    //先頭と末尾だけポイント数を減らす
                    if (pl_sfn == i)
                    {
                        l2pf.Add(p1);
                        l2pf.Add(p2);
                        Console.WriteLine("タンジェント先頭");
                    }
                    else if (pl_sfn + (pl_cfn * (3 + pl_tan)) - 4 > i)
                    {
                        l2pf.Add(p0);
                        l2pf.Add(p1);
                        l2pf.Add(p2);
                        Console.WriteLine("タンジェント中間");
                    }
                    else
                    {
                        l2pf.Add(p0);
                        l2pf.Add(p1);
                        Console.WriteLine("タンジェント末尾");
                    }

                }

                //デバッグ専用
                Debugger.Append(EN.NewLine + dgv3_fn);
                Debugger.Append(EN.NewLine + dgv3_va);
                Debugger.Append(EN.NewLine + dgv3_ta);
            }

            //リストをポイントF配列に
            PointF[] point2 = l2pf.ToArray();
            
            //ワールド設定
            g.ResetTransform();
            g.TranslateTransform(0, canvas.Height /2);
            //g.ScaleTransform(2F, 2F);
            
            
            
            
            Bitmap canvas2 = new Bitmap(Convert.ToInt32((Frame_Num) *plot_scale+20),Convert.ToInt32 (360*plot_scaley)) ;
            Graphics g2 = Graphics.FromImage(canvas2);
            g2.Clear(Color.Transparent);
            //描画
            
            g2.TranslateTransform(0, canvas2.Height / 2);
            
            //g2.ScaleTransform(5F, 5F);
            g2.DrawLine(penG, new PointF(0, -180*plot_scaley ), new PointF(0,180 * plot_scaley));
            g2.DrawLine(penR, new PointF(0, 0), new PointF(Int32.Parse(Txt_Total_Frame.Text) * plot_scale, 0));
            g2.DrawLine(penR, new PointF(0, -90 * plot_scaley), new PointF(5, -90 * plot_scaley));
            g2.DrawLine(penR, new PointF(0, 90 * plot_scaley), new PointF(5, 90 * plot_scaley));
            g2.DrawBeziers(penB, point2);

            //g2.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //g2.DrawImage(canvas2, 0, 0,  canvas2.Width * plot_scale, canvas2.Height * plot_scale);
            //ピクチャボックスに表示
            pictureBox1.Image = canvas2;
            pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;


            g.Dispose();
            g2.Dispose();
            
            

            //ステータスバーの設定
            tssl2.Text = com1.Text + "を描画しました。";
        }
    }
}

