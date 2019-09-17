using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YerbaSoft.Desktop.PW.Forms.Helper
{
    internal class FormTools
    {
        private BLL.PWClient Client;
        private ClientForm Form;
        private Timers Timers = new Timers();

        private string Status;

        public FormTools(ClientForm form, BLL.PWClient client)
        {
            this.Form = form;
            this.Client = client;

            this.Client.Mem.Link.OnConnect += (sender, e) => CalculateStatus();
            this.Client.Mem.Link.OnPlayerConnect += (sender, e) => CalculateStatus();
            this.Client.Mem.Link.OnCurrentHPChange += (sender, e) => CalculateStatus();
            this.Client.Auto.OnAutoKeyStatusChange += (sender, e) => { CalculateStatus(); };
            this.Client.Auto.OnAutoSpotStatusChange += (sender, e) => { CalculateStatus(); };
            this.Client.Auto.OnAutoFollowStatusChange += (sender, e) => { CalculateStatus(); };
            this.Client.Auto.OnAutoAssistStatusChange += (sender, e) => { CalculateStatus(); };
            this.Client.Auto.OnVillaStatusChange += (sender, e) => { CalculateStatus(); }; //no anda por thread q no creó el objeto

            StartDrawStatus();
        }

        private void CalculateStatus()
        {
            this.Status = null;
            if (this.Client.Mem?.Base1 == null)
                this.Status = "DISCONNECT";
            else if (this.Client.Mem.Base1.PJInfo == null)
                this.Status = "CHAMP_SELECT";
            else if (this.Client.Mem.Base1.PJInfo != null)
            {
                lock (this.Client.Mem.Base1.PJInfo)
                {
                    if (this.Client.Mem.Base1.PJInfo.Data.CurrHP == 0)
                        this.Status = "PJ_DEATH";
                    else if (this.Client.Auto.IsAnyAutoKeyRunning)
                        this.Status = "AUTOKEY";
                    else if (this.Client.Auto.IsAutoFollowRunning)
                        this.Status = "AUTOFOLLOW";
                    else if (this.Client.Auto.IsAutoAssistRunning)
                        this.Status = "AUTOASSIST";
                    else if (this.Client.Auto.IsAutoSpotRunning)
                        this.Status = "AUTOSPOT";
                    else if (this.Client.Auto.IsVillaRunning)
                        this.Status = "VILLA";
                }
            }
        }

        public void MultiThreadSafe(Control main, MethodInvoker action)
        {
            if (main.InvokeRequired)
            {
                main.Invoke(action);
            }
            else
            {
                action?.Invoke();
            }
        }

        #region Draw

        public void StartDrawStatus()
        {
            this.Timers.Remove("DrawStatus");
            this.Timers.Add("DrawStatus", 300, 2, (obj, index) => {
                try
                {
                    var pen = new Pen(this.Form.TransparencyKey) { Width = 3 };

                    switch (this.Status)
                    {
                        case "DISCONNECT":
                            break;
                        case "CHAMP_SELECT":
                            pen.Color = Color.Black;
                            break;
                        case "PJ_DEATH":
                            pen.Color = index == 1 ? Color.Red : Color.DarkRed;
                            break;
                        case "AUTOKEY":
                            pen.Color = Color.Blue;
                            break;
                        case "AUTOFOLLOW":
                            pen.Color = Color.Yellow;
                            break;
                        case "AUTOASSIST":
                            pen.Color = Color.Cyan;
                            break;
                        case "AUTOSPOT":
                            pen.Color = Color.Green;
                            break;
                        case "VILLA":
                            var color1 = Color.Gold;
                            var color2 = this.Form.TransparencyKey;
                            if (index == 1)
                            {
                                color1 = this.Form.TransparencyKey;
                                color2 = Color.Gold;
                            }
                            this.Form.CreateGraphics().DrawEllipse(new Pen(color1) { Width = 3 }, this.Form.IconArea);

                            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                            pen.Color = color2;
                            break;
                        default:
                            pen.Color = Color.LightGray;
                            break;
                    }
                    if (this.Form == null)
                    {
                        this.Timers.Remove("DrawStatus");
                        return;
                    }
                    
                    this.Form.CreateGraphics().DrawEllipse(pen, this.Form.IconArea);
                }
                catch { }
            }, null);
        }

        #endregion
    }
}
