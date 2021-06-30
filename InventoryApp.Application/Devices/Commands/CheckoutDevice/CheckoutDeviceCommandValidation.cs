using FluentValidation;

namespace InventoryApp.Application.Devices.Commands.CheckoutDevice
{
    public class CheckoutDeviceCommandValidation : AbstractValidator<CheckoutDeviceCommand>
    {
        public CheckoutDeviceCommandValidation()
        {
            RuleFor(checkinDeviceCommand => checkinDeviceCommand.DeviceId)
                .NotEqual(0).WithMessage("Это поле не можетбыть равно 0");
        }
    }
}
