using Avalonia.Controls;
using Collegium_of_Help.ViewModels;

namespace Collegium_of_Help.Views
{
    public partial class DatabaseView : UserControl
    {
        public DatabaseView()
        {
            DataContext = new TabItemViewModel[]
            {
                new TabItemViewModel(iconPath: "/Assets/home.svg", content: new DatabaseBrowseView(), tabName: "Przegl¹daj"),
                new TabItemViewModel(iconPath: "/Assets/database.svg", content: new DatabaseAddView(), tabName: "Dodaj"),
                new TabItemViewModel(iconPath: "/Assets/home.svg", content: new DatabaseModifyView(), tabName: "Modyfikuj"),
                new TabItemViewModel(iconPath: "/Assets/database.svg", content: new DatabaseRemoveView(), tabName: "Usuñ")
            };
            InitializeComponent();
        }
    }
}
