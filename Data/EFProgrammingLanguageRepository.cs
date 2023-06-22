using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Data
{
    public class EFProgrammingLanguageRepository : DbContext, IProgrammingLanguageListRepository
    {
        public EFProgrammingLanguageRepository(DbContextOptions<EFProgrammingLanguageRepository> options) : base(options)
        {

        }
        public DbSet<ProgrammingLanguageList> Lists { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }




        public IList<ProgrammingLanguageListDescription> GetLists()
        {
            return Lists     
                .OrderBy(x=> x.Name)
                .Select(x => new { x.Id, x.Name })
                .ToList()
                .Select( x  => new ProgrammingLanguageListDescription(x.Id, x.Name))
                .ToList();
;
        }

        public ProgrammingLanguageList GetListById(Guid? id)
            =>Lists
            .Include(x=>x.Name)
            .Single(x=> x.Id == id);

        public ProgrammingLanguageList SaveProgrammingLanguageList(ProgrammingLanguageList plList)
        {
            if(plList.Id == Guid.Empty)
                Lists.Add(plList);
            SaveChanges();
            return plList;
        }


        public void DeleteProgrammingLanguageList(Guid id)
        {
            Lists.Remove(Lists.Single(x=>x.Id== id));
            SaveChanges();
        }
    }
}
