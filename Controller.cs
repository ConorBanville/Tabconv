namespace Tabconv
{
    public class Controller
    {
        public static bool verbose {get; set;}
        IHandler MDHandler = new MDHandler();
        IHandler CSVHandler = new CSVHandler();
        IHandler HTMLHandler = new HTMLHandler();
        IHandler JSONHandler = new JSONHandler();

        public void Convert(string input, string output)
        {   
            List<List<string>> arr;
            string[] file;
            string[] extensions = GetExtension(input, output);
            switch(extensions[0])
            {
                case ".csv":
                    arr = CSVHandler.ToArray(File.ReadAllLines(input));
                    break;
                case ".md":
                    arr = MDHandler.ToArray(File.ReadAllLines(input));
                    break;
                case ".html":
                    arr = HTMLHandler.ToArray(File.ReadAllLines(input));
                    break;
                case ".json":
                    arr = JSONHandler.ToArray(File.ReadAllLines(input));
                    break;
                default:
                    throw Writeables.FileTypeNotSupportedException(extensions[0]);
            }

            switch(extensions[1])
            {
                case ".csv":
                    file = CSVHandler.ToFile(arr);
                    break;
                case ".md":
                    file = MDHandler.ToFile(arr);
                    break;
                case ".html":
                    file = HTMLHandler.ToFile(arr);
                    break;
                case ".json":
                    file = JSONHandler.ToFile(arr);
                    break;
                default:
                    throw Writeables.FileTypeNotSupportedException(extensions[1]);
            }

            CreateDirectory(FormatPath(output));
            WriteFile(file, input, output);
        }

        private void WriteFile(string[] file, string input, string path)
        {
            File.WriteAllLines(path, file);
            if(verbose)
            {
                Console.WriteLine("Input ==>\n");
                Tools.DisplayFile(File.ReadAllLines(input));
                Console.WriteLine("\nOutput ==>\n");
                Tools.DisplayFile(file);
                Console.WriteLine($"\nFile saved in {path}\n");
            }
        }

        private void CreateDirectory(string path)
        {
            if(!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
        }

        private string FormatPath(string path)
        {
            for(int i=path.Length - 1; i>0; i--)
            {
                if(path[i].Equals('/') || path[i].Equals('\\')) return path.Substring(0, i);
            }
            return path;
        }

        private string[] GetExtension(string input, string output)
        {
            string[] extensions = new string[2];
            for(int i=input.Length-1; i>0; i--)
            {
                if(input[i] == '.')extensions[0] = input.Substring(i, input.Length - i);  
            }
            for(int i=output.Length-1; i>0; i--)
            {
                if(output[i] == '.')extensions[1] = output.Substring(i, output.Length - i); 
            }
            return extensions;
        }
    }
}