using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.IO;
namespace UpdateModule.ViewModels
{
    public class ModuleUpdateViewModel : BindableBase
    {
        public ObservableCollection<string> ModuleLists { get; set; }
        private string _buildPath = Environment.CurrentDirectory + "\\ProModules";
        public string BuildPath
        {
            get { return _buildPath = Environment.CurrentDirectory + "\\ProModules"; }
            set { SetProperty(ref _buildPath, value); }
        }
        public ModuleUpdateViewModel()
        {
            ModuleLists = new ObservableCollection<string>();
            //读取文件地址内所有模块名称
            ReadModulesFunc();
        }
        private void ReadModulesFunc()
        {
            DirectoryInfo theFolder = new DirectoryInfo($@"{BuildPath}");
            FileInfo[] dirInfo = theFolder.GetFiles();
            //遍历文件夹
            foreach (FileInfo NextFile in dirInfo)
            {
                ModuleLists.Add(NextFile.Name.Replace(".txt", null));
            }
        }
    }
}
