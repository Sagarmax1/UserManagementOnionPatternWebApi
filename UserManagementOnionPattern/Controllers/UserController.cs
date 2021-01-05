using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using UserManagementOnionPattern.Controllers.UserDTO;

namespace UserManagment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        IUserRepository _userRepository;

        IUserProfileRepository _userProfileRepository;


        public UserController(IUserRepository userRepository, IUserProfileRepository userProfileRepository)
        {
            this._userRepository = userRepository;

            this._userProfileRepository = userProfileRepository;
        }

        [HttpGet("UserList")]
        public ActionResult UserList()
        {
            return Ok(_userRepository.GetUsers());
        }

        [HttpPost("AddUser")]
        public ActionResult AddedUser(UserDto user)  // we should not pass model as parameter to action. use View Model or DTO(Data Transfer Model) 
        {
            var userEntity = new User
            {
                UserName = user.UserName,

                Email = user.Email,

                Password = user.Password,

                AddedDate = user.AddedDate,

                ModifiedDate=DateTime.Now,

                IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),

                userProfile = new UserProfile
                {

                    FirstName = user.FirstName,

                    LastName = user.LastName,

                    Address = user.Address,

                    AddedDate = DateTime.UtcNow,

                    ModifiedDate=DateTime.UtcNow,

                    IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),

                }

            };
            _userRepository.InsertUser(userEntity);

            return Ok(1);
        }


        //[HttpPut("EditDepartment")] for cheking forcheking Syntax https://localhost:44385/api/Department/EditDepartment and Id put in body
       // [HttpPost("Edit/{​​​​​id}​​​​​")] 
       [HttpPut("Edit")]
        public void EditUser(UserDto model)
        {
            User userEntity = _userRepository.GetUser(model.Id);
            userEntity.Email = model.Email;
            userEntity.ModifiedDate = DateTime.UtcNow;
            userEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
           _userRepository.UpdateUser(userEntity);
        }


     // [HttpDelete("DeleteDepartment")] forcheking syntax- https://localhost:44385/api/Department/DeleteDepartment?id=13
      //  [HttpPost("Delete/{​​​​​​​id}​​​​​​​")] 
        [HttpDelete("Delete/{​​​​​​​id}")]
        public void DeleteUser(long id)
        {
            UserProfile userProfile = _userProfileRepository.GetUserProfile(id);
           _userRepository.DeleteUser(id);
        }



    }
}