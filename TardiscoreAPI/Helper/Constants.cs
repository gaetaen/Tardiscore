namespace TardiscoreAPI.Helper
{
    public static class Constants
    {
        public static class ErrorMessage
        {
            public const string UserNameExist = "ErrorMessage::UserNameExist";
            public const string EmailExist = "ErrorMessage::EmailExist";
            public const string KeyNotFound = "ErrorMessage::KeyNotFound";
            public const string InvalidCredentials = "ErrorMessage::InvalidCredentials";
            public const string PasswordRequiresDigit = "ErrorMessage::PasswordRequiresDigit";
            public const string PasswordRequiresUpper = "ErrorMessage::PasswordRequiresUpper";
            public const string PasswordRequiresLower = "ErrorMessage::PasswordRequiresLower";
            public const string PasswordTooShort = "ErrorMessage::PasswordTooShort";
        }

        public static class SuccessMessage
        {
            public const string RegisterSucceeded = "SuccessMessage::Succeeded ";
        }
    }
}