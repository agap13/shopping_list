using Plugin.Settings.Abstractions;

namespace Shopping.Core.Services
{
    public class AppSettings : IAppSettings
    {
        public const string SuperNumberKey = "SuperNumberKey";

        public const int SuperNumberDefaultValue = 1;

        private readonly ISettings _settings;

        public AppSettings(ISettings settings)
        {
            _settings = settings;
        }
    }
}
