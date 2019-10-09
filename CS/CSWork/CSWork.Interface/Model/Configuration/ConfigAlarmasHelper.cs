using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWork.Interface.Model.Configuration
{
    public class ConfigAlarmasHelper : ConfigBase
    {
        // Apariencia
        private ComboBox cbAlarmasMonitor => GetControl<ComboBox>("pAlarmaApariencia", "cbAlarmasMonitor");
        private Button bAlarmasMonitorFind => GetControl<Button>("pAlarmaApariencia", "bAlarmasMonitorFind");
        private ComboBox cbAlarmasPosicion => GetControl<ComboBox>("pAlarmaApariencia", "cbAlarmasPosicion");
        private ComboBox cbAlarmasAnimacion => GetControl<ComboBox>("pAlarmaApariencia", "cbAlarmasAnimacion");

        private CheckBox cbAlarmIssueAlarmEnabled => GetControl<CheckBox>("pAlarmaIssues", "cbAlarmIssueAlarmEnabled");
        private CheckBox cbAlarmIssuePriorityChanged => GetControl<CheckBox>("pAlarmaIssues", "cbAlarmIssuePriorityChanged");
        private CheckBox cbAlarmIssueAdjuntoChanged => GetControl<CheckBox>("pAlarmaIssues", "cbAlarmIssueAdjuntoChanged");
        private CheckBox cbAlarmIssueCommentChanged => GetControl<CheckBox>("pAlarmaIssues", "cbAlarmIssueCommentChanged");

        private CheckBox cbAlarmTempoAtEndDay => GetControl<CheckBox>("pAlarmTempo", "cbAlarmTempoAtEndDay");
        private CheckBox cbAlarmTempoAtEndWeek => GetControl<CheckBox>("pAlarmTempo", "cbAlarmTempoAtEndWeek");
        private CheckBox cbAlarmTempoAtEndPeriod => GetControl<CheckBox>("pAlarmTempo", "cbAlarmTempoAtEndPeriod");

        public ConfigAlarmasHelper(Forms.Configuration form, Control container) : base(form, container)
        {
            // load initial data
            cbAlarmasMonitor.Items.AddRange(
                new ComboBoxItem[] 
                {
                    new ComboBoxItem("Monitor Principal", null)
                }.Concat(
                    Screen.AllScreens.Select(p => new ComboBoxItem(p.DeviceName, p)).OrderBy(p => p.Text)
                ).ToArray()
            );
            cbAlarmasMonitor.SelectedItem = cbAlarmasMonitor.Items.OfType<ComboBoxItem>().Single(p => p.Get<Screen>()?.DeviceName == Config.Global.Alarmas.ShowInMonitor);

            cbAlarmasPosicion.Items.AddRange(
                new ComboBoxItem[]
                {
                    new ComboBoxItem("Arriba a la Derecha", 0)
                }
            );
            cbAlarmasPosicion.SelectedItem = cbAlarmasPosicion.Items.OfType<ComboBoxItem>().Single(p => p.Get<int>() == Config.Global.Alarmas.ShowInPosition);

            cbAlarmasAnimacion.Items.AddRange(
                new ComboBoxItem[]
                {
                    new ComboBoxItem("Aparecer", 0)
                }
            );
            cbAlarmasAnimacion.SelectedItem = cbAlarmasAnimacion.Items.OfType<ComboBoxItem>().Single(p => p.Get<int>() == Config.Global.Alarmas.ShowAnimation);

            cbAlarmIssueAlarmEnabled.Checked = Config.Global.Alarmas.IssueAlarmEnabled;
            cbAlarmIssuePriorityChanged.Checked = Config.Global.Alarmas.IssuePriorityChanged;
            cbAlarmIssuePriorityChanged.Enabled = cbAlarmIssueAlarmEnabled.Checked;
            cbAlarmIssueAdjuntoChanged.Checked = Config.Global.Alarmas.IssueAdjuntoChanged;
            cbAlarmIssueAdjuntoChanged.Enabled = cbAlarmIssueAlarmEnabled.Checked;
            cbAlarmIssueCommentChanged.Checked = Config.Global.Alarmas.IssueCommentChanged;
            cbAlarmIssueCommentChanged.Enabled = cbAlarmIssueAlarmEnabled.Checked;

            cbAlarmTempoAtEndDay.Checked = Config.Global.Alarmas.TempoAtEndDay;
            cbAlarmTempoAtEndWeek.Checked = Config.Global.Alarmas.TempoAtEndWeek;
            cbAlarmTempoAtEndPeriod.Checked = Config.Global.Alarmas.TempoAtEndPeriod;

            // Eventos
            bAlarmasMonitorFind.Click += (sender, e) =>
            {
                Forms.Tools.SelectMonitor fSelectMonitor = null;
                (fSelectMonitor = new Forms.Tools.SelectMonitor(((ComboBoxItem)cbAlarmasMonitor.SelectedItem).Get<Screen>())).ShowDialog();
                cbAlarmasMonitor.SelectedItem = cbAlarmasMonitor.Items.OfType<ComboBoxItem>().Single(p => p.Get<Screen>()?.DeviceName == fSelectMonitor.Result?.DeviceName);
            };

            cbAlarmasMonitor.SelectedIndexChanged += (sender, e) => { Config.Global.Alarmas.ShowInMonitor = ((ComboBoxItem)cbAlarmasMonitor.SelectedItem).Get<Screen>()?.DeviceName; Config.SaveGlobal(); };
            cbAlarmasPosicion.SelectedIndexChanged += (sender, e) => { Config.Global.Alarmas.ShowInPosition = ((ComboBoxItem)cbAlarmasPosicion.SelectedItem).Get<int>(); Config.SaveGlobal(); };
            cbAlarmasAnimacion.SelectedIndexChanged += (sender, e) => { Config.Global.Alarmas.ShowAnimation = ((ComboBoxItem)cbAlarmasAnimacion.SelectedItem).Get<int>(); Config.SaveGlobal(); };

            cbAlarmIssueAlarmEnabled.CheckedChanged += (sender, e) =>
            {
                Config.Global.Alarmas.IssueAlarmEnabled = cbAlarmIssueAlarmEnabled.Checked;
                Config.SaveGlobal();
                cbAlarmIssuePriorityChanged.Enabled = cbAlarmIssueAdjuntoChanged.Enabled = cbAlarmIssueCommentChanged.Enabled = cbAlarmIssueAlarmEnabled.Checked;
            };
            cbAlarmIssuePriorityChanged.CheckedChanged += (sender, e) => { Config.Global.Alarmas.IssuePriorityChanged = cbAlarmIssuePriorityChanged.Checked; Config.SaveGlobal(); };
            cbAlarmIssueAdjuntoChanged.CheckedChanged += (sender, e) => { Config.Global.Alarmas.IssueAdjuntoChanged = cbAlarmIssueAdjuntoChanged.Checked; Config.SaveGlobal(); };
            cbAlarmIssueCommentChanged.CheckedChanged += (sender, e) => { Config.Global.Alarmas.IssueCommentChanged = cbAlarmIssueCommentChanged.Checked; Config.SaveGlobal(); };

            cbAlarmTempoAtEndDay.CheckedChanged += (sender, e) => { Config.Global.Alarmas.TempoAtEndDay = cbAlarmTempoAtEndDay.Checked; Config.SaveGlobal(); };
            cbAlarmTempoAtEndWeek.CheckedChanged += (sender, e) => { Config.Global.Alarmas.TempoAtEndWeek = cbAlarmTempoAtEndWeek.Checked; Config.SaveGlobal(); };
            cbAlarmTempoAtEndPeriod.CheckedChanged += (sender, e) => { Config.Global.Alarmas.TempoAtEndPeriod = cbAlarmTempoAtEndPeriod.Checked; Config.SaveGlobal(); };

            ReLoadData();
        }

        private void ReLoadData()
        {

        }
    }
}
