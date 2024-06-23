using Avalonia.Controls;
using Collegium_of_Help.ViewModels;

namespace Collegium_of_Help.Views
{
    public partial class DatabaseBrowseItemsView : UserControl
    {
        public DatabaseBrowseItemsView()
        {
            DataContext = new DatabaseItemsViewModel();
            InitializeComponent();
        }
    }
}
