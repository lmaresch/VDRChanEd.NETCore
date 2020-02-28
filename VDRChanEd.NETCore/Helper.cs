using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDRChanEd.NETCore
{
    public static class Helper
    {
        public static Dictionary<char, string> SplitParameters(string parameters)
        {
            Dictionary<char, string> splittedStrings = new Dictionary<char, string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < parameters.Length; ++i)
            {
                if (parameters[i] >= 'A' && sb.Length > 0)
                {
                    string text = sb.ToString();
                    splittedStrings.Add(text[0], text.Length > 1 ? text.Substring(1) : string.Empty);
                    sb.Clear();
                }

                sb.Append(parameters[i]);
            }
            if (sb.Length > 0)
            {
                string text = sb.ToString();
                splittedStrings.Add(text[0], text.Length > 1 ? text.Substring(1) : string.Empty);
            }

            return splittedStrings;
        }

        public static bool AreDictsEqual(Dictionary<char, string> lhs, Dictionary<char, string> rhs)
        {
            string errorMessage = string.Empty;
            return AreDictsEqual(lhs, rhs, ref errorMessage);
        }

        public static bool AreDictsEqual(Dictionary<char, string> lhs, Dictionary<char, string> rhs, ref string errorMessage)
        {
            bool retVal = true;
            errorMessage = string.Empty;
            Dictionary<char, char> uniqueItems = new Dictionary<char, char>();
            if (!AreOnlySameItemsinDicts(lhs, rhs, ref uniqueItems))
            {
                retVal = false;
                StringBuilder lsb = new StringBuilder();
                StringBuilder rsb = new StringBuilder();
                foreach(KeyValuePair<char, char> item in uniqueItems)
                {
                    if (item.Value.Equals('r'))
                        rsb.Append("Item " + item.Key + " missing in rhs.\n");
                    else
                        lsb.Append("Item " + item.Key + " missing in lhs.\n");
                }

                if (lsb.Length > 0)
                    errorMessage = lsb.ToString();
                if (rsb.Length > 0)
                    errorMessage += rsb.ToString();
            }

            Dictionary<char, KeyValuePair<string, string>> diffItems = new Dictionary<char, KeyValuePair<string, string>>();
            if (!AreAllItemsEqual(lhs, rhs, ref diffItems))
            {
                retVal = false;
                StringBuilder sb = new StringBuilder();
                foreach(KeyValuePair<char, KeyValuePair<string, string>> item in diffItems)
                {
                    sb.Append("Item " + item.Key + " differs in values: lhs=" + item.Value.Key + " / rhs=" + item.Value.Value + ".\n");
                }

                if (sb.Length > 0)
                    errorMessage += sb.ToString();
            }

            return retVal;
        }

        public static bool AreOnlySameItemsinDicts(Dictionary<char, string> lhs, Dictionary<char, string> rhs, ref Dictionary<char, char> uniqueKeys)
        {
            bool retVal = true;
            var diff1 = lhs.Except(rhs);
            var diff2 = rhs.Except(lhs);
            if (diff1.ToList().Count > 0)
                retVal = false;
            if (diff2.ToList().Count > 0)
                retVal = false;
            foreach(var diff1vals in diff1)
                uniqueKeys.Add(diff1vals.Key, 'r');
            foreach (var diff2vals in diff2)
                uniqueKeys.Add(diff2vals.Key, 'l');
            return retVal;
        }

        public static bool AreAllItemsEqual(Dictionary<char, string> lhs, Dictionary<char, string> rhs, ref Dictionary<char, KeyValuePair<string, string>> diffItems)
        {
            bool retVal = true;
            foreach(KeyValuePair<char, string> litem in lhs)
            {
                if (rhs.ContainsKey(litem.Key))
                {
                    if (!litem.Value.Equals(rhs[litem.Key]))
                    {
                        retVal = false;
                        diffItems.Add(litem.Key, new KeyValuePair<string, string>(litem.Value, rhs[litem.Key]));
                    }
                }
                else
                    continue; // Only checking for different items, not if it doesn't exist
            }

            return retVal;
        }

        public static Sources GetSourcesValueFromString(string source)
        {
            return (Sources)Enum.Parse(typeof(Sources), source.Replace('.', '_'));
        }

        public static string ReplaceDotWithComma(string input) => input.Replace('.', ',');
        public static string ReplaceCommaWithDot(string input) => input.Replace(',', '.');
        public static string ReplaceColonWithPipe(string input) => input.Replace(':', '|');
        public static string ReplacePipeWithColon(string input) => input.Replace('|', ':');

    }
}
