using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{
    [Table("BankDetails")]
    public class BankDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankDetailId { get; set; }
        public string AccountNumber { get; set; }
        public string SortCode { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }


    }
}