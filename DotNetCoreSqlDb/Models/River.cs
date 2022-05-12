using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreSqlDb.Models
{
    public class River
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Square { get; set; }
        public string Ocean { get; set; }
      
        [NotMapped]
        public IFormFile CountryFile { get; set; } 
        public byte[] Country { get; set; }

    }
}
