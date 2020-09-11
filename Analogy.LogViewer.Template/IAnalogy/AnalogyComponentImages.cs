using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.LogViewer.Template.Properties;

namespace Analogy.LogViewer.Template
{
    public class AnalogyComponentImages : IAnalogyComponentImages
    {
        public virtual Image GetLargeImage(Guid analogyComponentId)
        {
            if (analogyComponentId == PrimaryFactory.Id)
                return Resources.Analogy32x32;
            return null;
        }

        public virtual Image GetSmallImage(Guid analogyComponentId)
        {
            if (analogyComponentId == PrimaryFactory.Id)
                return Resources.Analogy16x16;
            return null;
        }

        public virtual Image GetOnlineConnectedLargeImage(Guid analogyComponentId) => null;

        public virtual Image GetOnlineConnectedSmallImage(Guid analogyComponentId) => null;

        public virtual Image GetOnlineDisconnectedLargeImage(Guid analogyComponentId) => null;

        public virtual Image GetOnlineDisconnectedSmallImage(Guid analogyComponentId) => null;
    }
}
