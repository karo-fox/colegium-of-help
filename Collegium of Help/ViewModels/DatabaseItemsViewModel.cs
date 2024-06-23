using Collegium_of_Help.Models.Entities;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collegium_of_Help.ViewModels
{
    public class DatabaseItemsViewModel : MainViewModel
    {
        #region Publiczne właściwości
        public ObservableCollection<Equipment> EquipmentItems { get; set; }
        public int SelectedIndex { get => _selectedIndex; set 
            {
                this.RaiseAndSetIfChanged(ref _selectedIndex, value);
                Name = EquipmentItems[_selectedIndex].Name;
                Description = EquipmentItems[_selectedIndex].Description;
                Rarity = EquipmentItems[_selectedIndex].Rarity;
                Weight = EquipmentItems[_selectedIndex].Weight;
                Cost = EquipmentItems[_selectedIndex].Cost;
                Alignment = EquipmentItems[_selectedIndex].Alignment;
                Magical = EquipmentItems[_selectedIndex].Magic;
                EquipmentSource = EquipmentItems[_selectedIndex].SourceBook;
            } }
        public string Name { get => _name; set => this.RaiseAndSetIfChanged(ref _name, value); }
        public string Description { get => _description; set => this.RaiseAndSetIfChanged(ref _description, value); }
        public string Rarity { get => _rarity; set => this.RaiseAndSetIfChanged(ref _rarity, value); }
        public float Weight { get => _weight; set => this.RaiseAndSetIfChanged(ref _weight, value); }
        public string Cost { get => _cost; set => this.RaiseAndSetIfChanged(ref _cost, value); }
        public bool Magical { get => _magical; set => this.RaiseAndSetIfChanged(ref _magical, value); }
        public string Alignment { get => _alignment; set => this.RaiseAndSetIfChanged(ref _alignment, value); }
        public int EquipmentSource { get => _source; set => this.RaiseAndSetIfChanged(ref _source, value); }
        #endregion
        #region Prywatne właściwości
        private int _selectedIndex = 0;
        private string _name = String.Empty;
        private string _description = String.Empty;
        private string _rarity = String.Empty;
        private float _weight = 0.0f;
        private string _cost = String.Empty;
        private bool _magical = false;
        private string _alignment = String.Empty;
        private int _source = 0;
        #endregion
        #region Metody
        public DatabaseItemsViewModel()
        {
            EquipmentItems = new ObservableCollection<Equipment>();
            EquipmentItems.Add(new Equipment(1, "Miecz", "Ostry", "pospolity", 1.5f, "50 sz", false, null, 1));
            EquipmentItems.Add(new Equipment(2, "Ognisty miecz", "Ostry i parzy", "rzadki", 1.5f, "250 sz", true, "Wymaga zestrojenia z wojownikiem", 1));
            SelectedIndex = 0;
        }
        #endregion
    }
}
