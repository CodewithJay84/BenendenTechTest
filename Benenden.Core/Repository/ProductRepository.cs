using System.Collections.Generic;
using System.Linq;
using Benenden.Core.DAL;
using Benenden.Core.Interface;
using Benenden.Core.Models;

namespace Benenden.Core.Repository
{
    public class ProductRepository : IGenericRespository<Product>
    {
        private readonly BenendenContext _context;

        public ProductRepository(BenendenContext context)
        {
            _context = context;
        }
               
        public Product Get(int Id)
        {
            var product = _context.Products.Where(a => !a.IsDeleted).FirstOrDefault(c => c.Id == Id);
            var member = _context.Members.FirstOrDefault(a => a.Id == _context.Products.Where(b => !b.IsDeleted).FirstOrDefault(c => c.Id == Id).Member.Id);
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Where(a => !a.IsDeleted).OrderBy(r => r.Member.Id);
        }

        public IEnumerable<Product> GetProductperMember(int MemberId)
        {
            var product = _context.Products.Where(a => !a.IsDeleted && a.Member.Id == MemberId);
            return product;
        }
    }
}
