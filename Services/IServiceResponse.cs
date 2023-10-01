using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.models; 
using backend.Controllers;
using backend.DTOs;

namespace backend.Services
{
    public interface IServiceResponse
    {
        Task<List<UserModel>> GetAllUsers();
        Task<List<UserModel>> AddUserComment(AddComment newUserComment);
    }
}
