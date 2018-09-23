using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Api.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Entities.Book, Mappings.Book>().
            ForMember(dest => dest.Author, opt => opt.MapFrom(src =>
            $"{src.Author.FirstName} {src.Author.LastName}"));

            CreateMap<Mappings.BookForCreation, Entities.Book>();
        }

    }
}
