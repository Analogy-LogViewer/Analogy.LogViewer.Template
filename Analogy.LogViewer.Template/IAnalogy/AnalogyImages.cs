using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.LogViewer.Template.Properties;

namespace Analogy.LogViewer.Template.IAnalogy
{
   public class AnalogyImages:IAnalogyImages
    {
        public virtual Image GetLargeBookmarksImage(Guid analogyComponentId) => Resources.Bookmark32x32;
        public virtual Image GetSmallBookmarksImage(Guid analogyComponentId) => Resources.Bookmark16x16;
        public virtual Image GetLargeOpenFolderImage(Guid analogyComponentId) => Resources.OpenFolder_32x32;
        public virtual Image GetSmallOpenFolderImage(Guid analogyComponentId) => Resources.OpenFolder_16x16;
        public virtual Image GetLargeRecentFoldersImage(Guid analogyComponentId) => Resources.RecentFolders32x32;
        public virtual Image GetSmallRecentFoldersImage(Guid analogyComponentId) => Resources.RecentFolders16x16;
        public virtual Image GetLargeFilePoolingImage(Guid analogyComponentId) => Resources.FilePooling32x32;
        public virtual Image GetSmallFilePoolingImage(Guid analogyComponentId) => Resources.FilePooling16x16;
        public virtual Image GetLargeRecentFilesImage(Guid analogyComponentId) => Resources.RecentFiles32x32;
        public virtual Image GetSmallRecentFilesImage(Guid analogyComponentId) => Resources.RecentFiles16x16;
        public virtual Image GetLargeKnownLocationsImage(Guid analogyComponentId) => Resources.Location32x32;
        public virtual Image GetSmallKnownLocationsImage(Guid analogyComponentId) => Resources.Location16x16;
        public virtual Image GetLargeSearchImage(Guid analogyComponentId) => Resources.Search32x32;
        public virtual Image GetSmallSearchImage(Guid analogyComponentId) => Resources.Search16x16;
        public virtual Image GetLargeCombineLogsImage(Guid analogyComponentId) => Resources.Combine32x32;
        public virtual Image GetSmallCombineLogsImage(Guid analogyComponentId) => Resources.Combine16x16;
        public virtual Image GetLargeCompareLogsImage(Guid analogyComponentId) => Resources.Compare32x32;
        public virtual Image GetSmallCompareLogsImage(Guid analogyComponentId) => Resources.Compare16x16;
        public virtual Image GetLargeConnectedLogsImage(Guid analogyComponentId) => Resources.DatabaseOn32x32;
        public virtual Image GetSmallConnectedLogsImage(Guid analogyComponentId) => Resources.DatabaseOn16x16;
        public virtual Image GetLargeDisconnectedLogsImage(Guid analogyComponentId) => Resources.DatabaseOff32x32;
        public virtual Image GetSmallDisconnectedLogsImage(Guid analogyComponentId) => Resources.DatabaseOff16x16;
    }
}
