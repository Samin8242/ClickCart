namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intiDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "SId", "dbo.Sellers");
            DropForeignKey("dbo.Orders", "OrderedById", "dbo.Users");
            DropForeignKey("dbo.Wishlists", "UId", "dbo.Users");
            DropForeignKey("dbo.Reviews", "UId", "dbo.Users");
            DropIndex("dbo.Products", new[] { "SId" });
            DropIndex("dbo.Reviews", new[] { "UId" });
            DropIndex("dbo.Orders", new[] { "OrderedById" });
            DropIndex("dbo.WishLists", new[] { "UId" });
            RenameColumn(table: "dbo.Products", name: "CId", newName: "CategoryId");
            RenameColumn(table: "dbo.Reviews", name: "PId", newName: "ProductId");
            RenameColumn(table: "dbo.WishLists", name: "PId", newName: "ProductId");
            RenameColumn(table: "dbo.Reviews", name: "UId", newName: "ReviewBy");
            RenameColumn(table: "dbo.Orders", name: "OrderedById", newName: "OrderedBy");
            RenameColumn(table: "dbo.WishLists", name: "UId", newName: "WishBy");
            RenameColumn(table: "dbo.OrderDetails", name: "OId", newName: "OrderId");
            RenameColumn(table: "dbo.OrderDetails", name: "PId", newName: "ProductId");
            RenameIndex(table: "dbo.OrderDetails", name: "IX_PId", newName: "IX_ProductId");
            RenameIndex(table: "dbo.OrderDetails", name: "IX_OId", newName: "IX_OrderId");
            RenameIndex(table: "dbo.Products", name: "IX_CId", newName: "IX_CategoryId");
            RenameIndex(table: "dbo.Reviews", name: "IX_PId", newName: "IX_ProductId");
            RenameIndex(table: "dbo.WishLists", name: "IX_PId", newName: "IX_ProductId");
            DropPrimaryKey("dbo.Users");
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CartId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CartBy)
                .Index(t => t.CartBy);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        DiscountPercent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 100),
                        Dob = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.PaymentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentBy = c.String(maxLength: 128),
                        OrderId = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentMethod = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.PaymentBy)
                .Index(t => t.PaymentBy)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false, maxLength: 100),
                        Dob = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Username);
            
            AddColumn("dbo.Categories", "Name", c => c.String());
            AddColumn("dbo.Categories", "Description", c => c.String());
            AddColumn("dbo.Categories", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "DiscountId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "SupplyBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Reviews", "Description", c => c.String());
            AddColumn("dbo.Users", "Gender", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Users", "Dob", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Phone", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Users", "Type", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "DeliveryAddress", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "TotalPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "DeliveryBy", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.WishLists", "Description", c => c.String());
            AlterColumn("dbo.Reviews", "ReviewBy", c => c.String(maxLength: 128));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Orders", "OrderedBy", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.OrderDetails", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.WishLists", "WishBy", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Users", "Username");
            CreateIndex("dbo.Orders", "OrderedBy");
            CreateIndex("dbo.Orders", "DeliveryBy");
            CreateIndex("dbo.Products", "DiscountId");
            CreateIndex("dbo.Products", "SupplyBy");
            CreateIndex("dbo.Reviews", "ReviewBy");
            CreateIndex("dbo.WishLists", "WishBy");
            AddForeignKey("dbo.Products", "DiscountId", "dbo.Discounts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SupplyBy", "dbo.Suppliers", "Username");
            AddForeignKey("dbo.Orders", "DeliveryBy", "dbo.Shippers", "Username", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "OrderedBy", "dbo.Users", "Username", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "ReviewBy", "dbo.Users", "Username");
            AddForeignKey("dbo.WishLists", "WishBy", "dbo.Users", "Username");
            DropColumn("dbo.Categories", "CategoryName");
            DropColumn("dbo.Products", "Qty");
            DropColumn("dbo.Products", "SId");
            DropColumn("dbo.Reviews", "Comment");
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Orders", "Amount");
            DropColumn("dbo.OrderDetails", "Qty");
            DropTable("dbo.Sellers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        SellerContact = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.OrderDetails", "Qty", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AddColumn("dbo.Reviews", "Comment", c => c.String());
            AddColumn("dbo.Products", "SId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Qty", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            DropForeignKey("dbo.WishLists", "WishBy", "dbo.Users");
            DropForeignKey("dbo.Reviews", "ReviewBy", "dbo.Users");
            DropForeignKey("dbo.Orders", "OrderedBy", "dbo.Users");
            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CartItems", "CartId", "dbo.Carts");
            DropForeignKey("dbo.Carts", "CartBy", "dbo.Users");
            DropForeignKey("dbo.Orders", "DeliveryBy", "dbo.Shippers");
            DropForeignKey("dbo.PaymentDetails", "PaymentBy", "dbo.Users");
            DropForeignKey("dbo.PaymentDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "SupplyBy", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "DiscountId", "dbo.Discounts");
            DropIndex("dbo.PaymentDetails", new[] { "OrderId" });
            DropIndex("dbo.PaymentDetails", new[] { "PaymentBy" });
            DropIndex("dbo.WishLists", new[] { "WishBy" });
            DropIndex("dbo.Reviews", new[] { "ReviewBy" });
            DropIndex("dbo.Products", new[] { "SupplyBy" });
            DropIndex("dbo.Products", new[] { "DiscountId" });
            DropIndex("dbo.Orders", new[] { "DeliveryBy" });
            DropIndex("dbo.Orders", new[] { "OrderedBy" });
            DropIndex("dbo.Carts", new[] { "CartBy" });
            DropIndex("dbo.CartItems", new[] { "ProductId" });
            DropIndex("dbo.CartItems", new[] { "CartId" });
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.WishLists", "WishBy", c => c.String(maxLength: 10));
            AlterColumn("dbo.OrderDetails", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "OrderedBy", c => c.String(maxLength: 10));
            AlterColumn("dbo.Orders", "Status", c => c.String());
            AlterColumn("dbo.Users", "Address", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Reviews", "ReviewBy", c => c.String(maxLength: 10));
            DropColumn("dbo.WishLists", "Description");
            DropColumn("dbo.OrderDetails", "Quantity");
            DropColumn("dbo.Orders", "DeliveryBy");
            DropColumn("dbo.Orders", "TotalPrice");
            DropColumn("dbo.Orders", "DeliveryAddress");
            DropColumn("dbo.Users", "Type");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "Dob");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Reviews", "Description");
            DropColumn("dbo.Products", "SupplyBy");
            DropColumn("dbo.Products", "DiscountId");
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Products", "CreatedDate");
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Categories", "UpdatedDate");
            DropColumn("dbo.Categories", "CreatedDate");
            DropColumn("dbo.Categories", "Description");
            DropColumn("dbo.Categories", "Name");
            DropTable("dbo.Shippers");
            DropTable("dbo.PaymentDetails");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Discounts");
            DropTable("dbo.Carts");
            DropTable("dbo.CartItems");
            AddPrimaryKey("dbo.Users", "Username");
            RenameIndex(table: "dbo.WishLists", name: "IX_ProductId", newName: "IX_PId");
            RenameIndex(table: "dbo.Reviews", name: "IX_ProductId", newName: "IX_PId");
            RenameIndex(table: "dbo.Products", name: "IX_CategoryId", newName: "IX_CId");
            RenameIndex(table: "dbo.OrderDetails", name: "IX_OrderId", newName: "IX_OId");
            RenameIndex(table: "dbo.OrderDetails", name: "IX_ProductId", newName: "IX_PId");
            RenameColumn(table: "dbo.OrderDetails", name: "ProductId", newName: "PId");
            RenameColumn(table: "dbo.OrderDetails", name: "OrderId", newName: "OId");
            RenameColumn(table: "dbo.WishLists", name: "WishBy", newName: "UId");
            RenameColumn(table: "dbo.Orders", name: "OrderedBy", newName: "OrderedById");
            RenameColumn(table: "dbo.Reviews", name: "ReviewBy", newName: "UId");
            RenameColumn(table: "dbo.WishLists", name: "ProductId", newName: "PId");
            RenameColumn(table: "dbo.Reviews", name: "ProductId", newName: "PId");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "CId");
            CreateIndex("dbo.WishLists", "UId");
            CreateIndex("dbo.Orders", "OrderedById");
            CreateIndex("dbo.Reviews", "UId");
            CreateIndex("dbo.Products", "SId");
            AddForeignKey("dbo.Reviews", "UId", "dbo.Users", "Username");
            AddForeignKey("dbo.Wishlists", "UId", "dbo.Users", "Username");
            AddForeignKey("dbo.Orders", "OrderedById", "dbo.Users", "Username");
            AddForeignKey("dbo.Products", "SId", "dbo.Sellers", "Id", cascadeDelete: true);
        }
    }
}
