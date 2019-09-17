using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Desktop.PW.Forms.Helper
{
    public class InputValues
    {
        private TwoList<string, string> AllKeys;
        private TwoList<int, string> Times;
        private TwoList<string, string> Partys;

        public InputValues()
        {
            FillAllKeys();
            FillTimes();
            FillPartys();
        }

        #region All Keys

        private void FillAllKeys()
        {
            AllKeys = new TwoList<string, string>();
            AllKeys.Add("F1", "F1");
            AllKeys.Add("F2", "F2");
            AllKeys.Add("F3", "F3");
            AllKeys.Add("F4", "F4");
            AllKeys.Add("F5", "F5");
            AllKeys.Add("F6", "F6");
            AllKeys.Add("F7", "F7");
            AllKeys.Add("F8", "F8");
            AllKeys.Add("Tab", "Tab");
            AllKeys.Add("D1", "1");
            AllKeys.Add("D2", "2");
            AllKeys.Add("D3", "3");
            AllKeys.Add("D4", "4");
            AllKeys.Add("D5", "5");
            AllKeys.Add("D6", "6");
            AllKeys.Add("D7", "7");
            AllKeys.Add("D8", "8");
            AllKeys.Add("D9", "9");
            AllKeys.Add("NumPad5", "Pet Atk");
            AllKeys.Add("NumPad6", "Pet Skill 1");
            AllKeys.Add("NumPad7", "Pet Skill 2");
            AllKeys.Add("NumPad8", "Pet Skill 3");
            AllKeys.Add("NumPad9", "Pet Skill 4");
        }

        public string GetAllKeyFirst(IEnumerable<string> excludes = null)
        {
            excludes = excludes ?? new List<string>();
            return AllKeys.Where(p => !excludes.Contains(p.V1)).First().V1;
        }
        public string GetAllKeyText(string key)
        {
            if (string.IsNullOrEmpty(key))
                return "none";
            return AllKeys.SingleOrDefault(p => p.V1 == key)?.V2;
        }
        public string GetAllKeyPrev(string key, bool includeNone = false, IEnumerable<string> excludes = null)
        {
            excludes = excludes ?? new List<string>();
            var universe = AllKeys.Where(p => !excludes.Contains(p.V1)).ToList();
            if (includeNone)
                universe.Insert(0, new Two<string, string>(null, "none"));

            for (var i = 1; i < universe.Count; i++)
            {
                if (universe[i].V1 == key)
                    return universe[i - 1].V1;
            }
            return key;
        }
        public string GetAllKeyPost(string key, bool includeNone = false, IEnumerable<string> excludes = null)
        {
            excludes = excludes ?? new List<string>();
            var universe = AllKeys.Where(p => !excludes.Contains(p.V1)).ToList();
            if (includeNone)
                universe.Insert(0, new Two<string, string>(null, "none"));

            for (var i = 0; i < universe.Count - 1; i++)
            {
                if (universe[i].V1 == key)
                    return universe[i + 1].V1;
            }
            return key;
        }

        #endregion

        #region Times

        private void FillTimes()
        {
            Times = new TwoList<int, string>();
            Times.Add(0, "off");
            Times.Add(120, "faster");
            Times.Add(500, "0.5s");
            for (var i = 1; i <= 59; i++) Times.Add(i * 1000, $"{i}s");    // segs
            for (var i = 1; i <= 59; i++) Times.Add(i * 60000, $"{i}m");   // mins
        }

        public int GetTimesFirst()
        {
            return Times.First().V1;
        }
        public string GetTimesText(int time)
        {
            return Times.SingleOrDefault(p => p.V1 == time)?.V2;
        }
        public int GetTimesPrev(int time)
        {
            for (var i = 1; i < Times.Count; i++)
            {
                if (Times[i].V1 == time)
                    return Times[i - 1].V1;
            }
            return time;
        }
        public int GetTimesPost(int time)
        {
            for (var i = 0; i < Times.Count - 1; i++)
            {
                if (Times[i].V1 == time)
                    return Times[i + 1].V1;
            }
            return time;
        }

        #endregion

        #region PartyMembers

        private void FillPartys()
        {
            Partys = new TwoList<string, string>();
            Partys.Add("NumPad0", "Party 1");
            Partys.Add("NumPad1", "Party 2");
            Partys.Add("NumPad2", "Party 3");
            Partys.Add("NumPad3", "Party 4");
            Partys.Add("NumPad4", "Party 5");
        }

        public string GetPartysFirst(IEnumerable<string> excludes = null)
        {
            excludes = excludes ?? new List<string>();
            return Partys.Where(p => !excludes.Contains(p.V1)).First().V1;
        }
        public string GetPartysText(string key)
        {
            return Partys.SingleOrDefault(p => p.V1 == key)?.V2;
        }
        public string GetPartysPrev(string key, IEnumerable<string> excludes = null)
        {
            excludes = excludes ?? new List<string>();
            var universe = Partys.Where(p => !excludes.Contains(p.V1)).ToList();

            for (var i = 1; i < universe.Count; i++)
            {
                if (universe[i].V1 == key)
                    return universe[i - 1].V1;
            }
            return key;
        }
        public string GetPartysPost(string key, IEnumerable<string> excludes = null)
        {
            excludes = excludes ?? new List<string>();
            var universe = Partys.Where(p => !excludes.Contains(p.V1)).ToList();

            for (var i = 0; i < universe.Count - 1; i++)
            {
                if (universe[i].V1 == key)
                    return universe[i + 1].V1;
            }
            return key;
        }

        #endregion

        public int GetPost(int value, List<int> list)
        {
            for (var i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == value)
                    return list[i + 1];
            }
            return value;
        }

        public int GetPrev(int value, List<int> list)
        {
            for (var i = 1; i < list.Count; i++)
            {
                if (list[i] == value)
                    return list[i - 1];
            }
            return value;
        }
    }
}
