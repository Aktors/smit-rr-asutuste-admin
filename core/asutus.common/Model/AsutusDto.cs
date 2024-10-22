namespace asutus.common.Model;

//TODO: change these classes to contain patch like information
public class AsutusDto
{
    public string Code { get; set; }
    public string Name { get; set; }
    public List<Translation> Translations { get; set; }
}

public class Translation
{
    public string Code { get; set; }
    public string Text { get; set; }
}