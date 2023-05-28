using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace asp.Lib
{
	public partial class EntityModel : DbContext
	{
		public EntityModel()
			: base("name=EntityModel")
		{
		}

		public virtual DbSet<Room> Room { get; set; }
		public virtual DbSet<RoomProperty> RoomProperty { get; set; }
		public virtual DbSet<RoomType> RoomType { get; set; }
		public virtual DbSet<Service> Service { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Room>()
				.Property(e => e.Square)
				.HasPrecision(18, 0);

			modelBuilder.Entity<RoomType>()
				.HasMany(e => e.Room)
				.WithRequired(e => e.RoomType)
				.WillCascadeOnDelete(false);
		}
	}
}
