using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace ClientsRegistration.Model.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ClassificationEnum : int
    {
        Active = 1,
        Inactive = 2,
        Preferential = 3,
    }
}
