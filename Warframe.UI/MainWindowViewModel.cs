using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warframe.Data;
using Warframe.UI.Screens;

namespace Warframe.UI
{
    class MainWindowViewModel : ViewModel
    {
        const string _baseUrl = "http://content.warframe.com/PublicExport/Manifest/";
        const string _index = "http://content.warframe.com/PublicExport/index_en.txt.lzma";
        const int _refresh = 60;

        WeaponsDataAccess _dataAccess;

        RelayCommand _load;
        public RelayCommand Load
        {
            get => _load ?? (_load = new RelayCommand(() => OnLoad()));
        }

        public async Task OnLoad()
        {
            _dataAccess = new WeaponsDataAccess(_baseUrl, _index, _refresh);
            var weapons = await _dataAccess.GetAllWeapons();
            Weapons = new WeaponsViewModel(weapons);
        }

        public WeaponsViewModel Weapons
        {
            get => _weapons;
            set
            {
                if (_weapons == value)
                    return;

                _weapons = value;
                OnPropertyChanged(nameof(Weapons));
            }
        }

        WeaponsViewModel _weapons;
    }
}
