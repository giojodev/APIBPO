using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBPO.BPOApi.Infrasctructure.DTO
{
    public class BaseResponse<T>
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public BaseResponse(int code, string? message, T? data)
        {
            StatusCode = code;
            Message = message;
            Data = data;
        }
    }
}