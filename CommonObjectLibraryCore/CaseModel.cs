using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CommonObjectLibraryCore
{


    [Index(nameof(CaseReference), IsUnique = true)]
    [Index(nameof(ClientReference), nameof(ClientEntity.ClientEntityId), IsUnique = true)]
    [Table("Cases")]
    public class Case
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CaseId { get; set; }
        [Required]
        [DisplayName("Case Reference")]
        public string CaseReference { get; set; }
        [Required]
        [DisplayName("Current Status")]
        public virtual CaseStatus CurrentStatus { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select a case status")]
        public int CurrentStatusId { get; set; }
        [DisplayName("Client Reference")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "A Client Reference Is Required")]
        public string ClientReference { get; set; }
        [Required]
        public virtual ClientEntity Client { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select a cient")]
        public int ClientId { get; set; }
        [DisplayName("Case Handler")]
        public virtual UserEntity CaseHandler { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select a case handler")]
        public int CaseHandlerId { get; set; }
        public virtual List<CaseEntity> CaseEntities { get; set; }


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
