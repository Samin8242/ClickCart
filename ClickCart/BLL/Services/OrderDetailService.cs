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
    public class OrderDetailService
    {
        public static List<OrderDetailDTO> GetOrderDetail()
        {
            var data = DataAccessFactory.OrderDetailData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<OrderDetailDTO>>(data);
            return mapped;
        }

        public static OrderDetailDTO GetOrderDetail(int id)
        {
            var data = DataAccessFactory.OrderDetailData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDetailDTO>(data);
            return mapped;
        }

        public static OrderDetailDTO Create(OrderDetailDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDetail, OrderDetailDTO>();
                c.CreateMap<OrderDetailDTO, OrderDetail>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDetail>(obj);
            var data = DataAccessFactory.OrderDetailData().Create(mapped);
            var mapped2 = mapper.Map<OrderDetailDTO>(data);
            return mapped2;
        }
        public static OrderDetailDTO Update(OrderDetail orderdetail)
        {
            var data = DataAccessFactory.OrderDetailData().Update(orderdetail);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<OrderDetailDTO>(data);
            return mapped;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.OrderDetailData().Delete(id); ;
        }
    }
}
