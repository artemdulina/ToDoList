using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.DataTransferObject;
using ORM;

namespace DAL.Configurations
{
    public static class MapperDomainConfiguration
    {
        public static IMapper MapperInstance { get; private set; }

        static MapperDomainConfiguration()
        {
            Configure();
        }

        public static void Configure()
        {
            MapperInstance = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, DalAuthor>().ReverseMap();
                cfg.CreateMap<ORM.Task, DalTask>().ReverseMap();
                cfg.CreateMap<ToDoForm, DalToDoForm>().ReverseMap();
            }).CreateMapper();
        }
    }
}
