using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class AddComment
    {
        
        public string Name{get; set;} = "Name"; 
        public string LastName{get; set;} = "LastName";
        public string SchoolName{get; set;} = "SchoolName";
        public string UserComment{get; set;} = "Comment";
    }
}