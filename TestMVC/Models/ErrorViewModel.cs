using System;
using CommonObjectLibraryCore;
using System.Collections.Generic;

namespace TestMVC.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }


}
