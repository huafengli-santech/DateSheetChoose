using DateSheetChoose.Base;
using DateSheetChoose.Common;
using DateSheetChoose.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DateSheetChoose.ViewModels
{
    public class MainWindowViewModel
    {
        //初始化
        string m_Path = $@"{Environment.CurrentDirectory}\{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}EModules.txt";
        ModuleFile moduleFile;
        DynamicModules dynamicModules;
        public MainWindowViewModel()
        {
            moduleFile=new ModuleFile();
            dynamicModules=new DynamicModules();
        }
        private CommandBase _closeComamnd;
        public CommandBase CloseCommand
        {
            get
            {
                if (_closeComamnd == null)
                {
                    _closeComamnd = new CommandBase(
                        p => true,
                        p => 
                        { 
                            Window window=p as Window;
                            window.Close();
                        }
                        );
                }
                return _closeComamnd;
            }
        }
        private CommandBase _minComamnd;
        public CommandBase MinCommand
        {
            get
            {
                if (_minComamnd == null)
                {
                    _minComamnd = new CommandBase(
                        p => true,
                        p =>
                        {
                            Window window = p as Window;
                            window.WindowState = window.WindowState == WindowState.Minimized ? WindowState.Normal : WindowState.Minimized;
                        }
                        );
                }
                return _minComamnd;
            }
        }
        private CommandBase _maxComamnd;
        public CommandBase MaxCommand
        {
            get
            {
                if (_maxComamnd == null)
                {
                    _maxComamnd = new CommandBase(
                        p => true,
                        p =>
                        {
                            Window window = p as Window;
                            window.WindowState=window.WindowState== WindowState.Maximized? WindowState.Normal: WindowState.Maximized;
                        }
                        );
                }
                return _maxComamnd;
            }
        }

        private CommandBase _createModuleCommand;

        public CommandBase CreateModuleCommand
        {
            get
            {
                if (_createModuleCommand == null)
                {
                    _createModuleCommand = new CommandBase(
                        p => true,
                        p =>
                        {
                            dynamicModules.CreateModules(m_Path,moduleFile.StandardModuleProgram);
                        }
                        );
                }
                return _createModuleCommand;
            }
        }

    }
}
