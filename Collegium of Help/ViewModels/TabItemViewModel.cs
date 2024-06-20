using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.ViewModels
{
    public class TabItemViewModel
    {
        public string IconPath { get; set; }
        public UserControl Content { get; set; }

        public string TabName {  get; set; }

        public TabItemViewModel(string iconPath, UserControl content, string tabName)
        {
            IconPath = iconPath;
            Content = content;
            TabName = tabName; 
        }
    }
}
