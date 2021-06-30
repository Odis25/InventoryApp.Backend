using FluentValidation;

namespace InventoryApp.Application.Cables.Commands.CreateCable
{
    public class CreateCableCommandValidation : AbstractValidator<CreateCableCommand>
    {
        public CreateCableCommandValidation()
        {
            RuleFor(createCableCommand => createCableCommand.Length)
                .GreaterThanOrEqualTo(1).WithMessage("Длина кабеля не может быть меньше 1 метра");

            RuleFor(createCableCommand => createCableCommand.Name)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");

            RuleFor(createCableCommand => createCableCommand.Mark)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");

            RuleFor(createCableCommand => createCableCommand.Type)
                .NotEmpty().WithMessage("Это поле не должно быть пустым")
                .MaximumLength(50).WithMessage("Максимальная допустимая длина 50 символов");
        }
    }
}
