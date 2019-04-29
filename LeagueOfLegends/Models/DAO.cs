﻿using LeagueOfLegends.Models.StaticDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueOfLegends.Models
{
    public class DAO
    {
        private LeagueOfLegendsStaticDataEntities db;

        public DAO()
        {
            this.db = new LeagueOfLegendsStaticDataEntities();
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
                this.updateChampionInfoTable(entry.key, champion.info);
                this.updateChampionStatsTable(entry.key, champion.stats);
                this.updateChampionSkinsTable(entry.key, champion.skins);
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
    }
}