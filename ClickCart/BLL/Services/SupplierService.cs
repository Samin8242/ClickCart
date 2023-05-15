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
    public class SupplierService
    {
        public static List<SupplierDTO> Get()
        {
            var data = DataAccessFactory.SupplierData().Read();
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Supplier, SupplierDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<SupplierDTO>>(data);
            return mapped;

        }
        public static SupplierDTO Get(string username)
        {
            var data = DataAccessFactory.SupplierData().Read(username);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Supplier, SupplierDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SupplierDTO>(data);
            return mapped;
        }

        public static SupplierDTO Create(SupplierDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Supplier, SupplierDTO>();
                c.CreateMap<SupplierDTO, Supplier>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Supplier>(obj);
            var data = DataAccessFactory.SupplierData().Create(mapped);
            var mapped2 = mapper.Map<SupplierDTO>(data);
            return mapped2;
        }



        public static SupplierDTO Update(Supplier username)
        {
            var data = DataAccessFactory.SupplierData().Update(username);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Supplier, SupplierDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<SupplierDTO>(data);
            return mapped;
        }



        public static bool Delete(string username)
        {
            return DataAccessFactory.SupplierData().Delete(username); ;
        }
    }
}
