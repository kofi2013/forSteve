using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Enrollment_Application
{
    /// <summary>
    /// Concrete Strategy
    /// </summary>
    class RecordFieldsValidation : ValidationIStrategy
    {
        private const int fieldLength = 5;

        /// <summary>
        /// Validates the record fields
        /// </summary>
        /// <param name="fields"></param>
        /// <returns>Boolean false if validation fails</returns>
        public bool ValidateRecord(string[] fields)
        {
            bool NotificationStatus = true;


            if(fields.Length < fieldLength)
            {
                Console.WriteLine("less fields - File processing will stop");
                return NotificationStatus = false;
            }

            var firstName = fields[0];
            if (!Regex.IsMatch(firstName, "[a-z]"))
            {
                Console.WriteLine("Invalid first name field - File processing will stop");
                return NotificationStatus = false;
            }

            var lastName = fields[1];
            if (!Regex.IsMatch(lastName, "[a-z]"))
            {
                Console.WriteLine("Invalid last name field - File processing will stop");
                return NotificationStatus = false;
            }


            var dateOfBirth = fields[2];
            if (!Regex.IsMatch(dateOfBirth, @"^(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])(19|20)\d\d$"))
            {
                Console.WriteLine("Invalid last name field - File processing will stop");
                return NotificationStatus = false;
            }


           // string planType = fields[3];
            //if (!String.Equals(planType, "HSA") || !String.Equals(planType, "HRA") || !String.Equals(planType, "FSA"))
            //{
                //Console.WriteLine("Invalid plan type field - File processing will stop");
               // return NotificationStatus = false;
            //}


            var effectiveDate = fields[4];
            if (!Regex.IsMatch(effectiveDate, @"^(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])(19|20)\d\d$"))
            {
                Console.WriteLine("Invalid effective date field - File processing will stop");
                return NotificationStatus = false;
            }
            return NotificationStatus;
        }
    }
    
}
