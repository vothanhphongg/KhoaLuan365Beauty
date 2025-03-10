using _365Beauty.Command.Application.Commands.Bookings.BookingTransactions;
using _365Beauty.Command.Presentation.Abstractions;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _365Beauty.Command.Presentation.Controllers.v1.Bookings
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/bookingTransaction")]
    public class BookingTransactionController : ApiController
    {
        private readonly IMediator mediator;

        public BookingTransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SaveBookingTransaction([FromQuery] decimal vnp_Amount, [FromQuery] string? vnp_BankCode,
                [FromQuery] string? vnp_BankTranNo, [FromQuery] string? vnp_CardType, [FromQuery] string? vnp_OrderInfo, 
                [FromQuery] string? vnp_ResponseCode, [FromQuery] string? vnp_TransactionNo, [FromQuery] string? vnp_TransactionStatus,
                [FromQuery] string? vnp_TxnRef, [FromQuery] string? vnp_SecureHash)
        {
          

            var command = new CreateBookingTransactionCommand
            {
                UserBookId = int.Parse(vnp_TxnRef ?? "0"),
                Amount = vnp_Amount / 100, 
                BankCode = vnp_BankCode,
                BankTranNo = vnp_BankTranNo,
                CardType = vnp_CardType,
                OrderInfo = vnp_OrderInfo,
                ResponseCode = vnp_ResponseCode,
                TransactionNo = vnp_TransactionNo,
                Status = vnp_TransactionStatus
            };

            var result = await mediator.Send(command);

            // Kiểm tra trạng thái thanh toán để chuyển hướng
            if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
            {
                // Thành công: chuyển hướng sang trang success của frontend
                return Redirect($"http://localhost:3000/booking-success/{command.UserBookId}");
            }
            else
            {
                // Thất bại: chuyển hướng sang trang failed của frontend
                return Redirect("http://localhost:3000/booking-failed");
            }
        }
    }
}