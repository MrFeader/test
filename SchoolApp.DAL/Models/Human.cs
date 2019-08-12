using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.DAL.Models
{
    public abstract class Human
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SecondName { get; set; }

        public string Surname { get; set; }

    }
}
