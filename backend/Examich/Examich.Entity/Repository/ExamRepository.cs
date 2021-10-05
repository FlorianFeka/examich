using AutoMapper;
using Examich.DTO.Exam;
using Examich.Interfaces.Entity.Repository;
using System;
using System.Collections.Generic;

namespace Examich.Entity.Repository
{
    public class ExamRepository : IExamRepository
    {
        private readonly ExamichDbContext _context;
        private readonly IMapper _mapper;

        public ExamRepository(ExamichDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddExam(CreateExamDto exam)
        {

        }

        public GetExamDto DuplicateExam(DuplicateExamDto duplicateExam)
        {
            throw new NotImplementedException();
        }

        public GetExamDto GetExamById(string id, string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetExamDto> GetExamsByName(string name, string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetExamDto> GetExamsByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        private bool ExamExists()
        {
            return false;
        }
    }
}
