using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Desktop.PW.BLL.Actions
{
    public class ActionsSkills
    {
        public PWActions Actions { get; set; }
        public PWClient Client => Actions.Client;

        public ActionsSkills(PWActions actions)
        {
            this.Actions = actions;
        }

        /// <summary>
        /// Bufea
        /// </summary>
        /// <param name="cancelOnFocus">Indica si se debe cancelar el proceso cuando el pj es focuseado</param>
        /// <param name="keys">listado de Keys-CastTime para los buffs</param>
        public bool DoBuff(bool cancelOnFocus, TwoList<Keys, int> keys)
        {
            foreach (var key in keys)
            {
                // disparo el skill
                this.Client.Manager.KeyPress(key.V1);

                // espero a que termine de bufear
                var start = DateTime.Now;
                do
                {
                    Thread.Sleep(300);
                    if (cancelOnFocus)
                    {
                        var target = this.Client.Mem.Link.NPC.GetById(this.Client.Mem.Link.PJInfo.Data.TargetId);
                        if (target?.IsMob ?? false)
                            return false;
                    }

                } while (start.AddMilliseconds(key.V2) > DateTime.Now);
            }

            return true;
        }
    }
}
