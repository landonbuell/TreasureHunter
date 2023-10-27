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
        StreamWriter _outStream;
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

        internal TextLogger(AppSettings settings)
        {
            // Constructor
            string outputFile = Path.Combine(settings.OutputPath, "textLog.txt");

            _outStream = new StreamWriter(outputFile);
            _logLevel = settings.MinimumLogLevel;

            _logToFile = settings.LogToFile;
            _logToConsole = settings.LogToConsole;
        }

        ~TextLogger()
        {
            // Destructor
            _outStream.Close();
        }

        #region Getters and Setters

        public LogLevel Level
        {
            // Return the log level
            get { return _logLevel; }
        }

        #endregion

        #region Public Interface

        public static string CurrentTimeStamp()
        {
            // Return the current Time in YYYY.MM.DD.HH.MM.SS.UUUUUU
            const string sep = ".";
            DateTime now = DateTime.Now;
            StringBuilder time = new StringBuilder(24);
            time.Append(now.Year + sep);
            time.Append(now.Month + sep);
            time.Append(now.Day + sep);
            time.Append(now.Hour + sep);
            time.Append(now.Minute + sep);
            time.Append(now.Second + sep);
            time.Append(now.Millisecond);
            return time.ToString();
        }

        public void LogMessage(string message, LogLevel logLevel)
        {
            // Log a Message with this Logger
            if (logLevel < _logLevel)
            {
                // Not logging Message due to insignficance
                return;
            }

            TextLoggerMessage textLoggerMessage = new TextLoggerMessage();
            textLoggerMessage.timeStamp = CurrentTimeStamp();
            textLoggerMessage.message = message;
            textLoggerMessage.logLevel = logLevel;

            LogMessage(ref textLoggerMessage);
            return;
        }

        #endregion


        #region Private Interface

        private struct TextLoggerMessage
        {
            // Structure w/ Message Data
            public string timeStamp;
            public string message;
            public LogLevel logLevel;

            public override string ToString()
            {
                // Cast Message to String
                string msg = string.Format("{0:-32}{1:-32}{2}",
                    timeStamp, logLevel, message);
                return msg;
            }

        }

        private void LogMessage(ref TextLoggerMessage message)
        {
            // Log Message
            if (_logToConsole == true)
            {
                // Print Message To Console
                Console.WriteLine(message.ToString());
            }
            if (_logToFile == true)
            {
                _outStream.WriteLine(message.ToString());
                _outStream.Close();
            }
            return;
        }

        #endregion


    }
}
