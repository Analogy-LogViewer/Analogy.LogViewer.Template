﻿using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Template.Managers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Template
{
    /// <summary>
    ///Object of this class gives you all the details about the update useful in handling the update logic yourself.
    /// </summary>
    [Serializable]
    public abstract class AnalogyDownloadInformation : IAnalogyDownloadInformation
    {
        /// <summary>
        /// ID of the primary Factory it belongs to
        /// </summary>
        public abstract Guid FactoryId { get; set; }

        /// <summary>
        /// The component title/name
        /// </summary>
        public abstract string Name { get; set; }

        /// <summary>
        /// If new update is available then returns true otherwise false.
        /// </summary>
        public virtual bool IsUpdateAvailable { get; set; }

        /// <summary>
        /// Download URL of the update file.
        /// </summary>
        public virtual string? DownloadURL { get; set; }

        /// <summary>
        /// URL of the webpage specifying changes in the new update.
        /// </summary>
        public virtual string? ChangeLogURL { get; set; }

        public virtual string? LatestVersionNumber { get; set; }

        /// <summary>
        /// Returns newest version of the application available to download.
        /// </summary>
        public virtual Version? LatestVersion
        {
            get
            {
                if (LatestVersionNumber == null)
                {
                    return null;
                }

                try
                {
                    return new Version(LatestVersionNumber);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public abstract string InstalledVersionNumber { get; }

        /// <summary>
        ///     Returns version of the application currently installed on the user's PC.
        /// </summary>
        public virtual Version InstalledVersion
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(InstalledVersionNumber))
                    {
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                        return new Version(fvi.FileVersion);
                    }
                    return new Version(InstalledVersionNumber);
                }
                catch (Exception e)
                {
                    LogManager.Instance.LogError(e, $"Error getting Version: {e.Message}", e, nameof(InstalledVersion));
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                    return new Version(fvi.FileVersion);
                }
            }
        }

        /// <summary>
        ///     Shows if the update is required or optional.
        /// </summary>
        public virtual bool Mandatory { get; set; }

        /// <summary>
        ///Command line arguments used by Installer.
        /// </summary>
        public virtual string? InstallerArgs { get; set; }

        /// <summary>
        ///Checksum of the update file.
        /// </summary>
        public virtual string? Checksum { get; set; }

        /// <summary>
        ///Hash algorithm that generated the checksum.
        /// </summary>
        public virtual string? HashingAlgorithm { get; set; }

        public abstract TargetFrameworkAttribute CurrentFrameworkAttribute { get; set; }

        protected abstract string RepositoryURL { get; set; }
        public async Task<bool> CheckVersion()
        {
            try
            {
                if (string.IsNullOrEmpty(LatestVersionNumber))
                {
                    var (_, release) = await Analogy.CommonUtilities.Web.Utils.CheckVersion(RepositoryURL,
                        "Analogy Log Viewer Example", "", DateTime.MinValue);
                    if (release != null)
                    {
                        LatestVersionNumber = release.TagName.Substring(1);
                        ChangeLogURL = release.HtmlUrl;
                        var matchingAsset = Analogy.CommonUtilities.Web.Utils.GetMatchingAsset(release, CurrentFrameworkAttribute);
                        if (matchingAsset != null)
                        {
                            DownloadURL = matchingAsset.BrowserDownloadUrl;
                        }
                    }
                }
                IsUpdateAvailable = LatestVersion != null && LatestVersion > InstalledVersion;
                return IsUpdateAvailable;
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogError(ex, $"Unable to check version: {ex.Message}", ex, nameof(CheckVersion));
                return false;
            }
        }
    }
}