namespace asutus.common.Model;

public class AsutusDto : AsutusShortDto
{
    public AsutusDto()
    {
        Translations = [];
    }
    
    public AsutusDto(List<TranslationDto> translations)
    {
        Translations = translations;
    }

    public List<TranslationDto> Translations { get; set; }
}

public class TranslationDto
{
    public string Code { get; set; }
    public string Text { get; set; }
}