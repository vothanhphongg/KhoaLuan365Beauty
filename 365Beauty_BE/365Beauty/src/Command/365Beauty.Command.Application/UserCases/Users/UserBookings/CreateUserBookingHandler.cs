using _365Beauty.Command.Application.Commands.Users.UserBookings;
using _365Beauty.Command.Domain.Abstractions.Repositories.BeautySalons;
using _365Beauty.Command.Domain.Abstractions.Repositories.Users;
using _365Beauty.Command.Domain.Constants.Users;
using _365Beauty.Command.Domain.Entities.Users;
using _365Beauty.Contract.Shared;
using Commerce.Command.Contract.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace _365Beauty.Command.Application.UserCases.Users.UserBookings
{
    public class CreateUserBookingHandler : IRequestHandler<CreateUserBookingCommand, Result<object>>
    {
        private readonly IUserBookingRepository userBookingRepository;
        private readonly IBeautySalonServiceRepository beautySalonServiceRepository;
        private readonly IVnpay vnpay;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateUserBookingHandler(
            IUserBookingRepository userBookingRepository,
            IBeautySalonServiceRepository beautySalonServiceRepository,
            IVnpay vnpay,
            IHttpContextAccessor httpContextAccessor)
        {
            this.userBookingRepository = userBookingRepository;
            this.beautySalonServiceRepository = beautySalonServiceRepository;
            this.vnpay = vnpay;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<object>> Handle(CreateUserBookingCommand request, CancellationToken cancellationToken)
        {
            var ipAddress = httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var salonService = await beautySalonServiceRepository.FindByIdAsync(request.SalonServiceId, true, true, cancellationToken, x => x.Price);

            var entity = new UserBooking
            {
                UserId = request.UserId,
                SalonServiceId = request.SalonServiceId,
                TimeId = request.TimeId,
                BookingTypeId = request.BookingTypeId,
                StaffId = request.StaffId,
                Description = request.Description,
                BookingDate = request.BookingDate,
                CreateDate = DateTime.UtcNow,
                IsActived = UserBookingConst.NOT_CONFIRM,
            };

            using var transaction = await userBookingRepository.BeginTransactionAsync(cancellationToken);
            try
            {
                userBookingRepository.Add(entity);
                await userBookingRepository.SaveChangesAsync(cancellationToken);
                if (request.BookingTypeId == 1)
                {
                    var paymentRequest = new PaymentRequest
                    {
                        Money = (double)salonService.Price.FinalPrice,
                        Description = "Chuyển tiền đặt lịch thẩm mỹ viện",
                        IpAddress = ipAddress,
                        CreatedDate = DateTime.UtcNow,
                        Currency = Currency.VND,
                        BankCode = BankCode.ANY,
                        PaymentId = entity.Id  // Dùng ID sau khi đã lưu để tạo PaymentId
                    };
                    var paymentUrl = vnpay.GetPaymentUrl(paymentRequest);
                    transaction.Commit();
                    return Result.Ok(new { RedirectUrl = paymentUrl });
                }
                transaction.Commit();
                return Result.Ok(entity.Id);
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}