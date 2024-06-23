using Avalonia.Controls;
using Collegium_of_Help.ViewModels;

namespace Collegium_of_Help.Views
{
    public partial class DatabaseBrowseClassesView : UserControl
    {
        public DatabaseBrowseClassesView()
        {
            DataContext = new DatabaseClassesViewModel();
            InitializeComponent();
        }
    }
}
