using System.Collections.Generic;
using Benenden.Core.Models;


namespace Benenden.Core.ViewModels
{
    public class MemberVM
    {
        
        public int MemberId { get; set; }
        //public int ProductId { get; set; }

        public Member Member { get; set; }
        public Product Product { get; set; }

        public IEnumerable<Member> Members { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
