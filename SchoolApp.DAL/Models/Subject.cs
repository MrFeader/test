using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.DAL.Models
{
    public class Subject
    {
        public Subject()
        {

        }
        public Subject(string subj)
        {
            Name = subj;
        }
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}

