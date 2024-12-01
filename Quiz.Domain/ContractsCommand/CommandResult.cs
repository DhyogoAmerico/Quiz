using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Domain.ContractsCommand
{
    public class CommandResult
    {
        public bool Success { get; set; }
        public dynamic? Data { get; set; }
        public static CommandResult Send(bool success, dynamic? data)
        {
            return new() {
                Success = success,
                Data = data
            };
        }
    }
}