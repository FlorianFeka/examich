﻿using System;
using ExamichUserService.DTO.Exam;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamichUserService.Interfaces.Entity.Repository
{
    public interface IExamRepository
    {
        Task<int> CreateExamAsync(Guid userId, CreateExamDto createExam);
        Task<bool> ExamExistsAsync(Guid examId);
        Task<int> UpdateExamAsync(Guid examId, Guid userId, UpdateExamDto updateExam);
        Task<List<GetExamDto>> GetExamsByNameAsync(string name);
        Task<List<GetExamDto>> GetExamsByUserIdAsync(Guid userId);
        Task<GetExamDto> GetExamInfoByIdAsync(Guid id);
        Task<GetExamDto> DuplicateExamAsync(Guid examId, Guid userId);
        Task<int> DeleteExamAsync(Guid examId, Guid userId);
    }
}
