namespace Tabconv
{
    public static class Writeables
    {
        public static string list = 
@"
<==========================================================================>
Comma Separated Values
                Extension:      .csv
                Description:    Files with Comma Separated Values extension 
                                represent plain text files that contain 
                                records of data with comma separated values.
                More info:      https://docs.fileformat.com/spreadsheet/csv/

Markdown   
                Extension:      .md
                Description:    Markdown is a lightweight markup language 
                                that you can use to add formatting elements 
                                to plaintext text documents.
                More info:      https://www.markdownguide.org/basic-syntax/

Hyper Text Markup Language
                Extension:      .html
                Description:    HTML is the standard markup language for 
                                documents designed to be displayed in a web 
                                browser.
                More info:      https://www.w3schools.com/html/

JavaScript Object Notation 
                Extension:      .json
                Description:    JavaScript Object Notation is a lightweight 
                                data-interchange format. It is easy for humans
                                to read and write. It is easy for machines to 
                                parse and generate.
                More info:      https://www.json.org/json-en.html

<==========================================================================>
";

public static string help = 
@"
-v,	—verbose	 	 	 	 Verbose mode (print files to Console)
-o	<file>,	—output=<file>	 Output	file specified by <file>	
-l,	—list-formats	 	 	 List formats	
-h,	—help		 	 	 	 Show usage	message	
-version		 	 	 	 Show version information
";

public static string info = 
@"
Tabconv version  1.0.0 2022-02-28";

        public static Exception FileTypeNotSupportedException(string type)
        {
            return new Exception($"File type not currently supported: {type}");
        }

        public static Exception NotAllPathsSetException(string pathtype)
        {
            return new Exception($"Error! {pathtype} path not set");
        }
    }
}