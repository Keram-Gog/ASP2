using Lab3.Models;
namespace Lab3.Data
{
    public interface IProgrammingLanguageListRepository
    {
        IList<ProgrammingLanguageListDescription> GetLists();

        ProgrammingLanguageList GetListById (Guid? id);

        ProgrammingLanguageList SaveProgrammingLanguageList(ProgrammingLanguageList ProgrammingLanguageList);

        void DeleteProgrammingLanguageList(Guid id);

    }
}
