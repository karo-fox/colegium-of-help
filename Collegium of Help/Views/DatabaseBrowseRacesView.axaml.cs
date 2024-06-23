using Avalonia.Controls;
using Collegium_of_Help.ViewModels;

namespace Collegium_of_Help.Views
{
    public partial class DatabaseBrowseRacesView : UserControl
    {
        public DatabaseBrowseRacesView()
        {
            DataContext = new DatabaseRacesViewModel();
            InitializeComponent();
        }
    }
}
