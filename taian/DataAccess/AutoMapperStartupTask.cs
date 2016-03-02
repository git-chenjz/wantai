using AutoMapper;
using MyFrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Domain;

namespace DataAccess
{
    public class AutoMapperStartupTask : IStartupTask
    {
        public void Execute()
        {
            Create();
        }

        protected virtual void Create()
        {
            //Mapper.CreateMap<Users, UsersDto>();
            //Mapper.CreateMap<UsersDto, Users>();

            Mapper.CreateMap<AdminInfo, AdminDto>()
                .ForMember(dto => dto.Password, mc => mc.Ignore());

            Mapper.CreateMap<AdminDto, AdminInfo>();
        }
    }
}
