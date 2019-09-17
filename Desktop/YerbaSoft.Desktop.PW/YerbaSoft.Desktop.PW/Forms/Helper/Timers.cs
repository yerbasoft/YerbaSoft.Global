using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Desktop.PW.Forms.Helper
{
    public class Timers
    {
        private FiveList<string, int, object, Thread, EventHandler<int>> TimerList;

        public Timers()
        {
            TimerList = new FiveList<string, int, object, Thread, EventHandler<int>>();
        }

        public void Add(string name, int interval, int maxindex, EventHandler<int> @event, object tagSender)
        {
            lock (TimerList)
            {
                var item = TimerList.Add(name, maxindex, tagSender, null, @event);
                item.V4 = new Thread(_DoTimer) { IsBackground = true, Priority = ThreadPriority.Lowest };
                item.V4.Start(new { interval, item });
            }
        }

        private void _DoTimer(object obj)
        {
            var interval = (int)((dynamic)obj).interval;
            var timer = (Five<string, int, object, Thread, EventHandler<int>>)((dynamic)obj).item;

            var index = 0;
            while(true)
            {
                bool ok = false;
                lock (TimerList)
                    ok = TimerList.Contains(timer);

                if (!ok)
                    return;

                Thread.Sleep(interval);
                index++;
                if (index > timer.V2)
                    index = 1;

                timer.V5?.Invoke(timer.V3, index);
            }
        }

        public void Remove(string name)
        {
            lock (TimerList)
            {
                var item = TimerList.SingleOrDefault(p => p.V1 == name);
                if (item != null)
                    TimerList.Remove(item);
            }
        }
    }
}
