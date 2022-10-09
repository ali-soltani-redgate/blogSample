using BlogSample.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSample.Infrastructure
{
    public class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> blogConfiguration)
        {
            blogConfiguration.HasKey(b => b.Id);
            blogConfiguration.Property<string>("Description").IsRequired(false);
        }
    }
}