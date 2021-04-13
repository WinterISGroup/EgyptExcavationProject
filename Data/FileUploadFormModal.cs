using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//Modal to work with photo uploading to S3
namespace EgyptExcavationProject.Data
{
    public class FileUploadFormModal
    {
        [Required]
        [Display(Name ="File")]
        public IFormFile FormFile { get; set; }

        public Guid BurialID { get; set; }
    }
}
