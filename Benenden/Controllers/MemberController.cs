using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Benenden.Core.Interface;
using Benenden.Core.Models;
using Benenden.Core.ViewModels;

namespace Benenden.Web.Controllers
{
    [Produces("appliation/Json")]
    public class MemberController : Controller
    {
        private readonly IGenericRespository<Member> _memberRepository;
        private readonly IGenericRespository<Product> _productRepository;

        public MemberController(IGenericRespository<Member> memberRepo, IGenericRespository<Product> productRepo)
        {
            this._memberRepository = memberRepo;
            this._productRepository = productRepo;
        }


        public IActionResult Index()
        {
            return View();
        }


        // Step 1. Getting members list and passing there id to see what Products they have
        [HttpGet]
        public IActionResult SelectMember()
        {
            var viewModel = new MemberVM
            {
                Members = _memberRepository.GetAll()
            };
            return Json(viewModel);
        }

        // Step 2. Get products related to the selected member
        [HttpGet]
        public IActionResult RelatedProducts(int MemberId)
        {
            var products = _productRepository.GetProductperMember(MemberId);

            var productVM = new ProductVM();
            productVM.Products = products;

            return Json(productVM);
        }


    }
}