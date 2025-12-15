using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Shared.Responses
{
    public class ActionResponse<T>
    {
        public T? Result { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}