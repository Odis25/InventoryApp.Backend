using FluentValidation;

namespace InventoryApp.Application.Cables.Commands.CheckoutCable
{
    public class CheckoutCableCommandValidation: AbstractValidator<CheckoutCableCommand>
    {
        public CheckoutCableCommandValidation()
        {
            RuleFor(checkoutCableCommand => checkoutCableCommand.CableId)
                .NotEqual(0).WithMessage("Это поле не можетбыть равно 0");
        }
    }
}
