using BlogSample.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSample.Infrastructure
{
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> postConfiguration)
        {
            postConfiguration.HasKey(p => p.Id);
            postConfiguration.Property<string>("Description").IsRequired(false);
        }
    }
}