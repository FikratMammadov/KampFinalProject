using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductImageDto:IDto
    {
        public int ProductId { get; set; }
        public IFormFile file  { get; set; }
    }
}
