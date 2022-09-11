using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Examich.DTO.Question;
using Examich.Entity.Data.Exam;
using Examich.Exceptions;
using Examich.Interfaces.Entity.Repository;
using Microsoft.EntityFrameworkCore;

namespace Examich.Entity.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ExamichDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public QuestionRepository(ExamichDbContext context, IUserRepository userRepository, IExamRepository examRepository, IMapper mapper)
        {
            _context = context;
            _userRepository = userRepository;
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateQuestionAsync(Guid examId, CreateQuestionDTO createQuestionDto)
        {
            if (!await _examRepository.ExamExistsAsync(examId)) throw new ExamichDbException("Exam not found");
            var question = _mapper.Map<QuestionEntity>(createQuestionDto);
            question.ExamId = examId;
            await _context.Questions.AddAsync(question);
            return await _context.SaveChangesAsync();
        }

        public async Task<GetQuestionDTO> DuplicateQuestionAsync(Guid examId, Guid questionId)
        {
            var questionToDuplicate = await _context.Questions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == questionId);
            
            if (!await _examRepository.ExamExistsAsync(examId)) throw new ExamichDbException("Exam not found");
            if (questionToDuplicate == null) throw new ExamichDbException("Question not found");

            questionToDuplicate.Id = Guid.NewGuid();
            await _context.Questions.AddAsync(questionToDuplicate);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetQuestionDTO>(questionToDuplicate);
        }

        public async Task<GetQuestionDTO> GetQuestionByIdAsync(Guid id)
        {
            var question = await _context.Questions.FindAsync(id);
            return _mapper.Map<GetQuestionDTO>(question);
        }
        
        public async Task<List<GetQuestionDTO>> GetQuestionsByTextOrAnswerAsync(string text)
        {
            var questions = await _context.Questions
                .AsNoTracking()
                .Where(x => 
                    x.Text.Contains(text) || 
                    x.Answers.Any(y => y.Text.Contains(text)))
                .Select(x => _mapper.Map<GetQuestionDTO>(x))
                .ToListAsync();
            return questions;
        }

        public async Task<List<GetQuestionDTO>> GetQuestionsByExamIdAsync(Guid examId)
        {
            var questions = await _context.Questions
                .AsNoTracking()
                .Where(x => x.ExamId == examId)
                .Select(x => _mapper.Map<GetQuestionDTO>(x))
                .ToListAsync();
            return questions;
        }

        public async Task<int> UpdateQuestionAsync(Guid questionId, Guid examId, UpdateQuestionDTO updateQuestion)
        {
            var questionToUpdate = await _context.Questions.FindAsync(questionId);
            if (questionToUpdate == null) throw new ExamichDbException("Question not found.");
            if (questionToUpdate.ExamId == examId) throw new ExamichDbException("Question not assigned to exam.");

            _mapper.Map(updateQuestion, questionToUpdate);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteQuestionAsync(Guid questionId, Guid examId)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question == null) throw new ExamichDbException("Question not found");
            if (question.ExamId == examId) throw new ExamichDbException("Question not assigned to exam.");
            _context.Questions.Remove(question);
            return await _context.SaveChangesAsync();
        }
    }
}