using System.Text.RegularExpressions;

namespace Tabconv
{
    public static class Tools
    {

        public static bool isNumber(string value)
        {
            if(Regex.IsMatch(value, @"^(\d+(\.\d+)?)$"))return true;
            else return false;
        }

        public static void DisplayArray(List<List<string>> arr)
        {
            for(int i=0; i<arr.Count; i++)
            {
                Console.Write(@$"[{i}]: ");
                for(int j=0; j<arr[i].Count; j++)
                {
                    string temp = arr[i][j]+",";
                    if(j == arr[i].Count - 1) temp = temp.Substring(0, temp.Length -1);
                    Console.Write(temp);
                }
                Console.WriteLine();
            }
        }

        public static void DisplayFile(string[] file)
        {
            foreach(string s in file)
            {
                Console.WriteLine(s)
;            }
        }

        public static string Remove(string str, char target)
        {
            string s = "";
            foreach(char c in str)
            {
                if(c!=target) s += c;
            }
            return s;
        }

        public static List<List<string>> TrimArray(List<List<string>> array)
        {
            for(int i=0; i< array.Count; i++)
            {
                for(int j=0; j<array[i].Count; j++)
                {
                   array[i][j] = array[i][j].Trim(' ');
                }
            }
            return array;
        }

        public static List<List<string>> RemoveAllWhitespace(List<List<string>> arr)
        {
            for(int i=0; i<arr.Count; i++)
            {
                for(int j=0; j<arr[i].Count; j++)
                {
                    arr[i][j] = ReplaceWhitespace(arr[i][j], " ");
                }
            }
            return arr;
        }

        public static string RemoveWhitespace(string s, string replace)
        {
            return ReplaceWhitespace(s, replace);
        }

        // Crediting @hypehuman, https://stackoverflow.com/questions/6219454/efficient-way-to-remove-all-whitespace-from-string
        private static readonly Regex sWhitespace = new Regex(@"\s+");
        private static string ReplaceWhitespace(string input, string replacement) 
        {
            return sWhitespace.Replace(input, replacement);
        }
    }
}