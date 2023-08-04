﻿using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Analogy.LogViewer.Template.Managers
{
    public class LogManager : ILogger
    {
        private static readonly Lazy<LogManager> _instance = new Lazy<LogManager>();
        public static LogManager Instance => _instance.Value;
        private ILogger? Logger { get; set; }
        private List<(AnalogyLogLevel level, string source, string message, string memberName, int lineNumber, string filePath)> PendingMessages { get; set; }
        public LogManager()
        {
            PendingMessages = new List<(AnalogyLogLevel level, string source, string message, string memberName, int lineNumber, string filePath)>();
        }

        public virtual void SetLogger(ILogger logger)
        {
            Logger = logger;
            foreach ((AnalogyLogLevel level, string source, string message, string memberName, int lineNumber, string filePath) in PendingMessages)
            {
                switch (level)
                {


                    case AnalogyLogLevel.Debug:
                        logger.LogDebug(message, source, memberName, lineNumber, filePath);
                        break;
                    case AnalogyLogLevel.Analogy:
                    case AnalogyLogLevel.Information:
                    case AnalogyLogLevel.Trace:
                    case AnalogyLogLevel.Verbose:
                        logger.LogInformation(message, source, memberName, lineNumber, filePath);
                        break;
                    case AnalogyLogLevel.Warning:
                        logger.LogWarning(message, source, memberName, lineNumber, filePath);
                        break;
                    case AnalogyLogLevel.Error:
                        logger.LogError(message, source, memberName, lineNumber, filePath);
                        break;
                    case AnalogyLogLevel.Critical:
                        logger.LogCritical(message, source, memberName, lineNumber, filePath);
                        break;
                    case AnalogyLogLevel.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Invalid level {level}");
                }
            }
        }

        public virtual void LogInformation(string message, string source, string memberName = "", int lineNumber = 0, string filePath = "")
        {
            if (Logger == null)
            {
                PendingMessages.Add((AnalogyLogLevel.Information, source, message, memberName, lineNumber, filePath));
            }
            else
            {
                Logger.LogInformation(message, source, memberName, lineNumber, filePath);
            }
        }

        public virtual void LogWarning(string message, string source, string memberName = "", int lineNumber = 0, string filePath = "")
        {
            if (Logger == null)
            {
                PendingMessages.Add((AnalogyLogLevel.Warning, source, message, memberName, lineNumber, filePath));
            }
            else
            {
                Logger.LogWarning(message, source, memberName, lineNumber, filePath);
            }
        }

        public virtual void LogDebug(string message, string source, string memberName = "", int lineNumber = 0, string filePath = "")
        {
            if (Logger == null)
            {
                PendingMessages.Add((AnalogyLogLevel.Debug, source, message, memberName, lineNumber, filePath));
            }
            else
            {
                Logger.LogDebug(message, source, memberName, lineNumber, filePath);
            }
        }

        public virtual void LogError(string message, string source, string memberName = "", int lineNumber = 0, string filePath = "")
        {
            if (Logger == null)
            {
                PendingMessages.Add((AnalogyLogLevel.Error, source, message, memberName, lineNumber, filePath));
            }
            else
            {
                Logger.LogError(message, source, memberName, lineNumber, filePath);
            }
        }

        public virtual void LogCritical(string message, string source, string memberName = "", int lineNumber = 0, string filePath = "")
        {
            if (Logger == null)
            {
                PendingMessages.Add((AnalogyLogLevel.Critical, source, message, memberName, lineNumber, filePath));
            }
            else
            {
                Logger.LogCritical(message, source, memberName, lineNumber, filePath);
            }
        }

        public virtual void LogException(string message, Exception ex, string source, string memberName = "", int lineNumber = 0, string filePath = "")
        {
            if (Logger == null)
            {
                PendingMessages.Add((AnalogyLogLevel.Error, source, $"Error: {message.Length}Exception: {ex}", memberName, lineNumber, filePath));
            }
            else
            {
                Logger.LogError(message, ex, source, memberName, lineNumber, filePath);
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Logger?.Log(logLevel, eventId, state, exception, formatter);

        }

        public bool IsEnabled(LogLevel logLevel)
        {
           return Logger?.IsEnabled(logLevel) ?? false;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return Logger?.BeginScope(state);
        }
    }
}
