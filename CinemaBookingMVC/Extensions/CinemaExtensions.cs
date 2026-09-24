namespace CinemaBookingMVC.Extensions;

public static class CinemaExtensions
{
    public static string GetBookingStatus(this Booking booking)
    {
        if (booking.CancellationDate.HasValue)
        {
            return "Cancelled";
        }

        DateTime today = DateTime.Today;
        DateTime showDate = booking.ShowDate.Date;

        if (showDate < today)
        {
            return "Completed";
        }
        else if (showDate == today)
        {
            return "Today";
        }
        else
        {
            return "Upcoming";
        }
    }

    public static decimal CalculateTotalAmount(this Booking booking, decimal ticketPrice)
    {
        return booking.NumberOfTickets * ticketPrice;
    }
}