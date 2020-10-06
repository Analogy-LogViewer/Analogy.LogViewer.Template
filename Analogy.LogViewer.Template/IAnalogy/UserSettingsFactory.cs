using System;
using System.Drawing;
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
        public virtual Image SmallImage { get; set; } = Resources.Settings16x16;
        public virtual Image LargeImage { get; set; } = Resources.Settings32x32;
        public abstract Guid FactoryId { get; set; }
        public abstract Guid Id { get; set; }

        public abstract Task SaveSettingsAsync();

    }
}
