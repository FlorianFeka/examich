using System;

namespace ExamichService.Entity.Data.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
