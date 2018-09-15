namespace Patterns
{
    public class Singleton
    {
        private static Singleton _singleton;

        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            return _singleton ?? new Singleton();
        }

        public string GetUnicornio()
        {
            return "Unicornio";
        }
    }
}
