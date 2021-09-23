using System;
using AutoMapper;
using BooksWebApi.DTOs;
using BooksWebApi.Models;

namespace BooksWebApi.Mappers
{
    //Maps Book to BookDto
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<BookDto, Book>().ReverseMap();
        }
    }
}
