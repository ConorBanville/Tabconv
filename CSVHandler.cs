using System;
using System.Collections.Generic;

namespace Tabconv
{
    public class CSVHandler : IHandler
    {
        public override List<List<string>> ToArray(string[] csv)
        {
            List<List<string>> arr = new List<List<string>>();
            for(int i=0 ; i<csv.Length; i++)
            {
                arr.Add(new List<string>(csv[i].Replace("\"","").Replace("\t","").Replace("\n","").Split(',')));
            }
            return Tools.RemoveAllWhitespace(arr);
        }

        public override string[] ToFile(List<List<string>> array)
        {
            string[] csv = new string[array.Count];
            string temp;
            for(int i=0; i<array.Count; i++)
            {
                temp = "";
                for(int j=0; j<array[i].Count; j++)
                {
                    if(Tools.isNumber(array[i][j]))
                    {
                        temp += array[i][j]+",";
                    } 
                    else 
                    {
                        temp += "\"" + array[i][j] + "\",";
                    }
                }
                csv[i] = temp.Substring(0, temp.Length - 1);
            }
            return csv;
        }
    }
}