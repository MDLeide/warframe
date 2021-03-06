﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Warframe
{
    public class Weapon : Item
    {
        public int OmegaAttentuation { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public WeaponNoiseLevel Noise { get; set; }
        public float SecondsPerShot { get; set; }
        public float[] DamagePerShot { get; set; }
        public int MagazineSize { get; set; }
        public float ReloadTime { get; set; }
        public float TotalDamage { get; set; }
        public int DamagePerSecond { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public WeaponTriggerType? Trigger { get; set; }
        public float Accuracy { get; set; }
        public float CriticalChance { get; set; }
        public float CriticalMultiplier { get; set; }
        public float ProcChance { get; set; }
        public int ChargeAttack { get; set; }
        public int SpinAttack { get; set; }
        public int LeapAttack { get; set; }
        public int WallAttack { get; set; }
        public int Slot { get; set; }
        public bool Sentinel { get; set; }
        public int MasteryRequired { get; set; }
        public string ProductCategory { get; set; }
    }
}