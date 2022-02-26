using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public enum ErrorCodes
    {
        Undefined = 0,
        
        // --- Auth (10x) -- 
        // example: 100, 101, .. , 199
        JWTExpired = 100,
        ImportantChanges = 101
    }
}
