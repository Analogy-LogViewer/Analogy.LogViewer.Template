using Analogy.Interfaces;
using System;

namespace Analogy.LogViewer.Template.Managers
{
    public class NotificationManager : INotificationReporter
    {
        private static readonly Lazy<NotificationManager> _instance = new Lazy<NotificationManager>();
        public static NotificationManager Instance => _instance.Value;
        private INotificationReporter? Reporter { get; set; }

        public void SetReporter(INotificationReporter notificationReporter) => Reporter = notificationReporter;


        public void RaiseNotification(IAnalogyNotification notification, bool showAsPopup)
        {
            Reporter?.RaiseNotification(notification, showAsPopup);
        }
    }
}
