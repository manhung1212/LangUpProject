using LangUp.Entities;
using LangUp.ViewModels;
using LangUp.ViewModels.WordDetailsViewModel;
using LangUp.ViewModels.WordsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangUp.Services.Interfaces
{
    public interface IWordService
    {
        Task<ServiceResponse<bool>> CreateWord(CreateWordViewModel createWordViewModel, Guid crrUser);
        Task<ServiceResponse<bool>> UpdateSingleDetailWord(EditSingleWordDetailsViewModel editSingleWordDetailsViewModel, Guid crrUser);
        Task<ServiceResponse<bool>> UpdateWord(EditWordViewModel editWordViewModel, Guid crrUser);
        Task<ServiceResponse<bool>> DeleteWord(Guid lessonId, Guid crrUser);
        Task<ServiceResponse<IEnumerable<Word>>> GetAllWordyLessonId(Guid lessonId);
    }
}
