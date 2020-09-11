﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;

namespace Analogy.LogViewer.Template.Managers
{
    public class LogManager : IAnalogyLogger
    {
        private static Lazy<LogManager> _instance = new Lazy<LogManager>();
        public static LogManager Instance => _instance.Value;
        private IAnalogyLogger Logger { get; set; }

        public void SetLogger(IAnalogyLogger logger) => Logger = logger;

        public void LogEvent(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
            => Logger.LogEvent(message, source, memberName, lineNumber, filePath);

        public void LogWarning(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
            => Logger.LogWarning(message, source, memberName, lineNumber, filePath);

        public void LogDebug(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
            => Logger.LogDebug(message, source, memberName, lineNumber, filePath);

        public void LogError(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
        => Logger.LogError(message, source, memberName, lineNumber, filePath);

        public void LogCritical(string message, string source = "", string memberName = "", int lineNumber = 0, string filePath = "")
            => Logger.LogCritical(message, source, memberName, lineNumber, filePath);
        
        public void LogException(string message,  Exception ex, string source="", string memberName = "", int lineNumber = 0, string filePath = "")
        => Logger.LogException(message,ex, source,  memberName, lineNumber, filePath);
        
    }
}