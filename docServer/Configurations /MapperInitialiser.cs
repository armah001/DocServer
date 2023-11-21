using System;
using AutoMapper;
using docServer.Models;
using docServer.Data;
using docServer.DTOs;

namespace docServer.Configurations
{
	public class MapperInitialiser : Profile
    {
		public MapperInitialiser()
		{
            //CreateMap<Document, DocumentDTO>().ReverseMap();

            //CreateMap<Document, CreateDocumentDTO>().ReverseMap();

            //CreateMap<Document, UpdateDocumentDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

            //CreateMap<ApiUser, LoginUserDTO>().ReverseMap();
        }
    }
}

