using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YerbaSoft.Desktop.PW.BLL;

namespace YerbaSoft.Desktop.PW
{
    public static class WinManager
    {
        public static List<Forms.ClientForm> Clients { get; set; } = new List<Forms.ClientForm>();
        public static List<Forms.PartyForm> Partys { get; set; } = new List<Forms.PartyForm>();

        internal static void AddClient(PWClient client)
        {
            var win = new Forms.ClientForm(client);
            Clients.Add(win);
            win.Show();
        }

        internal static void RemoveClient(PWClient client)
        {
            var win = Clients.Where(p => p.Client == client).SingleOrDefault();
            if (win == null)
                return;

            win.Close();
            Clients.Remove(win);
            win.Dispose();
        }

        internal static void AddParty(PWParty party)
        {
            var win = new Forms.PartyForm(party);
            Partys.Add(win);
            win.Show();
        }

        internal static void RemoveParty(PWParty party)
        {
            var win = Partys.Where(p => p.Party == party).SingleOrDefault();
            if (win == null)
                return;

            win.Close();
            Partys.Remove(win);
            win.Dispose();
        }
    }
}
