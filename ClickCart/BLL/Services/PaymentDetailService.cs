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
    public class PaymentDetailService
    {
        public static List<PaymentDetailDTO> GetPaymentDetail()
        {
            var data = DataAccessFactory.PaymentDetailData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentDetail, PaymentDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PaymentDetailDTO>>(data);
            return mapped;
        }

        public static PaymentDetailDTO GetPaymentDetail(int id)
        {
            var data = DataAccessFactory.PaymentDetailData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentDetail, PaymentDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PaymentDetailDTO>(data);
            return mapped;
        }

        public static PaymentDetailDTO Create(PaymentDetailDTO obj)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentDetail, PaymentDetailDTO>();
                c.CreateMap<PaymentDetailDTO, PaymentDetail>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PaymentDetail>(obj);
            var data = DataAccessFactory.PaymentDetailData().Create(mapped);
            var mapped2 = mapper.Map<PaymentDetailDTO>(data);
            return mapped2;
        }
        public static PaymentDetailDTO Update(PaymentDetail paymentdetail)
        {
            var data = DataAccessFactory.PaymentDetailData().Update(paymentdetail);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PaymentDetail, PaymentDetailDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PaymentDetailDTO>(data);
            return mapped;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.PaymentDetailData().Delete(id); ;
        }
    }
}
