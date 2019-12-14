﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;

namespace Analogy.LogViewer.Template
{
    public class OnlineDataProvider : IAnalogyRealTimeDataProvider
    {

        public IAnalogyOfflineDataProvider FileOperationsHandler { get; }
        public bool IsConnected { get; }
        public event EventHandler<AnalogyDataSourceDisconnectedArgs> OnDisconnected;
        public event EventHandler<AnalogyLogMessageArgs> OnMessageReady;
        public event EventHandler<AnalogyLogMessagesArgs> OnManyMessagesReady;

        public Guid ID { get; }
        public string OptionalTitle { get; }

        public Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            throw new NotImplementedException();
        }

        public void MessageOpened(AnalogyLogMessage message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CanStartReceiving()
        {
            throw new NotImplementedException();
        }

        public void StartReceiving()
        {
            throw new NotImplementedException();
        }

        public void StopReceiving()
        {
            throw new NotImplementedException();
        }

    }
}
