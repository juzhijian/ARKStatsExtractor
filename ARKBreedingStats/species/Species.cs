﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using ARKBreedingStats.mods;

namespace ARKBreedingStats.species
{
    [JsonObject]
    public class Species
    {
        /// <summary>
        /// The name as it is displayed for the user in most controls.
        /// </summary>
        [JsonProperty]
        public string name;
        /// <summary>
        /// The name used for sorting in lists.
        /// </summary>
        public string SortName;
        /// <summary>
        /// The name suffixed by possible additional infos like cave, minion, etc.
        /// </summary>
        public string DescriptiveName { get; private set; }
        /// <summary>
        /// List of variant infos about that species.
        /// </summary>
        [JsonProperty]
        public string[] variants;
        /// <summary>
        /// The name of the species suffixed by additional variant infos and the mod it comes from.
        /// </summary>
        public string VariantInfo;
        public string DescriptiveNameAndMod { get; private set; }
        [JsonProperty]
        public string blueprintPath;
        /// <summary>
        /// The raw stat values without multipliers.
        /// </summary>
        [JsonProperty]
        public double[][] fullStatsRaw;
        /// <summary>
        /// The  alternative / Troodonism / bugged raw stat values without multipliers.
        /// The key is the stat index, the value is the base value (the only one that can have alternate values).
        /// Values depending on the base value, e.g. incPerWild or incPerDom etc. can use either the correct or alternative base value.
        /// </summary>
        [JsonProperty("altBaseStats")]
        public Dictionary<int, double> altBaseStatsRaw;
        /// <summary>
        /// The stat values with all multipliers applied and ready to use.
        /// </summary>
        public CreatureStat[] stats;
        /// <summary>
        /// The alternative / Troodonism base stat values with all multipliers applied and ready to use.
        /// Values depending on the base value, e.g. incPerWild or incPerDom etc. can use either the correct or alternative base value.
        /// </summary>
        public CreatureStat[] altStats;

        /// <summary>
        /// Indicates if a stat is shown in game represented by bit-flags
        /// </summary>
        [JsonProperty]
        private int displayedStats;
        public const int displayedStatsDefault = 927;
        /// <summary>
        /// Indicates if a species uses a stat represented by bit-flags
        /// </summary>
        private int usedStats;

        /// <summary>
        /// Indicates if the species is affected by the setting AllowFlyerSpeedLeveling
        /// </summary>
        [JsonProperty] public bool isFlyer;

        [JsonProperty]
        public float? TamedBaseHealthMultiplier;
        /// <summary>
        /// Indicates the multipliers for each stat applied to the imprinting-bonus
        /// </summary>
        [JsonProperty]
        private double[] statImprintMult;
        /// <summary>
        /// Custom override for stat imprinting multipliers.
        /// </summary>
        private double[] statImprintMultOverride;
        [JsonProperty]
        public ColorRegion[] colors; // every species has up to 6 color regions
        [JsonProperty]
        public TamingData taming;
        [JsonProperty]
        public BreedingData breeding;
        /// <summary>
        /// If the species uses no gender, ignore the sex in the breeding planner.
        /// </summary>
        [JsonProperty]
        public bool noGender;
        [JsonProperty]
        public Dictionary<string, double> boneDamageAdjusters;
        [JsonProperty]
        public List<string> immobilizedBy;
        /// <summary>
        /// Information about the mod. If this value equals null, the species is probably from the base-game.
        /// </summary>
        private Mod _mod;

        /// <summary>
        /// Custom stat names of the species, e.g. glowSpecies use this.
        /// The key is the stat index as string, the value the statName.
        /// If this property is null, the default names are used.
        /// </summary>
        [JsonProperty]
        public Dictionary<string, string> statNames;

        /// <summary>
        /// True if the species is tameable or domesticable in other ways (e.g. raising from collected eggs).
        /// </summary>
        public bool IsDomesticable;

        /// <summary>
        /// creates properties that are not created during deserialization. They are set later with the raw-values with the multipliers applied.
        /// </summary>
        [OnDeserialized]
        private void Initialize(StreamingContext context)
        {
            // TODO: Base species are maybe not used in game and may only lead to confusion (e.g. Giganotosaurus).

            InitializeNames();

            stats = new CreatureStat[Stats.StatsCount];
            if (altBaseStatsRaw != null)
                altStats = new CreatureStat[Stats.StatsCount];

            usedStats = 0;
            double[][] completeRaws = new double[Stats.StatsCount][];
            for (int s = 0; s < Stats.StatsCount; s++)
            {
                stats[s] = new CreatureStat();
                if (altBaseStatsRaw?.ContainsKey(s) ?? false)
                    altStats[s] = new CreatureStat();

                completeRaws[s] = new double[] { 0, 0, 0, 0, 0 };
                if (fullStatsRaw.Length > s && fullStatsRaw[s] != null)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (fullStatsRaw[s].Length > i)
                        {
                            completeRaws[s][i] = fullStatsRaw[s]?[i] ?? 0;
                            if (i == 0 && fullStatsRaw[s][0] > 0)
                            {
                                usedStats |= (1 << s);
                            }
                        }
                    }
                }
            }
            fullStatsRaw = completeRaws;
            if (TamedBaseHealthMultiplier == null)
                TamedBaseHealthMultiplier = 1;

            if (colors?.Length == 0)
                colors = null;
            if (colors != null && colors.Length < Ark.ColorRegionCount)
            {
                var allColorRegions = new ColorRegion[Ark.ColorRegionCount];
                colors.CopyTo(allColorRegions, 0);
                colors = allColorRegions;
            }

            if (string.IsNullOrEmpty(blueprintPath))
                blueprintPath = string.Empty;

            if (boneDamageAdjusters != null && boneDamageAdjusters.Any())
            {
                // cleanup boneDamageMultipliers. Remove duplicates. Improve names.
                var boneDamageAdjustersCleanedUp = new Dictionary<string, double>();
                Regex rCleanBoneDamage = new Regex(@"(^r_|^l_|^c_|Cnt_|JNT|\d+|SKL)");
                foreach (KeyValuePair<string, double> bd in boneDamageAdjusters)
                {
                    string boneName = rCleanBoneDamage.Replace(bd.Key, "").Replace("_", "");
                    if (boneName.Length < 2) continue;
                    boneName = boneName.Substring(0, 1).ToUpper() + boneName.Substring(1);
                    if (!boneDamageAdjustersCleanedUp.ContainsKey(boneName))
                        boneDamageAdjustersCleanedUp.Add(boneName, Math.Round(bd.Value, 2));
                }
                boneDamageAdjusters = boneDamageAdjustersCleanedUp;
            }

            IsDomesticable = (taming != null && (taming.nonViolent || taming.violent))
                             || (breeding != null && (breeding.incubationTime > 0 || breeding.gestationTime > 0));

            if (statImprintMult == null) statImprintMult = new double[] { 0.2, 0, 0.2, 0, 0.2, 0.2, 0, 0.2, 0.2, 0.2, 0, 0 }; // default values for the stat imprint multipliers
        }

        /// <summary>
        /// Sets the name, descriptive name and variant info.
        /// </summary>
        public void InitializeNames()
        {
            string variantInfoForName = null;
            if (variants != null && variants.Any())
            {
                VariantInfo = string.Join(", ", variants);
                variantInfoForName = string.Join(", ", variants.Where(v => !name.Contains(v)));
            }

            DescriptiveName = name + (string.IsNullOrEmpty(variantInfoForName) ? string.Empty : " (" + variantInfoForName + ")");
            string modSuffix = string.IsNullOrEmpty(_mod?.title) ? string.Empty : _mod.title;
            DescriptiveNameAndMod = DescriptiveName + (string.IsNullOrEmpty(modSuffix) ? string.Empty : " (" + modSuffix + ")");
            SortName = DescriptiveNameAndMod;
        }

        /// <summary>
        /// Sets the ArkColor objects for the natural occurring colors. Call after colors are loaded or changed by loading mods.
        /// </summary>
        public void InitializeColors(ArkColors arkColors)
        {
            if (colors != null)
            {
                for (int i = 0; i < Ark.ColorRegionCount; i++)
                    colors[i]?.Initialize(arkColors);
            }

            InitializeColorRegions();
        }

        /// <summary>
        /// Sets which color regions are enabled. Call after Properties.Settings.Default.HideInvisibleColorRegions was changed.
        /// </summary>
        public void InitializeColorRegions()
        {
            EnabledColorRegions = colors?.Select(n =>
                      !string.IsNullOrEmpty(n?.name) && (!n.invisible || !Properties.Settings.Default.HideInvisibleColorRegions)
                ).ToArray() ??
                new[] { true, true, true, true, true, true, };
        }

        /// <summary>
        /// Array indicating which color regions are used by this species.
        /// </summary>
        public bool[] EnabledColorRegions;

        /// <summary>
        /// Indicates the multipliers for each stat applied to the imprinting-bonus.
        /// To override the multipliers, set the value to a custom array.
        /// </summary>
        public double[] StatImprintMultipliers => statImprintMultOverride ?? statImprintMult;

        /// <summary>
        /// The default stat imprinting multipliers.
        /// </summary>
        public double[] StatImprintingMultipliersDefault => statImprintMult;

        /// <summary>
        /// Sets the stat imprinting multipliers to custom values. If null is passed, the default values are used.
        /// </summary>
        /// <param name="overrides"></param>
        public void SetCustomImprintingMultipliers(double?[] overrides)
        {
            if (overrides == null)
            {
                statImprintMultOverride = null;
                return;
            }

            // if a value if null, use the default value
            double[] overrideValues = new double[Stats.StatsCount];

            // if value is equal to default, set override to null
            bool isEqual = true;
            for (int s = 0; s < Stats.StatsCount; s++)
            {
                if (overrides[s] == null)
                {
                    overrideValues[s] = statImprintMult[s];
                    continue;
                }
                overrideValues[s] = overrides[s] ?? 0;
                if (statImprintMult[s] != overrideValues[s])
                {
                    isEqual = false;
                }
            }
            if (isEqual) statImprintMultOverride = null;
            else statImprintMultOverride = overrideValues;
        }

        /// <summary>
        /// Returns if the species uses a stat, i.e. it has a base value > 0.
        /// </summary>
        /// <param name="statIndex"></param>
        /// <returns></returns>
        public bool UsesStat(int statIndex) => (usedStats & 1 << statIndex) != 0;

        /// <summary>
        /// Returns if the species displays a stat ingame in the inventory.
        /// </summary>
        /// <param name="statIndex"></param>
        /// <returns></returns>
        public bool DisplaysStat(int statIndex) => (displayedStats & 1 << statIndex) != 0;

        public override string ToString()
        {
            return DescriptiveNameAndMod ?? name;
        }

        public override int GetHashCode()
        {
            return blueprintPath.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Species other && !string.IsNullOrEmpty(other.blueprintPath) && other.blueprintPath == blueprintPath;
        }

        public static bool operator ==(Species a, Species b)
        {
            if (a is null)
                return b is null;

            return ReferenceEquals(a, b) || a.Equals(b);
        }

        public static bool operator !=(Species a, Species b) => !(a == b);

        public Mod Mod
        {
            set
            {
                _mod = value;
                InitializeNames();
            }
            get => _mod;
        }

        /// <summary>
        /// Returns an array of colors for a creature of this species with the naturally occurring colors.
        /// </summary>
        public byte[] RandomSpeciesColors(Random rand = null)
        {
            if (rand == null) rand = new Random();

            var randomColors = new byte[Ark.ColorRegionCount];
            for (int ci = 0; ci < Ark.ColorRegionCount; ci++)
            {
                if (!EnabledColorRegions[ci]) continue;
                var colorCount = colors?[ci]?.naturalColors?.Count ?? 0;
                if (colorCount == 0)
                    randomColors[ci] = (byte)(6 + rand.Next(100));
                else randomColors[ci] = colors[ci].naturalColors[rand.Next(colorCount)].Id;
            }

            return randomColors;
        }
    }
}
