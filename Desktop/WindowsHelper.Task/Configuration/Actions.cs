﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsHelper.Task.Configuration
{
    public class Actions
    {
        [YerbaSoft.DTO.Mapping.SubList]
        public List<ActionType> Action { get; set; }
    }
}
