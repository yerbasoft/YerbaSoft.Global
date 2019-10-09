using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSWork.DTO;

namespace CSWork.DAL
{
    public class Session
    {
        public const string GlobalConfigFileName = "CSWork.GlobalConfig.json";
        public const string WorkDataFileName = "CSWork.Working.json";

        public GlobalConfig GetGlobalConfig()
        {
            var file = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GlobalConfigFileName);

            if (!System.IO.File.Exists(file))
                return new GlobalConfig();

            string content;
            lock (GlobalConfigFileName)
            {
                content = System.IO.File.ReadAllText(file);
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GlobalConfig>(content);
        }

        public DTO.WorkData GetWorkData()
        {
            var file = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, WorkDataFileName);

            if (!System.IO.File.Exists(file))
                return new DTO.WorkData();

            string content;
            lock (WorkDataFileName)
            {
                content = System.IO.File.ReadAllText(file);
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<DTO.WorkData>(content);
        }

        public void Save(GlobalConfig config)
        {
            lock (GlobalConfigFileName)
            {
                var file = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, GlobalConfigFileName);
                var content = Newtonsoft.Json.JsonConvert.SerializeObject(config);
                System.IO.File.WriteAllText(file, content);
            }
        }
        public void Save(WorkData config)
        {
            lock (WorkDataFileName)
            {
                var file = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, WorkDataFileName);
                var content = Newtonsoft.Json.JsonConvert.SerializeObject(config);
                System.IO.File.WriteAllText(file, content);
            }
        }
    }
}
