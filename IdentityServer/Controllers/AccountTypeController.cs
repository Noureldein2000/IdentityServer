using IdentityServer.DTOs;
using IdentityServer.Helpers;
using IdentityServer.Models;
using IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class AccountTypeController : BaseController
    {
        private readonly IAccountTypeService _accountTypeService;
        public AccountTypeController(IAccountTypeService accountTypeService)
        {
            _accountTypeService = accountTypeService;
        }

        [HttpGet]
        [Route("GetAccountTypeById/{id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AccountTypeModel), StatusCodes.Status200OK)]
        public IActionResult GetAccountTypeById([FromRoute] int id)
        {
            try
            {
                var result = _accountTypeService.GetAccountTypeById(id);
                return Ok(Map(result));
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return BadRequest(ex.ErrorCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("GetAccountTypes")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.SuperAdmin)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PagedResult<AccountTypeModel>), StatusCodes.Status200OK)]
        public IActionResult GetAccountTypes(int pageNumber = 1, int pageSize = 10, string language = "ar")
        {
            try
            {
                var result = _accountTypeService.GetAccountTypes(pageNumber, pageSize, language);
                return Ok(new PagedResult<AccountTypeModel>
                {
                    Results = result.Results.Select(ard => Map(ard)).ToList(),
                    PageCount = result.PageCount
                });
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return BadRequest(ex.ErrorCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("AddAccountType")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult AddAccountType([FromBody] AccountTypeModel addAccountTypeModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("102", string.Join(", ", ModelState.Values));

                _accountTypeService.AddAccountType(new AccountTypeDTO
                {
                    Id = addAccountTypeModel.Id,
                    Name = addAccountTypeModel.Name,
                    NameAr = addAccountTypeModel.NameAr,
                    Status = addAccountTypeModel.Status,
                });

                return Ok();
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return BadRequest(ex.ErrorCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("EditAccountType")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult EditAccountType([FromBody] AccountTypeModel editAccountTypeModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("102", string.Join(", ", ModelState.Values));

                _accountTypeService.EditAccountType(new AccountTypeDTO
                {
                    Id = editAccountTypeModel.Id,
                    Name = editAccountTypeModel.Name,
                    NameAr = editAccountTypeModel.NameAr,
                    Status = editAccountTypeModel.Status,
                });
                return Ok();
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return BadRequest(ex.ErrorCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("DeleteAccountType/{id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult DeleteAccountType(int id)
        {
            try
            {
                _accountTypeService.DeleteAccountType(id);
                return Ok();
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return BadRequest(ex.ErrorCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("ChangeStatus/{id}")]
        //[Authorize(Roles = Constants.AvaliableRoles.Admin + "," + Constants.AvaliableRoles.Manager)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public IActionResult ChangeStatus(int id)
        {
            try
            {
                _accountTypeService.ChnageStatus(id);
                return Ok();
            }
            catch (AuthorizationException ex)
            {
                return Unauthorized(ex.ErrorCode, ex.Message);
            }
            catch (OkException ex)
            {
                return BadRequest(ex.ErrorCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [NonAction]
        private AccountTypeModel Map(AccountTypeDTO model)
        {
            return new AccountTypeModel
            {
                Id = model.Id,
                Name = model.Name,
                NameAr = model.NameAr,
                Status = model.Status
            };
        }

    }
}
