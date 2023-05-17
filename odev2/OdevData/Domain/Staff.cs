using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using Odev2Base;


namespace OdevData.Domain
{
    public class Staff : BaseModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        [NotMapped]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }

    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.CreatedAt).IsRequired(false);
            builder.Property(x => x.CreatedBy).IsRequired(false).HasMaxLength(50);

            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.Phone).IsRequired(true).HasMaxLength(30);
            builder.Property(x => x.DateOfBirth).IsRequired(true);
            builder.Property(x => x.AddressLine1).IsRequired(true).HasMaxLength(100);
            builder.Property(x => x.City).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Country).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.Province).IsRequired(true).HasMaxLength(50);

            builder.HasIndex(x => x.Email).IsUnique(true);
        }
    }


}
