using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAndDeleteTMP
{
    class WriteLogFile
    {
        public static void WriteLog(string fullFilePath, string[] fileArray, string[] logArray)
        {

            for (int i = 0; i < fileArray.Length; i++)
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
                writer.WriteLine(DateTime.Now);
                writer.WriteLine(string.Format("{0, -10} {1, -50}", "[File Name]", "[File Size]"));                

                foreach (var item in logArray)
                {
                    writer.WriteLine(item);
                }
                writer.Close();
            }
        }
    }
}
