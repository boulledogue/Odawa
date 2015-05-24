using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BU
{
    public static class LogManager
    {
        private static string tmpPath = System.IO.Path.GetTempPath();

        public static void LogException(string message)
        {
            string logFilePath =  tmpPath + "OdawaExceptionLog.log";
            System.IO.File.AppendAllText(logFilePath, message);
        }
    }
}
