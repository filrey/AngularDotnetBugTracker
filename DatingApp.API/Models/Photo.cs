using System;

namespace DatingApp.API.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public int Url { get; set; }


        public int Description { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }



    }
}