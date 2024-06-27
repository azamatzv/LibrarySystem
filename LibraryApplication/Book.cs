using System.Text.Json.Serialization;

namespace LibraryApplication
{
    public class Book
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("publication_year")]
        public object PublicationYear { get; set; }
        [JsonPropertyName("genre")]
        public List<string> Genre { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("cover_image")]
        public string CoverImage { get; set; }
    }
}
