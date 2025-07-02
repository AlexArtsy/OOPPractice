namespace DocumentManager.Document
{
    public enum ContentFormat
    {
        Txt,
        Doc,
        Rtf,
        Fm1
    }

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
                _ => throw new ArgumentException($"Unknown format: '{format}'. Supported formats: {string.Join(", ", Enum.GetNames(typeof(ContentFormat)))}")
            };
        }
    }
}
