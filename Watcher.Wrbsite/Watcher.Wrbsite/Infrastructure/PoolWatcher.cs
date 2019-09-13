using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Watcher.Wrbsite.Infrastructure
{
    public class PoolWatcher
    {
        private INotificationAction _action;

        public PoolWatcher() { }

        public PoolWatcher(INotificationAction notificationAction)
        {
            this._action = notificationAction;
        }

        public INotificationAction Action
        {
            get { return _action; }
            set { _action = value; }
        }

        public void Notify(string message)
        {
            if (_action == null)
            {
                _action = new EventLogWriter();
            }

            _action.ActOnNotification(message);
        }


        public void Notify(INotificationAction action, string message)
        {
            this._action = @action;
            action.ActOnNotification(message);
        }
    }
}