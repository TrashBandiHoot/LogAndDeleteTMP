using System;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;


namespace LogAndDeleteTMP
{
    class Program
    {
        
        public static void Main()
        {
            var path = @"C:\Users\Dominic\Desktop\Text";
            var fullFilePath = path + @"\log.txt";

            string[] fileArray = Directory.GetFiles(path);
            string[] logArray = new string[fileArray.Length];
            
            
            /*for (int i = 0; i < fileArray.Length; i++)
            {
                var shortFile = Path.GetFileName(fileArray[i]);
                var fileSize = GetSize.GetFileSizeOnDisk(fileArray[i]);
                var extension = Path.GetExtension(fileArray[i]);

                if (fileSize > 1024 * 1024 * 3.5)
                {
                    logArray[i] = ($"File {shortFile} is {fileSize} bytes !!LARGE FILE!!");
                }
                else
                    logArray[i] = ($"File {shortFile} is {fileSize} bytes");

                if (extension == ".tmp")
                {
                    logArray[i] = ($"File {shortFile} was DELETED");
                }
                
                // Likely don't need any information on the .tmp files, should use a counter and display number of deleted .tmp files.

                Console.WriteLine($"File is {shortFile}, file size is {fileSize} in bytes");
            }

            using (StreamWriter writer = new StreamWriter(fullFilePath)) 
            {
                foreach (var item in logArray)
                {
                    writer.WriteLine(item);
                }
            }*/
            
            WriteLogFile.WriteLog(fullFilePath, fileArray, logArray);
        }
    }
}
