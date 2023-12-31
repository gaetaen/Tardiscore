﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TardiscoreAPI.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TardiscoreAPI.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email aleready used.
        /// </summary>
        internal static string ErrorMessage__EmailExist {
            get {
                return ResourceManager.GetString("ErrorMessage::EmailExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid credentials.
        /// </summary>
        internal static string ErrorMessage__InvalidCredentials {
            get {
                return ResourceManager.GetString("ErrorMessage::InvalidCredentials", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Email.
        /// </summary>
        internal static string ErrorMessage__InvalidEmail {
            get {
                return ResourceManager.GetString("ErrorMessage::InvalidEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Key not found.
        /// </summary>
        internal static string ErrorMessage__KeyNotFound {
            get {
                return ResourceManager.GetString("ErrorMessage::KeyNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password must contain at least one digit.
        /// </summary>
        internal static string ErrorMessage__PasswordRequiresDigit {
            get {
                return ResourceManager.GetString("ErrorMessage::PasswordRequiresDigit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password must contain at least one lower case letter.
        /// </summary>
        internal static string ErrorMessage__PasswordRequiresLower {
            get {
                return ResourceManager.GetString("ErrorMessage::PasswordRequiresLower", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password must contain at least one capital letter.
        /// </summary>
        internal static string ErrorMessage__PasswordRequiresUpper {
            get {
                return ResourceManager.GetString("ErrorMessage::PasswordRequiresUpper", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The password must contain at least 6 characters.
        /// </summary>
        internal static string ErrorMessage__PasswordTooShort {
            get {
                return ResourceManager.GetString("ErrorMessage::PasswordTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Already existing username.
        /// </summary>
        internal static string ErrorMessage__UserNameExist {
            get {
                return ResourceManager.GetString("ErrorMessage::UserNameExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to success.
        /// </summary>
        internal static string SuccessMessage__Default {
            get {
                return ResourceManager.GetString("SuccessMessage::Default", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Successful registration.
        /// </summary>
        internal static string SuccessMessage__RegisterSucceeded {
            get {
                return ResourceManager.GetString("SuccessMessage::RegisterSucceeded", resourceCulture);
            }
        }
    }
}
