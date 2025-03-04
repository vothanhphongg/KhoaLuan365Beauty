import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

const BookingEndPoint = {
    bookingTimes: '/bookingTimes',
    getAll: '/getAll',
}

export const getAllBookingTimeByBookingDate = (booking) => {
    console.log(booking);
    return axios.get(END_POINT.queryBooking + BookingEndPoint.bookingTimes, {
        params:
        {
            salonServiceId: booking.salonServiceId,
            bookingDate: booking.bookingDate
        }
    });
}