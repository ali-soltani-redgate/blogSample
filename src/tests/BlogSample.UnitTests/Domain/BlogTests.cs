namespace BlogSample.UnitTests
{
    using System;
    using BlogSample.Domain;
    using NUnit.Framework;
    public class BlogTests
    {
        [Test]
        public void Add_ValidInputs_BlogShouldBeReturned()
        {
            // Arrange
            var name = "Test";
            var description = "des";

            // Act
            Blog blog = Blog.Add(name, description);

            // Assert
            Assert.IsNotNull(blog);
            Assert.AreEqual(name, blog.Name);
            Assert.AreEqual(description, blog.Description);
        }

        [Test]
        public void Add_NameIsEmpty_ErrorShouldBeReturned()
        {
            // Arrange
            var name = "";
            var description = "des";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Blog.Add(name, description));
        }

        [Test]
        public void AddPost_InvalidPost_BlogHavingOnlyOnePostShouldBeReturned()
        {
            // Arrange
            var content = "test";
            var createDate = DateTime.Now;
            Blog blog = GetFakeBlog();

            // Act
            blog.AddPost(content, createDate);

            // Assert
            Assert.AreEqual(blog.Posts.Count(), 1);
        }
        

        private static Blog GetFakeBlog()
        {
            return Blog.Add("blog", "description");
        }
    }
}