﻿using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Template.Managers;
using Analogy.LogViewer.Template.Properties;
using Microsoft.Extensions.Logging;
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
        public virtual event EventHandler<AnalogyStartedProcessingArgs> ProcessingStarted;
        public virtual event EventHandler<AnalogyEndProcessingArgs> ProcessingFinished;
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

        public virtual IEnumerable<(string OriginalHeader, string ReplacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public virtual (Color BackgroundColor, Color ForegroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public virtual IEnumerable<AnalogyLogMessagePropertyName> HideExistingColumns() => Enumerable.Empty<AnalogyLogMessagePropertyName>();

        public virtual IEnumerable<string> HideAdditionalColumns() => Enumerable.Empty<string>();

        public abstract Task<IEnumerable<IAnalogyLogMessage>> Process(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler);
        public virtual AnalogyToolTip? ToolTip { get; set; } = new AnalogyToolTip("Offline Data Provider", "Read a static list of messages (in most cases the source is a log file)", "", null, null);

        public IEnumerable<FileInfo> GetSupportedFiles(DirectoryInfo dirInfo, bool recursiveLoad) =>
            GetSupportedFilesInternal(dirInfo, recursiveLoad);

        public virtual Task SaveAsync(List<IAnalogyLogMessage> messages, string fileName) => Task.CompletedTask;

        public virtual bool CanOpenFile(string fileName) => SupportFormats.Any(pattern =>
                CommonUtilities.Files.FilesPatternMatcher.StrictMatchPattern(pattern, fileName));

        public virtual bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);

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
                    LogManager.Instance.LogError(ex, $"Error getting files from directory with pattern {pattern}", ex,
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
                LogManager.Instance.LogError(ex, $"Error getting files from directory", ex, nameof(GetSupportedFilesInternal));
            }

            return files;
        }

        protected void RaiseProcessingStarted(AnalogyStartedProcessingArgs args)
        {
            ProcessingStarted?.Invoke(this, args);
        }
        protected void RaiseProcessingFinished(AnalogyEndProcessingArgs args)
        {
            ProcessingFinished?.Invoke(this, args);
        }
    }
}