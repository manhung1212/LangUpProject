using LangUp.Entities;
using LangUp.Repositories.Interfaces;
using LangUp.Services.Interfaces;
using LangUp.ViewModels;
using LangUp.ViewModels.WordDetailsViewModel;
using LangUp.ViewModels.WordsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LangUp.Services
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _iwordRepository;
        private readonly IWordDetailRepository _iwordDetailRepository;
        private readonly ILessonRepository _ilessonRepository;
        private readonly ICourseRepository _icourseRepository;

        public WordService(
            IWordRepository wordRepository,
            ILessonRepository lessonRepository,
            IWordDetailRepository wordDetailRepository,
            ICourseRepository courseRepository)
        {
            _iwordRepository = wordRepository;
            _ilessonRepository = lessonRepository;
            _iwordDetailRepository = wordDetailRepository;
            _icourseRepository = courseRepository;
        }

        public async Task<ServiceResponse<bool>> CreateWord(CreateWordViewModel createWordViewModel, Guid crrUser)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var checkLesson = (await _ilessonRepository.FindBy(x => x.LessonId == createWordViewModel.LessonId)).FirstOrDefault();
                if (checkLesson == null)
                {
                    response.Message = "Lesson NOT exist";
                    return response;
                }
                var wordTemp = new Word
                {
                    Content = createWordViewModel.Content,
                    LessonId = checkLesson.LessonId,
                    Status = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
                var newWord = await _iwordRepository.Create(wordTemp);
                if (newWord == null)
                {
                    response.Message = "Create Word Fail";
                    return response;
                }

                if (createWordViewModel.CreateWordDetailsViewModel.Count > 0)
                {
                    foreach (var w in createWordViewModel.CreateWordDetailsViewModel)
                    {
                        var wordDetailTemp = new WordDetail
                        {
                            WordId = newWord.WordId,
                            Meaning = w.Meaning,
                            Example = w.Example,
                            Spelling = w.Spelling,
                            WordType = w.WordType,
                            Status = "1",
                        };
                        if ((await _iwordDetailRepository.Create(wordDetailTemp)) == null)
                        {
                            response.Message = "Create Word Detail Fail";
                            return response;
                        }
                    }
                }
                response.Success = true;
                response.Message = "Create Word successfull";
                response.Data = true;
            }
            catch (Exception e)
            {
                response.Message = "Create Word failed: " + e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteWord(Guid wordId, Guid crrUser)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var checkWord = (await _iwordRepository.FindBy(x => x.WordId == wordId)).FirstOrDefault();
                if (checkWord == null)
                {
                    response.Message = "Word NOT exist";
                    return response;
                }
                var lesson = (await _ilessonRepository.FindBy(x => x.LessonId == checkWord.LessonId)).FirstOrDefault();
                if (lesson == null)
                {
                    response.Message = "Lesson NOT exist";
                    return response;
                }
                var checkCourse = (await _icourseRepository.FindBy(x => x.CourseId == lesson.CourseId)).FirstOrDefault();
                if (checkCourse == null)
                {
                    response.Message = "Course NOT exist";
                    return response;
                }
                if (checkCourse.AuthorId != crrUser)
                {
                    response.Message = "You NOT permission for this function";
                    return response;
                }

                checkWord.Status = -1;
                checkWord.UpdatedDate = DateTime.Now;
                if ((await _iwordRepository.Update(checkWord, checkWord.WordId)) == -1)
                {
                    response.Message = "Delete Word failed";
                    return response;
                }

                response.Message = "Delete Word Successfull";
                response.Success = true;
                response.Data = true;
            }
            catch (Exception e)
            {
                response.Message = "Delete Word Failed: " + e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<Word>>> GetAllWordyLessonId(Guid lessonId)
        {
            var response = new ServiceResponse<IEnumerable<Word>>();
            try
            {
                var checkLesson = (await _ilessonRepository.FindBy(x => x.LessonId == lessonId)).FirstOrDefault();
                if (checkLesson == null)
                {
                    response.Message = "Lesson NOT exist";
                    return response;
                }
                var lstWordOut = new List<Word>();
                var wordsOfLesson = (await _iwordRepository.FindBy(x => x.LessonId == checkLesson.LessonId)).ToList();
                if (wordsOfLesson.Count > 0)
                {
                    foreach (var w in wordsOfLesson)
                    {
                        var detailOfWord = (await _iwordDetailRepository.FindBy(x => x.WordId == w.WordId)).ToList();
                        w.WordDetail = detailOfWord;
                        lstWordOut.Add(w);
                    }
                }
                response.Data = lstWordOut;
                response.Message = "GetAllWordyLessonId Successfull";
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Message = "GetAllWordyLessonId Failed: " + e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateSingleDetailWord(EditSingleWordDetailsViewModel editSingleWordDetailsViewModel, Guid crrUser)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var checkDetailWord = (await _iwordDetailRepository.FindBy(x => x.WordDetailId == editSingleWordDetailsViewModel.WordDetailId)).FirstOrDefault();
                if (checkDetailWord == null)
                {
                    response.Message = "WordDetail NOT exist";
                    return response;
                }

                var word = (await _iwordRepository.FindBy(x => x.WordId == checkDetailWord.WordId)).FirstOrDefault();
                if (word == null)
                {
                    response.Message = "Word NOT exist";
                    return response;
                }
                var lesson = (await _ilessonRepository.FindBy(x=>x.LessonId == word.LessonId)).FirstOrDefault();
                if (lesson == null)
                {
                    response.Message = "Lesson NOT exist";
                    return response;
                }
                var checkCourse = (await _icourseRepository.FindBy(x => x.CourseId == lesson.CourseId)).FirstOrDefault();
                if (checkCourse == null)
                {
                    response.Message = "Course NOT exist";
                    return response;
                }

                if (checkCourse.AuthorId != crrUser)
                {
                    response.Message = "You NOT permission for this function";
                    return response;
                }

                checkDetailWord.Meaning = editSingleWordDetailsViewModel.Meaning;
                checkDetailWord.Example = editSingleWordDetailsViewModel.Example;
                checkDetailWord.Spelling = editSingleWordDetailsViewModel.Spelling;
                checkDetailWord.WordType = editSingleWordDetailsViewModel.WordType;
                checkDetailWord.Status = editSingleWordDetailsViewModel.Status;
                if ((await _iwordDetailRepository.Update(checkDetailWord, checkDetailWord.WordDetailId)) == -1)
                {
                    response.Message = "Update Word Detail Failed";
                    return response;
                }
                response.Message = "Update Word Detail Successfull";
                response.Success = true;
                response.Data = true;
            }
            catch (Exception e)
            {
                response.Message = "UpdateSingleDetailWord Failed: " + e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateWord(EditWordViewModel editWordViewModel, Guid crrUser)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                var checkWord = (await _iwordRepository.FindBy(x => x.WordId == editWordViewModel.WordId)).FirstOrDefault();
                if (checkWord == null)
                {
                    response.Message = "Word NOT exist";
                    return response;
                }
                var lesson = (await _ilessonRepository.FindBy(x => x.LessonId == checkWord.LessonId)).FirstOrDefault();
                if (lesson == null)
                {
                    response.Message = "Lesson NOT exist";
                    return response;
                }
                var checkCourse = (await _icourseRepository.FindBy(x => x.CourseId == lesson.CourseId)).FirstOrDefault();
                if (checkCourse == null)
                {
                    response.Message = "Course NOT exist";
                    return response;
                }
                if (checkCourse.AuthorId != crrUser)
                {
                    response.Message = "You NOT permission for this function";
                    return response;
                }

                checkWord.Content = editWordViewModel.Content;
                checkWord.Status = editWordViewModel.Status;
                if ((await _iwordRepository.Update(checkWord, checkWord.WordId)) == -1)
                {
                    response.Message = "Delete Word failed";
                    return response;
                }
                if (editWordViewModel.WordDetailsViewModel.Count > 0)
                {
                    foreach (var w in editWordViewModel.WordDetailsViewModel)
                    {
                        var wTemp = (await _iwordDetailRepository.FindBy(x => x.WordDetailId == w.WordDetailId)).FirstOrDefault();
                        if (wTemp == null)
                        {
                            response.Message = "Word Detail NOT exist";
                            return response;
                        }
                        wTemp.Meaning = w.Meaning;
                        wTemp.Example = w.Example;
                        wTemp.Spelling = w.Spelling;
                        wTemp.WordType = w.WordType;
                        wTemp.Status = w.Status;
                        if ((await _iwordDetailRepository.Update(wTemp, wTemp.WordDetailId)) == -1)
                        {
                            response.Message = "Update Word Detail Failed";
                            return response;
                        }
                    }
                }
                response.Message = "Update Word Successfull";
                response.Success = true;
                response.Data = true;
            }
            catch (Exception e)
            {
                response.Message = "Update Word Failed: " + e.Message;
            }
            return response;
        }
    }
}
