using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Analogy.LogViewer.Template.Managers;
using Analogy.LogViewer.Template.Properties;

namespace Analogy.LogViewer.Template
{
    public abstract class OfflineDataProvider : IAnalogyOfflineDataProvider
    {
        public virtual Image SmallImage { get; set; } = Resources.Analogy16x16;
        public virtual Image LargeImage { get; set; } = Resources.Analogy32x32;
        public virtual bool DisableFilePoolingOption { get; set; } = false;
        public abstract Guid Id { get; set; }
        public virtual string OptionalTitle { get; set; } = "Offline Parser";
        public virtual bool CanSaveToLogFile { get; set; } = false;
        public virtual string FileOpenDialogFilters { get; set; } = string.Empty;
        public virtual string FileSaveDialogFilters { get; set; } = string.Empty;
        public virtual IEnumerable<string> SupportFormats { get; set; } = new List<string>(0);
        public virtual string InitialFolderFullPath { get; } = string.Empty;
        public virtual bool UseCustomColors { get; set; } = false;
        public virtual IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public virtual  (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);

        public abstract Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler);


        public abstract IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad);
       
        public virtual Task SaveAsync(List<AnalogyLogMessage> messages, string fileName) =>Task.CompletedTask;

        public abstract bool CanOpenFile(string fileName);

        public virtual bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);
    


        public virtual Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;
        }

        public void MessageOpened(AnalogyLogMessage message)
        {
            throw new NotImplementedException();
        }

    }
}
