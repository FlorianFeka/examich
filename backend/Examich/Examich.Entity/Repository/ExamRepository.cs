using AutoMapper;
using Examich.DTO.Exam;
using Examich.Entity.Data.Exam;
using Examich.Exceptions;
using Examich.Interfaces.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Examich.Entity.Repository
{
    public class ExamRepository : IExamRepository
    {
        private readonly ExamichDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ExamRepository(ExamichDbContext context, IUserRepository userRepository, IMapper mapper)
        {
            _context = context;
            _userRepository = userRepository;
            _mapper = mapper;

        }

        public void AddExam(string userId, CreateExamDto createExamDto)
        {
            var exam = _mapper.Map<ExamEntity>(createExamDto);
            exam.UserId = userId;
            exam.CreatorId = userId;
            _context.Exams.Add(exam);
            _context.SaveChanges();
        }

        public GetExamDto DuplicateExam(string examId, string userId)
        {
            var examToDuplicate = _context.Exams
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == examId);

            if (examToDuplicate == null) throw new ExamichDbException("Exam not found.");
            if (!_userRepository.UserExists(examToDuplicate.UserId)) throw new ExamichDbException("User not found.");

            examToDuplicate.Id = Guid.NewGuid().ToString();
            examToDuplicate.UserId = userId;
            _context.Exams.Add(examToDuplicate);
            _context.SaveChanges();

            return _mapper.Map<GetExamDto>(examToDuplicate);
        }

        public GetExamDto GetExamById(string id)
        {
            var exam = _context.Exams.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return _mapper.Map<GetExamDto>(exam);
        }

        public IEnumerable<GetExamDto> GetExamsByName(string name)
        {
            var exams = _context.Exams
                .AsNoTracking()
                .Where(x => x.Name.Contains(name))
                .Select(x => _mapper.Map<GetExamDto>(x));
            return exams;
        }

        public IEnumerable<GetExamDto> GetExamsByUserId(string userId)
        {
            var exams = _context.Exams
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => _mapper.Map<GetExamDto>(x));
            return exams;
        }

        public void UpdateExam(string examId, string userId, UpdateExamDto updateExam)
        {
            var examToUpdate = _context.Exams.FirstOrDefault(x => x.Id == examId);
            if (examToUpdate == null) throw new ExamichDbException("Exam not found.");
            if(examToUpdate.UserId == userId) throw new ExamichDbException("Exam not owned by user.");

            _mapper.Map(updateExam, examToUpdate);
            _context.SaveChanges();
        }

        public void DeleteExam(string examId, string userId)
        {
            var exam = _context.Exams.FirstOrDefault(x => x.Id == examId);
            if (exam == null) throw new ExamichDbException("Exam not found.");
            if (exam.UserId != userId) throw new ExamichDbException("Exam not owned by user.");
            _context.Exams.Remove(exam);
            _context.SaveChanges();
        }
    }
}
