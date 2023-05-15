using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ShipperService
    {
        public static List<ShipperDTO> Get()
        {
            var data = DataAccessFactory.ShipperData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Shipper, ShipperDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ShipperDTO>>(data);
            return mapped;

        }
        public static ShipperDTO Get(string username)
        {
            var data = DataAccessFactory.ShipperData().Read(username);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Shipper, ShipperDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ShipperDTO>(data);
            return mapped;
        }

        public static ShipperDTO Create(ShipperDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Shipper, ShipperDTO>();
                c.CreateMap<ShipperDTO, Shipper>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Shipper>(obj);
            var data = DataAccessFactory.ShipperData().Create(mapped);
            var mapped2 = mapper.Map<ShipperDTO>(data);
            return mapped2;
        }



        public static ShipperDTO Update(Shipper username)
        {
            var data = DataAccessFactory.ShipperData().Update(username);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Shipper, ShipperDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ShipperDTO>(data);
            return mapped;
        }



        public static bool Delete(string username)
        {
            return DataAccessFactory.ShipperData().Delete(username); ;
        }

    }
}
