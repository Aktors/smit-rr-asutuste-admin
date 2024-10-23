namespace asutus.common.Model;

//TODO: change these classes to contain patch like information
public class AsutusDto : AsutusShortDto
{
    public List<Translation> Translations { get; set; }
}

public class Translation
{
    public string Code { get; set; }
    public string Text { get; set; }
}