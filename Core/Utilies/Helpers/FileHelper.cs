using Core.Utilies.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilies.Helpers
{
    public class FileHelper
    {
        
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            string directory = Environment.CurrentDirectory + @"\wwwroot\Images\";
            var name =newPath(file);
            var result = directory + name;
            File.Move(sourcepath, result);
            
            return  name;
        }
        public static IResult Delete(string path)
        {
            string directory = Environment.CurrentDirectory + @"\wwwroot\Images\";
            path = path.Replace("/", "\\");
            var file = directory + path;
            try
            {
                File.Delete(file);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var name = newPath(file);
            string directory = Environment.CurrentDirectory + @"\wwwroot\Images\";


            sourcePath = sourcePath.Replace("/", "\\");
            var filetoDelete = directory + sourcePath;

            var result = directory+name;
            if (file.Length>0)
            {
                using (var steam = new FileStream(result,FileMode.Create))
                {
                    file.CopyTo(steam);
                }
            }
            File.Delete(filetoDelete);
            return name;
        }

        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            //string path = Environment.CurrentDirectory + @"\wwwroot\Images";
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{newPath}";
            string result2 = result.Replace("\\", "/");
            return result2;
        }

    }

}
