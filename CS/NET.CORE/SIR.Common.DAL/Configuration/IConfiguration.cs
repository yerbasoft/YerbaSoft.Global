using SIR.Common.DAL.Configuration.Entities;
using SIR.Common.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIR.Common.DAL.Configuration
{
    public interface IConfiguration
    {
        Response<Config> Get(string key);
        Config Get(string key, SIR.Common.Log.Logger logger);
    }
}
