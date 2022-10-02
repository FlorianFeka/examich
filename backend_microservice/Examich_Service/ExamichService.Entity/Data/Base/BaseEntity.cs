using System;

namespace Examich.Entity.Data.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
