using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CommonObjectLibraryCore
{
    public interface IEntity
    {
        Guid EntityId { get; set; }
        PostalAddress PrincipalAddress { get; set; }
    }
}