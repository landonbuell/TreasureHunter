using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunterCore.Administrative
{
    internal class TextLogger
    {
        // Log Text to Console or To File
        private string _outputFile;
        private LogLevel _logLevel;

        private bool _logToConsole;
        private bool _logToFile;

        internal enum LogLevel
        {
            // Enumeration for Log Level Severity
            TRACE = 0,
            INFO = 1,
            MESSAGE = 2,
            WARNING = 3,
            ERROR = 4,
            FATAL = 5
        }




    }
}
