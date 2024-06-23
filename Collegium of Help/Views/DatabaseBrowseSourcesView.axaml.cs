using Avalonia.Controls;
using Collegium_of_Help.ViewModels;

namespace Collegium_of_Help.Views
{
    public partial class DatabaseBrowseSourcesView : UserControl
    {
        public DatabaseBrowseSourcesView()
        {
            DataContext = new DatabaseSourcesViewModel();
            InitializeComponent();
        }
    }
}
