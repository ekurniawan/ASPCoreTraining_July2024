namespace ASPCoreTraining.Web.Services
{
    public class Greeting : IGreeter
    {
        private readonly IConfiguration _config;

        public Greeting(IConfiguration config)
        {
            _config = config;
        }

        public string GetMessageOfTheDay()
        {
            return _config["Greeting"].ToString();
        }
    }
}
