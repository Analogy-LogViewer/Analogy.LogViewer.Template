using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Template.Managers;
using Analogy.LogViewer.Template.Properties;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Template
{
    public abstract class AnalogyProviderSidePagingProvider : IAnalogyProviderSidePagingProvider
    {
        public abstract Guid Id { get; set; }
        public virtual string? OptionalTitle { get; set; } = "Server Side Provider";
        public virtual bool UseCustomColors { get; set; }
        public virtual AnalogyToolTip? ToolTip { get; set; } = new AnalogyToolTip("Server Side Provider", "Server Side data Fetcher", "");
        public virtual Task InitializeDataProvider(ILogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;
        }

        public virtual void MessageOpened(IAnalogyLogMessage message)
        {
        }

        public virtual void MessageSelected(IAnalogyLogMessage message)
        {
        }
        public virtual (Color BackgroundColor, Color ForegroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);

        public virtual IEnumerable<(string OriginalHeader, string ReplacementHeader)> GetReplacementHeaders() => Array.Empty<(string, string)>();
        public virtual IEnumerable<AnalogyLogMessagePropertyName> HideExistingColumns() => Enumerable.Empty<AnalogyLogMessagePropertyName>();
        public virtual IEnumerable<string> HideAdditionalColumns() => Enumerable.Empty<string>();

        public abstract Task<IEnumerable<IAnalogyLogMessage>> FetchMessages(int pageNumber, int pageCount, FilterCriteria filterCriteria,
            CancellationToken token, ILogMessageCreatedHandler messagesHandler);

        public virtual Task ShutdownAsync(ILogger logger)
        {
            return Task.CompletedTask;
        }
    }
}