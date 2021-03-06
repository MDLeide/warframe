﻿using System;
using System.Linq;

namespace Warframe.Data
{
    class Index
    {
        public string BaseAddress { get; private set; }

        public string Customs { get; private set; }
        public string Drones { get; private set; }
        public string Flavour { get; private set; }
        public string FusionBundles { get; private set; }
        public string Gear { get; private set; }
        public string Keys { get; private set; }
        public string Recipes { get; private set; }
        public string Regions { get; private set; }
        public string RelicArcane { get; private set; }
        public string Resources { get; private set; }
        public string Sentinels { get; private set; }
        public string SortieRewards { get; private set; }
        public string Upgrades { get; private set; }
        public string Warframes { get; private set; }
        public string Weapons { get; private set; }
        public string Manifest { get; private set; }

        public string GetByDataType(CoreDataType dataType)
        {
            switch (dataType)
            {
                case CoreDataType.Customs:
                    return Customs;
                case CoreDataType.Drones:
                    return Drones;
                case CoreDataType.Flavour:
                    return Flavour;
                case CoreDataType.FusionBundles:
                    return FusionBundles;
                case CoreDataType.Gear:
                    return Gear;
                case CoreDataType.Keys:
                    return Keys;
                case CoreDataType.Recipes:
                    return Recipes;
                case CoreDataType.Regions:
                    return Recipes;
                case CoreDataType.RelicArcane:
                    return RelicArcane;
                case CoreDataType.Resources:
                    return Resources;
                case CoreDataType.Sentinels:
                    return Sentinels;
                case CoreDataType.SortieRewards:
                    return SortieRewards;
                case CoreDataType.Upgrades:
                    return Upgrades;
                case CoreDataType.Warframes:
                    return Warframes;
                case CoreDataType.Weapons:
                    return Weapons;
                case CoreDataType.Manifest:
                    return Manifest;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dataType), dataType, null);
            }
        }

        public static Index CreateFromString(string baseAddress, string data)
        {
            var lines = data.Split(new[] {Environment.NewLine}, StringSplitOptions.None).Select(p => p.Trim());

            var index = new Index();
            index.BaseAddress = baseAddress;
            index.Customs = lines.First(p => p.Contains("ExportCustoms"));
            index.Drones = lines.First(p => p.Contains("ExportDrones"));
            index.Flavour = lines.First(p => p.Contains("ExportFlavour"));
            index.FusionBundles = lines.First(p => p.Contains("ExportFusionBundles"));
            index.Gear = lines.First(p => p.Contains("ExportGear"));
            index.Keys = lines.First(p => p.Contains("ExportKeys"));
            index.Recipes = lines.First(p => p.Contains("ExportRecipes"));
            index.Regions = lines.First(p => p.Contains("ExportRegions"));
            index.RelicArcane = lines.First(p => p.Contains("ExportRelicArcane"));
            index.Resources = lines.First(p => p.Contains("ExportResources"));
            index.Sentinels = lines.First(p => p.Contains("ExportSentinels"));
            index.SortieRewards = lines.First(p => p.Contains("ExportSortieRewards"));
            index.Upgrades = lines.First(p => p.Contains("ExportUpgrades"));
            index.Warframes = lines.First(p => p.Contains("ExportWarframes"));
            index.Weapons = lines.First(p => p.Contains("ExportWeapons"));
            index.Manifest = lines.First(p => p.Contains("ExportManifest"));

            return index;
        }
    }
}