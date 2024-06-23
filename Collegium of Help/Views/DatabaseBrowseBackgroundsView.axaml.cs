using Avalonia.Controls;
using Collegium_of_Help.ViewModels;

namespace Collegium_of_Help.Views
{
    public partial class DatabaseBrowseBackgroundsView : UserControl
    {
        public DatabaseBrowseBackgroundsView()
        {
            DataContext = new DatabaseBackgroundsViewModel();
            InitializeComponent();
        }
    }
}
