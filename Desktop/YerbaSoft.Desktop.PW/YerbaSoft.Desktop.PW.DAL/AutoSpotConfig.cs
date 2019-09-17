using System;
using System.Collections.Generic;
using System.Windows.Forms;
using YerbaSoft.DTO.Mapping;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Desktop.PW.DAL
{
    public class AutoSpotConfig : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {

        [NoMap] public bool HasPick => !string.IsNullOrEmpty(this.PickKey);
        [Direct] public string PickKey { get; set; }
        [Direct] public int PickTime { get; set; }

        [Direct] public string AssistKey { get; set; }
        [NoMap] public int AssistMob { get; set; }

        [NoMap] public bool HasBuff => !string.IsNullOrEmpty(this.BuffKey);
        [Direct] public string BuffKey { get; set; }
        [Direct] public int BuffExpireTime { get; set; }
        [Direct] public int BuffCastTime { get; set; }

        [Direct] public bool WinPinned { get; set; }
        [Direct] public bool WinShowAttachParent { get; set; }
        [Direct] public int ScreenX { get; set; }
        [Direct] public int ScreenY { get; set; }
    }
}
