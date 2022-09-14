using DateSheetChoose.Base;
using DateSheetChoose.Common;
using DateSheetChoose.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace DateSheetChoose.ViewModels
{
    public class MainWindowViewModel:NotifyBase
    {
        //初始化
        string m_Path = $@"{Environment.CurrentDirectory}\{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}EModules.txt";
        ModuleFile moduleFile;
        DynamicModules dynamicModules;

        private string _log;

        public string Log
        {
            get { return _log; }
            set { _log =$"[{DateTime.Now}] {value}"; DoNotify(nameof(Log)); }
        }


        public MainWindowViewModel()
        {
            Log = "启动";
            moduleFile =new ModuleFile();
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
                            //在根目录下创建一个文件
                            dynamicModules.CreateModules(m_Path,moduleFile.StandardModuleProgram);
                            Log = $"已在路径：{m_Path}创建文件";
                        }
                        );
                }
                return _createModuleCommand;
            }
        }


        private async void StartAnimationIn(FrameworkElement element, float seconds)
        {
            var sb = new Storyboard();
            var offset = element.ActualHeight;
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, -offset, -0, offset),
                To = new Thickness(0)
            };
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            sb.Children.Add(animation);
            var fadeIn = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath("Opacity"));
            sb.Children.Add(fadeIn);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)(seconds * 1000));
        }

    }
}
