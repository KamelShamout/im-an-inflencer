using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ImanInfluencer.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Cartproduct> Cartproducts { get; set; }
        public virtual DbSet<Category1> Category1s { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Payment1> Payment1s { get; set; }
        public virtual DbSet<Product1> Product1s { get; set; }
        public virtual DbSet<Testimonial> Testimonials { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User1> User1s { get; set; }
        public virtual DbSet<Userlogin1> Userlogin1s { get; set; }
        public virtual DbSet<Deductions> Deductions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseOracle("USER ID=train_user101;PASSWORD=Kamel1234;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TRAIN_USER101")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("CART");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CART_FK1");
            });

            modelBuilder.Entity<Cartproduct>(entity =>
            {
                entity.ToTable("CARTPRODUCT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Cartid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CARTID");

                entity.Property(e => e.Productid)
                   .HasColumnType("NUMBER")
                   .HasColumnName("PRODUCTID");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Cartproducts)
                    .HasForeignKey(d => d.Cartid)
                    .HasConstraintName("CARTPRODUCT_FK1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cartproducts)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("CARTPRODUCT_FK2");
            });

           

            modelBuilder.Entity<Category1>(entity =>
            {
                entity.ToTable("CATEGORY1");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");
            });

            
            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("IMAGE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Productid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCTID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("IMAGE_FK1");
            });

            modelBuilder.Entity<Payment1>(entity =>
            {
                entity.ToTable("PAYMENT1");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Cardname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CARDNAME");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payment1s)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PAYMENT_FK1");
            });


            modelBuilder.Entity<Deductions>(entity =>
            {
                entity.ToTable("DEDUCTIONS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Dateof)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOF");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Deductions)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("DEDUCTION_FK1");
            });


            modelBuilder.Entity<Product1>(entity =>
            {
                entity.ToTable("PRODUCT1");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Dateofup)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFUP");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");


                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product1s)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PRODUCT1_FK2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Product1s)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PRODUCT1_FK1");
            });

           
            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.status)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("TESTIMONIAL_FK1");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("TRANSACTION");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Actiondate)
                    .HasColumnType("DATE")
                    .HasColumnName("ACTIONDATE");

                entity.Property(e => e.Buyerid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BUYERID");

                entity.Property(e => e.Paymentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PAYMENTID");

                entity.Property(e => e.Productid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCTID");

                entity.Property(e => e.Sellerid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SELLERID");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.TransactionBuyers)
                    .HasForeignKey(d => d.Buyerid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("TRANSACTION_FK2");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Paymentid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("TRANSACTION_FK4");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("TRANSACTION_FK3");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.TransactionSellers)
                    .HasForeignKey(d => d.Sellerid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("TRANSACTION_FK1");
            });

            modelBuilder.Entity<User1>(entity =>
            {
                entity.ToTable("USER1");

                entity.Property(e => e.Salary)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SALARY");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Dateofreg)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFREG");

                entity.Property(e => e.Age)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("AGE");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                    entity.Property(e => e.Jobtitle)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("JOBTITLE");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("FNAME");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LNAME");

                entity.Property(e => e.Phone)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PHONE");
            });

           

            modelBuilder.Entity<Userlogin1>(entity =>
            {
                entity.ToTable("USERLOGIN1");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userlogin1s)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USERLOGIN1_FK1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
