using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HIS
{
    public class FullAuditedEntityExt<TKey> : FullAuditedEntity<TKey>
    {
        [StringLength(50)]
        public virtual string CreatorName { get; set; }
        [StringLength(50)]
        public virtual string LastModifierName { get; set; }
        [StringLength(50)]
        public virtual string DeleterName { get; set; }
    }
}
