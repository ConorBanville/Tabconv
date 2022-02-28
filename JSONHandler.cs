namespace Tabconv
{
    public class JSONHandler : IHandler
    {
        public override List<List<string>> ToArray(string[] file)
        {
            List<string> data = new List<string>();
            List<string> fields = new List<string>();
            for(int i=0; i<file.Length; i++)
            {
                if(file[i].Contains(':'))
                {
                    string[] t = file[i].Split(":");
                    if(!fields.Contains(t[0])) fields.Add(t[0]);
                    string s = Tools.RemoveWhitespace(t[1]," ");
                    s = Tools.Remove(s,'"');
                    s = Tools.Remove(s,',');
                    s = s.Trim(' ');
                    data.Add(s);
                }
            }

            for(int i=0; i<fields.Count; i++)
            {
                fields[i] = Tools.RemoveWhitespace(fields[i]," ");
                fields[i] = Tools.Remove(fields[i], '"');
                fields[i] = Tools.Remove(fields[i], ',');
                fields[i] = fields[i].Trim(' ');
            }

            List<List<string>> arr = new List<List<string>>();
            arr.Add(fields);
            int delta = 0;
            for(int i=0; i<data.Count / arr[0].Count; i++)
            {
                List<string> elm = new List<string>();
                for(int j=0; j<arr[0].Count; j++)
                {
                    elm.Add(data[j+delta]);
                }
                arr.Add(elm);
                delta += arr[0].Count;
            }
            return arr;
        }

        public override string[] ToFile(List<List<string>> array)
        {
            List<string> file = new List<string>();
            file.Add("[");
            for(int i=1; i<array.Count; i++)
            {
                file.Add("\t{");
                for(int j=0; j<array[i].Count; j++)
                {
                    if(Tools.isNumber(array[i][j]))
                    {
                        file.Add($"\t\t\"{array[0][j]}\" : {array[i][j]},");
                    }
                    else file.Add($"\t\t\"{array[0][j]}\" : \"{array[i][j]}\",");

                    if(j==array[i].Count-1)
                    {
                        file[file.Count-1] = file[file.Count-1].Trim(',');
                    }
                }
                file.Add("\t},");
            }
            file[file.Count-1] = file[file.Count-1].Trim(',');
            file.Add("]");
            return file.ToArray();
        }
    }
}