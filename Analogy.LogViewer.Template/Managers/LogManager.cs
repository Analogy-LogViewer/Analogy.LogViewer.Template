using Analogy.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.Template.Managers
{
    public class LogManager : ILogger
    {
        private static readonly Lazy<LogManager> _instance = new Lazy<LogManager>();
        public static LogManager Instance => _instance.Value;
        private ILogger? Logger { get; set; }
        public LogManager()
        {
        }

        public virtual void SetLogger(ILogger logger)
        {
            Logger = logger;
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