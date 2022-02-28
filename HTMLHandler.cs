namespace Tabconv
{
    public class HTMLHandler : IHandler
    {
        public override List<List<string>> ToArray(string[] file)
        {
            List<List<string>> arr = new List<List<string>>();
            List<string> row = new List<string>();
            bool collecting = false;
            for(int i=0; i<file.Length; i++)
            {
                if(!collecting && file[i].Contains("<tr>")) 
                {
                    collecting = true;  
                    i++;
                }

                if(collecting && file[i].Contains("</tr>"))
                {
                    collecting = false;
                    arr.Add(row);
                    row = new List<string>();
                }

                if(collecting) row.Add(file[i]);
            }
            arr = Format(arr);
            return arr;
        }

        private List<List<string>> Format(List<List<string>> arr)
        {
            //arr = Tools.RemoveAllWhitespace(arr);
            for(int i=0; i<arr.Count; i++)
            {
                for(int j=0; j<arr[i].Count; j++)
                {
                    arr[i][j] = arr[i][j].Substring(arr[i][j].IndexOf('>') + 1, arr[i][j].Length - (arr[i][j].IndexOf('>')+1));
                    arr[i][j] = arr[i][j].Substring(0, arr[i][j].IndexOf('<'));
                }
            }
            arr = Tools.TrimArray(arr);
            return arr;
        }

        public override string[] ToFile(List<List<string>> array)
        {
            List<string> html = new List<string>();

            html.Add("<table>");
            html.Add("\t<tr>");
            foreach(string s in FormatHtmlHeaders(array[0]))
            {
                html.Add(s);
            }
            html.Add("\t</tr>");

            for(int i=1; i<array.Count; i++)
            {
                html.Add("\t<tr>");
                foreach(string s in FormatHtmlData(array[i]))
                {
                    html.Add(s);
                }
                html.Add("\t</tr>");
            }
            html.Add("</table>");
            return html.ToArray();
        }

        private List<string> FormatHtmlHeaders(List<string> headers)
        {
            for(int i=0; i<headers.Count; i++)
            {
                headers[i] = "\t\t<th>" + headers[i] + "</th>";
            }
            return headers;
        }

        private List<string> FormatHtmlData(List<string> data)
        {
            for(int i=0; i<data.Count; i++)
            {
                data[i] = "\t\t<td>" + data[i] + "</td>";
            }
            return data;
        }
    }
}