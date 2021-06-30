using FluentValidation;

namespace InventoryApp.Application.Devices.Commands.CheckinDevice
{
    public class CheckinDeviceCommandValidation : AbstractValidator<CheckinDeviceCommand>
    {
        public CheckinDeviceCommandValidation()
        {
            RuleFor(checkinDeviceCommand => checkinDeviceCommand.DeviceId)
                .NotEqual(0).WithMessage("Это поле не можетбыть равно 0");

            RuleFor(checkinDeviceCommand => checkinDeviceCommand.EmployeeId)
                .NotEqual(0).WithMessage("Это поле не можетбыть равно 0");
        }
    }
}
