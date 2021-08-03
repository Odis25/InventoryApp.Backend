using FluentValidation;

namespace InventoryApp.Application.Devices.Commands.CheckinDevice
{
    public class CheckinDeviceCommandValidation : AbstractValidator<CheckinDeviceCommand>
    {
        public CheckinDeviceCommandValidation()
        {
            RuleFor(checkinDeviceCommand => checkinDeviceCommand.DevicesId)
                .NotEmpty().WithMessage("Это поле не может быть пустым");

            RuleFor(checkinDeviceCommand => checkinDeviceCommand.EmployeeId)
                .NotEqual(0).WithMessage("Это поле не можетбыть равно 0");
        }
    }
}
