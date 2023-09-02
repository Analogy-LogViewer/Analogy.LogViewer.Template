using Analogy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.LogViewer.Template.Managers
{
    public class FolderAccessManager : IAnalogyFoldersAccess
    {
        private static readonly Lazy<FolderAccessManager> _instance = new Lazy<FolderAccessManager>();

        public virtual event EventHandler? RootFolderChanged;

        public static FolderAccessManager Instance => _instance.Value;
        private IAnalogyFoldersAccess? FoldersAccess { get; set; }

        public void SetFolderAccess(IAnalogyFoldersAccess foldersAccess)
        {
            FoldersAccess = foldersAccess;
            foldersAccess.RootFolderChanged += (s, e) => RootFolderChanged?.Invoke(s, e);
        }

        public string GetConfigurationFilePath(string configFile) => FoldersAccess.GetConfigurationFilePath(configFile);

        public bool TryGetConfigurationFilePathFromAnyValidLocation(string configFile, out string finalLocation)
            => FoldersAccess.TryGetConfigurationFilePathFromAnyValidLocation(configFile, out finalLocation);
       
        public string WriteableRootFolder => FoldersAccess.WriteableRootFolder;
        public string ConfigurationsFolder => FoldersAccess.ConfigurationsFolder;
    }
}
