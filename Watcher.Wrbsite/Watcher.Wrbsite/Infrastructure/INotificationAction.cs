using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watcher.Wrbsite.Infrastructure
{
    public interface INotificationAction
    {
        void ActOnNotification(string message);
    }
}
