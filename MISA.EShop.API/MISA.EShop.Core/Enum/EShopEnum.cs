using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Core.Enum
{
    public enum ErrorCode
    {
        NONE = 0,
        NOTFOUND = 404,
        BADREQUEST = 400,
        NOCONTENT = 204,
        EXCEPTION = 500
    }
}
