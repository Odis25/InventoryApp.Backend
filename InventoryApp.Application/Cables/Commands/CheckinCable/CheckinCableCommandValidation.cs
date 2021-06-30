using FluentValidation;

namespace InventoryApp.Application.Cables.Commands.CheckinCable
{
    public class CheckinCableCommandValidation : AbstractValidator<CheckinCableCommand>
    {
        public CheckinCableCommandValidation()
        {
            RuleFor(checkinCableCommand => checkinCableCommand.CableId)
                .NotEqual(0).WithMessage("Это поле не можетбыть равно 0");

            RuleFor(checkinCableCommand => checkinCableCommand.EmployeeId)
                .NotEqual(0).WithMessage("Это поле не можетбыть равно 0");
        }
    }
}
