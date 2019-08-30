using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace TexHaxU_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var THU = Properties.Resources.TexHaxU;
            var yaz0t = Properties.Resources.yaz0tool;
            var redme = Properties.Resources.readme;
            var cle = Properties.Resources.clean;
            var THUPrevPic = Properties.Resources.TexHaxU_GUI;
            FileStream fs1 = new FileStream("TexHaxU.zip", FileMode.Create, FileAccess.Write);
            FileStream fs2 = new FileStream("yaz0tool.bat", FileMode.Create, FileAccess.Write);
            FileStream fs3 = new FileStream("readme.html", FileMode.Create, FileAccess.Write);
            FileStream fs4 = new FileStream("clean.bat", FileMode.Create, FileAccess.Write);
            fs1.Write(THU, 0, THU.Length);
            fs2.Write(yaz0t, 0, yaz0t.Length);
            fs3.Write(redme, 0, redme.Length);
            fs4.Write(cle, 0, cle.Length);
            //リソースから画像を抽出
            Bitmap prev = new Bitmap(THUPrevPic);
            prev.Save("TexHaxU GUI.png");
            fs1.Close();
            fs2.Close();
            fs3.Close();
            fs4.Close();
            fs1.Dispose();
            fs2.Dispose();
            fs3.Dispose();
            fs4.Dispose();

            //zipファイルを現在のディレクトリに解凍する
            string CD = System.IO.Directory.GetCurrentDirectory();
            System.IO.Compression.ZipFile.ExtractToDirectory("TexHaxU.zip", CD);

            //終了時の処理
            Application.ApplicationExit += new EventHandler(AppExit);
        }

        private void AppExit(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("アプリケーション使用時に作成されたファイルを削除しますか?", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                System.IO.File.Delete(@"yaz0tool.bat");
                System.IO.File.Delete(@"clean.bat");
                System.IO.File.Delete(@"readme.html");
                System.IO.File.Delete(@"TexHaxU.zip");
                System.IO.File.Delete(@"TexHaxU GUI.png");
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("TexHaxU");
                di.Delete(true);
            }
            else if (result == DialogResult.Cancel)
            {
                MessageBox.Show("削除を中断しました。\r\nこのままTexHaxU GUIを終了します。");
            }
            else
            {
                MessageBox.Show("削除を中断しました。\r\nこのままTexHaxU GUIを終了します。");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProcessStartInfo ext1 = new ProcessStartInfo();
            ext1.FileName = "extract.bat";
            ext1.WorkingDirectory = "TexHaxU";
            Process.Start(ext1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProcessStartInfo copy1 = new ProcessStartInfo();
            copy1.FileName = "GTXCopy.bat";
            copy1.WorkingDirectory = "TexHaxU";
            Process.Start(copy1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProcessStartInfo convdds = new ProcessStartInfo();
            convdds.FileName = "convertGTX.bat";
            convdds.WorkingDirectory = "TexHaxU";
            Process.Start(convdds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FLPath = System.IO.Directory.GetCurrentDirectory();
            System.IO.StreamWriter sw = new System.IO.StreamWriter(FLPath + @"\TexHaxU\Filelist.bat", false);　//Filelist.batを作成
            sw.Write("py -2 hax.py " + textBox1.Text + ".bfres \r\npause");
            sw.Close();

            ProcessStartInfo FL = new ProcessStartInfo();
            FL.FileName = "Filelist.bat";
            FL.WorkingDirectory = "TexHaxU";
            Process.Start(FL);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string SPath = System.IO.Directory.GetCurrentDirectory();
            System.IO.StreamWriter sw = new System.IO.StreamWriter(SPath + @"\TexHaxU\Splicer.bat", false); //Splicer.batを作成|false=一度初期化して書き込む
            //Splicer.batの書き込みを開始
            //textBox5.Textのデフォルト値=0
            sw.Write("py -2 hax.py " + textBox4.Text + ".dds " + textBox1.Text + ".bfres " + textBox2.Text + " " + textBox5.Text);
            sw.Write("\r\npause");　//終了
            sw.Close();

            ProcessStartInfo SLI = new ProcessStartInfo();
            SLI.FileName = "Splicer.bat";
            SLI.WorkingDirectory = "TexHaxU";
            Process.Start(SLI);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ODDLPath = System.IO.Directory.GetCurrentDirectory();
            System.Diagnostics.Process.Start(ODDLPath + "\\TexHaxU\\OutDDS_Lossless"); //OutDDS_Losslessフォルダを開く|using System.Diagnostics;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProcessStartInfo yaz0 = new ProcessStartInfo();
            yaz0.FileName = "yaz0tool.bat";
            Process.Start(yaz0);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ProcessStartInfo RM = new ProcessStartInfo();
            RM.FileName = "readme.html";
            Process.Start(RM);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); //form2を読み込む
            form2.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ProcessStartInfo GTXDDSdel = new ProcessStartInfo();
            GTXDDSdel.FileName = "clean.bat"; //clean.batを起動します。
            Process.Start(GTXDDSdel);
        }
    }
}
