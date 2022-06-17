using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Template.Managers;

namespace Analogy.LogViewer.Template.IAnalogy
{
    public abstract class AnalogyProviderSidePagingProvider : IAnalogyProviderSidePagingProvider
    {
        public Guid Id { get; set; }
        public Image? SmallImage { get; set; }
        public Image? LargeImage { get; set; }
        public string? OptionalTitle { get; set; }
        public bool UseCustomColors { get; set; }
        public AnalogyToolTip? ToolTip { get; set; }
        public virtual Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;
        }

        public virtual void MessageOpened(AnalogyLogMessage message)
        {
        }

        public virtual (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);


        public virtual IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public virtual IEnumerable<string> HideColumns() => Enumerable.Empty<string>();

        public abstract Task<IEnumerable<AnalogyLogMessage>> FetchMessages(FilterCriteria filterCriteria,
            CancellationToken token, ILogMessageCreatedHandler messagesHandler);


        public virtual Task ShutdownAsync(IAnalogyLogger logger)
        {
            return Task.CompletedTask;
        }
    }
}
