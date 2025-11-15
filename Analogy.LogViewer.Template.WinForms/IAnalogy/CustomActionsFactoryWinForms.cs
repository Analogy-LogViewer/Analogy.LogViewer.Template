using Analogy.Interfaces.WinForms.Factories;
using Analogy.LogViewer.Template.WinForms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Analogy.LogViewer.Template.WinForms
{
    public abstract class CustomActionsFactoryWinForms : CustomActionsFactory, IAnalogyCustomActionsFactoryWinForms
    {
        public Dictionary<Guid, Image?> SmallImages { get; } = [];
        public Dictionary<Guid, Image?> LargeImages { get; } = [];

        public virtual Image? LargeImage { get; set; } = Resources.ServerMode_32x32;
        public virtual Image? SmallImage { get; set; } = Resources.ServerMode_16x16;
        public virtual Image? GetCustomActionSmallImage(Guid componentId)
        {
            SmallImages.TryGetValue(componentId, out var img);
            return img;
        }

        public virtual Image? GetCustomActionLargeImage(Guid componentId)
        {
            LargeImages.TryGetValue(componentId, out var img);
            return img;
        }

        public virtual Image? GetCustomActionToolTipSmallImage(Guid componentId)
        {
            SmallImages.TryGetValue(componentId, out var img);
            return img;
        }

        public virtual Image? GetCustomActionToolTipLargeImage(Guid componentId)
        {
            LargeImages.TryGetValue(componentId, out var img);
            return img;
        }
    }
}