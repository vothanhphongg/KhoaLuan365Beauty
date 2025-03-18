import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

export const getAllBookingTimeByBookingDate = (booking) => {
    return axios.get(END_POINT.queryBookingTime, {
        params:
        {
            salonServiceId: booking.salonServiceId,
            bookingDate: booking.bookingDate
        }
    });
}