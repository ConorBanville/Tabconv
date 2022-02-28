namespace Tabconv
{
    public abstract class IHandler
    {
        public abstract List<List<string>> ToArray(string[] file);

        public abstract string[] ToFile( List<List<string>> array);
    }
}