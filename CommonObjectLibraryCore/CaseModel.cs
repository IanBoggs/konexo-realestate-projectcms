using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CommonObjectLibraryCore
{


    [Index(nameof(CaseReference), IsUnique = true)]
    public class Case
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseId { get; set; }
        [Required]
        public string CaseReference { get; set; }
        public virtual List<CaseEntity> CaseEntities { get; set; }
        [NotMapped]
        public string ClientName
        {
            get
            {

                CompanyEntity clientEntity = (CompanyEntity)this.CaseEntities.FirstOrDefault(e => e.EntityRole.EntityRoleName == "Client").Entity;
                return string.IsNullOrEmpty(clientEntity.CompanyName) ? "No Client" : clientEntity.CompanyName;
            }
        }

        public string GetEntityNameByRole(string roleName)
        {
            var entity = this.CaseEntities.FirstOrDefault(e => e.EntityRole.EntityRoleName == roleName).Entity;
            if (entity.GetType() == typeof(CompanyEntity))
                return ((CompanyEntity)entity).CompanyName;
            else
                return ((IndividualEntity)entity).FullName;
        }
        public string GetEntityNameByRole(int roleId)
        {
            var entity = this.CaseEntities.FirstOrDefault(e => e.EntityRole.EntityRoleId == roleId).Entity;
            if (entity.GetType() == typeof(CompanyEntity))
                return ((CompanyEntity)entity).CompanyName;
            else
                return ((IndividualEntity)entity).FullName;
        }
        public List<Entity> GetEntitesByRole(string roleName)
        {
            return this.CaseEntities.Where(e => string.Equals(roleName, e.EntityRole.EntityRoleName, StringComparison.OrdinalIgnoreCase)).Select(e => e.Entity).ToList();
        }
        public List<Entity> GetEntitesByRole(int roleId)
        {
            return this.CaseEntities.Where(e => roleId == e.EntityRole.EntityRoleId).Select(e => e.Entity).ToList();
        }

    }
}
