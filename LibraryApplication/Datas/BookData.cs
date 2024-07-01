using System.IO;
using System.Text.Json;

namespace LibraryApplication.Datas
{
    public class BookData
    {
        private static string Path = @"C:\Users\azama\OneDrive\Desktop\LibrarySystem\LibraryApplication\Datas\Books.json";

        static JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };

        public static List<Book> Readfromfile()
        {
            using(StreamReader streamReader = new StreamReader(Path))
            {
                var readingjson = streamReader.ReadToEnd();
                var datajson = JsonSerializer.Deserialize<List<Book>>(readingjson , serializerOptions);

                return datajson;
            }
        }

        public static void Writetofile(List<Book> books)
        {
            using(StreamWriter streamWriter = new StreamWriter(Path))
            {
                var writejson = JsonSerializer.Serialize(books , serializerOptions);
                streamWriter.Write(writejson);
            }
        }
    }
}
