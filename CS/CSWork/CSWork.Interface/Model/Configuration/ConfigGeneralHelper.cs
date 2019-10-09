using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSWork.Interface.Properties;
using Microsoft.Win32;

namespace CSWork.Interface.Model.Configuration
{
    public class ConfigGeneralHelper : ConfigBase
    {
        // Windows
        private CheckBox cbGeneralStartWithWindows => GetControl<CheckBox>("pGeneralWindows", "cbGeneralStartWithWindows");

        // GCBA Red
        private TextBox tGeneralGCBARedUser => GetControl<TextBox>("pGCBARed", "tGeneralGCBARedUser");
        private TextBox tGeneralGCBARedPass => GetControl<TextBox>("pGCBARed", "tGeneralGCBARedPass");

        // Default Apps
        private TextBox tAppsWeb => GetControl<TextBox>("pGeneralApps", "tAppsWeb");
        private Button bAppsWebSearch => GetControl<Button>("pGeneralApps", "bAppsWebSearch");
        private Button bAppsWebNone => GetControl<Button>("pGeneralApps", "bAppsWebNone");

        // Modulos
        private CheckBox cbGeneralModuloAlarmas => GetControl<CheckBox>("pModulos", "cbGeneralModuloAlarmas");
        private CheckBox cbGeneralModuloMemory => GetControl<CheckBox>("pModulos", "cbGeneralModuloMemory");
        private CheckBox cbGeneralModuloAmbiente => GetControl<CheckBox>("pModulos", "cbGeneralModuloAmbiente");
        private CheckBox cbGeneralModuloLink => GetControl<CheckBox>("pModulos", "cbGeneralModuloLink");

        public ConfigGeneralHelper(Forms.Configuration form, Control container) : base(form, container)
        {
            // Windows - events
            cbGeneralStartWithWindows.CheckedChanged += OnStartWithWindowsChanged;

            // GCBA Red - events
            tGeneralGCBARedUser.TextChanged += (sender, e) => { Config.Global.General.GCBARed.User = tGeneralGCBARedUser.Text; Config.SaveGlobal(); };
            tGeneralGCBARedPass.TextChanged += (sender, e) => { Config.Global.General.GCBARed.Pass = tGeneralGCBARedPass.Text; Config.SaveGlobal(); };

            // Default Apps - events
            bAppsWebNone.Click += (sender, e) => { Config.Global.General.App.Web = null; Config.SaveGlobal(); ReLoad(); };
            bAppsWebSearch.Click += (sender, e) => { var app = SearchApp(); if (!string.IsNullOrEmpty(app)) { Config.Global.General.App.Web = app; Config.SaveGlobal(); ReLoad(); } };

            // Modulos - events
            cbGeneralModuloAlarmas.Image = Resources.alarmclock.ToBitmap().ZoomForControl(cbGeneralModuloAlarmas);
            cbGeneralModuloMemory.Image = Resources.note.ToBitmap().ZoomForControl(cbGeneralModuloMemory);
            cbGeneralModuloAmbiente.Image = Resources.data.ToBitmap().ZoomForControl(cbGeneralModuloAmbiente);
            cbGeneralModuloLink.Image = Resources.link.ToBitmap().ZoomForControl(cbGeneralModuloLink);

            cbGeneralModuloAlarmas.CheckedChanged += (sender, e) => { Config.Global.General.ModuleAlarma = cbGeneralModuloAlarmas.Checked; Config.SaveGlobal(); this.Form.Result.ReLoadAlarmaMenu = true; ReLoad(); };
            cbGeneralModuloMemory.CheckedChanged += (sender, e) => { Config.Global.General.ModuleMemory = cbGeneralModuloMemory.Checked; Config.SaveGlobal(); this.Form.Result.ReLoadMemoryMenu = true; ReLoad(); };
            cbGeneralModuloAmbiente.CheckedChanged += (sender, e) => { Config.Global.General.ModuleAmbiente = cbGeneralModuloAmbiente.Checked; Config.SaveGlobal(); this.Form.Result.ReLoadAmbientesMenu = true; ReLoad(); };
            cbGeneralModuloLink.CheckedChanged += (sender, e) => { Config.Global.General.ModuleLink = cbGeneralModuloLink.Checked; Config.SaveGlobal(); this.Form.Result.ReLoadLinksMenu = true; ReLoad(); };

            ReLoad();
        }

        private string SearchApp()
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = "exe";
            dialog.Filter = "Aplicaciones|*.exe";

            if (dialog.ShowDialog(this.Form) == DialogResult.OK)
                return dialog.FileName;

            return null;
        }

        private void ReLoad()
        {
            cbGeneralStartWithWindows.Checked = Config.Global.General.StartWithWindows;
            tGeneralGCBARedUser.Text = Config.Global.General.GCBARed.User;
            tGeneralGCBARedPass.Text = Config.Global.General.GCBARed.Pass;

            cbGeneralModuloAlarmas.Checked = Config.Global.General.ModuleAlarma;
            cbGeneralModuloMemory.Checked = Config.Global.General.ModuleMemory;
            cbGeneralModuloAmbiente.Checked = Config.Global.General.ModuleAmbiente;

            tAppsWeb.Text = string.IsNullOrEmpty(Config.Global.General.App.Web) ? "Usar Default del Sistema" : Config.Global.General.App.Web;
        }

        private void OnStartWithWindowsChanged(object sender, EventArgs e)
        {
            try
            {
                // intento registrar el inicio en el registro
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (cbGeneralStartWithWindows.Checked)
                    rk.SetValue("CS Work", Application.ExecutablePath);
                else
                    rk.DeleteValue("CS Work", false);
            }
            catch
            {
                // Si hubo error al registrar en el Registro, intento crear un acceso directo
                try
                {
                    IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
                    string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\WS Work.lnk";
                    System.Reflection.Assembly curAssembly = System.Reflection.Assembly.GetExecutingAssembly();

                    IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutAddress);
                    shortcut.Description = "CS Work";
                    shortcut.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    shortcut.TargetPath = curAssembly.Location;
                    shortcut.IconLocation = AppDomain.CurrentDomain.BaseDirectory + @"WSWork.ico";
                    shortcut.Save();
                }
                catch
                {
                    // no se pudo con ningún método
                    cbGeneralStartWithWindows.Checked = false;
                }
            }
            finally
            {
                BLL.Factory.Config.Global.General.StartWithWindows = cbGeneralStartWithWindows.Checked;
                BLL.Factory.Config.SaveGlobal();
            }
        }
    }
}
