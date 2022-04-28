using FluentValidation;
using System.Linq;
using TravelAPI.Entities;
using TravelAPI.Models;

namespace TravelAPI.Validators
{
    public class RegisterValidator:AbstractValidator<RegisterKlientDto>
    {
        public RegisterValidator(DataBase db)
        {
            RuleFor(x => x.username).NotEmpty().MinimumLength(6);

            RuleFor(x=>x.password).NotEmpty().MinimumLength(6);  

            RuleFor(x=>x.confirmPassword).Equal(e=>e.password);

            RuleFor(x=>x.username)
                .Custom((value, context)=>{
                    var inUse = db.Klienci.Any(u => u.username == value);
                    if (inUse)
                    {
                        context.AddFailure("username", "username is taken");
                    }
                });
        }
    }
}
