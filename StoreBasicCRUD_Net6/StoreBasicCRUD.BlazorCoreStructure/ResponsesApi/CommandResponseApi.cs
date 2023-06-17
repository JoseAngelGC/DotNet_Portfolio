using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBasicCRUD.BlazorCoreStructure.ResponsesApi
{
    public class CommandResponseApi
    {
        public int StatusResponse { get; set; }
        public string? Information { get; set; }
        public object? ValidationErrors { get; set; }
        public int? RecordsAffected { get; set; }
        public string? MessageResponse { get; set; }
        public bool IsSuccess { get; set; }
    }
}
