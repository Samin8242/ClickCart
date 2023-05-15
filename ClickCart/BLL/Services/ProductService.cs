using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL.Services
{
    public class ProductService
    {
        

        public static List<ProductDTO> GetProduct()
        {
            var data = DataAccessFactory.ProductData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ProductDTO>>(data);
            return mapped;
        }

        public static ProductDTO GetProduct(int id)
        {
            var data = DataAccessFactory.ProductData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductDTO>(data);
            return mapped;
        }

        public static ProductDTO Create(ProductDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
                c.CreateMap<ProductDTO, Product>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Product>(obj);
            var data = DataAccessFactory.ProductData().Create(mapped);
            var mapped2 = mapper.Map<ProductDTO>(data);
            return mapped2;
        }
        public static ProductDTO Update(Product product)
        {
            var data = DataAccessFactory.ProductData().Update(product);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductDTO>(data);
            return mapped;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.ProductData().Delete(id); ;
        }

        public static ProductReviewDTO GetwithReviews(int id)
        {
            var data = DataAccessFactory.ProductData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Product, ProductReviewDTO>();
                c.CreateMap<Review, ReviewDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductReviewDTO>(data);
            return mapped;

        }

        public static ProductWishDTO GetwithWishLists(int id)
        {
            var data = DataAccessFactory.ProductData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Product, ProductWishDTO>();
                c.CreateMap<WishList, WishListDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductWishDTO>(data);
            return mapped;

        }

        public static ProductOrderDetailDTO GetwithProductOrderDetails(int id)
        {
            var data = DataAccessFactory.ProductData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Product, ProductOrderDetailDTO>();
                c.CreateMap<OrderDetail, OrderDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductOrderDetailDTO>(data);
            return mapped;

        }
    }
}
