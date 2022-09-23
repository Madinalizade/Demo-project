using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Result.Abstract
{
    public interface IResult
    {
        bool Success { get; set; }
        string Message { get; set; }
    }
}
