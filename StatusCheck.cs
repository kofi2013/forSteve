using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_Application
{
    /// <summary>
    /// Concrete Strategy
    /// </summary>
    public class StatusCheck : ValidationIStrategy
    {
        private const int recordAgeIndex = 2;
        private double years;
        private const double ageLimit = 18;
        private const int recordEffectiveDateIndex = 4;

        public bool ValidateRecord(string[] fields)
        {
            bool myStatusCheck = false;
            bool checkAgeRequirement = AgeRequirementCheck(fields);
            bool checkPlaneffectiveDate = PlanEffectiveDateCheck(fields);

            if (!(checkAgeRequirement && checkPlaneffectiveDate) == true)
            {

                return myStatusCheck;
            }
            else
                return myStatusCheck = true;
        }

        /// <summary>
        /// Age validation check
        /// </summary>
        /// <param name="fields"></param>
        /// <returns>Boolean true if an individual is at least 18 years of age to enroll</returns>
        public bool AgeRequirementCheck(string[] fields)
        {
            bool AgeRequirementValid = false;

            string str = fields[recordAgeIndex];
            string dateOfBirthYr = str.Substring((str.Length - 4), 4);
            string dateOfBirthDay = str.Substring((str.Length - 6), 2);
            string dateOfBirthMonth = str.Substring((str.Length - 8), 2);

            DateTime date2 = new DateTime(int.Parse(dateOfBirthYr), int.Parse(dateOfBirthMonth), int.Parse(dateOfBirthDay));
            DateTime date1 = DateTime.Now;
            TimeSpan value = date1.Subtract(date2);
            years = (value).TotalDays / 365;

            if (years >= ageLimit)
            {
                AgeRequirementValid = true;
            }
            return AgeRequirementValid;
        }      

        /// <summary>
        /// Plan Effective Date validation check
        /// </summary>
        /// <param name="fields"></param>
        /// <returns>Boolean true if not more than 30 days in the future</returns>
        public bool PlanEffectiveDateCheck(string[] fields)
        {
            bool planEffectiveDayValid = false;

            string str = fields[recordEffectiveDateIndex];
            string effectiveDateYr = str.Substring((str.Length - 4), 4);
            string effectiveDateDay = str.Substring((str.Length - 6), 2);
            string effectiveDateMonth = str.Substring((str.Length - 8), 2);

            DateTime date1 = new DateTime(int.Parse(effectiveDateYr), int.Parse(effectiveDateMonth), int.Parse(effectiveDateDay));
            DateTime date2 = DateTime.Now;
            TimeSpan value = date1.Subtract(date2);

            if ((value).TotalDays < 30)
            {
                planEffectiveDayValid = true;
            }

            return planEffectiveDayValid;
        }
    }



    
}
