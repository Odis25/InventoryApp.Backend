using FluentValidation;

namespace InventoryApp.Application.Cables.Commands.UpdateCable
{
    public class UpdateCableCommandValidation: AbstractValidator<UpdateCableCommand>
    {
        public UpdateCableCommandValidation()
        {
            RuleFor(updateCableCommand => updateCableCommand.Length)
                .GreaterThanOrEqualTo(1).WithMessage("Длина кабеля не может быть меньше 1 метра");

            RuleFor(updateCableCommand => updateCableCommand.Name)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");

            RuleFor(updateCableCommand => updateCableCommand.Mark)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");

            RuleFor(updateCableCommand => updateCableCommand.Type)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");
        }
    }
}
