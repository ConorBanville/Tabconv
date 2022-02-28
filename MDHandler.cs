namespace Tabconv
{
    public class MDHandler : IHandler
    {
        public override List<List<string>> ToArray(string[] md)
        {
            List<List<string>> array = new List<List<string>>();
            for(int i=0; i<md.Length; i++)
            {
                if(i != 1)
                {
                    List<string> temp = new List<string>();
                    foreach(string x in GetDataValues(Tools.RemoveWhitespace(md[i], " ")))
                    {
                        if(x.Length > 0)
                        {
                            temp.Add(x.Replace("\t","").Replace("\n","").Trim(' '));
                        }
                    }
                    array.Add(temp);
                }
            }
            return array;
        }

        public override string[] ToFile(List<List<string>> array)
        {
            array = FormatArray(array);
            string[] md = new string[array.Count];
            for(int i=0; i<array.Count; i++)
            {
                md[i] = "|";
                for(int j=0; j<array[i].Count; j++)
                {
                    md[i] += array[i][j] + "|";
                }
            }
            return md;
        }

        private List<List<string>> FormatArray(List<List<string>> file)
        {
            int[] columnSizes = new int[file[0].Count];
            int maxColumn = 0;
            //loop through columns 
            for(int col=0; col<file[0].Count; col++)
            {
                //loop through rows
                for(int row=0; row<file.Count; row++)
                {
                    file[row][col] = file[row][col].Trim(' ');
                    if(file[row][col].Length > maxColumn) maxColumn = file[row][col].Length;
                }
                columnSizes[col] = maxColumn;
            }

            //loop through columns 
            for(int col=0; col<file[0].Count; col++)
            {
                //loop through rows
                for(int row=0; row<file.Count; row++)
                {
                    file[row][col] = padValue(file[row][col], columnSizes[col]);
                }
            }

            List<List<string>> newFile = new List<List<string>>();
            newFile.Add(file[0]);
            newFile.Add(getRowLine(columnSizes));
            for(int i=1; i<file.Count; i++)
            {
                newFile.Add(file[i]);
            }
            return newFile;
        }

        private List<string> getRowLine(int[] sizes)
        {
            List<string> _row = new List<string>();
            string row;
            for(int i=0; i<sizes.Length; i++)
            {
                row = "";
                for(int j=0; j<sizes[i]; j++)
                {
                    row += "-";
                }
                _row.Add(row);
            }
            return _row;
        }

        private string padValue(string s, int padLength)
        {
            if(s.Length >= padLength) return s;
            else 
            {
                int x = s.Length;
                for(int i=0; i<padLength-x; i++)
                {
                    s+= " ";
                }
                return s;
            }
        }

        private List<string> GetDataValues(string s)
        {
            s = s.Substring(1, s.Length - 2);
            return new List<string>(s.Split('|'));
        }
    }
}