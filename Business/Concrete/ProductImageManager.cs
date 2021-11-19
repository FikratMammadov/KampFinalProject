using Business.Abstract;
using Core.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        private IProductImageDal _productImageDal;
        private IFileHelper _fileHelper;

        public ProductImageManager(IProductImageDal productImageDal, IFileHelper fileHelper)
        {
            _productImageDal = productImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Upload(ProductImageDto productImageDto,IFormFile file)
        {
            var result = _fileHelper.Upload(file);
            if (!result.Success)
            {
                return new ErrorResult("Invalid file extension");
            }
            var productImage = new ProductImage
            {
                ImagePath = file.FileName,
                ProductId = productImageDto.ProductId,
                Date = DateTime.Now
            };
            _productImageDal.Add(productImage);
            return new SuccessResult();
        }
        //public IResult Upload(ProductImageDto productImageDto, IFormFile file)
        //{
        //    if (CheckIfImageFile(file))
        //    {
        //        WriteFile(file);
        //        var productImage = new ProductImage
        //        {
        //            ImagePath = file.FileName,
        //            ProductId = productImageDto.ProductId,
        //            Date = DateTime.Now
        //        };
        //        _productImageDal.Add(productImage);
        //        return new SuccessResult();
        //    }
        //    else
        //    {
        //        return new ErrorResult("Invalid file extension");
        //    }
        //}

        //private bool CheckIfImageFile(IFormFile file)
        //{
        //    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
        //    return (extension == ".png" || extension == ".jpg" || extension == ".jpeg"); // Change the extension based on your need
        //}

        //private bool WriteFile(IFormFile file)
        //{
        //    bool isSaveSuccess = false;
        //    try
        //    {
        //        var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\images");

        //        if (!Directory.Exists(pathBuilt))
        //        {
        //            Directory.CreateDirectory(pathBuilt);
        //        }

        //        var path = Path.Combine(pathBuilt,file.FileName);
        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            file.CopyToAsync(stream);
        //        }

        //        isSaveSuccess = true;
        //    }
        //    catch (Exception e)
        //    {
        //        //log error
        //    }

        //    return isSaveSuccess;
        //}
    }
}
