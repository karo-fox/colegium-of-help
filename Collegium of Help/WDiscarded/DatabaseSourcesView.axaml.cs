using Avalonia.Controls;
using Collegium_of_Help.ViewModels;

namespace Collegium_of_Help.Views
{
    public partial class DatabaseSourcesView : UserControl
    {
        public DatabaseSourcesView()
        {
            DataContext = new DatabaseViewModel();
            InitializeComponent();
        }
    }
}
