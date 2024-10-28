namespace asutus.common.Model;

public class AsutusDto : AsutusShortDto
{
    public List<TranslationDto> Translations { get; set; }
}

public class TranslationDto
{
    public string Code { get; set; }
    public string Text { get; set; }
}