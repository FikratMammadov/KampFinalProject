using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Helpers.FileHelper
{
    public class FileHelper : IFileHelper
    {
        public IResult Upload(IFormFile file)
        {
            if (!CheckIfImageFile(file))
            {
                return new ErrorResult("Invalid file extension");
            }
            
            WriteFile(file);
            return new SuccessResult();
        }

        private bool CheckIfImageFile(IFormFile file)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            return (extension == ".png" || extension == ".jpg" || extension == ".jpeg"); // Change the extension based on your need
        }

        private bool WriteFile(IFormFile file)
        {
            bool isSaveSuccess = false;
            try
            {
                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\images");

                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                var path = Path.Combine(pathBuilt, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }

                isSaveSuccess = true;
            }
            catch (Exception e)
            {
                //log error
            }

            return isSaveSuccess;
        }
    }
}
