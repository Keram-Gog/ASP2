using Lab3.Data;
using Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab3.Controllers
{
    public class ProgrammingLanguageController : Controller
    {
        private readonly ILogger<ProgrammingLanguageController> _logger;
        private readonly IProgrammingLanguageListRepository _programminglanguageListRepository;

        public ProgrammingLanguageController(IProgrammingLanguageListRepository programminglanguageListRepository, ILogger<ProgrammingLanguageController> logger)
        {
            _programminglanguageListRepository = programminglanguageListRepository ?? throw new ArgumentNullException(nameof(programminglanguageListRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IActionResult Index(Guid id)
        {
            var programminglanguagelists = _programminglanguageListRepository.GetLists();
            if (!programminglanguagelists.Any())
                return RedirectToAction(nameof(ProgrammingLanguageManagerController.Index), "ProgrammingLanguageManager");

            var selectedListId = programminglanguagelists.SingleOrDefault(x => x.Id == id)?.Id ?? programminglanguagelists.First().Id;
            var selectedList = _programminglanguageListRepository.GetListById(selectedListId);

            var viewModel = new IndexViewModel(
                programminglanguagelists,
                selectedListId,
                selectedList.PL);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddProgrammingLanguage(/*[FromBody]*/ AddProgrammingLanguageViewModel addModel)
        {
            try
            {
                var programminglanguageList = _programminglanguageListRepository.GetListById(addModel.ProgrammingLanguageListId) ?? throw new ArgumentNullException(nameof(addModel));
                programminglanguageList.PL.Add(new ProgrammingLanguage(Guid.Empty, addModel.Name, addModel.reitinght));
                _programminglanguageListRepository.SaveProgrammingLanguageList(programminglanguageList);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("Список не найден.");
            }
            return RedirectToAction(nameof(Index), new { id = addModel.ProgrammingLanguageListId });
        }

        public record IndexViewModel(
    IList<ProgrammingLanguageListDescription> ProgrammingLanguagetList,
    Guid SelectedProgrammingLanguageListId,
    IList<ProgrammingLanguage> ProgrammingLanguages);

        public record AddProgrammingLanguageViewModel(
             Guid ProgrammingLanguageListId,
             string Name,
             string reitinght);
    }
}