using Huffy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GigBug.ViewModels;
using System.Linq.Expressions;
using Huffy.Controllers;
using System.Web.Mvc;

namespace Huffy.ViewModels
{
    public class StabFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public string Heading { get; set; }
        
        public DateTime GetDateTime()
        {
                return DateTime.Parse(string.Format("{0}, {1}", Date, Time));
        }
    }
}