using Benenden.Core.Models;
using System.Collections.Generic;

namespace Benenden.Core.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Member Member { get; set; }
        public IEnumerable<Member> Members { get; set; }
    }
}
