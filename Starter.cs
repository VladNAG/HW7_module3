using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7_module3
{
    public class Starter
    {
        private const string Logfile = "Logger.txt";
        private const string BekupFolder = "Bekup";
        public Starter(Logger log)
        {
            log.LogEvent += Backup;
        }

        private void Backup(object? sender, EventArgs e)
        {
            var backupFile = Path.Combine(BekupFolder, $"{DateTime.Now:yyyyMMddHHmmss}.txt");
            File.Copy(Logfile, backupFile);
        }
    }
}
