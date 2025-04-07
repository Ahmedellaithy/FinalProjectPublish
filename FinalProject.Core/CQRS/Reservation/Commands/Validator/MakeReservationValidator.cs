using FinalProject.Core.CQRS.Reservation.Commands.Request;
using FluentValidation;

namespace FinalProject.Core.CQRS.Reservation.Commands.Validator;

public class MakeReservationValidator : AbstractValidator<MakeReservationCommand>
{
    public MakeReservationValidator()
    {
        MakeReservationValidation();
    }

    public void MakeReservationValidation()
    {
        RuleFor(x => x.reservationDate)
            .NotEmpty().WithMessage("Reservation Date is required")
            .NotNull().WithMessage("Reservation Date is required");
        //.Must(Valid).WithMessage("Invalid TimeSpan");
    }
    private bool Valid(TimeSpan time)
    {
        return time >= TimeSpan.Zero && time < TimeSpan.FromDays(1);
    }
}