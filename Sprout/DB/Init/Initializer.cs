using Sprout.Domain.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.DB.Init
{
    public class Initializer
    {
        private readonly SproutContext _context;
        public Initializer(SproutContext context)
        {
            _context = context;
        }


        public void Init()
        {
            // Поменять AddRange на AddRangeAsync
            // _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            if (!_context.Brands.Any())
            {
                _context.AddRange(Brands);
                _context.SaveChanges();

            }

            if(!_context.Vitamins.Any())
            {
                _context.AddRange(Vitamins);
                _context.SaveChanges();
            }

            if (!_context.Countries.Any())
            {
                _context.AddRange(Countries);
                _context.SaveChanges();
            }

            if(!_context.Categories.Any())
            {
                _context.AddRange(Categories);
                _context.SaveChanges();
            }

            if (!_context.Products.Any())
            {
                _context.AddRange(Products);
                _context.SaveChanges();
            }
            if (!_context.Users.Any())
            {
                _context.AddRange(Users);
                _context.SaveChanges();
            }


            if (!_context.CartItems.Any())
            {
                _context.CartItems.AddRange(CartItems);
                _context.SaveChanges();
            }

            if (!_context.Carts.Any())
            {
                _context.Carts.AddRange(Carts);
                _context.SaveChanges();
            }
            //if (!_context.CartItems.Any() && !_context.Carts.Any())
            //{
            //    _context.CartItems.AddRange(CartItems);
            //    _context.Carts.AddRange(Carts);
            //    _context.SaveChanges();
            //}
        }

        private static List<Country> Countries { get; }
            = new List<Country>()
            {
                new Country { Nation = "Bulgaria" }, //0
                new Country { Nation = "Australia" }, //1
                new Country { Nation = "Albania" }, //2
                new Country { Nation = "Qatar" }, //3
                new Country { Nation = "Romania" }, //4
                new Country { Nation = "Chilli" }, //5
                new Country { Nation = "Brazilia" }, //6
                new Country { Nation = "Peru" }, //7
                new Country { Nation = "Morocco" }, //8
                new Country { Nation = "India" }, //9
                new Country { Nation = "Turkish" }, //10
            };

        private static List<Brand> Brands { get; }
            = new List<Brand>()
            {
                new Brand { Title="Artisana"}, //0
                new Brand { Title="Barney"}, // 1
                new Brand { Title="Betty Lou’s"}, // 2
                new Brand { Title="Dastony"}, // 3
                new Brand { Title="Gopal’s"}, // 4
                new Brand { Title="Mighty Sesame"}, // 5
            };

        private static List<Vitamin> Vitamins { get; }
            = new List<Vitamin>
            {
                new Vitamin { Title = "B1"},
                new Vitamin { Title = "B2"},
                new Vitamin { Title = "C"},
                new Vitamin { Title = "A"},
                new Vitamin { Title = "E"}
            };

        private List<User> Users { get; }
            = new List<User>
            {
                new User
                {
                    Name = "a",
                    LastName = "a",
                    Phone = "88005553535",
                    Email = "a@a.com",
                    BirthDate = DateTime.Today,
                    Orders = null,
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("a"),
                    Cart = Carts[0],
                },
                new User
                {
                    Name = "b",
                    LastName = "b",
                    Phone = "88005553535",
                    Email = "b@b.com",
                    BirthDate = DateTime.Today,
                    Orders = null,
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("b"),
                   Cart = Carts[1],
                },
                new User
                {
                    Name = "c",
                    LastName = "c",
                    Phone = "88005553535",
                    Email = "c@c.com",
                    BirthDate = DateTime.Today,
                    Orders = null,
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("c"),
                    Cart = Carts[2],
                },
                new User
                {
                    Name = "d",
                    LastName = "d",
                    Phone = "88005553535",
                    Email = "d@d.com",
                    BirthDate = DateTime.Today,
                    Orders = null,
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("d"),
                     Cart = Carts[3],
                }
            };
        private static List<Category> Categories { get; }
            = new List<Category>
            {
                new Category { Title = "Dried Fruits"},
                new Category { Title = "Bananas"},
                new Category { Title = "Nuts" },
                new Category { Title = "Berries" },
                new Category { Title = "Mango" },
            };

        private static List<Product> Products { get; }
            = new List<Product> {
                new Product()
                {
                    Title = "Blackberry bluestem",
                    Raiting = 4.8F,
                    Price = 2.40M,
                    Img = "BlueBerry.png",
                    Country = Countries[4],
                    Volume = 500,
                    Discount = 0,
                    Delivery = "1-3 days",
                    Categories = new List<Category> { Categories[0], Categories[3] },
                    Composition = "Natural berries",
                    Brand = Brands[0],
                    Vitamins = Vitamins,
                    Descriptions = "" +
                        "Dried apricots are an important source of carotenoids (vitamin A) and potassium. Because of their high fiber-to-volume ratio, they are sometimes used to relieve constipation.\n" +
                        "Fibre in apricots normalizes the gastrointestinal tract, saves from constipation, promotes the removal of toxins and impurities, cleaning the liver.\n" +
                        "Dried apricots normally do not have any sugar added and have a low glycemic index. The maximum moisture rate allowed in Turkey is 25%.",
                    IsInStock = true,
                    Comments = null,
                },
                new Product()
                {
                    Title = "Seedless prune",
                    Raiting = 5.0F,
                    Price = 3.00M,
                    Img = "ChernoslivBezKostochek.png",
                    Country = Countries[5],
                    Volume = 500,
                    Discount = 33,
                    Delivery = "1-3 days",
                    Categories = new List<Category> { Categories[0], Categories[3] },
                    Composition = "Natural prune",
                    Brand = Brands[0],
                    Vitamins = Vitamins,
                    Descriptions = "" +
                        "Dried apricots are an important source of carotenoids (vitamin A) and potassium. Because of their high fiber-to-volume ratio, they are sometimes used to relieve constipation.\n" +
                        "Fibre in apricots normalizes the gastrointestinal tract, saves from constipation, promotes the removal of toxins and impurities, cleaning the liver.\n" +
                        "Dried apricots normally do not have any sugar added and have a low glycemic index. The maximum moisture rate allowed in Turkey is 25%.",
                    IsInStock = true,
                    Comments = null,
                },
                new Product()
                {
                    Title = "Raisins from red grapes Extra series",
                    Raiting = 5.0F,
                    Price = 4.00M,
                    Img = "ChernoslivBezKostochek2.png",
                    Country = Countries[5],
                    Volume = 500,
                    Discount = 0,
                    Delivery = "1-3 days",
                    Categories = new List<Category> { Categories[0], Categories[3] },
                    Composition = "Natural prune",
                    Brand = Brands[2],
                    Vitamins = Vitamins,
                    Descriptions = "" +
                        "Dried apricots are an important source of carotenoids (vitamin A) and potassium. Because of their high fiber-to-volume ratio, they are sometimes used to relieve constipation.\n" +
                        "Fibre in apricots normalizes the gastrointestinal tract, saves from constipation, promotes the removal of toxins and impurities, cleaning the liver.\n" +
                        "Dried apricots normally do not have any sugar added and have a low glycemic index. The maximum moisture rate allowed in Turkey is 25%.",
                    IsInStock = true,
                    Comments = null,
                },
                new Product()
                {
                    Title = "Сhocolate apricots",
                    Raiting = 5.0F,
                    Price = 4.00M,
                    Img = "ChocolateApricots.png",
                    Country = Countries[6],
                    Volume = 500,
                    Discount = 0,
                    Delivery = "2-4 days",
                    Categories = new List<Category> { Categories[0], Categories[3] },
                    Composition = "Natural chocolate apricots",
                    Brand = Brands[3],
                    Vitamins = Vitamins,
                    Descriptions = "" +
                        "Dried apricots are an important source of carotenoids (vitamin A) and potassium. Because of their high fiber-to-volume ratio, they are sometimes used to relieve constipation.\n" +
                        "Fibre in apricots normalizes the gastrointestinal tract, saves from constipation, promotes the removal of toxins and impurities, cleaning the liver.\n" +
                        "Dried apricots normally do not have any sugar added and have a low glycemic index. The maximum moisture rate allowed in Turkey is 25%.",
                    IsInStock = true,
                    Comments = null,
                },
                new Product()
                {
                    Title = "Red apricots",
                    Raiting = 4.8F,
                    Price = 2.10M,
                    Img = "RedApricots.png",
                    Country = Countries[7],
                    Volume = 500,
                    Discount = 0,
                    Delivery = "2-4 days",
                    Categories = new List<Category> { Categories[0], Categories[3] },
                    Composition = "Natural",
                    Brand = Brands[4],
                    Vitamins = Vitamins,
                    Descriptions = "" +
                        "Dried apricots are an important source of carotenoids (vitamin A) and potassium. Because of their high fiber-to-volume ratio, they are sometimes used to relieve constipation.\n" +
                        "Fibre in apricots normalizes the gastrointestinal tract, saves from constipation, promotes the removal of toxins and impurities, cleaning the liver.\n" +
                        "Dried apricots normally do not have any sugar added and have a low glycemic index. The maximum moisture rate allowed in Turkey is 25%.",
                    IsInStock = true,
                    Comments = null,
                },
                new Product()
                {
                    Title = "Gold apricots Jumbo Limited edition",
                    Raiting = 4.8F,
                    Price = 5.40M,
                    Img = "gold-apricots-Jumbo-Limited-edition.png",
                    Country = Countries[7],
                    Volume = 500,
                    Discount = 0,
                    Delivery = "2-4 days",
                    Categories = new List<Category> { Categories[0], Categories[3] },
                    Composition = "Natural",
                    Brand = Brands[4],
                    Vitamins = Vitamins,
                    Descriptions = "" +
                        "Dried apricots are an important source of carotenoids (vitamin A) and potassium. Because of their high fiber-to-volume ratio, they are sometimes used to relieve constipation.\n" +
                        "Fibre in apricots normalizes the gastrointestinal tract, saves from constipation, promotes the removal of toxins and impurities, cleaning the liver.\n" +
                        "Dried apricots normally do not have any sugar added and have a low glycemic index. The maximum moisture rate allowed in Turkey is 25%.",
                    IsInStock = true,
                    Comments = null,
                },
                new Product()
                {
                    Title = "Natural mango King size",
                    Raiting = 4.5F,
                    Price = 14.00M,
                    Img = "mango-king-size.png",
                    Country = Countries[9],
                    Volume = 500,
                    Discount = 0,
                    Delivery = "2-4 days",
                    Categories = new List<Category> { Categories[0], Categories[4] },
                    Composition = "Natural",
                    Brand = Brands[3],
                    Vitamins = Vitamins,
                    Descriptions = "" +
                        "Dried apricots are an important source of carotenoids (vitamin A) and potassium. Because of their high fiber-to-volume ratio, they are sometimes used to relieve constipation.\n" +
                        "Fibre in apricots normalizes the gastrointestinal tract, saves from constipation, promotes the removal of toxins and impurities, cleaning the liver.\n" +
                        "Dried apricots normally do not have any sugar added and have a low glycemic index. The maximum moisture rate allowed in Turkey is 25%.",
                    IsInStock = true,
                    Comments = null,
                },
                new Product()
                {
                    Title = "Dried mini-pineapple sliced pieces",
                    Raiting = 4.4F,
                    Price = 9.00M,
                    Img = "dried-mini-pineapple-sliced-pieces.png",
                    Country = Countries[10],
                    Volume = 500,
                    Discount = 0,
                    Delivery = "2-4 days",
                    Categories = new List<Category> { Categories[0] },
                    Composition = "Natural",
                    Brand = Brands[1],
                    Vitamins = Vitamins,
                    Descriptions = "" +
                        "Dried apricots are an important source of carotenoids (vitamin A) and potassium. Because of their high fiber-to-volume ratio, they are sometimes used to relieve constipation.\n" +
                        "Fibre in apricots normalizes the gastrointestinal tract, saves from constipation, promotes the removal of toxins and impurities, cleaning the liver.\n" +
                        "Dried apricots normally do not have any sugar added and have a low glycemic index. The maximum moisture rate allowed in Turkey is 25%.",
                    IsInStock = true,
                    Comments = null,
                },
                new Product()
                {
                    Title = "White adriatic figs",
                    Raiting = 4.4F,
                    Price = 9.00M,
                    Img = "white-arabic-figs.png",
                    Country = Countries[3],
                    Volume = 500,
                    Discount = 0,
                    Delivery = "1-3 days",
                    Categories = new List<Category> { Categories[0] },
                    Composition = "Natural",
                    Brand = Brands[3],
                    Vitamins = Vitamins,
                    Descriptions = "" +
                        "Dried apricots are an important source of carotenoids (vitamin A) and potassium. Because of their high fiber-to-volume ratio, they are sometimes used to relieve constipation.\n" +
                        "Fibre in apricots normalizes the gastrointestinal tract, saves from constipation, promotes the removal of toxins and impurities, cleaning the liver.\n" +
                        "Dried apricots normally do not have any sugar added and have a low glycemic index. The maximum moisture rate allowed in Turkey is 25%.",
                    IsInStock = true,
                    Comments = null,
                },
                new Product()
                {
                    Title = "Whole pear",
                    Raiting = 4.4F,
                    Price = 8.90M,
                    Img = "whole-pear.png",
                    Country = Countries[2],
                    Volume = 20,
                    Discount = 0,
                    Delivery = "1-3 days",
                    Categories = new List<Category> { Categories[0] },
                    Composition = "Natural",
                    Brand = Brands[0],
                    Vitamins = Vitamins,
                    Descriptions = "" +
                        "Dried apricots are an important source of carotenoids (vitamin A) and potassium. Because of their high fiber-to-volume ratio, they are sometimes used to relieve constipation.\n" +
                        "Fibre in apricots normalizes the gastrointestinal tract, saves from constipation, promotes the removal of toxins and impurities, cleaning the liver.\n" +
                        "Dried apricots normally do not have any sugar added and have a low glycemic index. The maximum moisture rate allowed in Turkey is 25%.",
                    IsInStock = true,
                    Comments = null,
                },
                new Product()
                {
                    Title = "Seedless apple halves Granny Smith",
                    Raiting = 4.3F,
                    Price = 5.20M,
                    Img = "seedless-apple-granny-smith.png",
                    Country = Countries[1],
                    Volume = 20,
                    Discount = 20,
                    Delivery = "1-3 days",
                    Categories = new List<Category> { Categories[0] },
                    Composition = "Natural",
                    Brand = Brands[0],
                    Vitamins = Vitamins,
                    Descriptions = "" +
                        "Dried apricots are an important source of carotenoids (vitamin A) and potassium. Because of their high fiber-to-volume ratio, they are sometimes used to relieve constipation.\n" +
                        "Fibre in apricots normalizes the gastrointestinal tract, saves from constipation, promotes the removal of toxins and impurities, cleaning the liver.\n" +
                        "Dried apricots normally do not have any sugar added and have a low glycemic index. The maximum moisture rate allowed in Turkey is 25%.",
                    IsInStock = true,
                    Comments = null,
                },
                new Product()
                {
                    Title = "Jerky persimmon",
                    Raiting = 4.3F,
                    Price = 5.20M,
                    Img = "jerky-permission.png",
                    Country = Countries[1],
                    Volume = 20,
                    Discount = 0,
                    Delivery = "1-3 days",
                    Categories = new List<Category> { Categories[0] },
                    Composition = "Natural",
                    Brand = Brands[0],
                    Vitamins = Vitamins,
                    Descriptions = "" +
                        "Dried apricots are an important source of carotenoids (vitamin A) and potassium. Because of their high fiber-to-volume ratio, they are sometimes used to relieve constipation.\n" +
                        "Fibre in apricots normalizes the gastrointestinal tract, saves from constipation, promotes the removal of toxins and impurities, cleaning the liver.\n" +
                        "Dried apricots normally do not have any sugar added and have a low glycemic index. The maximum moisture rate allowed in Turkey is 25%.",
                    IsInStock = false,
                    Comments = null,
                },
            };


        private static List<CartItem> CartItems { get; }
            = new List<CartItem>
            {
                new CartItem { Product = Products[0], Quantity = 3 },
                new CartItem { Product = Products[1], Quantity = 5 },
                new CartItem { Product = Products[2], Quantity = 8 },
                new CartItem { Product = Products[7], Quantity = 2 },
                new CartItem { Product = Products[1], Quantity = 6 },
            };
        private static List<Cart> Carts { get; }
            = new List<Cart>{
                new Cart { CartItems = new List <CartItem> { CartItems[0] }  },
                new Cart { CartItems = new List <CartItem> { CartItems[1] }  },
                new Cart { CartItems = new List <CartItem> { CartItems[2] }  },
                new Cart { CartItems = new List <CartItem> { CartItems[3] }  },
            };
    }
}
