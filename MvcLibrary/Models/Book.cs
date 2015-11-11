using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MvcLibrary.Helpers;

namespace MvcLibrary.Models
{
    public class Book : BaseModel, IDataErrorInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }

        public int PublicationYear { get; set; }
        public bool OnLoan { get; set; }
        public string Loaner { get; set; }

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error { get { return null; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get { return GetValidationError(propertyName); }
        }

        #endregion // IDataErrorInfo Members

        #region Validation

        /// <summary>
        /// Checks if the Model is valid or not
        /// </summary>
        public bool IsValid
        {
            get
            { return ValidateProperties.All(property => GetValidationError(property) == null); }
        }

        /// <summary>
        /// Array of properties to validate
        /// </summary>
        static readonly string[] ValidateProperties =
        {
            "Name",
            "OriginalName",
            "PublicationYear",
            "Loaner"
        };

        public string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidateProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "Name":
                    if (!ModelValidator.ValidateString(Name))
                        error = "Name not Valid";
                    break;

                case "OriginalName":
                    if (!ModelValidator.ValidateString(OriginalName))
                        error = "Original name not valid";
                    break;

                case "PublicationYear":
                    if (!ModelValidator.ValidateYear(PublicationYear.ToString()))
                        error = "Publication year not valid";
                    break;

                case "Loaner":
                    if (!ModelValidator.ValidateString(Loaner))
                        error = "Loaner not valid";
                    break;

                default:
                    Debug.Fail("Failed. The Book Model doesn't have property: " + propertyName);
                    break;
            }
            return error;
        }

        #endregion
    }
}