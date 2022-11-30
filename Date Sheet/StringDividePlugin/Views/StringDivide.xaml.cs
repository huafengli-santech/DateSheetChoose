using StringDividePlugin.ViewModels;
using System.Windows;
using System.Windows.Controls;
namespace StringDividePlugin.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class StringDivide : UserControl
    {
        StringDivideViewModel model = null;
        public StringDivide()
        {
            InitializeComponent();
            model = new StringDivideViewModel();
            this.DataContext = model;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            model.UpdateCommand.Execute();
        }
    }
}
