using Prism_DataSheet.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Prism_DataSheet.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            this.MaxHeight=SystemParameters.MaximizedPrimaryScreenHeight;
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            _vm = DataContext as MainWindowViewModel;
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _vm.LoadModules.Execute();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
