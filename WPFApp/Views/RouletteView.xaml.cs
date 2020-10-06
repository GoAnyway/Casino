using WPFApp.ViewModels;

namespace WPFApp.Views
{
    /// <summary>
    ///     Interaction logic for RouletteView.xaml
    /// </summary>
    public partial class RouletteView
    {
        public RouletteView()
        {
            InitializeComponent();
            DataContext = new RouletteViewModel();
        }
    }
}