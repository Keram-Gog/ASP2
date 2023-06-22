namespace Lab3.Models;

public record ProgrammingLanguage(Guid Id, string NamePL, string reithingPL);
public record ProgrammingLanguageListDescription(Guid Id, string Name);

public record ProgrammingLanguageList : ProgrammingLanguageListDescription
{
    private IList<ProgrammingLanguage>? pl;

    public IList<ProgrammingLanguage> PL { get; init; }

    public ProgrammingLanguageList(Guid id, string name, IList<ProgrammingLanguage> pl) : base(id, name)
    {
        PL = pl;
    }
    
}
