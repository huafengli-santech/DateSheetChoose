using LoadModules.Date;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.IO;
using System.Windows;
namespace LoadModules.ViewModels
{
    public class LoadModuleViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        private string _buildPath = Environment.CurrentDirectory + "\\ProModules";
        public string BuildPath
        {
            get { return _buildPath = Environment.CurrentDirectory + "\\ProModules"; }
            set { SetProperty(ref _buildPath, value); }
        }
        private DelegateCommand _openSaveFileCommand;
        public DelegateCommand OpenSaveFileCommand { get => _openSaveFileCommand ?? (_openSaveFileCommand = new DelegateCommand(OpenSaveFileFunc)); }
        private DelegateCommand _createNewModuleFileCommand;
        public DelegateCommand CreateNewModuleFileCommand { get => _createNewModuleFileCommand ?? (_createNewModuleFileCommand = new DelegateCommand(CreateNewMFileFunc)); }
        private DelegateCommand _copyPathToClipComamnd;
        public DelegateCommand CopyPathToClipComamnd { get => _copyPathToClipComamnd ?? (_copyPathToClipComamnd = new DelegateCommand(CoptToClipFunc)); }
        private void CreateNewMFileFunc()
        {
            using (StreamWriter writer = new StreamWriter(BuildPath + "\\StandardProgram.txt"))
            {
                FileModel file = new FileModel();
                writer.Write(file.StandardModuleProgram);
            }
            MessageBox.Show("模板文件已生成", "模块文件生成提示");
        }
        private void CoptToClipFunc()
        {
            Clipboard.SetText(BuildPath);
            MessageBox.Show("模板文件生成路径已经复制到粘贴板", "模块文件生成提示");
        }
        private void OpenSaveFileFunc()
        {
            if (!Directory.Exists(BuildPath))
            {
                Directory.CreateDirectory(BuildPath);
            }
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
        }
        public LoadModuleViewModel()
        {
            Message = "点击此处打开存储目录";
        }
        public void SaveFileToModulesFunc(object sender, DragEventArgs e)
        {
        }
    }
}
