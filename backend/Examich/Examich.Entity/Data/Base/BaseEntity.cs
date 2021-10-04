using System;

namespace Examich.Entity.Data.Base
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
