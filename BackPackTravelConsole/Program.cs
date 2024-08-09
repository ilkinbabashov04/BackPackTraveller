using Business.Concrete;
using DataAccess.Concrete.EF;
using Entities.Concrete;

AboutManager aboutManager = new AboutManager(new EfAboutDal());
BlogManager blogManager = new BlogManager(new EfBlogDal());
CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
FaqManager faqManager = new FaqManager(new EfFaqDal());
TravelManager travelManager = new TravelManager(new EfTraveldal());

About about = new About() {Title = "About", Description = "AboutDescription", ImageLink = "htttps/image.com"};
Blog blog = new Blog() { Title = "Blog", Description = "BlogDesc", ImageUrl = "https/..."};
Category category = new Category() { CategoryName = "Category", ImageUrl = "https/...", IconUrl = "https/..." };
Faq faq = new Faq() { Title = "Faq", Description = "FaqDesc", ImageLink = "https/.." };
Travel travel = new Travel() { Title = "Travel", Description = "TravelDesc", ImageLink = "https/.." };
TravelToCategory travelToCategory = new TravelToCategory();

aboutManager.Add(about);
blogManager.Add(blog);
categoryManager.Add(category);
faqManager.Add(faq);
travelManager.Add(travel);

var getAllAbout = aboutManager.GetAll().Data;
var getAllCategory = categoryManager.GetAll().Data;
var getAllFaq = faqManager.GetAll().Data;
var getAllTravel = travelManager.GetAll().Data;
var getAllBlog = blogManager.GetAll().Data;

foreach(var about1 in getAllAbout)
{
    if(about1.Id == 1)
    {
        //aboutManager.Delete(about1);
        //about1.Title = "azer";
        //about1.Description = "Salam";
        //aboutManager.Update(about1);
    }
}

foreach (var category1 in getAllCategory)
{
    if (category1.Id == 1)
    {
        //categoryManager.Delete(category1);
        category1.IconUrl = "....";
        category1.ImageUrl = "....";
        categoryManager.Update(category1);
    }
}

foreach (var faq1 in getAllFaq)
{
    if (faq1.Id == 1)
    {
        //faqManager.Delete(faq1);
        faq1.Title = "Salam";
        faq1.Description = "Sagol";
        faqManager.Update(faq1);
    }
}

foreach (var travel1 in getAllTravel)
{
    if (travel1.Id == 1)
    {
        travel1.Title = "Salam";
        travel1.Description = "Sagol";
        travelManager.Update(travel1);
        //travelManager.Delete(travel1);
    }
}

foreach (var blog1 in getAllBlog)
{
    if (blog1.Id == 1)
    {
        blog1.Title = "Salam";
        blog1.ImageUrl = "aaa";
        blogManager.Update(blog1);
        //blogManager.Delete(blog1);
    }
}
