namespace lr2.entity;

public class Material(MaterialQuality materialQuality)
{
    public Boolean IsQualitative()
    {
        return materialQuality.Equals(MaterialQuality.Qualitative);
    }
}