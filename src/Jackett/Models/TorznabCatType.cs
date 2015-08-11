﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackett.Models
{
    class TorznabCatType
    {
        private static Dictionary<int, string> cats = new Dictionary<int, string>();

        static TorznabCatType()
        {
            cats.Add(1000, "Consoles");
            cats.Add(1010, "Consoles/DS");
            cats.Add(1020, "Consoles/PSP");
            cats.Add(1030, "Consoles/Wii");
            cats.Add(1040, "Consoles/Xbox");
            cats.Add(1050, "Consoles/360");
            cats.Add(1080, "Consoles/PS3");

            cats.Add(2000, "Movies");
            cats.Add(2010, "Movies/Foreign");
            cats.Add(2020, "Movies/Other");
            cats.Add(2040, "Movies/HD");
            cats.Add(2030, "Movies/SD");
            cats.Add(2050, "Movies/3D");
            cats.Add(2060, "Movies/BluRay");

            cats.Add(3000, "Audio");
            cats.Add(3010, "Audio/Lossy");
            cats.Add(3020, "Audio/Video");
            cats.Add(3030, "Audio/Audiobook");
            cats.Add(3040, "Audio/Lossless");

            cats.Add(4000, "PC");
            cats.Add(4010, "PC/Apps");
            cats.Add(4020, "PC/ISO");
            cats.Add(4030, "PC/Mac");
            cats.Add(4040, "PC/Mobile");
            cats.Add(4050, "PC/Games");
            cats.Add(4060, "PC/Mobile/IOS");
            cats.Add(4070, "PC/Mobile/Android");

            cats.Add(5000, "TV");
            cats.Add(5020, "TV/Foreign");
            cats.Add(5030, "TV/SD");
            cats.Add(5040, "TV/HD");
            cats.Add(5060, "TV/Sport");
            cats.Add(5070, "TV/Anime");
            cats.Add(5080, "TV/Documentary");

            cats.Add(6000, "XXX");
            cats.Add(6010, "XXX/DVD");
            cats.Add(6040, "XXX/x264");
            cats.Add(6060, "XXX/Imageset");

            cats.Add(8000, "Books");
            cats.Add(8010, "Books/Ebook");
            cats.Add(8020, "Books/Comics");
        }

        public static bool QueryContainsParentCategory(int[] queryCats, int releaseCat)
        {
            if (cats.ContainsKey(releaseCat) && queryCats != null)
            {
                var ncab = cats[releaseCat];
                var split = ncab.IndexOf("/");
                if (split > -1)
                {
                    string parentCatName = ncab.Substring(0, split);
                    if (cats.ContainsValue(parentCatName))
                    {
                        var parentCat = cats.Where(c => c.Value == parentCatName).First().Key;
                        return queryCats.Contains(parentCat);
                    }
                }
            }

            return false;
        }

        public static string GetCatDesc(int newznabcat)
        {
            if (cats.ContainsKey(newznabcat))
            {
                return cats[newznabcat];
            }

            return string.Empty;
        }

        private static TorznabCategory GetCat(int id)
        {
            return new TorznabCategory()
            {
                ID = id,
                Name = cats.ContainsKey(id) ? cats[id] : string.Empty
            };
        }

        public static TorznabCategory Anime
        {
            get { return GetCat(5070); }
        }

        public static TorznabCategory TV
        {
            get { return GetCat(5000); }
        }

        public static TorznabCategory TVDocs
        {
            get { return GetCat(5080); }
        }

        public static TorznabCategory TVSD
        {
            get { return GetCat(5030); }
        }

        public static TorznabCategory TVHD
        {
            get { return GetCat(5040); }
        }

        public static TorznabCategory TVSport
        {
            get { return GetCat(5060); }
        }

        public static TorznabCategory TVForeign
        {
            get { return GetCat(5020); }
        }

        public static TorznabCategory Books
        {
            get { return GetCat(8000); }
        }

        public static TorznabCategory EBooks
        {
            get { return GetCat(8020); }
        }

        public static TorznabCategory Comic
        {
            get { return GetCat(8020); }
        }

        public static TorznabCategory Apps
        {
            get { return GetCat(4010); }
        }

        public static TorznabCategory AppsMobile
        {
            get { return GetCat(4040); }
        }

        public static TorznabCategory Movies
        {
            get { return GetCat(2000); }
        }

        public static TorznabCategory MoviesForeign
        {
            get { return GetCat(2010); }
        }

        public static TorznabCategory MoviesOther
        {
            get { return GetCat(2020); }
        }

        public static TorznabCategory MoviesHD
        {
            get { return GetCat(2040); }
        }

        public static TorznabCategory MoviesSD
        {
            get { return GetCat(2030); }
        }

        public static TorznabCategory MoviesBlueRay
        {
            get { return GetCat(2060); }
        }

        public static TorznabCategory Movies3D
        {
            get { return GetCat(2050); }
        }

        public static TorznabCategory Audio
        {
            get { return GetCat(3000); }
        }

        public static TorznabCategory AudioBooks
        {
            get { return GetCat(3030); }
        }

        public static TorznabCategory AudioLossless
        {
            get { return GetCat(3040); }
        }

        public static TorznabCategory AudioLossy
        {
            get { return GetCat(3010); }
        }


        public static TorznabCategory AudioMusicVideos
        {
            get { return GetCat(3020); }
        }

        public static TorznabCategory XXX
        {
            get { return GetCat(6000); }
        }

        public static TorznabCategory XXXHD
        {
            get { return GetCat(6040); }
        }

        public static TorznabCategory XXXSD
        {
            get { return GetCat(6010); }
        }

        public static TorznabCategory XXXImg
        {
            get { return GetCat(6060); }
        }

        public static TorznabCategory PC
        {
            get { return GetCat(4000); }
        }

        public static TorznabCategory PC0Day
        {
            get { return GetCat(4010); }
        }

        public static TorznabCategory PCIso
        {
            get { return GetCat(4020); }
        }

        public static TorznabCategory PCMac
        {
            get { return GetCat(4030); }
        }

        public static TorznabCategory PCGames
        {
            get { return GetCat(4050); }
        }

        public static TorznabCategory PCMobileOther
        {
            get { return GetCat(4040); }
        }

        public static TorznabCategory PCMobileIos
        {
            get { return GetCat(4060); }
        }

        public static TorznabCategory PCMobileAndroid
        {
            get { return GetCat(4070); }
        }

        public static TorznabCategory Consoles
        {
            get { return GetCat(1000); }
        }

        public static TorznabCategory ConsoleDS
        {
            get { return GetCat(1010); }
        }

        public static TorznabCategory ConsolePSP
        {
            get { return GetCat(1020); }
        }

        public static TorznabCategory ConsoleXbox
        {
            get { return GetCat(1040); }
        }

        public static TorznabCategory ConsoleXbox360
        {
            get { return GetCat(1050); }
        }

        public static TorznabCategory ConsoleWii
        {
            get { return GetCat(1030); }
        }

        public static TorznabCategory ConsolePS3
        {
            get { return GetCat(1080); }
        }
    }
}
