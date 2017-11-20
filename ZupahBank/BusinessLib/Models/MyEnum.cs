using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Models
{
    public enum MyEnum
    {
        [Description("Success on creating")]
        Success = 1,
        [Description("Error error error!!!")]
        Error = 2
    }
}
