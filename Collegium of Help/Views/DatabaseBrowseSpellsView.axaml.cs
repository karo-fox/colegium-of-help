using Avalonia.Controls;
using Collegium_of_Help.ViewModels;

namespace Collegium_of_Help.Views
{
    public partial class DatabaseBrowseSpellsView : UserControl
    {
        public DatabaseBrowseSpellsView()
        {
            DataContext = new DatabaseSpellsViewModel();
            InitializeComponent();
        }
    }
}
