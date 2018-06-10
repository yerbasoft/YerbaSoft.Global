using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WindowsHelper.Task.Configuration.Trigger
{
    public class Timer : TriggerType
    {
        internal override string TypeName => "Timer";

        [YerbaSoft.DTO.Mapping.Direct("days")]
        public int Days { get; set; }

        [YerbaSoft.DTO.Mapping.Direct("hours")]
        public int Hours { get; set; }

        [YerbaSoft.DTO.Mapping.Direct("mins")]
        public int Mins { get; set; }

        [YerbaSoft.DTO.Mapping.Direct("secs")]
        public int Secs { get; set; }

        Thread working;
        private int Times { get; set; } = 0;
        private bool Stopping = false;

        internal override void Start()
        {
            this.Stopping = false;
            working = new Thread(Doing);
            working.Start();
        }
        
        internal override void Stop()
        {
            this.Stopping = true;
            working.Abort();
        }

        private void Doing()
        {
            var time = this.Secs + (this.Mins * 60) + (this.Hours * 60 * 60) + (this.Days * 60 * 60 * 24);
            Thread.Sleep(time);
                
        }

        private void Timer_Raise(object sender, RaiseDelegate e)
        {
            throw new NotImplementedException();
        }
    }
}
