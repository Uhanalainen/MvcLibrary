using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MvcLibrary.Helpers;

namespace MvcLibrary.Models
{
    public class Category : BaseModel, IDataErrorInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }

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
            "Name"
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

                default:
                    Debug.Fail("Failed. The Category Model doesn't have property: " + propertyName);
                    break;
            }
            return error;
        }

        #endregion
    }
}