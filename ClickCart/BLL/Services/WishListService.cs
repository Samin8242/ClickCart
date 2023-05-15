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
    public class WishListService
    {
        public static List<WishListDTO> GetWishList()
        {
            var data = DataAccessFactory.WishListData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<WishList, WishListDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<WishListDTO>>(data);
            return mapped;
        }

        public static WishListDTO GetWishList(int id)
        {
            var data = DataAccessFactory.WishListData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<WishList, WishListDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<WishListDTO>(data);
            return mapped;
        }

        public static WishListDTO Create(WishListDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<WishList, WishListDTO>();
                c.CreateMap<WishListDTO, WishList>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<WishList>(obj);
            var data = DataAccessFactory.WishListData().Create(mapped);
            var mapped2 = mapper.Map<WishListDTO>(data);
            return mapped2;
        }
        public static WishListDTO Update(WishList wishList)
        {
            var data = DataAccessFactory.WishListData().Update(wishList);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<WishList, WishListDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<WishListDTO>(data);
            return mapped;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.WishListData().Delete(id); ;
        }
    }
}
