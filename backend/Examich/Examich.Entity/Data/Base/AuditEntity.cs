using Microsoft.EntityFrameworkCore;
using System;

namespace Examich.Entity.Data.Base
{
    public class AuditEntity : BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public static void OnModelBuilding(ModelBuilder builder)
        {
            builder.Entity<AuditEntity>()
                .Property(x => x.Created)
                .ValueGeneratedOnAdd();

            builder.Entity<AuditEntity>()
                .Property(x => x.Updated)
                .ValueGeneratedOnUpdate();
        }
    }
}
