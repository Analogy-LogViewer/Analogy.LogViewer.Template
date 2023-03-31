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
using Analogy.LogViewer.Template.Properties;

namespace Analogy.LogViewer.Template.IAnalogy
{
    public abstract class AnalogyProviderSidePagingProvider : IAnalogyProviderSidePagingProvider
    {
        public abstract Guid Id { get; set; }
        public virtual Image? SmallImage { get; set; } = Resources.Analogy16x16;
        public virtual Image? LargeImage { get; set; } = Resources.Analogy32x32;
        public virtual string? OptionalTitle { get; set; }
        public virtual bool UseCustomColors { get; set; }
        public virtual AnalogyToolTip? ToolTip { get; set; }
        public virtual Task InitializeDataProvider(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;
        }

        public virtual void MessageOpened(IAnalogyLogMessage message)
        {
        }

        public virtual (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);


        public virtual IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders() => Array.Empty<(string, string)>();
        public virtual IEnumerable<AnalogyLogMessagePropertyName> HideExistingColumns() => Enumerable.Empty<AnalogyLogMessagePropertyName>();
        public virtual IEnumerable<string> HideAdditionalColumns() => Enumerable.Empty<string>();

        public abstract Task<IEnumerable<IAnalogyLogMessage>> FetchMessages(int pageNumber, int pageCount,FilterCriteria filterCriteria,
            CancellationToken token, ILogMessageCreatedHandler messagesHandler);


        public virtual Task ShutdownAsync(IAnalogyLogger logger)
        {
            return Task.CompletedTask;
        }
    }
}
