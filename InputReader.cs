using System;
using System.IO;

namespace Tabconv
{
    public class InputReader
    {  
        Controller cont = new Controller();
        public void Start(string[] args)
        {
            //string x = "-i ./files/csv.csv -o ./output/file.html";
            try
            {
                Parse(args);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Parse(string[] args)
        {
            string input = "";
            string output = "";

            for(int i=0; i<args.Length; i++)
            {
                switch(args[i])
                {
                    case "-v":
                        Controller.verbose = true;
                        break;
                    case "-verbose":
                        Controller.verbose = true;
                        break;
                    case "-l":
                        Console.WriteLine(Writeables.list);
                        break;
                    case "-list-formats":
                        Console.WriteLine(Writeables.list);
                        break;
                    case "-h":
                        Console.WriteLine(Writeables.help);
                        break;
                    case "-help":
                        Console.WriteLine(Writeables.help);
                        break;
                    case "-version":
                        Console.WriteLine(Writeables.info);
                        break;
                    case "-i":
                        input = args[i+1];
                        break;
                    case "-input":
                        input = args[i+1];
                        break;
                    case "-o":
                        output = args[i+1];
                        break;
                    case "-output":
                        output = args[i+1];
                        break;
                    default: 
                        break;
                }
            }

            if(input != "" && output != "") cont.Convert(input, output);
            else if(input != "" && output == "") throw Writeables.NotAllPathsSetException("Output");
            else if(input == "" && output != "") throw Writeables.NotAllPathsSetException("Input");
        }
    }
}