﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YerbaSoft.Web.Games.Clue.DAL.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\YerbaSoft.Web.Games." +
            "Clue.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False;Context Conne" +
            "ction=False")]
        public string YerbaSoft_Games_Web_ClueConnectionString {
            get {
                return ((string)(this["YerbaSoft_Games_Web_ClueConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\YerbaSoft.Web.Games." +
            "Clue.mdf;Integrated Security=True;Connect Timeout=30")]
        public string YerbaSoft_Games_Web_ClueConnectionString1 {
            get {
                return ((string)(this["YerbaSoft_Games_Web_ClueConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(LocalDB)\\v11.0;AttachDbFilename=W:\\YerbaSoft\\Games\\Web\\YerbaSoft.Gam" +
            "es.Web.Clue.mdf;Integrated Security=True;Connect Timeout=30")]
        public string YerbaSoft_Games_Web_ClueConnectionString2 {
            get {
                return ((string)(this["YerbaSoft_Games_Web_ClueConnectionString2"]));
            }
        }
    }
}
