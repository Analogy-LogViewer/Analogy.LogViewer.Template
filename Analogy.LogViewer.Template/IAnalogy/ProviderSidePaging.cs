using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Template.Managers;
using Analogy.LogViewer.Template.Properties;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Template.IAnalogy
{
    public abstract class ProviderSidePaging : IAnalogyProviderSidePagingProvider
    {
        public abstract Guid Id { get; set; }
        public virtual string? OptionalTitle { get; set; } = "Server Side Provider";
        public virtual bool UseCustomColors { get; set; } = false;
        public virtual AnalogyToolTip? ToolTip { get; set; } = new AnalogyToolTip("Server Side Provider", "Server Side data Fetcher", "", null, null);
        public virtual Image? LargeImage { get; set; } = Resources.ServerMode_32x32;
        public virtual Image? SmallImage { get; set; } = Resources.ServerMode_16x16;
        public virtual Task InitializeDataProvider(ILogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;
        }

        public virtual void MessageOpened(IAnalogyLogMessage message)
        {
            //noop
        }

        public virtual (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);

        public virtual IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();
        public IEnumerable<AnalogyLogMessagePropertyName> HideExistingColumns()
        {
            return new List<AnalogyLogMessagePropertyName>();
        }

        public virtual IEnumerable<string> HideAdditionalColumns() => Enumerable.Empty<string>();


        public abstract Task<IEnumerable<IAnalogyLogMessage>> FetchMessages(int pageNumber, int pageCount,
            FilterCriteria filterCriteria, CancellationToken token, ILogMessageCreatedHandler messagesHandler);
        
        public virtual Task ShutdownAsync(ILogger logger) => Task.CompletedTask;
        
    }
}