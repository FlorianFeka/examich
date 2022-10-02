using AutoMapper;
using ExamichService.DTO.Question;
using ExamichService.Entity.Data.Exam;
using ExamichService.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamichService.Entity.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ExamichServiceDbContext _context;
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public QuestionRepository(ExamichServiceDbContext context, IExamRepository examRepository, IMapper mapper)
        {
            _context = context;
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateQuestionAsync(CreateQuestionDTO createQuestionDto)
        {
            if (!await _examRepository.ExamExistsAsync(createQuestionDto.ExamId)) throw new ExamichServiceDbException("Exam not found");
            var question = _mapper.Map<QuestionEntity>(createQuestionDto);
            question.ExamId = createQuestionDto.ExamId;
            await _context.Questions.AddAsync(question);
            return await _context.SaveChangesAsync();        }

        public async Task<GetQuestionDTO> DuplicateQuestionAsync(Guid questionId)
        {
            var questionToDuplicate = await _context.Questions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == questionId);
            
            if (questionToDuplicate == null) throw new ExamichServiceDbException("Question not found");

            questionToDuplicate.Id = Guid.NewGuid();
            await _context.Questions.AddAsync(questionToDuplicate);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetQuestionDTO>(questionToDuplicate);
        }

        public async Task<GetQuestionDTO> GetQuestionByIdAsync(Guid id)
        {
            var question = await _context.Questions
                    .Where(x => x.Id == id)
                    .Include(x => x.Answers)
                    .FirstOrDefaultAsync();
            return _mapper.Map<GetQuestionDTO>(question);
        }
        
        public async Task<List<GetQuestionDTO>> GetQuestionsByTextOrAnswerAsync(string text)
        {
            var questions = await _context.Questions
                .AsNoTracking()
                .Where(x => 
                    x.Text.Contains(text) || 
                    x.Answers.Any(y => y.Text.Contains(text)))
                .Include(x => x.Answers)
                .Select(x => _mapper.Map<GetQuestionDTO>(x))
                .ToListAsync();
            return questions;
        }

        public async Task<List<GetQuestionDTO>> GetQuestionsByExamIdAsync(Guid examId)
        {
            var questions = await _context.Questions
                .AsNoTracking()
                .Where(x => x.ExamId == examId)
                .Include(x => x.Answers)
                .Select(x => _mapper.Map<GetQuestionDTO>(x))
                .ToListAsync();
            return questions;
        }

        public async Task<int> UpdateQuestionAsync(Guid questionId, UpdateQuestionDTO updateQuestion)
        {
            var questionToUpdate = await _context.Questions.FindAsync(questionId);
            if (questionToUpdate == null) throw new ExamichServiceDbException("Question not found.");

            _mapper.Map(updateQuestion, questionToUpdate);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteQuestionAsync(Guid questionId)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question == null) throw new ExamichServiceDbException("Question not found");
            _context.Questions.Remove(question);
            return await _context.SaveChangesAsync();
        }
    }
}