using System;
using System.ComponentModel.DataAnnotations;


namespace DotNetCoreSqlDb.Models
{
    public class River
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Square { get; set; }
        public string Ocean { get; set; }

    }
}
