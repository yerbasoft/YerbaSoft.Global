using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Task.Configuration.Trigger
{
    public abstract class TriggerType
    {
        internal abstract string TypeName { get; }

        internal delegate void RaiseDelegate(int times);

        internal event RaiseDelegate RaiseEvent;
        
        internal abstract void Start();

        internal abstract void Stop();
    }
}
