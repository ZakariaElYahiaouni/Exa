using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.models
{
    public class UserModel 
    {
        public int Id {get; set;}
        public string Name{get; set;} = "Name"; 
        public string LastName{get; set;} = "LastName";
        public string SchoolName{get; set;} = "SchoolName";
        public string UserComment{get; set;} = "Comment";
    }
}