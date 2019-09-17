using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YerbaSoft.Desktop.PW.BLL
{
    public class PWParty
    {
        public List<PWClient> Cuentas { get; set; } = new List<PWClient>();

        public PWParty(PWClient client)
        {
            ToggleCuenta(client);
        }

        public void ToggleCuenta(PWClient client)
        {
            if (this.Cuentas.Contains(client))
                this.Cuentas.Remove(client);
            else
                this.Cuentas.Add(client);

            if (this.Cuentas.Count == 0)
                BLL.ClientManager.RemoveParty(this);
        }

        public override string ToString()
        {
            var output = string.Join(",", Cuentas.Select(p => p.Config.Name));
            return string.IsNullOrEmpty(output) ? "-Empty-" : output;
        }

        public void Invite(string[] names, bool force, bool individualPick)
        {
            var cuentas = new List<PWClient>();
            foreach(var name in names)
            {
                var cuenta = BLL.ClientManager.Cuentas.SingleOrDefault(p => p.Config.Name == name);
                if (cuenta != null)
                    cuentas.Add(cuenta);
            }
            Invite(cuentas.ToArray(), force, individualPick);
        }

        public void Invite(PWClient[] clients, bool force, bool individualPick)
        {
            if (force)
            {
                foreach(var cuenta in Cuentas.Concat(clients))
                    cuenta.Action.Party.LeaveParty();
            }

            var lider = Cuentas[0];
            lider.Action.Party.SetPartyIndividual(individualPick);

            foreach (var client in clients.Where(c => !Cuentas.Contains(c)))
            {
                lider.Action.Party.InviteToParty(client.Config.Name);
                Thread.Sleep(600);
                client.Action.Global.DoAcceptMessage();
                ToggleCuenta(client);
            }
        }
    }
}
