using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Interfaces.Winforms;
using Analogy.Interfaces.Winforms.DataTypes;
using Analogy.LogViewer.Template.Managers;
using Analogy.LogViewer.Template.Properties;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

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

        public virtual IEnumerable<(string OriginalHeader, string ReplacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public virtual IEnumerable<AnalogyLogMessagePropertyName> HideExistingColumns() => Enumerable.Empty<AnalogyLogMessagePropertyName>();

        public virtual IEnumerable<string> HideAdditionalColumns() => Enumerable.Empty<string>();

        public virtual (Color BackgroundColor, Color ForegroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public abstract Guid Id { get; set; }
        public virtual string? OptionalTitle { get; set; } = "Online Data Receiver";
        public virtual Image? ConnectedLargeImage { get; set; } = Resources.DatabaseOn32x32;
        public virtual Image? ConnectedSmallImage { get; set; } = Resources.DatabaseOn16x16;
        public virtual Image? DisconnectedLargeImage { get; set; } = Resources.DatabaseOff32x32;
        public virtual Image? DisconnectedSmallImage { get; set; } = Resources.DatabaseOff16x16;
        public virtual Task InitializeDataProvider(ILogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;
        }

        public virtual void MessageOpened(IAnalogyLogMessage message)
        {
            //noop
        }
        public virtual void MessageSelected(IAnalogyLogMessage message)
        {
        }
        public abstract Task<bool> CanStartReceiving();

        public abstract Task StartReceiving();

        public abstract Task StopReceiving();

        protected void Disconnected(object sender, AnalogyDataSourceDisconnectedArgs args) => OnDisconnected?.Invoke(sender, args);
        protected void MessageReady(object sender, AnalogyLogMessageArgs message) => OnMessageReady?.Invoke(sender, message);
        protected void MessagesReady(object sender, AnalogyLogMessagesArgs messages) => OnManyMessagesReady?.Invoke(sender, messages);

        public abstract Task ShutDown();
    }
    public abstract class OnlineDataProviderWinforms : IAnalogyRealTimeDataProviderWinforms
    {
        IAnalogyOfflineDataProvider? IAnalogyRealTimeDataProvider.FileOperationsHandler => FileOperationsHandler;
        public virtual IAnalogyOfflineDataProviderWinforms? FileOperationsHandler { get; set; }
        public virtual event EventHandler<AnalogyDataSourceDisconnectedArgs>? OnDisconnected;
        public virtual event EventHandler<AnalogyLogMessageArgs>? OnMessageReady;
        public virtual event EventHandler<AnalogyLogMessagesArgs>? OnManyMessagesReady;
        public virtual bool UseCustomColors { get; set; }
        AnalogyToolTip? IAnalogyDataProvider.ToolTip
        {
            get => ToolTip;
            set => ToolTip = value is AnalogyToolTipWinforms winforms ? winforms : null;
        }
        public virtual AnalogyToolTipWinforms? ToolTip { get; set; } = new AnalogyToolTipWinforms("Online Data Provider", "Supply a stream of messages", "", null, null);

        public virtual IEnumerable<(string OriginalHeader, string ReplacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public virtual IEnumerable<AnalogyLogMessagePropertyName> HideExistingColumns() => Enumerable.Empty<AnalogyLogMessagePropertyName>();

        public virtual IEnumerable<string> HideAdditionalColumns() => Enumerable.Empty<string>();
        public virtual (Color BackgroundColor, Color ForegroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public abstract Guid Id { get; set; }
        public virtual string? OptionalTitle { get; set; } = "Online Data Receiver";
        public virtual Image? ConnectedLargeImage { get; set; } = Resources.DatabaseOn32x32;
        public virtual Image? ConnectedSmallImage { get; set; } = Resources.DatabaseOn16x16;
        public virtual Image? DisconnectedLargeImage { get; set; } = Resources.DatabaseOff32x32;
        public virtual Image? DisconnectedSmallImage { get; set; } = Resources.DatabaseOff16x16;
        public virtual Task InitializeDataProvider(ILogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;
        }

        public virtual void MessageOpened(IAnalogyLogMessage message)
        {
            //noop
        }
        public virtual void MessageSelected(IAnalogyLogMessage message)
        {
        }
        public abstract Task<bool> CanStartReceiving();

        public abstract Task StartReceiving();

        public abstract Task StopReceiving();

        protected void Disconnected(object sender, AnalogyDataSourceDisconnectedArgs args) => OnDisconnected?.Invoke(sender, args);
        protected void MessageReady(object sender, AnalogyLogMessageArgs message) => OnMessageReady?.Invoke(sender, message);

        protected void MessagesReady(object sender, AnalogyLogMessagesArgs messages) => OnManyMessagesReady?.Invoke(sender, messages);
        public abstract Task ShutDown();
    }
}