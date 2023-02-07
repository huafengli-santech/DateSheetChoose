using System;
using System.IO;
using System.Windows.Forms;

namespace TXTCodeAndDcode
{
    public partial class Form1 : Form
    {
        private string beforePath = Application.StartupPath + "\\Before";
        private string afterPath = Application.StartupPath + "\\After";

        public Form1()
        {
            InitializeComponent();
            CreateDir();
            tbxAfterPath.Text = afterPath;
            tbxBeforePath.Text = beforePath;
        }

        private void CreateDir()
        {
            if (!Directory.Exists(beforePath))
            {
                Directory.CreateDirectory(beforePath);
            }
            if (!Directory.Exists(afterPath))
            {
                Directory.CreateDirectory(afterPath);
            }
        }

        private void btnSecret_Click(object sender, EventArgs e)
        {
            string scanDirectoryPath = beforePath;
            if (String.IsNullOrEmpty(scanDirectoryPath))
            {
                MessageBox.Show("扫描文件路径不能为空");
            }
            else
            {
                //指定的文件夹目录
                DirectoryInfo dir = new DirectoryInfo(scanDirectoryPath);
                if (dir.Exists == false)
                {
                    MessageBox.Show("路径不存在！请重新输入");
                }
                else
                {
                    //检索表示当前目录的文件和子目录
                    FileSystemInfo[] fsinfos = dir.GetFiles();
                    rbxLog.Clear();
                    //遍历检索的文件和子目录
                    foreach (FileSystemInfo fsinfo in fsinfos)
                    {
                        this.rbxLog.AppendText(fsinfo.Name);
                        this.rbxLog.AppendText("\r\n");
                        CodeTxt(fsinfo.Name);
                    }
                }
            }
        }

        private void CodeTxt(string filename)
        {
            string path = Path.Combine(beforePath, filename);
            try
            {
                // 创建一个 StreamReader 的实例来读取文件
                // using 语句也能关闭 StreamReader
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    string text = "";
                    // 从文件读取并显示行，直到文件的末尾
                    while ((line = sr.ReadLine()) != null)
                    {
                        text += $"{line}\n";
                    }
                    SercrtTxt(filename, text);
                }
            }
            catch (Exception e)
            {
                // 向用户显示出错消息
                MessageBox.Show(e.Message);
            }
        }

        private void SercrtTxt(string outFilename, string text)
        {
            outFilename = Path.Combine(afterPath, outFilename);
            //加密
            text = AuthcodeHelper.Encode(text);
            //保存到客户端
            StreamWriter streamw = new StreamWriter(outFilename, false);
            streamw.Write(text);
            streamw.Close();
        }

        private void btnOpenBefore_Click(object sender, EventArgs e)
        {
            OpenDir(ref beforePath);
        }

        private void btnOpenAfter_Click(object sender, EventArgs e)
        {
            OpenDir(ref afterPath);
        }

        private void OpenDir(ref string path)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "请选择待加密文件所在的目录";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowser.SelectedPath;
            }
        }
    }
}