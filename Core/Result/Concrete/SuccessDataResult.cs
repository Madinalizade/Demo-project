﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Result.Concrete
{
    public class SuccessDataResult<T> :DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,message,true)
        {

        }
        public SuccessDataResult(T data):base(data,true)
        {
                
        }
        public SuccessDataResult():base(default,true)
        {

        }
    }
}
