using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace J3D_BCK_Editor.File_Edit
{
    class File_Select
    {
        public static void Dialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "default.bin";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "バイナリファイル(*.bck;*.Bck)|*.bck;*.Bck|すべてのファイル(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "開くファイルを選択してください";
            ofd.RestoreDirectory = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Filecheck(ofd.FileName);
            }
        }

        /// <summary>
        /// 拡張子をチェック
        /// <remarks>Filecheck(<param name="filepath">対象のファイルのパス</param>)</remarks>
        /// </summary>
        /// 
        /// <returns>なし</returns>
        public static void Filecheck(string filepath)
        {
            //BCKクラスインスタンス作成
            BCK bck = new BCK();

            //拡張子抽出
            string File_Extension = Path.GetExtension(filepath);

            //拡張子の種類を判別
            switch (File_Extension.ToLower())
            {
                case ".bck":
                    bck.Reader(filepath);
                    break;
                default:
                    //bck.Reader(filepath);
                    MessageBox.Show("未対応のファイルです", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

            }
        }

        public static void file_save() 
        {
            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "新しいファイル.bck";
            sfd.InitialDirectory = @"C:\";
            sfd.Filter = "BCKファイル(*.bck)|*.bck;*.BCK";
            sfd.FilterIndex = 1;
            sfd.Title = "保存先のファイルを選択してください";
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する
                Console.WriteLine(sfd.FileName);
                BCK bck = new BCK();
                bck.Write(sfd.FileName);
            }
        }
    }
}
