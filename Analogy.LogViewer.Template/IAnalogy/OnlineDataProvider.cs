using Analogy.Interfaces;
using Analogy.LogViewer.Template.Managers;
using Analogy.LogViewer.Template.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Analogy.Interfaces.DataTypes;

namespace Analogy.LogViewer.Template
{
    public abstract class OnlineDataProvider : IAnalogyRealTimeDataProvider
    {
        public virtual IAnalogyOfflineDataProvider? FileOperationsHandler { get; set; }
        public virtual event EventHandler<AnalogyDataSourceDisconnectedArgs>? OnDisconnected;
        public virtual event EventHandler<AnalogyLogMessageArgs>? OnMessageReady;
        public virtual event EventHandler<AnalogyLogMessagesArgs>? OnManyMessagesReady;
        public virtual bool UseCustomColors { get; set; }
        public virtual AnalogyToolTip? ToolTip { get; set; } = new AnalogyToolTip("Online Data Provider", "Supply a stream of messages", "");

        public virtual IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public virtual IEnumerable<string> HideColumns()=>Enumerable.Empty<string>();
        
        public virtual (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public abstract Guid Id { get; set; }
        public virtual string? OptionalTitle { get; set; } = "Online Data Receiver";
        public virtual Image? ConnectedLargeImage { get; set; } = Resources.DatabaseOn32x32;
        public virtual Image? ConnectedSmallImage { get; set; } = Resources.DatabaseOn16x16;
        public virtual Image? DisconnectedLargeImage { get; set; } = Resources.DatabaseOff32x32;
        public virtual Image? DisconnectedSmallImage { get; set; } = Resources.DatabaseOff16x16;
        public virtual Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;
        }

        public virtual void MessageOpened(AnalogyLogMessage message)
        {
            //noop
        }

        public abstract Task<bool> CanStartReceiving();

        public abstract Task StartReceiving();

        public abstract Task StopReceiving();

        protected void Disconnected(object sender, AnalogyDataSourceDisconnectedArgs args) => OnDisconnected?.Invoke(sender, args);
        protected void MessageReady(object sender, AnalogyLogMessageArgs message) => OnMessageReady?.Invoke(sender, message);
        protected void MessagesReady(object sender, AnalogyLogMessagesArgs messages) => OnManyMessagesReady?.Invoke(sender, messages);
    }
}
