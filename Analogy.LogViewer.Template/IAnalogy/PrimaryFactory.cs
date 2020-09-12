using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using System;
using System.Collections.Generic;
using System.Drawing;
using Analogy.LogViewer.Template.Properties;

namespace Analogy.LogViewer.Template
{
    public abstract class PrimaryFactory : IAnalogyFactory
    {
        public abstract Guid FactoryId { get; set; }
        public virtual string Title { get; set; } = "Data Provider";//override this
        public virtual IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = ChangeLogList.GetChangeLog();
        public virtual IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public virtual string About { get; set; } = "Log Parser for Analogy Log Viewer";//override this
        public virtual Image SmallImage { get; set; } = Resources.Analogy16x16;
        public virtual Image LargeImage { get; set; } = Resources.Analogy32x32;

    }
}