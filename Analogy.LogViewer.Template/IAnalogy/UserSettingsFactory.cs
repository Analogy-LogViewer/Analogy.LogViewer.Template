using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.Interfaces;
using Analogy.LogViewer.Template.Properties;

namespace Analogy.LogViewer.Template
{
    public abstract class UserSettingsFactory: IAnalogyDataProviderSettings
    {
        public virtual string Title { get; set; } = "User Settings";
        public abstract UserControl DataProviderSettings { get; set; }
        public virtual Image SmallImage { get; set; } = Resources.Analogy16x16;
        public virtual Image LargeImage { get; set; } = Resources.Analogy32x32;
        public virtual Guid FactoryId { get; set; } = PrimaryFactory.Id;
        public abstract Guid Id { get; set; }

        public abstract Task SaveSettingsAsync();

    }
}
