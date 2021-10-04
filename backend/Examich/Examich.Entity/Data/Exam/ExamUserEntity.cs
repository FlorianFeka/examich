using Examich.Entity.Data.User;

namespace Examich.Entity.Data.Exam
{
    public class ExamUserEntity
    {
        public bool IsOwner { get; set; }

        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public string ExamId { get; set; }
        public ExamEntity Exam { get; set; }
    }
}
