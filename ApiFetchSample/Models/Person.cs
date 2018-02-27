using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFetchSample.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid Id { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
        }
    }
}