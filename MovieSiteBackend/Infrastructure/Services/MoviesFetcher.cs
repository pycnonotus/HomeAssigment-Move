using System.Text.Json;

namespace Infrastructure.Services;

internal static class MoviesFetcher
{
   private const string DataUrl = "https://mocki.io/v1/0831c517-d42c-4481-9cef-5ea097bf65a8";
   
   public static async Task<List<MovieJson>> GetMoviesAsync(HttpClient client)
   {
      var httpResponse = client.GetAsync(DataUrl);
      var content = (await httpResponse.Result.Content.ReadAsStringAsync()).ToString();
      var options = new JsonSerializerOptions
      {
         PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      };
      var movies = JsonSerializer.Deserialize<IEnumerable<MovieJson>>(content, options);
      return movies!.Where(x=> x.TitleType?.ToLower() == "movie").ToList();
   }
}


