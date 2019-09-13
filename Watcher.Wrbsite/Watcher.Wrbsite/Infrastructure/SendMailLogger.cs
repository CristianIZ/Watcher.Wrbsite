using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Watcher.Wrbsite.Infrastructure
{
    public class SendMailLogger : INotificationAction
    {
        private const string LogFileNameOnly = @"LogFile";
        private const string LogFileExtension = @".txt";
        private const string LogFileDirectory = @"~/App_Data";
        private static string _logFileName;

        public void ActOnNotification(string message)
        {
            string docPath = System.Web.Hosting.HostingEnvironment.MapPath(LogFileDirectory);

            _logFileName = MakeLogFileName(false);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, _logFileName), true))
            {
                outputFile.WriteLine( "SendMailLogger is Writing: " + message);
            }
        }

        private static string MakeLogFileName(bool isArchive)
        {
            return !isArchive ? $"{LogFileNameOnly}{LogFileExtension}" :
                                $"{LogFileNameOnly} {DateTime.UtcNow.ToString("ddMMyyyy_hhmmss")}{LogFileExtension}";
        }
    }
}