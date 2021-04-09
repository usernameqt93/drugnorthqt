namespace ModelQT.Framework {
  using System;
  using System.Data.Entity;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Linq;

  public partial class WeblogQTDbContext:DbContext {
	public WeblogQTDbContext()
		: base("name=WeblogQTDbContext") {
	}

	public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
	public virtual DbSet<TblTaiKhoan> TblTaiKhoans { get; set; }

	protected override void OnModelCreating(DbModelBuilder modelBuilder) {
	  modelBuilder.Entity<TblTaiKhoan>()
		  .Property(e => e.UserName)
		  .IsUnicode(false);

	  modelBuilder.Entity<TblTaiKhoan>()
		  .Property(e => e.Password)
		  .IsUnicode(false);

	  modelBuilder.Entity<TblTaiKhoan>()
		  .Property(e => e.CreatedBy)
		  .IsUnicode(false);

	  modelBuilder.Entity<TblTaiKhoan>()
		  .Property(e => e.ModifiedBy)
		  .IsUnicode(false);
	}
  }
}
