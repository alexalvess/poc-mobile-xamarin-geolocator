using Plugin.Settings.Abstractions;
using Plugin.Settings;

namespace Treinus.App.Helpers
{
    public static class UserSettings
    {
        private static ISettings AppSettings
        {
            get => CrossSettings.Current;
        }

        #region Constants
        private const string NameKey = "name_key";
        private static readonly string NameDefault = string.Empty;

        private const string EmailKey = "email_key";
        private static readonly string EmailDefault = string.Empty;
        #endregion

        public static string Name
        {
            get => AppSettings.GetValueOrDefault(NameKey, NameDefault);
            set => AppSettings.AddOrUpdateValue(NameKey, value);
        }

        public static string Email
        {
            get => AppSettings.GetValueOrDefault(EmailKey, EmailDefault);
            set => AppSettings.AddOrUpdateValue(EmailKey, value);
        }
    }
}
