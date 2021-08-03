using FluentValidation;

namespace InventoryApp.Application.Cables.Commands.CheckinCable
{
    public class CheckinCableCommandValidation : AbstractValidator<CheckinCableCommand>
    {
        public CheckinCableCommandValidation()
        {
            RuleFor(checkinCableCommand => checkinCableCommand.CablesId)
                .NotEmpty().WithMessage("Это поле не может быть пустым");

            RuleFor(checkinCableCommand => checkinCableCommand.EmployeeId)
                .NotEqual(0).WithMessage("Это поле не может быть равно 0");
        }
    }
}
