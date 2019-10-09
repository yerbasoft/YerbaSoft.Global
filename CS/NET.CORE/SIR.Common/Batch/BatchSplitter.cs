using SIR.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIR.Common.Batch
{
    public class BatchSplitter
    {
        public Response<T> Deserialize<T>(string row) where T : ISplitted, new()
        {
            try
            {
                var response = new Response<T>(true);

                var output = new T();
                var valid = output.IsValidRow(row);
                if (!valid.Success)
                    return new Response<T>(valid);

                var props = Reflection.GetPropertiesWithAttribute<T, Split>();
                
                foreach (var prop in props)
                {
                    var value = prop.Attr.GetValue(row, prop.Type);
                    response.Add(value);

                    if (value.Success)
                        prop.Prop.SetValue(output, value.Data);
                }

                return response.SetData(output);
            }
            catch (Exception ex)
            {
                return new Response<T>(ex);
            }
        }
    }
}
