using Prism.Commands;
using Prism.Mvvm;
using StringDividePlugin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace StringDividePlugin.ViewModels
{
    public class StringDivideViewModel : BindableBase
    {
        //模块列表
        public ObservableCollection<ModulesInfo> ModuleLists { get; set; }
        public ObservableCollection<PortInfo> PortLists { get; set; }
        //用于判断是否
        private string _toolTipString;
        private DelegateCommand _updateCommand;
        private DelegateCommand _copyToClipCmd;
        private ModulesInfo _selectedModuleName;
        private string _clipResultString;
        private string _clipSourceString;

        public string ClipSourceString
        {
            get { return _clipSourceString; }
            set { SetProperty(ref _clipSourceString, value); }
        }

        public string ClipResultString
        {
            get { return _clipResultString; }
            set { SetProperty(ref _clipResultString, value); }
        }

        public string ToolTipString
        {
            get { return _toolTipString; }
            set { SetProperty(ref _toolTipString, value); }
        }

        private string BuildPath = Environment.CurrentDirectory + "\\ProModules";

        public ModulesInfo SelectedModuleName
        {
            get { return _selectedModuleName; }
            set
            {
                SetProperty(ref _selectedModuleName, value);
                if (ModuleLists.Count != 0)
                {
                    if (ModuleLists.Contains(value))
                    {
                        OpenFileCreateForm(value.FilePath);
                    }
                }
            }
        }

        public DelegateCommand UpdateCommand { get => _updateCommand = new DelegateCommand(ReadModulesFunc); }
        public DelegateCommand CopyToClipCmd { get => _copyToClipCmd = new DelegateCommand(CopyToClipFunc); }

        public StringDivideViewModel()
        {
            ModuleLists = new ObservableCollection<ModulesInfo>();
            PortLists = new ObservableCollection<PortInfo>();
            UpdateForm();
        }

        private void CopyToClipFunc()
        {
            Clipboard.SetText($"{ToolTipString}");
        }

        private void DetectClipFunc()
        {
            try
            {
                string clipText = Clipboard.GetText(0).ToLower();
                string clipSourceText = "";
                int preindex = 0;
                for (int i = 0; i < ModuleLists.Count; i++)
                {
                    if (clipText.Contains(ModuleLists[i].Name.ToLower()))
                    {
                        Clipboard.SetText("");
                        MessageBoxResult result = MessageBox.Show("检测到粘贴板内含有模块关键字，是否进行分析？", "粘贴板检测");
                        if (result == MessageBoxResult.OK)
                        {
                            //处理粘贴板内生成的字符串
                            //1.分解成对应模块字符串长度
                            OpenFileCreateForm($"{ModuleLists[i].FilePath}");
                            clipSourceText += ModuleLists[i].Name;
                            for (int j = 0; j < PortLists.Count; j++)
                            {
                                for (int m = 0; m < PortLists[j].EParaNames.Count; m++)
                                {

                                    if (clipText.Contains(PortLists[j].EParaNames[m].ToLower()))
                                    {
                                        int startindex = clipText.IndexOf(PortLists[j].EParaNames[m].ToLower(), preindex);
                                        if (startindex!=-1)
                                        {
                                            string resultText = $"{PortLists[j].CName} : {PortLists[j].CParaNames[m]}\n";
                                            clipText = $"{clipText.Substring(0, startindex)} {resultText} {clipText.Substring(startindex + PortLists[j].EParaNames[m].Length)}";
                                            //int sourceStartIndex= sourceClipText.IndexOf(PortLists[j].EParaNames[m].ToLower());
                                            clipSourceText += $"{PortLists[j].EParaNames[m]} ";
                                            preindex = startindex+resultText.Length;
                                        }
                                    }

                                }
                            }
                            ClipResultString = clipText;
                            ClipSourceString = clipSourceText;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("粘贴板调用错误,按下Win+V调出面板，\n清空当前所有粘贴板内容后重试");
            }
        }

        /// <summary>
        /// 实时修改已经选中模块的状态
        /// </summary>
        private void UpdateForm()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    Application.Current.Dispatcher.BeginInvoke(() =>
                    {
                        string resultString = "型号为：\n";
                        for (int i = 0; i < PortLists.Count; i++)
                        {
                            resultString += $"{PortLists[i].SelectedEParaName} ";
                        }
                        ToolTipString = resultString;

                        DetectClipFunc();
                    });
                }
            });
        }

        /// <summary>
        /// 加载标准路径下的模板文件
        /// </summary>
        private void ReadModulesFunc()
        {
            ModuleLists.Clear();
            DirectoryInfo theFolder = new DirectoryInfo($@"{BuildPath}");
            FileInfo[] dirInfo = theFolder.GetFiles();


            //遍历文件夹
            foreach (FileInfo NextFile in dirInfo)
            {
                if (NextFile.Name.Contains(".txt"))
                {
                    ModuleLists.Add(new ModulesInfo() { Name = NextFile.Name.Replace(".txt", null), FilePath = NextFile.FullName });
                }
            }

        }
        /// <summary>
        /// 选中已经支持的模块时，自动读取对应的文件，并动态添加在左侧的UI中
        /// </summary>
        /// <param name="path">选中文件的路径</param>
        private void OpenFileCreateForm(string path)
        {
            PortLists.Clear();
            using (StreamReader reader = new StreamReader(path))
            {
                int i = 0;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!line.Contains('$'))
                    {
                        string[] gettype = line.Split(" ：");
                        //获取区块名称
                        string[] portName = gettype[0].Split(" ");
                        //获取参数列表
                        string[] portPara = gettype[1].Split(" | ");
                        List<string> eParaList = new List<string>();
                        List<string> cParaList = new List<string>();
                        for (int j = 0; j < portPara.Length; j++)
                        {
                            eParaList.Add(portPara[j].Split(" ")[0]);
                            cParaList.Add(portPara[j].Split(" ")[1]);
                        }

                        PortLists.Add(new PortInfo() { EName = portName[0], CName = portName[1], EParaNames = eParaList, CParaNames = cParaList, Index = cParaList.Count - 1 });
                        i++;
                    }
                }
            }
        }

    }
}
