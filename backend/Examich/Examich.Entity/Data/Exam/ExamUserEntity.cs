using System;
using Examich.Entity.Data.User;

namespace Examich.Entity.Data.Exam
{
    public class ExamUserEntity
    {
        public bool IsOwner { get; set; }

        public Guid UserId { get; set; }
        public UserEntity User { get; set; }
        public Guid ExamId { get; set; }
        public ExamEntity Exam { get; set; }
    }
}
