using SIR.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.Batch
{
    public interface ISplitted
    {
        Response IsValidRow(string row);
    }
}
