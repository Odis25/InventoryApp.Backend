using FluentValidation;

namespace InventoryApp.Application.Devices.Commands.CreateDevice
{
    public class CreateDeviceCommandValidation : AbstractValidator<CreateDeviceCommand>
    {
        public CreateDeviceCommandValidation()
        {
            RuleFor(createDeviceCommand => createDeviceCommand.Name)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");

            RuleFor(createDeviceCommand => createDeviceCommand.Model)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");

            RuleFor(createDeviceCommand => createDeviceCommand.SerialNumber)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");

            RuleFor(createDeviceCommand => createDeviceCommand.Manufacturer)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");
        }
    }
}
