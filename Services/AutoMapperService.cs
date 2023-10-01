using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DTOs;
using backend.models;
namespace backend.Services
{
    public class AutoMapperService:Profile
    {
        public AutoMapperService(){
            CreateMap<UserModel, AddComment>(); 
        }
    }
}