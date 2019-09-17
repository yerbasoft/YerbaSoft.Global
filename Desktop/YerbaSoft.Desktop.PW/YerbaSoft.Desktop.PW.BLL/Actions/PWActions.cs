using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.Desktop.PW.Client.PWI_1_3_6_2265.Structs;

namespace YerbaSoft.Desktop.PW.BLL.Actions
{
    public class PWActions
    {
        public delegate T WaitForDelegate<T>();
        public delegate bool WaitForDelegate();

        internal PWClient Client;

        private Actions.ActionsGlobal _Global;
        private Actions.ActionsParty _Party;
        private Actions.ActionsMove _Move;
        private Actions.ActionsCamara _Cam;
        private Actions.ActionsInteract _Interact;
        private Actions.ActionsSkills _Skills;
        public Actions.ActionsGlobal Global => _Global = _Global ?? new ActionsGlobal(this);
        public Actions.ActionsParty Party => _Party = _Party ?? new ActionsParty(this);
        public Actions.ActionsMove Move => _Move = _Move ?? new ActionsMove(this);
        public Actions.ActionsCamara Cam => _Cam = _Cam ?? new ActionsCamara(this);
        public Actions.ActionsInteract Interact => _Interact = _Interact ?? new ActionsInteract(this);
        public Actions.ActionsSkills Skills => _Skills = _Skills ?? new ActionsSkills(this);

        public PWActions(PWClient client)
        {
            this.Client = client;
        }
    }
}
