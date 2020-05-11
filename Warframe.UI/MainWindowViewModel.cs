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

        WeaponDataAccess _dataAccess;

        public MainWindowViewModel()
        {
            Configure.Init(_baseUrl, _index, _refresh);
        }

        RelayCommand _load;
        public RelayCommand Load
        {
            get => _load ?? (_load = new RelayCommand(() => OnLoad()));
        }

        public void OnLoad()
        {
            _dataAccess = new WeaponDataAccess();
            var weapons = _dataAccess.GetAll().Result;
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
