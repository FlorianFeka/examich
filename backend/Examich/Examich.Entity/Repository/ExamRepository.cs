using AutoMapper;
using Examich.DTO.Exam;
using Examich.Entity.Data.Exam;
using Examich.Exceptions;
using Examich.Interfaces.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<int> CreateExamAsync(Guid userId, CreateExamDto createExamDto)
        {
            var exam = _mapper.Map<ExamEntity>(createExamDto);
            exam.UserId = userId;
            exam.CreatorId = userId;
            await _context.Exams.AddAsync(exam);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> ExamExistsAsync(Guid examId)
        {
            return await _context.Exams.AnyAsync(e => e.Id == examId);
        }

        public async Task<GetExamDto> DuplicateExamAsync(Guid examId, Guid userId)
        {
            var examToDuplicate = await _context.Exams
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == examId);

            if (examToDuplicate == null) throw new ExamichDbException("Exam not found.");
            if (!await _userRepository.UserExistsAsync(examToDuplicate.UserId)) throw new ExamichDbException("User not found.");

            examToDuplicate.Id = Guid.NewGuid();
            examToDuplicate.UserId = userId;
            await _context.Exams.AddAsync(examToDuplicate);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetExamDto>(examToDuplicate);
        }

        public async Task<GetExamDto> GetExamByIdAsync(Guid id)
        {
            var exam = await _context.Exams.FindAsync(id);
            return _mapper.Map<GetExamDto>(exam);
        }

        public async Task<List<GetExamDto>> GetExamsByNameAsync(string name)
        {
            var exams = await _context.Exams
                .AsNoTracking()
                .Where(x => x.Name.Contains(name))
                .Select(x => _mapper.Map<GetExamDto>(x))
                .ToListAsync();
            return exams;
        }

        public async Task<List<GetExamDto>> GetExamsByUserIdAsync(Guid userId)
        {
            var exams = await _context.Exams
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .Select(x => _mapper.Map<GetExamDto>(x))
                .ToListAsync();
            return exams;
        }

        public async Task<int> UpdateExamAsync(Guid examId, Guid userId, UpdateExamDto updateExam)
        {
            var examToUpdate = await _context.Exams.FindAsync(examId);
            if (examToUpdate == null) throw new ExamichDbException("Exam not found.");
            if (examToUpdate.UserId == userId) throw new ExamichDbException("Exam not owned by user.");

            _mapper.Map(updateExam, examToUpdate);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteExamAsync(Guid examId, Guid userId)
        {
            var exam = await _context.Exams.FindAsync(examId);
            if (exam == null) throw new ExamichDbException("Exam not found.");
            if (exam.UserId != userId) throw new ExamichDbException("Exam not owned by user.");
            _context.Exams.Remove(exam);
            return await _context.SaveChangesAsync();
        }
    }
}
