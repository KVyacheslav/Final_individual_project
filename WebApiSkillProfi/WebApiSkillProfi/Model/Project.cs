﻿using System.ComponentModel.DataAnnotations;

namespace WebApiSkillProfi.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }


        public static Project CreateNullProject()
        {
            return new Project
            {
                Id = -1,
                Title = "Null",
                Description = "Null",
                ImageUrl = "Null"
            };
        }
    }
}
