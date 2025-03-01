using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AcunMedya.Restaurantly.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }

        [NotMapped] //veritabanına kadetmiyor
        public HttpPostedFileBase ImageFile { get; set; }

        [NotMapped] //veritabanına kadetmiyor
        public string CurrentPassword { get; set; }

        [NotMapped] //veritabanına kadetmiyor
        public string NewPassword { get; set; }

        [NotMapped] //veritabanına kadetmiyor
        public string ConfirmPassword { get; set; }

    }
}