using IdentityServer.DTOs;
using IdentityServer.Models;
using IdentityServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost]
        [Route("Add")]
        public IActionResult Add(AddAccountRequestModel addRequestModel)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest("102", string.Join(", ", ModelState.Values));

                var result = _accountService.Add(new AccountRequestDTO
                {
                    OwnerName = addRequestModel.OwnerName,
                    AccountName = addRequestModel.AccountName,
                    Mobile = addRequestModel.Mobile,
                    Address = addRequestModel.Address,
                    Email = addRequestModel.Email,
                    NationalID = addRequestModel.NationalID,
                    CommercialRegistrationNo = addRequestModel.CommercialRegistrationNo,
                    TaxNo = addRequestModel.TaxNo,
                    ActivityID = addRequestModel.ActivityID,
                });

                return Ok(Map(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);                
            }
        }

        private AccountRequestModel Map(AccountRequestDTO model)
        {
            return new AccountRequestModel
            {

            };
        }
    }
}
