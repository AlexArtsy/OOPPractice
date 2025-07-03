using Core.Enums;

namespace Core.Utilities
{
    public static class ContentFormatParser
    {
        public static ContentFormat Parse(string format)
        {
            string cleanedFormat = format.Trim().TrimStart('.').ToLowerInvariant();

            return cleanedFormat switch
            {
                "txt" => ContentFormat.Txt,
                "doc" => ContentFormat.Doc,
                "rtf" => ContentFormat.Rtf,
                "fm1" => ContentFormat.Fm1,
                _ => throw new ArgumentException($"Неизвестный формат: '{format}'. Поддерживаемые форматы: {string.Join(", ", Enum.GetNames(typeof(ContentFormat)))}")
            };
        }
    }
}
