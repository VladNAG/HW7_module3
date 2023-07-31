using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HW7_module3
{
    public class Logger
    {
        private const string Logfile = "Logger.txt";
        private const string BekupFolder = "Bekup";
        private readonly object _lock = new object();
        private static int _count = 0;
        public event EventHandler? LogEvent;

        public async Task MyLogger()
        {
            if (!Directory.Exists(BekupFolder))
            {
                Directory.CreateDirectory(BekupFolder);
            }

            await Task.WhenAll(Func1(), Func2());
        }

        private async Task Func1()
        {
            for (int i = 0; i < 50; i++)
            {
                Log($"working mathed1:{DateTime.Now}");
                await Task.Delay(100);
            }
        }

        private async Task Func2()
        {
            for (int i = 0; i < 50; i++)
            {
                Log($"working mathed2:{DateTime.Now}");
                if (++_count % 10 == 0)
                {
                    LogEvent.Invoke(null, null);
                }

                await Task.Delay(100);
            }
        }

        private void Log(string msg)
        {
            lock (_lock)
            {
                File.AppendAllText(Logfile, msg);
            }
        }
    }
}
