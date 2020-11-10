using Microsoft.Extensions.Configuration;

namespace ChallengeDataObjects
{
    public sealed class Configuration
    {
        public string ConnectionString { get; set; }


        public Configuration()
        {
            var config = new ConfigurationBuilder()
                            .AddJsonFile("config.json")
                            .Build();

            ConnectionString = config["connectionString"];
        }
    }
}
