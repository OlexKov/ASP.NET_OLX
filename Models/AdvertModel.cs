using ASP.NET_OLX.Models.Data.Entities;
using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_OLX.Models
{
    public class AdvertModel
    {
        public int Id { get; set; }

        public string? SellerName { get; set; } 

        public string City { get; set; }

        public string Category { get; set; } 

        public string? Title { get; set; }
        
        public string? Description { get; set; } 

        public bool IsNew { get; set; } 

        public decimal Price { get; set; } 

        public List<string> ImagesUrls { get; set; } = [];

        public List<IFormFile> Images { get; set; } = [];
    }
}
