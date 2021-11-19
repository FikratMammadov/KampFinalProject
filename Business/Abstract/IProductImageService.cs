using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IResult Upload(ProductImageDto productImageDto, IFormFile file);
    }
}
