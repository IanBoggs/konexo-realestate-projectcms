using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{
    [Table("Users")]
    public class UserEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserEntityId { get; set; }
        public string FullName { get; set; }

    }
}
