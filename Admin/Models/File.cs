using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Models
{
    public enum FileType
    {
        Avatar = 1, Photo
    }
    public class File
    {
        public Guid FileId { get; set; }
        [StringLength(250, ErrorMessage = "File Name cannot be longer than 250 characters.")]
        public string FileName { get; set; }
        [StringLength(250, ErrorMessage = "Content Type cannot be longer than 250 characters.")]
        public string ContentType { get; set; }
        public byte[] ContentData { get; set; }
        public FileType FileType { get; set; }
    }
}