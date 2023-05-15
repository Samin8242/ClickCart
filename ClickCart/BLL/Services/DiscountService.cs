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
    public class DiscountService
    {
        public static List<DiscountDTO> GetDiscount()
        {
            var data = DataAccessFactory.DiscountData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Discount, DiscountDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<DiscountDTO>>(data);
            return mapped;
        }

        public static DiscountDTO GetDiscount(int id)
        {
            var data = DataAccessFactory.DiscountData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Discount, DiscountDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DiscountDTO>(data);
            return mapped;
        }

        public static DiscountDTO Create(DiscountDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Discount, DiscountDTO>();
                c.CreateMap<DiscountDTO, Discount>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Discount>(obj);
            var data = DataAccessFactory.DiscountData().Create(mapped);
            var mapped2 = mapper.Map<DiscountDTO>(data);
            return mapped2;
        }
        public static DiscountDTO Update(Discount discount)
        {
            var data = DataAccessFactory.DiscountData().Update(discount);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Discount, DiscountDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DiscountDTO>(data);
            return mapped;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.DiscountData().Delete(id); ;
        }
    }
}
