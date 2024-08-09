using Business.Abstract;
using Core.Helper.Results.Abstract;
using Core.Helper.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public IResult Add(Blog blog)
        {
            _blogDal.Add(blog);
            return new SuccesResult();
        }

        public IResult Delete(int id)
        {
            var deletedBlog =_blogDal.Get(p => p.Id == id && p.IsDelete == false);
            if(deletedBlog != null)
            {
                deletedBlog.IsDelete = true;
                _blogDal.Delete(deletedBlog);
                return new SuccesResult();
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IDataResult<Blog> Get(int id)
        {
            var getBlog = _blogDal.Get(p => p.Id == id && p.IsDelete == false);
            if(getBlog != null)
            {
                return new SuccesDataResult<Blog>(getBlog);
            }
            else
            {
                return new ErrorDataResult<Blog>();
            }
        }

        public IDataResult<List<Blog>> GetAll()
        {
            var getAllBlog = _blogDal.GetAll(p => p.IsDelete == false);
            if(getAllBlog != null)
            {
                return new SuccesDataResult<List<Blog>>(getAllBlog);
            }
            else
            {
                return new ErrorDataResult<List<Blog>>();
            }
        }

        public IResult Update(Blog blog)
        {
            var updatedBlog = _blogDal.Get(p => p.Id == blog.Id && p.IsDelete == false);
            if(updatedBlog != null)
            {
                updatedBlog.Title = blog.Title;
                updatedBlog.Description = blog.Description;
                updatedBlog.ImageUrl = blog.ImageUrl;
                _blogDal.Update(updatedBlog);
                return new SuccesResult();
            }
            else
            {
                return new ErrorResult();
            }
        }
    }
}
