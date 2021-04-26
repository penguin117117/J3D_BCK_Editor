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
        public void Draw(PictureBox pictureBox1)
        {
            //宣言
            int pl_sfn, pl_cfn, pl_tan;
            int dgv3_fn;
            float dgv3_va, dgv3_ta, dgv3_ta2, lineF;
            PointF p_line, p_line2,p0,p1,p2;

            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);
            
            //ペンの設定
            Pen penB = new Pen(Color.Blue, 1);
            Pen penR = new Pen(Color.Red, 3);
            penR.EndCap = LineCap.ArrowAnchor;

            //初期化
            pl_sfn = Plot_List_Rot_Combo[com1.SelectedIndex][0];
            pl_cfn = Plot_List_Rot_Combo[com1.SelectedIndex][1];
            pl_tan = Plot_List_Rot_Combo[com1.SelectedIndex][2];
            List<PointF> l2pf = new List<PointF>();

            //デバッグ
            Console.WriteLine(pl_sfn + "_" + pl_cfn + "_" + pl_tan);

            //曲線がないパターン(直線で一定)
            if (pl_cfn == 1) 
            {
                //初期化
                lineF = float.Parse(string.Format("{0:0.##########}", dgv3.Rows[pl_sfn].Cells["Rotation_Value"].Value, CultureInfo.InvariantCulture.NumberFormat));
                p_line  = new PointF(0,lineF);
                p_line2 = new PointF(Int32.Parse(Txt_Total_Frame.Text),lineF);

                //ワールド設定
                g.ResetTransform();
                g.TranslateTransform(0, canvas.Height / 2);
                g.ScaleTransform(3F, 0.5F);

                //線を描画
                g.DrawLine(penR, new PointF(0, 0), new PointF(Int32.Parse(Txt_Total_Frame.Text), 0));
                g.DrawLine(penB,p_line,p_line2);

                //イメージをピクチャボックスに
                pictureBox1.Image = canvas;
                pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                //ステータスバー設定
                tssl2.Text = com1.Text +"を描画しました。";
                return;
            }
            
            //曲線のあるパターン(エルミート曲線)
            for (int i = pl_sfn; i < pl_sfn + (pl_cfn * (3 + pl_tan)); i += (3 + pl_tan))
            {
                //初期化
                dgv3_fn = Convert.ToInt16(dgv3.Rows[i].Cells["Rotation_Value"].Value);
                dgv3_va =float.Parse(string.Format("{0:0.##########}", dgv3.Rows[i+1].Cells["Rotation_Value"].Value , CultureInfo.InvariantCulture.NumberFormat));
                dgv3_ta = float.Parse(string.Format("{0:0.##########}", dgv3.Rows[i + 2].Cells["Rotation_Value"].Value, CultureInfo.InvariantCulture.NumberFormat));
                p0 =new PointF(dgv3_fn, dgv3_va - (dgv3_ta / 92) / 3);
                p1 = new PointF(dgv3_fn, dgv3_va);
                
                //ﾀﾝｼﾞｪﾝﾄﾓｰﾄﾞなし
                if ((3 + pl_tan) == 3) {
                    //タンジェントモード「なし」のポイント設定&初期化
                    p2 = new PointF(dgv3_fn, dgv3_va + (dgv3_ta / 92) / 3);

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
                    //タンジェントモード「あり」のポイント設定&初期化
                    dgv3_ta2 = float.Parse(string.Format("{0:0.##########}", dgv3.Rows[i + 3].Cells["Rotation_Value"].Value, CultureInfo.InvariantCulture.NumberFormat));
                    p2 = new PointF(dgv3_fn, dgv3_va + (dgv3_ta2 / 92) / 3);

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
                debug.AppendText(EN.NewLine + dgv3_fn);
                debug.AppendText(EN.NewLine + dgv3_va);
                debug.AppendText(EN.NewLine + dgv3_ta);
            }

            //リストをポイントF配列に
            PointF[] point2 = l2pf.ToArray();
            
            //ワールド設定
            g.ResetTransform();
            g.TranslateTransform(0, canvas.Height /2);
            g.ScaleTransform(2F, 1F);
            
            //描画
            g.DrawLine(penR, new PointF(0, 0), new PointF(Int32.Parse(Txt_Total_Frame.Text), 0));
            g.DrawBeziers(penB, point2);
            
            //ピクチャボックスに表示
            pictureBox1.Image = canvas;
            pictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            
            //ステータスバーの設定
            tssl2.Text = com1.Text + "を描画しました。";
        }
    }
}

