using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;
using UserManagementOnionPattern.Controllers.UserDTO;

namespace UserManagment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
                   // UserName = user.UserName,

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

        [HttpPost("Edit/{​​​​​id}​​​​​")]
        public void EditUser(UserDto model)
        {
            User userEntity = _userRepository.GetUser(model.Id);
            userEntity.Email = model.Email;
            userEntity.ModifiedDate = DateTime.UtcNow;
            userEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            UserProfile userProfileEntity = _userProfileRepository.GetUserProfile(model.Id);
            userProfileEntity.FirstName = model.FirstName;
            userProfileEntity.LastName = model.LastName;
            userProfileEntity.Address = model.Address;
            userProfileEntity.ModifiedDate = DateTime.UtcNow;
            userProfileEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            userEntity.userProfile = userProfileEntity;
           _userRepository.UpdateUser(userEntity);
        }

        //[HttpPost("Delete/{​​​​​​​id}​​​​​​​")]
        //public void DeleteUser(long Id)
        //{​​​​​​​
        //    UserProfile userProfile = _userProfileRepository.GetUserProfile(Id);
        //    _userRepository.DeleteUser(Id);
        //}​​​​​​​

        [HttpPost("Delete/{​​​​​​​id}​​​​​​​")]
        public void DeleteUser(long Id)
        {
            UserProfile userProfile = _userProfileRepository.GetUserProfile(Id);
           _userRepository.DeleteUser(Id);
        }



    }
}