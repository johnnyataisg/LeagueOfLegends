using LeagueOfLegends.Models.StaticDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class DAO
    {
        private DatabaseEntity db;

        public DAO()
        {
            this.db = new DatabaseEntity();
        }

        public void importChampionFullJSON(ChampionFull data)
        {
            this.updateDatatypeTable(data.type, data.format, data.version);
            this.updateChampionKeysTable(data.keys);
            this.updateChampionInfoTable(data.data);
        }

        public void updateDatatypeTable(String type, String format, String version)
        {
            bool newRow = false;
            Datatype entry = this.db.Datatypes.Find(type);
            if (entry == null)
            {
                newRow = true;
                entry = new Datatype();
                entry.type = type;
            }
            entry.format = format;
            entry.version = version;
            if (newRow)
            {
                this.db.Datatypes.Add(entry);
            }
            this.db.SaveChanges();
        }

        public void updateChampionKeysTable(Dictionary<String, String> keys)
        {
            foreach (KeyValuePair<String, String> pair in keys)
            {
                bool newRow = false;
                int key = Convert.ToInt32(pair.Key);
                ChampionKey entry = this.db.ChampionKeys.Find(key);
                if (entry == null)
                {
                    newRow = true;
                    entry = new ChampionKey();
                    entry.id = key;
                }
                entry.name = pair.Value;
                entry.dbtype = "champion";
                if (newRow)
                {
                    this.db.ChampionKeys.Add(entry);
                }
            }
            this.db.SaveChanges();
        }

        public void updateChampionInfoTable(Dictionary<String, ChampionData> data)
        {
            foreach (KeyValuePair<String, ChampionData> pair in data)
            {
                bool newRow = false;
                ChampionData champion = pair.Value;
                int key = Convert.ToInt32(champion.key);
                ChampionSummary entry = this.db.ChampionSummary.Find(key);
                if (entry == null)
                {
                    newRow = true;
                    entry = new ChampionSummary();
                    entry.key = key;
                }
                entry.id = champion.id;
                entry.name = champion.name;
                entry.title = champion.title;
                entry.image = this.updateChampionImagesTable(champion.image);
                entry.lore = champion.lore;
                entry.blurb = champion.blurb;
                entry.partype = champion.partype;
                entry.passive = this.updateChampionPassivesTable(champion.passive);
                if (newRow)
                {
                    this.db.ChampionSummary.Add(entry);
                }
                this.updateDependentTables(key, champion);
            }
            this.db.SaveChanges();
        }

        public int updateChampionImagesTable(StaticDataModels.ChampionImage image)
        {
            bool newRow = false;
            ChampionImage entry = this.db.ChampionImages.Where(row => row.full == image.full).FirstOrDefault();
            if (entry == null)
            {
                newRow = true;
                entry = new ChampionImage();
            }
            entry.full = image.full;
            entry.sprite = image.sprite;
            entry.group = image.group;
            entry.x = image.x;
            entry.y = image.y;
            entry.w = image.w;
            entry.h = image.h;
            if (newRow)
            {
                this.db.ChampionImages.Add(entry);
            }
            this.db.SaveChanges();
            return entry.id;
        }

        public int updateChampionPassivesTable(StaticDataModels.ChampionPassive passive)
        {
            bool newRow = false;
            int foreignKey = this.updatePassiveImagesTable(passive.image);
            ChampionPassive entry = this.db.ChampionPassives.Where(row => row.image == foreignKey).FirstOrDefault();
            if (entry == null)
            {
                newRow = true;
                entry = new ChampionPassive();
            }
            entry.image = foreignKey;
            if (passive.name != "" && passive.name != null)
            {
                entry.name = passive.name;
                entry.description = passive.description;
            }
            if (newRow)
            {
                this.db.ChampionPassives.Add(entry);
            }
            this.db.SaveChanges();
            return entry.id;
        }

        public int updatePassiveImagesTable(StaticDataModels.SpellImage image)
        {
            bool newRow = false;
            PassiveImage entry = this.db.PassiveImages.Where(row => row.full == image.full).FirstOrDefault();
            if (entry == null)
            {
                newRow = true;
                entry = new PassiveImage();
            }
            entry.full = image.full;
            entry.sprite = image.sprite;
            entry.group = image.group;
            entry.x = image.x;
            entry.y = image.y;
            entry.w = image.w;
            entry.h = image.h;
            if (newRow)
            {
                this.db.PassiveImages.Add(entry);
            }
            this.db.SaveChanges();
            return entry.id;
        }

        public int updateSpellImagesTable(StaticDataModels.SpellImage image)
        {
            bool newRow = false;
            SpellImage entry = this.db.SpellImages.Where(row => row.full == image.full).FirstOrDefault();
            if (entry == null)
            {
                newRow = true;
                entry = new SpellImage();
            }
            entry.full = image.full;
            entry.sprite = image.sprite;
            entry.group = image.group;
            entry.x = image.x;
            entry.y = image.y;
            entry.w = image.w;
            entry.h = image.h;
            if (newRow)
            {
                this.db.SpellImages.Add(entry);
            }
            this.db.SaveChanges();
            return entry.id;
        }

        public void updateDependentTables(int championKey, ChampionData championData)
        {
            this.updateAllyTipsTable(championKey, championData.allytips);
            this.updateEnemyTipsTable(championKey, championData.enemytips);
            this.updateChampionTypesTable(championKey, championData.tags);
            this.updateChampionInfoTable(championKey, championData.info);
            this.updateChampionStatsTable(championKey, championData.stats);
            this.updateChampionSkinsTable(championKey, championData.skins);
            this.updateChampionSpellsTable(championKey, championData.spells);
        }

        public void updateAllyTipsTable(int championKey, List<String> allytips)
        {
            List<AllyTip> entries = this.db.AllyTips.Where(row => row.championKey == championKey).ToList();
            if (entries.Count() == 0 || entries == null)
            {
                foreach (String tip in allytips)
                {
                    AllyTip newEntry = new AllyTip();
                    newEntry.description = tip;
                    newEntry.championKey = championKey;
                    this.db.AllyTips.Add(newEntry);
                    this.db.SaveChanges();
                }
            }
            else if (entries.Count() == allytips.Count())
            {
                for (int i = 0; i < entries.Count(); i++)
                {
                    entries.ElementAt(i).description = allytips.ElementAt(i);
                    entries.ElementAt(i).championKey = championKey;
                    this.db.SaveChanges();
                }
            }
            else if (entries.Count() > allytips.Count())
            {
                for (int i = 0; i < allytips.Count(); i++)
                {
                    entries.ElementAt(i).description = allytips.ElementAt(i);
                    entries.ElementAt(i).championKey = championKey;
                    this.db.SaveChanges();
                }
                for (int i = allytips.Count(); i < entries.Count(); i++)
                {
                    this.db.AllyTips.Remove(entries.ElementAt(i));
                    this.db.SaveChanges();
                }
            }
            else if (entries.Count() < allytips.Count())
            {
                for (int i = 0; i < entries.Count(); i++)
                {
                    entries.ElementAt(i).description = allytips.ElementAt(i);
                    entries.ElementAt(i).championKey = championKey;
                    this.db.SaveChanges();
                }
                for (int i = entries.Count(); i < allytips.Count(); i++)
                {
                    AllyTip newEntry = new AllyTip();
                    newEntry.description = allytips.ElementAt(i);
                    newEntry.championKey = championKey;
                    this.db.AllyTips.Add(newEntry);
                    this.db.SaveChanges();
                }
            }
        }

        public void updateEnemyTipsTable(int championKey, List<String> enemytips)
        {
            List<EnemyTip> entries = this.db.EnemyTips.Where(row => row.championKey == championKey).ToList();
            if (entries.Count() == 0 || entries == null)
            {
                foreach (String tip in enemytips)
                {
                    EnemyTip newEntry = new EnemyTip();
                    newEntry.description = tip;
                    newEntry.championKey = championKey;
                    this.db.EnemyTips.Add(newEntry);
                    this.db.SaveChanges();
                }
            }
            else if (entries.Count() == enemytips.Count())
            {
                for (int i = 0; i < entries.Count(); i++)
                {
                    entries.ElementAt(i).description = enemytips.ElementAt(i);
                    entries.ElementAt(i).championKey = championKey;
                    this.db.SaveChanges();
                }
            }
            else if (entries.Count() > enemytips.Count())
            {
                for (int i = 0; i < enemytips.Count(); i++)
                {
                    entries.ElementAt(i).description = enemytips.ElementAt(i);
                    entries.ElementAt(i).championKey = championKey;
                    this.db.SaveChanges();
                }
                for (int i = enemytips.Count(); i < entries.Count(); i++)
                {
                    this.db.EnemyTips.Remove(entries.ElementAt(i));
                    this.db.SaveChanges();
                }
            }
            else if (entries.Count() < enemytips.Count())
            {
                for (int i = 0; i < entries.Count(); i++)
                {
                    entries.ElementAt(i).description = enemytips.ElementAt(i);
                    entries.ElementAt(i).championKey = championKey;
                    this.db.SaveChanges();
                }
                for (int i = entries.Count(); i < enemytips.Count(); i++)
                {
                    EnemyTip newEntry = new EnemyTip();
                    newEntry.description = enemytips.ElementAt(i);
                    newEntry.championKey = championKey;
                    this.db.EnemyTips.Add(newEntry);
                    this.db.SaveChanges();
                }
            }
        }

        public void updateChampionTypesTable(int championKey, List<String> types)
        {
            List<ChampionType> entries = this.db.ChampionTypes.Where(row => row.championKey == championKey).ToList();
            if (entries.Count() == 0 || entries == null)
            {
                foreach (String tag in types)
                {
                    ChampionType newEntry = new ChampionType();
                    newEntry.description = tag;
                    newEntry.championKey = championKey;
                    this.db.ChampionTypes.Add(newEntry);
                    this.db.SaveChanges();
                }
            }
            else if (entries.Count() == types.Count())
            {
                for (int i = 0; i < entries.Count(); i++)
                {
                    entries.ElementAt(i).description = types.ElementAt(i);
                    entries.ElementAt(i).championKey = championKey;
                    this.db.SaveChanges();
                }
            }
            else if (entries.Count() > types.Count())
            {
                for (int i = 0; i < types.Count(); i++)
                {
                    entries.ElementAt(i).description = types.ElementAt(i);
                    entries.ElementAt(i).championKey = championKey;
                    this.db.SaveChanges();
                }
                for (int i = types.Count(); i < entries.Count(); i++)
                {
                    this.db.ChampionTypes.Remove(entries.ElementAt(i));
                    this.db.SaveChanges();
                }
            }
            else if (entries.Count() < types.Count())
            {
                for (int i = 0; i < entries.Count(); i++)
                {
                    entries.ElementAt(i).description = types.ElementAt(i);
                    entries.ElementAt(i).championKey = championKey;
                    this.db.SaveChanges();
                }
                for (int i = entries.Count(); i < types.Count(); i++)
                {
                    ChampionType newEntry = new ChampionType();
                    newEntry.description = types.ElementAt(i);
                    newEntry.championKey = championKey;
                    this.db.ChampionTypes.Add(newEntry);
                    this.db.SaveChanges();
                }
            }
        }

        public void updateChampionInfoTable(int championKey, StaticDataModels.ChampionInfo info)
        {
            bool newRow = false;
            ChampionInfo entry = this.db.ChampionInfo.Where(row => row.championKey == championKey).FirstOrDefault();
            if (entry == null)
            {
                newRow = true;
                entry = new ChampionInfo();
            }
            entry.attack = info.attack;
            entry.defense = info.defense;
            entry.magic = info.magic;
            entry.difficulty = info.difficulty;
            entry.championKey = championKey;
            if (newRow)
            {
                this.db.ChampionInfo.Add(entry);
            }
            this.db.SaveChanges();
        }

        public void updateChampionStatsTable(int championKey, ChampionStats stats)
        {
            bool newRow = false;
            ChampionStat entry = this.db.ChampionStats.Where(row => row.championKey == championKey).FirstOrDefault();
            if (entry == null)
            {
                newRow = true;
                entry = new ChampionStat();
            }
            entry.hp = Math.Round(stats.hp, 3);
            entry.hpperlevel = Math.Round(stats.hpperlevel, 3);
            entry.mp = Math.Round(stats.mp, 3);
            entry.mpperlevel = Math.Round(stats.mpperlevel, 3);
            entry.movespeed = Math.Round(stats.movespeed, 3);
            entry.armor = Math.Round(stats.armor, 3);
            entry.armorperlevel = Math.Round(stats.armorperlevel, 3);
            entry.spellblock = Math.Round(stats.spellblock, 3);
            entry.spellblockperlevel = Math.Round(stats.spellblockperlevel, 3);
            entry.attackrange = Math.Round(stats.attackrange, 3);
            entry.hpregen = Math.Round(stats.hpregen, 3);
            entry.hpregenperlevel = Math.Round(stats.hpregenperlevel, 3);
            entry.mpregen = Math.Round(stats.mpperlevel, 3);
            entry.mpregenperlevel = Math.Round(stats.mpregenperlevel, 3);
            entry.crit = Math.Round(stats.crit, 3);
            entry.critperlevel = Math.Round(stats.critperlevel, 3);
            entry.attackdamage = Math.Round(stats.attackdamage, 3);
            entry.attackdamageperlevel = Math.Round(stats.attackdamageperlevel, 3);
            entry.attackspeed = Math.Round(stats.attackspeed, 3);
            entry.attackspeedperlevel = Math.Round(stats.attackspeedperlevel, 3);
            entry.championKey = championKey;
            if (newRow)
            {
                this.db.ChampionStats.Add(entry);
            }
            this.db.SaveChanges();
        }

        public void updateChampionSkinsTable(int championKey, List<StaticDataModels.ChampionSkin> skins)
        {
            foreach (StaticDataModels.ChampionSkin skin in skins)
            {
                bool newRow = false;
                int key = Convert.ToInt32(skin.id);
                ChampionSkin entry = this.db.ChampionSkins.Where(row => row.id == key).FirstOrDefault();
                if (entry == null)
                {
                    newRow = true;
                    entry = new ChampionSkin();
                    entry.id = key;
                }
                entry.num = skin.num;
                entry.name = skin.name;
                entry.chromas = skin.chromas;
                entry.championKey = championKey;
                if (newRow)
                {
                    this.db.ChampionSkins.Add(entry);
                }
            }
            this.db.SaveChanges();
        }

        public void updateChampionSpellsTable(int championKey, List<StaticDataModels.ChampionSpell> spells)
        {
            foreach (StaticDataModels.ChampionSpell spell in spells)
            {
                bool newRow = false;
                ChampionSpell entry = this.db.ChampionSpells.Find(spell.id);
                if (entry == null)
                {
                    newRow = true;
                    entry = new ChampionSpell();
                    entry.id = spell.id;
                }
                entry.name = spell.name;
                entry.description = spell.description;
                entry.tooltip = spell.tooltip;
                entry.maxrank = spell.maxrank;
                entry.costburn = spell.costBurn;
                entry.cooldownburn = spell.cooldownBurn;
                entry.datavalues = "";
                entry.vars = "";
                entry.costtype = spell.costType;
                entry.maxammo = spell.maxammo;
                entry.rangeburn = spell.rangeBurn;
                entry.image = this.updateSpellImagesTable(spell.image);
                entry.resource = spell.resource;
                entry.championKey = championKey;
                if (newRow)
                {
                    this.db.ChampionSpells.Add(entry);
                }
                if (spell.leveltip != null)
                {
                    this.updateLevelTipsTable(entry.id, spell.leveltip);
                }
                this.updateSpellRanksTable(entry.id, spell.cooldown, spell.cost, spell.effect, spell.effectBurn, spell.range);
            }
            this.db.SaveChanges();
        }

        public void updateLevelTipsTable(String spellID, SpellLevelTip levelTip)
        {
            List<LevelTip> entries = this.db.LevelTips.Where(row => row.spellID == spellID).ToList();
            if (entries.Count() == 0 || entries == null)
            {
                for (int i = 0; i < levelTip.label.Count(); i++)
                {
                    LevelTip newEntry = new LevelTip();
                    newEntry.label = levelTip.label.ElementAt(i);
                    newEntry.effect = levelTip.effect.ElementAt(i);
                    newEntry.spellID = spellID;
                    this.db.LevelTips.Add(newEntry);
                    this.db.SaveChanges();
                }
            }
            else if (entries.Count() == levelTip.label.Count())
            {
                for (int i = 0; i < entries.Count(); i++)
                {
                    entries.ElementAt(i).label = levelTip.label.ElementAt(i);
                    entries.ElementAt(i).effect = levelTip.effect.ElementAt(i);
                    entries.ElementAt(i).spellID = spellID;
                    this.db.SaveChanges();
                }
            }
            else if (entries.Count() > levelTip.label.Count())
            {
                for (int i = 0; i < levelTip.label.Count(); i++)
                {
                    entries.ElementAt(i).label = levelTip.label.ElementAt(i);
                    entries.ElementAt(i).effect = levelTip.effect.ElementAt(i);
                    entries.ElementAt(i).spellID = spellID;
                    this.db.SaveChanges();
                }
                for (int i = levelTip.label.Count(); i < entries.Count(); i++)
                {
                    this.db.LevelTips.Remove(entries.ElementAt(i));
                    this.db.SaveChanges();
                }
            }
            else if (entries.Count() < levelTip.label.Count())
            {
                for (int i = 0; i < entries.Count(); i++)
                {
                    entries.ElementAt(i).label = levelTip.label.ElementAt(i);
                    entries.ElementAt(i).effect = levelTip.effect.ElementAt(i);
                    entries.ElementAt(i).spellID = spellID;
                    this.db.SaveChanges();
                }
                for (int i = entries.Count(); i < levelTip.label.Count(); i++)
                {
                    LevelTip newEntry = new LevelTip();
                    newEntry.label = levelTip.label.ElementAt(i);
                    newEntry.effect = levelTip.effect.ElementAt(i);
                    newEntry.spellID = spellID;
                    this.db.LevelTips.Add(newEntry);
                    this.db.SaveChanges();
                }
            }
        }

        public void updateSpellRanksTable(String spellID, List<float> cooldown, List<float> cost, List<List<float>> effect, List<String> effectBurn, List<float> range)
        {
            List<SpellRank> entries = this.db.SpellRanks.Where(row => row.spellID == spellID).ToList();
            for (int i = 0; i < entries.Count(); i++)
            {
                entries.ElementAt(i).rank = i + 1;
                entries.ElementAt(i).cooldown = cooldown.ElementAt(i);
                entries.ElementAt(i).cost = cost.ElementAt(i);
                entries.ElementAt(i).range = range.ElementAt(i);
                entries.ElementAt(i).spellID = spellID;
                //this.updateSpellEffectsTable(entries.ElementAt(i).id, i, effect, effectBurn);
                this.db.SaveChanges();
            }
            for (int i = entries.Count(); i < cooldown.Count(); i++)
            {
                SpellRank newEntry = new SpellRank();
                newEntry.rank = i + 1;
                newEntry.cooldown = cooldown.ElementAt(i);
                newEntry.cost = cost.ElementAt(i);
                newEntry.range = range.ElementAt(i);
                newEntry.spellID = spellID;
                this.db.SpellRanks.Add(newEntry);
                //this.updateSpellEffectsTable(newEntry.id, i, effect, effectBurn);
                this.db.SaveChanges();
            }
        }

        public void updateSpellEffectsTable(int spellRankID, int index, List<List<float>> effect, List<String> effectBurn)
        {
            List<SpellEffect> entries = this.db.SpellEffects.Where(row => row.spellRankID == spellRankID).ToList();
            for (int i = 0; i < entries.Count(); i++)
            {
                if (effect.ElementAt(i) == null)
                {
                    entries.ElementAt(i).effect = null;
                }
                else
                {
                    entries.ElementAt(i).effect = effect.ElementAt(i).ElementAt(index);
                }
                entries.ElementAt(i).effectburn = effectBurn.ElementAt(i);
                entries.ElementAt(i).spellRankID = spellRankID;
                this.db.SaveChanges();
            }
            for (int i = entries.Count(); i < effect.Count(); i++)
            {
                SpellEffect newEntry = new SpellEffect();
                if (effect.ElementAt(i) == null)
                {
                    newEntry.effect = null;
                }
                else
                {
                    newEntry.effect = effect.ElementAt(i).ElementAt(index);
                }
                newEntry.effectburn = effectBurn.ElementAt(i);
                newEntry.spellRankID = spellRankID;
                this.db.SpellEffects.Add(newEntry);
                this.db.SaveChanges();
            }
        }
    }
}