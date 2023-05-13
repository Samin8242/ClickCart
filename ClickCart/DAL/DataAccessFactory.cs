using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }

        public static IRepo<Review, int, Review> ReviewData()
        {
            return new ReviewRepo();
        }
        public static IRepo<Order, int, Order> OrderData()
        {
            return new OrderRepo();
        }

        public static IRepo<WishList, int, WishList> WishListData()
        {
            return new WishListRepo();
        }

        public static IRepo<Product, int, Product> ProductData()
        {
            return new ProductRepo();
        }

        public static IRepo<OrderDetail, int, OrderDetail> OrderDetailData()
        {
            return new OrderDetailRepo();
        }

        public static IRepo<Category, int,Category> CategoryData()
        {
            return new CategoryRepo();
        }

        public static IRepo<Cart, int, Cart> CartData()
        {
            return new CartRepo();
        }

        public static IRepo<CartItem, int, CartItem> CartItemData()
        {
            return new CartItemRepo();
        }

        public static IRepo<Discount, int, Discount> DiscountData()
        {
            return new DiscountRepo();
        }
        public static IRepo<PaymentDetail, int, PaymentDetail> PaymentDetailData()
        {
            return new PaymentDetailRepo();
        }

        public static IRepo<Supplier, string, Supplier> SupplierData()
        {
            return new SupplierRepo();
        }

        public static IRepo<Shipper, string, Shipper> ShipperData()
        {
            return new ShipperRepo();
        }

        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }

        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
    }
}
