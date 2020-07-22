using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_Application
{
    class EnrollmentApp
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\workspace\\VisualStudio\\EnrollmentApplication.txt";

            string[] recordFields = null;
            string status = null;

            FileReaderSingleton fileReaderSingleton = FileReaderSingleton.GetInstance;          

            ContextStrategy contextStrategy = new ContextStrategy();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            //Get the records in the file from from the Singleton file reader
            string[] fileRecords = fileReaderSingleton.ReadRecord(filePath);
           
            //Iterate the fields in each record and put them in arrays
            try
            {           

                for (int i = 0; i < fileRecords.Length; i++)
                {
                    //put the fields in arrays
                    recordFields = fileRecords[i].Split(',');

                    // validate record files. Processing should stop when invalid fields are encountered.
                    contextStrategy.SetStrategy(new RecordFieldsValidation());
                    if(contextStrategy.ExecuteStrategy(recordFields) == false)
                    {
                        Console.WriteLine("A record in the file failed validation. Processing has stopped.");
                        return;
                    }

                    contextStrategy.SetStrategy(new StatusCheck());
                    bool statusCheck = contextStrategy.ExecuteStrategy(recordFields);
                    {
                        
                        if (statusCheck == true)
                            status = "Accepted";
                        else
                            status = "Rejected";
                    }
                 
                    string iRecord = recordFields[0] + ", " + recordFields[1] + ", " + recordFields[2] + ", " + recordFields[3] + ", " + recordFields[4];

                    //Add the record and the record status in a Dictionary.
                    dictionary.Add(iRecord, status);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception thrown : " + ex);
            }

            //print each record and status to the console
            foreach (KeyValuePair<string, string> kvp in dictionary)
            {
                Console.WriteLine(kvp.Value + ", " + kvp.Key);
            }

        }
    }
}
