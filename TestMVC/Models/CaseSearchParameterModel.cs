using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestMVC.Models;
using CommonObjectLibraryCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestMVC.Models
{

    public enum SearchTypes
    {
        CaseReference,
        ClientReference
    }

    public class CaseSearchParameters
    {
        public string SearchTerm { get; set; }
        public SearchTypes SearchType { get; set; }
        public bool ExactMatch { get; set; }
    }
}