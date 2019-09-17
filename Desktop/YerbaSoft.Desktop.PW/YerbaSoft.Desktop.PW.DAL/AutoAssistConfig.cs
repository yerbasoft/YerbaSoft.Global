using System;
using System.Collections.Generic;
using System.Windows.Forms;
using YerbaSoft.DTO.Mapping;
using YerbaSoft.DTO.Types;

namespace YerbaSoft.Desktop.PW.DAL
{
    public class AutoAssistConfig : YerbaSoft.DAL.Repositories.XmlSimpleClass
    {
        [Direct] public bool WinPinned { get; set; }
        [Direct] public bool WinShowAttachParent { get; set; }
        [Direct] public int ScreenX { get; set; }
        [Direct] public int ScreenY { get; set; }

        [Direct] public string AssistPJKey { get; set; }
        [Direct] public string AssistKey { get; set; }
        [Direct] public int AssistTime { get; set; }

        [NoMap] public bool HasPick => !string.IsNullOrEmpty(this.PickKey);
        [Direct] public string PickKey { get; set; }
        [Direct] public int PickTime { get; set; }

        [Direct] public string FollowParty { get; set; }

        [NoMap] public int FollowPartyNum => Convert.ToInt32(FollowParty.Substring("NumPad".Length));

    }
}
