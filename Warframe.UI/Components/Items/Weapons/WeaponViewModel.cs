using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warframe.UI.Components.Items.Weapons
{
    class WeaponViewModel : ViewModel
    {
        public WeaponViewModel(Weapon weapon)
        {
            Weapon = weapon;
        }

        public Weapon Weapon { get; }
        public string Name => Weapon.Name;

        public int OmegaAttentuation
        {
            get => Weapon.OmegaAttentuation;
            set
            {
                Weapon.OmegaAttentuation = value;
                OnPropertyChanged(nameof(OmegaAttentuation));
            }
        }

        public WeaponNoiseLevel Noise
        {
            get => Weapon.Noise;
            set
            {
                Weapon.Noise = value;
                OnPropertyChanged(nameof(Noise));
            }
        }

        public float SecondsPerShot
        {
            get => Weapon.SecondsPerShot;
            set
            {
                Weapon.SecondsPerShot = value;
                OnPropertyChanged(nameof(SecondsPerShot));
            }
        }

        public float[] DamagePerShot
        {
            get => Weapon.DamagePerShot;
            set
            {
                Weapon.DamagePerShot = value;
                OnPropertyChanged(nameof(DamagePerShot));
            }
        }

        public int MagazineSize
        {
            get => Weapon.MagazineSize;
            set
            {
                Weapon.MagazineSize = value;
                OnPropertyChanged(nameof(MagazineSize));
            }
        }

        public float ReloadTime
        {
            get => Weapon.ReloadTime;
            set
            {
                Weapon.ReloadTime = value;
                OnPropertyChanged(nameof(ReloadTime));
            }
        }

        public float TotalDamage
        {
            get => Weapon.TotalDamage;
            set
            {
                Weapon.TotalDamage = value;
                OnPropertyChanged(nameof(TotalDamage));
            }
        }

        public int DamagePerSecond
        {
            get => Weapon.DamagePerSecond;
            set
            {
                Weapon.DamagePerSecond = value;
                OnPropertyChanged(nameof(DamagePerSecond));
            }
        }

        public WeaponTriggerType? Trigger
        {
            get => Weapon.Trigger;
            set
            {
                Weapon.Trigger = value;
                OnPropertyChanged(nameof(Trigger));
            }
        }

        public float Accuracy
        {
            get => Weapon.Accuracy;
            set
            {
                Weapon.Accuracy = value;
                OnPropertyChanged(nameof(Accuracy));
            }
        }

        public float CriticalChance
        {
            get => Weapon.CriticalChance;
            set
            {
                Weapon.CriticalChance = value;
                OnPropertyChanged(nameof(CriticalChance));
            }
        }

        public float CriticalMultiplier
        {
            get => Weapon.CriticalMultiplier;
            set
            {
                Weapon.CriticalMultiplier = value;
                OnPropertyChanged(nameof(CriticalMultiplier));
            }
        }

        public float ProcChance
        {
            get => Weapon.ProcChance;
            set
            {
                Weapon.ProcChance = value;
                OnPropertyChanged(nameof(ProcChance));
            }
        }

        public int ChargeAttack
        {
            get => Weapon.ChargeAttack;
            set
            {
                Weapon.ChargeAttack = value;
                OnPropertyChanged(nameof(ChargeAttack));
            }
        }

        public int SpinAttack
        {
            get => Weapon.SpinAttack;
            set
            {
                Weapon.SpinAttack = value;
                OnPropertyChanged(nameof(SpinAttack));
            }
        }

        public int LeapAttack
        {
            get => Weapon.LeapAttack;
            set
            {
                Weapon.LeapAttack = value;
                OnPropertyChanged(nameof(LeapAttack));
            }
        }

        public int WallAttack
        {
            get => Weapon.WallAttack;
            set
            {
                Weapon.WallAttack = value;
                OnPropertyChanged(nameof(WallAttack));
            }
        }

        public int Slot
        {
            get => Weapon.Slot;
            set
            {
                Weapon.Slot = value;
                OnPropertyChanged(nameof(Slot));
            }
        }

        public bool Sentinel
        {
            get => Weapon.Sentinel;
            set
            {
                Weapon.Sentinel = value;
                OnPropertyChanged(nameof(Sentinel));
            }
        }

        public int MasteryRequired
        {
            get => Weapon.MasteryRequired;
            set
            {
                Weapon.MasteryRequired = value;
                OnPropertyChanged(nameof(MasteryRequired));
            }
        }

        public string ProductCategory
        {
            get => Weapon.ProductCategory;
            set
            {
                Weapon.ProductCategory = value;
                OnPropertyChanged(nameof(ProductCategory));
            }
        }

    }
}
