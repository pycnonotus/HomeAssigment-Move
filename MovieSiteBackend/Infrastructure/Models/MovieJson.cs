// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Image
    {
        public int Height { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }

    public class Role
    {
        public string Character { get; set; }
        public string CharacterId { get; set; }
    }

    public class Principal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<string> Characters { get; set; }
        public List<Role> Roles { get; set; }
        public List<string> Attr { get; set; }
        public int? EndYear { get; set; }
        public int? EpisodeCount { get; set; }
        public int? StartYear { get; set; }
        public string Disambiguation { get; set; }
    }

    public class Cast
    {
        public string Category { get; set; }
        public List<string> Characters { get; set; }
        public List<Role> Roles { get; set; }
        public int? EndYear { get; set; }
        public int? EpisodeCount { get; set; }
        public int? StartYear { get; set; }
    }

    public class Summary
    {
        public string Category { get; set; }
        public List<string> Characters { get; set; }
        public string DisplayYear { get; set; }
    }

    public class Crew
    {
        public string Category { get; set; }
        public int EndYear { get; set; }
        public int EpisodeCount { get; set; }
        public int StartYear { get; set; }
        public string Job { get; set; }
    }

    public class KnownFor
    {
        public List<Cast> Cast { get; set; }
        public Summary Summary { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string TitleType { get; set; }
        public int Year { get; set; }
        public List<Crew> Crew { get; set; }
    }

    public class MovieJson
    {
        public string Id { get; set; }
        public Image Image { get; set; }
        public int RunningTimeInMinutes { get; set; }
        public string Title { get; set; }
        public string TitleType { get; set; }
        public int Year { get; set; }
        public List<Principal> Principals { get; set; }
        public string Name { get; set; }
        public List<KnownFor> KnownFor { get; set; }
        public string NextEpisode { get; set; }
        public int? NumberOfEpisodes { get; set; }
        public int? SeriesStartYear { get; set; }
        public int? SeriesEndYear { get; set; }
    }

