using Microsoft.AspNetCore.Http;

namespace Utilities.Helper
{
    public class FileUploader
    {

        // make it generic to apply all types of files
        public static string FileUpload(IFormFile file)
        {
            try
            {
                //1: catch folder path on server to save on 
                string FilesFolderPath = Directory.GetCurrentDirectory() + @"\wwwroot\images";
                // 2- cath the file name to send it to database
                string fileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
                // 3- concat 1,2 ("the finally phiscal Path )
                string FileFinalPath = Path.Combine(FilesFolderPath, fileName);
                // 4- save file 
                using (var stream = new FileStream(FileFinalPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                // return the file name to send it to the database 
                return fileName;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string RemoveFiles(string fileName)
        {
            try
            {
                var fileDirectory = Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot\images", fileName);
                if(File.Exists(fileDirectory)) {
                    File.Delete(fileDirectory);
                    return "file deleted";
                }
                return "file deleted";

            }catch (Exception ex) {
                return ex.Message;
                    }
        }
    }
}
