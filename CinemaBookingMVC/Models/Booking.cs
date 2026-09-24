namespace CinemaBookingMVC.Models;

public class Booking
{
    public int BookingId { get; set; }

    [Required(ErrorMessage = "Customer name is required.")]
    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a movie.")]
    [Display(Name = "Movie")]
    public int MovieId { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Booking Date")]
    public DateTime BookingDate { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Show date is required.")]
    [DataType(DataType.Date)]
    [Display(Name = "Show Date")]
    public DateTime ShowDate { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Number of tickets is required.")]
    [Range(1, 10, ErrorMessage = "You can book between 1 and 10 tickets.")]
    [Display(Name = "Number of Tickets")]
    public int NumberOfTickets { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Cancellation Date")]
    public DateTime? CancellationDate { get; set; }
}