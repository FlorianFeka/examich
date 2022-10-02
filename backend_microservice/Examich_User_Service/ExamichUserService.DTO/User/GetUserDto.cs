using System;

namespace Examich.DTO.User
{
    public class GetUserDto
    {
        public Guid Id {  get; set; }
        public string UserName {  get; set; }
        public string Email {  get; set; }
    }
}
