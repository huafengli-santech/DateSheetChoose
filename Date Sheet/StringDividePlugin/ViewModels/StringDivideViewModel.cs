using Prism.Commands;
using Prism.Mvvm;
using StringDividePlugin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

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
        private string _searchText;
        private bool _isAutoDetectClip;

        public bool IsAutoDetectClip
        {
            get { return _isAutoDetectClip; }
            set { _isAutoDetectClip = value; RaisePropertyChanged(); }
        }

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; RaisePropertyChanged(); UpdateSelectedFunc(_searchText); }
        }
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
            IsAutoDetectClip = true;
        }
        private void CopyToClipFunc()
        {
            Clipboard.SetText($"{ToolTipString}");
        }
        private void UpdateSelectedFunc(string _searchText)
        {
            string _tempString = "";
            int preindex = 0;
            string bitstring = "";
            bool isAlreadyAdd = false;
            bool isCorrectModuleName = false;
            bool isFirst = false;

            List<int> index = new List<int>();
            for (int i = 0; i < ModuleLists.Count; i++)
            {
                _tempString = _searchText.ToLower();
                isFirst = true;//每次新模块初次检查是否模块匹配
                isCorrectModuleName = true;
                if (String.IsNullOrEmpty(_tempString)) { return; }
                if (_tempString.Length < ModuleLists[i].Name.Length) { return; }
                string splitString = _tempString.Substring(0, ModuleLists[i].Name.Length);//获取最前面的字符数组用于完全匹配
                if (String.Equals(splitString, ModuleLists[i].Name, StringComparison.OrdinalIgnoreCase))
                    if (_tempString.Contains(ModuleLists[i].Name.ToLower()))
                    {
                        _tempString = _tempString.Replace(ModuleLists[i].Name.ToLower(), "");
                        //1.分解成对应模块字符串长度
                        OpenFileCreateForm($"{ModuleLists[i].FilePath}");
                        index.Clear();
                        for (int j = 0; j < PortLists.Count; j++)
                        {
                            isAlreadyAdd = false;
                            if (!isCorrectModuleName) { break; }
                            for (int m = 0; m < PortLists[j].EParaNames.Count; m++)
                            {
                                //获取当前变量的长度，根据长度分割字符串
                                int bitValue = PortLists[j].EParaNames[m].Length;
                                //如果字符串不为空，并且字符长于待分割的长度，则继续分割
                                if (!string.IsNullOrEmpty(_tempString) & (_tempString.Length >= bitValue))
                                {
                                    bitstring = _tempString.ToLower().Substring(0, bitValue);
                                }
                                //如果没有匹配首个区域上任何一个参数可能是匹配错误了模块重新匹配 
                                if (isFirst)
                                {
                                    isCorrectModuleName = IsCorrectModuleNameFunc(PortLists[j].EParaNames, bitstring);
                                    if (!isCorrectModuleName) { break; }
                                    else { isFirst = false; }//如果是正常的模块，下次就不检测，避免后续的出现问题
                                }
                                //如果分割出来的包含，证明匹配上了，添加一个新的Index和把该字符串删除已经匹配的字段
                                //否则给一个默认的index=0
                                if (bitstring.Contains(PortLists[j].EParaNames[m].ToLower()))
                                {
                                    if (_tempString.Contains(PortLists[j].EParaNames[m].ToLower()))
                                    {
                                        int startindex = _tempString.IndexOf(PortLists[j].EParaNames[m].ToLower(), preindex);
                                        if (startindex != -1)
                                        {
                                            if (m < PortLists[j].EParaNames.Count)
                                            {
                                                index.Add(m);
                                                isAlreadyAdd = true;
                                            }
                                            _tempString = _tempString.Remove(startindex, PortLists[j].EParaNames[m].Length);
                                        }
                                    }
                                }
                            }
                            if (!isAlreadyAdd)
                                index.Add(0);
                        }
                        OpenFileCreateForm($"{ModuleLists[i].FilePath}", index);
                    }
            }
        }
        /// <summary>
        /// 根据遍历第一个英文数组与截取的第一段循环遍历看是否为真
        /// 返回值为true 代表当前模块名称正确
        ///返回值为false 代表当前模块名称错误 
        /// </summary>
        /// <param name="sourceList"></param>
        /// <param name="bitString"></param>
        /// <returns></returns>
        private bool IsCorrectModuleNameFunc(List<string> sourceList, string bitString)
        {
            bool result = false;
            for (int lndex = 0; lndex < sourceList.Count; lndex++)
            {
                if (bitString.Equals(sourceList[lndex].ToLower()))
                {
                    result = true;
                }
            }
            return result;
        }
        private void DetectClipFunc(string clipText)
        {
            int preindex = 0;
            string bitstring = "";
            string _tempString = "";
            bool isCorrectModuleName = false;
            bool isFirst = false;
            bool isFirstShowMessage=true;
            MessageBoxResult result = new MessageBoxResult();

            for (int i = 0; i < ModuleLists.Count; i++)
            {
                _tempString = clipText.ToLower();
                isFirst = true;//每次新模块初次检查是否模块匹配
                isCorrectModuleName = true;
                if (String.IsNullOrEmpty(_tempString)) { return; }
                if (_tempString.Length < ModuleLists[i].Name.Length) { return; }
                string splitString = _tempString.Substring(0, ModuleLists[i].Name.Length);//获取最前面的字符数组用于完全匹配
                if (String.Equals(splitString, ModuleLists[i].Name, StringComparison.OrdinalIgnoreCase))
                    if (_tempString.Contains(ModuleLists[i].Name.ToLower()))
                    {
                        try
                        {
                            Clipboard.SetText("");
                        }
                        catch
                        {
                        }
                        if(isFirstShowMessage)
                        {
                            result = MessageBox.Show("检测到粘贴板内含有模块关键字，是否进行分析？", "粘贴板检测", MessageBoxButton.YesNo);
                            isFirstShowMessage = false; 
                        }
                        if (result == MessageBoxResult.Yes | !isFirstShowMessage)
                        {
                            ClipResultString = "";
                            ClipSourceString = "";
                            _tempString = _tempString.Replace(ModuleLists[i].Name.ToLower(), "");
                            //1.分解成对应模块字符串长度
                            OpenFileCreateForm($"{ModuleLists[i].FilePath}");
                            for (int j = 0; j < PortLists.Count; j++)
                            {
                                if (!isCorrectModuleName) { break; }
                                for (int m = 0; m < PortLists[j].EParaNames.Count; m++)
                                {
                                    //获取当前变量的长度，根据长度分割字符串
                                    int bitValue = PortLists[j].EParaNames[m].Length;
                                    //如果字符串不为空，并且字符长于待分割的长度，则继续分割
                                    if (!string.IsNullOrEmpty(_tempString) & (_tempString.Length >= bitValue))
                                    {
                                        bitstring = _tempString.ToLower().Substring(0, bitValue);
                                    }
                                    //如果没有匹配首个区域上任何一个参数可能是匹配错误了模块重新匹配 
                                    if (isFirst)
                                    {
                                        isCorrectModuleName = IsCorrectModuleNameFunc(PortLists[j].EParaNames, bitstring);
                                        if (!isCorrectModuleName) { break; }
                                        else { isFirst = false; }//如果是正常的模块，下次就不检测，避免后续的出现问题
                                    }
                                    //如果分割出来的包含，证明匹配上了，添加一个新的Index和把该字符串删除已经匹配的字段
                                    //否则给一个默认的index=0
                                    if (bitstring.Contains(PortLists[j].EParaNames[m].ToLower()))
                                    {
                                        if (_tempString.Contains(PortLists[j].EParaNames[m].ToLower()))
                                        {
                                            int startindex = _tempString.IndexOf(PortLists[j].EParaNames[m].ToLower(), preindex);
                                            if (startindex != -1)
                                            {
                                                ClipResultString += $"{PortLists[j].CName} : {PortLists[j].CParaNames[m]}\n";
                                                ClipSourceString += $"{PortLists[j].EParaNames[m]} ";
                                                _tempString = _tempString.Remove(startindex, PortLists[j].EParaNames[m].Length);
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
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
                    Thread.Sleep(1000);
                    Application.Current.Dispatcher.BeginInvoke(() =>
                    {
                        string resultString = "型号为：\n";
                        for (int i = 0; i < PortLists.Count; i++)
                        {
                            resultString += $"{PortLists[i].SelectedEParaName} ";
                        }
                        ToolTipString = resultString;
                        if (IsAutoDetectClip)
                            DetectClipFunc(Clipboard.GetText(0).ToLower());
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
        private void OpenFileCreateForm(string path, List<int> index)
        {
            if (index.Count == 0) { return; }
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
                        PortLists.Add(new PortInfo() { EName = portName[0], CName = portName[1], EParaNames = eParaList, CParaNames = cParaList, Index = index[i] });
                        if (i < index.Count - 1)
                            i++;
                        else
                            i = 0;
                    }
                }
            }
        }
    }
}
