using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Data
{
    public class OrdersContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
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

            modelBuilder.Entity<Core.Entities.Order>(entity =>
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
    }
}