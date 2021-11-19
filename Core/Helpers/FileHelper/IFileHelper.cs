using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers.FileHelper
{
    public interface IFileHelper
    {
        IResult Upload(IFormFile file);
    }
}
