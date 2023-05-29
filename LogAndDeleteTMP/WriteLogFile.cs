using System;
using System.IO;
using System.Linq;

namespace LogAndDeleteTMP
{
    class WriteLogFile
    {

        public static void WriteLog(string path)
        {
            string[] fileArray = Directory.GetFiles(path);
            string[] logArray = new string[fileArray.Length];
            string[] largeFileArray = new string[fileArray.Length];

            var count = 0;
            int idx = 0;

            for (int i = 0; i < fileArray.Length; i++)
            {
                var shortFile = Path.GetFileName(fileArray[i]);
                var fileSize = GetSize.GetFileSizeOnDisk(fileArray[i]);
                var shortFileSize = GetSize.ShortFileSize(fileSize);
                var extension = Path.GetExtension(fileArray[i]);

               

                if (fileSize > 1024 * 1024 * 3.5)
                {
                    // Should log all file names and add to array, then append the large files to the end of the list
                    largeFileArray[idx] = $"{shortFile}";
                    idx++;

                    logArray[i] = $"[LARGE FILE]\t {shortFileSize}\t {shortFile}";
                }
                else
                    logArray[i] = $"[   OK   ]\t {shortFileSize} \t {shortFile}";

                if (extension == ".tmp")
                {
                    logArray[i] = $"[DELETED]\t {shortFileSize} \t {shortFile}";
                    File.Delete(Path.Combine(path, shortFile));
                    count++;
                }
            }

            using (StreamWriter writer = new StreamWriter(Path.Combine(path, "log.txt"), true)) 
            {
                writer.WriteLine(DateTime.Now);
                writer.WriteLine(string.Format("{0}\t {1}\t {2}\t", "[Status]", "[File Size]", "[File Name]"));

                foreach (var item in logArray)
                {
                    writer.WriteLine(item);
                }
                writer.WriteLine("{0} cache files deleted", count);
                writer.WriteLine("\n");


                var slicedLargeFileArray = (largeFileArray.Take(idx));

                writer.WriteLine($"Files in path {path} that are over the size limit");

                foreach (var item in slicedLargeFileArray)
                {
                    writer.WriteLine(item);
                }

                writer.WriteLine("\n\n");
                writer.Close();
            }   
        }
    }
}
