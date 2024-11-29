using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftDesign.Library.Domain.Entities.Core
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public DateTime? DeletedDate { get; private set; }
        public bool IsActive => DeletedDate != null;

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}