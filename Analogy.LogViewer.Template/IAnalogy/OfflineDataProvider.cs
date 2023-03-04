using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Template.Managers;
using Analogy.LogViewer.Template.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Template
{
    public abstract class OfflineDataProvider : IAnalogyOfflineDataProvider
    {
        public virtual Image? SmallImage { get; set; } = Resources.Analogy16x16;
        public virtual Image? LargeImage { get; set; } = Resources.Analogy32x32;
        public virtual bool DisableFilePoolingOption { get; set; }
        public abstract Guid Id { get; set; }
        public virtual string? OptionalTitle { get; set; } = "Offline Parser";
        public virtual bool CanSaveToLogFile { get; set; }
        public virtual string FileOpenDialogFilters { get; set; } = string.Empty;
        public virtual string FileSaveDialogFilters { get; set; } = string.Empty;
        public virtual IEnumerable<string> SupportFormats { get; set; } = Array.Empty<string>();
        public virtual string? InitialFolderFullPath { get; set; } = string.Empty;
        public virtual bool UseCustomColors { get; set; }
        public virtual IEnumerable<(string originalHeader, string replacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public virtual (Color backgroundColor, Color foregroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);

        public abstract Task<IEnumerable<IAnalogyLogMessage>> Process(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler);
        public virtual AnalogyToolTip? ToolTip { get; set; } = new AnalogyToolTip("Offline Data Provider", "Read a static list of messages (in most cases the source is a log file)", "", null, null);
        public virtual IEnumerable<string> HideColumns() => Enumerable.Empty<string>();
        public IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad) =>
            GetSupportedFilesInternal(dirInfo, recursiveLoad);

        public virtual Task SaveAsync(List<IAnalogyLogMessage> messages, string fileName) => Task.CompletedTask;

        public virtual bool CanOpenFile(string fileName) => SupportFormats.Any(pattern =>
                CommonUtilities.Files.FilesPatternMatcher.StrictMatchPattern(pattern, fileName));

        public virtual bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);

        public virtual Task InitializeDataProvider(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return Task.CompletedTask;
        }

        public virtual void MessageOpened(IAnalogyLogMessage message)
        {
            //noop
        }
        protected virtual List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {
            List<FileInfo> files = new List<FileInfo>();
            foreach (string pattern in SupportFormats)
            {
                try
                {
                    files.AddRange(dirInfo.GetFiles(pattern).ToList());
                }
                catch (Exception ex)
                {
                    LogManager.Instance.LogException($"Error getting files from directory with pattern {pattern}", ex,
                        nameof(GetSupportedFilesInternal));
                }

            }

            if (!recursive)
            {
                return files;
            }
            try
            {
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    files.AddRange(GetSupportedFilesInternal(dir, true));
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogException($"Error getting files from directory", ex, nameof(GetSupportedFilesInternal));
            }

            return files;
        }
    }
}
