using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;

namespace LogAndDeleteTMP
{
    class Program
    {
        
        public static void Main()
        {
            var path = @"C:\Users\Dominic\Desktop\Text";


            // I would assume this is normally done with some sort of scheduling/CRON service.
            bool flag = true;

            while (flag)
            {
                WriteLogFile.WriteLog(path);
                Thread.Sleep(3600000);
            }
        }
    }
}
