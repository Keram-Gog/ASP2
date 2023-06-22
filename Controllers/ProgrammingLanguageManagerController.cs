using Microsoft.AspNetCore.Mvc;
using Lab3.Data;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class ProgrammingLanguageManagerController : Controller
    {
        private readonly IProgrammingLanguageListRepository _ProgrammingLanguageListRepository;

        public ProgrammingLanguageManagerController(IProgrammingLanguageListRepository ProgrammingLanguageListRepository)
        {
            _ProgrammingLanguageListRepository = ProgrammingLanguageListRepository;
        }

        public IActionResult Index()
        {
            var ProgrammingLanguagelists = _ProgrammingLanguageListRepository.GetLists();

            return View(ProgrammingLanguagelists);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult Create(ProgrammingLanguageListDescription ProgrammingLanguageListDescription)
        {
            _ProgrammingLanguageListRepository.SaveProgrammingLanguageList(new ProgrammingLanguageList(Guid.Empty, ProgrammingLanguageListDescription.Name, new List<ProgrammingLanguage>()));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(Guid id)
        {
            _ProgrammingLanguageListRepository.DeleteProgrammingLanguageList(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
