using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApi.Data
{
    public class OrdersDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options)
        {
            // /Database.EnsureCreated();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseIdentityColumns();
            modelBuilder.HasAnnotation("Npgsql:ValueGenerationStrategy",
                NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity<Models.Orders.Order>(entity =>
            {
                entity.ToTable("order", "orders");
                entity.Property(e => e.Id)
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id).HasName("orders_order_PK");
                
                entity.Property(e => e.SystemType)
                    .HasColumnName("system_type");
                
                entity.Property(e => e.SystemType)
                    .HasColumnName("order_number");

                
                entity.Property(e => e.SourceOrder)
                    .HasColumnType("json")
                    .HasColumnName("source_order");
                
                entity.Property(e => e.ConvertedOrder)
                    .HasColumnType("json")
                    .HasColumnName("converted_order");
                
                
                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(0) with time zone")
                    .HasDefaultValueSql("NULL::timestamp with time zone");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Startup.Configuration.GetConnectionString("DefaultConnection"));
        }
    }
}