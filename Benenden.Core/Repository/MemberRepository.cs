using System;
using System.Collections.Generic;
using System.Linq;
using Benenden.Core.DAL;
using Benenden.Core.Interface;
using Benenden.Core.Models;

namespace Benenden.Core.Repository
{
    public class MemberRepository : IGenericRespository<Member>
    {
        private readonly BenendenContext _context;

        public MemberRepository(BenendenContext context)
        {
            _context = context;
        }

        public Member Get(int Id)
        {
            var member = _context.Members.Where(a => !a.IsDeleted).FirstOrDefault(c => c.Id == Id);
            return member;
        }

        public IEnumerable<Member> GetAll()
        {
            return _context.Members.Where(a => !a.IsDeleted).OrderBy(r => r.Id);
        }

        public IEnumerable<Member> GetProductperMember(int MemberId)
        {
            throw new NotImplementedException();
        }
    }
}
