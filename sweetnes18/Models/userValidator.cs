using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Validators;
namespace sweetnes18.Models
{
    public class userValidator:AbstractValidator<user>
    {
        public userValidator()
        {
            RuleFor(x => x.fname).NotEmpty().WithMessage("Fullname is required");
            RuleFor(x => x.lname).NotEmpty().WithMessage("LastNAme is required");
            RuleFor(x => x.mobileno).NotEmpty().WithMessage("Mobile Number is required");
            RuleFor(x => x.password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.username).NotEmpty().WithMessage("Username is required").EmailAddress().WithMessage("In Username Email is required").Must(ifexistUsername).WithMessage("Username Already Exist");
          
        }
        private conn ds = new conn();
        private bool ifexistUsername(user user , string UserName )
        { 
            var exist = ds.user.Where(x => x.username == UserName).FirstOrDefault();

            if (exist == null)
                return true;

            return exist.id == user.id; 
        }
 
    } 

}