﻿using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
        // returns the current authenticated account (null if not logged in)
        //public Account Account => (Account)HttpContext.Items["Account"];
    }
}
