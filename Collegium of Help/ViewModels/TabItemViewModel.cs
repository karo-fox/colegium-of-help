using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.ViewModels
{
    public class TabItemViewModel : ViewModelBase
    {
        private string _iconPath;
        private UserControl _content;
        private string _tabName;
        public string IconPath 
        {
            get => _iconPath;
            set => this.RaiseAndSetIfChanged(ref _iconPath, value);
        }
        public UserControl Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public string TabName
        {
            get => _tabName;
            set => this.RaiseAndSetIfChanged(ref _tabName, value);
        }

        public TabItemViewModel(string iconPath, UserControl content, string tabName)
        {
            IconPath = iconPath;
            Content = content;
            TabName = tabName; 
        }
    }
}
