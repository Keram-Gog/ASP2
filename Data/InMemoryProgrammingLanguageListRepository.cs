using Lab3.Models;

namespace Lab3.Data
{
    public class InMemoryProgrammingLanguageListRepository : IProgrammingLanguageListRepository
    {
        private readonly List<ProgrammingLanguageList> ProgrammingLanguageLists = new();
        
        public void DeleteProgrammingLanguageList(Guid id)
        {
            ProgrammingLanguageLists.Remove(ProgrammingLanguageLists.Single(x => x.Id == id));
        }

        public ProgrammingLanguageList? GetListById(Guid? id)
        {
            if (id == null) return null;
            return ProgrammingLanguageLists.Single(x => x.Id == id);
        }

        public IList<ProgrammingLanguageListDescription> GetLists()
        {
            return ProgrammingLanguageLists.Select(x => new ProgrammingLanguageListDescription(x.Id, x.Name)).ToList();
        }

        public ProgrammingLanguageList SaveProgrammingLanguageList(ProgrammingLanguageList ProgrammingLanguageList)
        {
               if (ProgrammingLanguageList.Id == Guid.Empty)
                {
                var savedList = new ProgrammingLanguageList(Guid.NewGuid(), ProgrammingLanguageList.Name, ProgrammingLanguageList.PL);
                ProgrammingLanguageLists.Add(savedList);
                    return savedList;
                }
               return ProgrammingLanguageList;
                
         }
    }
}
