using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DBRampUp
{
    public static class DBRampUpLogging
    {
        private static string _logPath = @"setup\logs";

        /// <summary>
        /// The directory where log files are created.  Relative to the Project Path.  Defaults to lib\setup\logs.
        /// </summary>        
        public static  string LogPath
        {
            get { return _logPath; }
            set { _logPath = value; }
        }

        private static string  _logFileName = string.Empty;
        public static  string LogFileName
        {
            get { return _logFileName; }
            set { _logFileName = value; }
        }
        public static bool LogToFile;

        private static StringBuilder _logString = new StringBuilder();


        public static StringBuilder LogString
        {
            get { return _logString; }
            set { _logString = value; }
        }
        public static string FullLogPath
        {
            get
            {
                return Path.Combine(DBRampUpProvider.ProjectPath, LogPath);
            }
        }
        public static void CloseLog()
        {
            if (LogToFile && !string.IsNullOrEmpty(LogFileName))
            {
                if (!Directory.Exists(FullLogPath))
                    Directory.CreateDirectory(FullLogPath);
                using (TextWriter tw = new StreamWriter(Path.Combine(FullLogPath, LogFileName)))
                {
                    tw.Write(LogString.ToString());
                }
            }

        }

        /// <summary>
        /// Write to the console & the log file
        /// </summary>        
        public static void WriteLine(string stringToWrite)
        {
            Console.WriteLine(stringToWrite);
            if (LogToFile)
                _logString.AppendLine(stringToWrite);
        }

        public static void Write(string stringToWrite)
        {
            Console.Write(stringToWrite);
            if (LogToFile)
                _logString.Append(stringToWrite);
        }

    

    }
}
