 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrollment_Application
{
   /// <summary>
   /// This class retrieves data from a file location.
   /// </summary>
   public sealed class FileReaderSingleton
    {
       /// <summary>
       /// Private Singleton constructor 
       /// </summary>
       private FileReaderSingleton()
        {
        }

        private static readonly Lazy<FileReaderSingleton> instance = new Lazy<FileReaderSingleton>(() => new FileReaderSingleton());

        public static FileReaderSingleton GetInstance
        {
            get
            {
                return instance.Value;
            }
        }


        /// <summary>
        /// Reads the records from a file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Array of records</returns>
        public string[] ReadRecord(String filePath)
        {
            string[] recordLines = null;
            try
            {
                recordLines = System.IO.File.ReadAllLines(filePath);   
                
            }
            catch (IOException)
            {
                Console.WriteLine("File doesnt exist in : " + filePath);
            }

            return recordLines;
        }
    }
}
