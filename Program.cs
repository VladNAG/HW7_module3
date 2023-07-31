namespace HW7_module3
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var log = new Logger();
            var start = new Starter(log);
            await log.MyLogger();
        }
    }
}