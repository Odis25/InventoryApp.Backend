using FluentValidation;

namespace InventoryApp.Application.Devices.Commands.UpdateDevice
{
    public class UpdateDeviceCommandValidation : AbstractValidator<UpdateDeviceCommand>
    {
        public UpdateDeviceCommandValidation()
        {
            RuleFor(updateDeviceCommand => updateDeviceCommand.Name)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");

            RuleFor(updateDeviceCommand => updateDeviceCommand.Model)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");

            RuleFor(updateDeviceCommand => updateDeviceCommand.SerialNumber)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");

            RuleFor(updateDeviceCommand => updateDeviceCommand.Manufacturer)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");
        }
    }
}
