namespace CinemaBookingMVC.Controllers;

public class CinemaController : Controller
{
    // Temporary in-memory movie store
    public static List<Movie> Movies = new()
    {
        new Movie { MovieId = 1, MovieName = "Inception", Genre = "Sci-Fi", Language = "English", TicketPrice = 12.50m, AvailableSeats = 100 },
        new Movie { MovieId = 2, MovieName = "Interstellar", Genre = "Sci-Fi", Language = "English", TicketPrice = 15.00m, AvailableSeats = 80 },
        new Movie { MovieId = 3, MovieName = "RRR", Genre = "Action", Language = "Telugu", TicketPrice = 10.00m, AvailableSeats = 150 }
    };

    // Temporary in-memory booking store with initial sample data
    public static List<Booking> Bookings = new()
    {
        new Booking
        {
            BookingId = 101,
            CustomerName = "Alice Smith",
            Email = "alice@example.com",
            Phone = "555-0199",
            MovieId = 1,
            BookingDate = DateTime.Today.AddDays(-5),
            ShowDate = DateTime.Today.AddDays(-2),
            NumberOfTickets = 2
        },
        new Booking
        {
            BookingId = 102,
            CustomerName = "Bob Johnson",
            Email = "bob@example.com",
            Phone = "555-0244",
            MovieId = 2,
            BookingDate = DateTime.Today,
            ShowDate = DateTime.Today,
            NumberOfTickets = 3
        },
        new Booking
        {
            BookingId = 103,
            CustomerName = "Charlie Brown",
            Email = "charlie@example.com",
            Phone = "555-0388",
            MovieId = 3,
            BookingDate = DateTime.Today,
            ShowDate = DateTime.Today.AddDays(3),
            NumberOfTickets = 4
        },
        new Booking
        {
            BookingId = 104,
            CustomerName = "Diana Prince",
            Email = "diana@example.com",
            Phone = "555-0411",
            MovieId = 1,
            BookingDate = DateTime.Today.AddDays(-1),
            ShowDate = DateTime.Today.AddDays(1),
            NumberOfTickets = 2,
            CancellationDate = DateTime.Today
        }
    };

    // GET: /Cinema/ or /Cinema/Index
    public IActionResult Index()
    {
        ViewBag.Movies = Movies;
        return View(Bookings);
    }

    // GET: /Cinema/BookTicket
    [HttpGet]
    public IActionResult BookTicket()
    {
        ViewBag.MovieList = new SelectList(Movies, "MovieId", "MovieName");
        return View(new Booking { BookingDate = DateTime.Today, ShowDate = DateTime.Today });
    }

    // POST: /Cinema/BookTicket
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult BookTicket(Booking booking)
    {
        if (ModelState.IsValid)
        {
            booking.BookingId = Bookings.Any() ? Bookings.Max(b => b.BookingId) + 1 : 101;
            Bookings.Add(booking);
            
            TempData["SuccessMessage"] = $"Ticket booked successfully for {booking.CustomerName}!";
            return RedirectToAction(nameof(Index));
        }

        ViewBag.MovieList = new SelectList(Movies, "MovieId", "MovieName", booking.MovieId);
        return View(booking);
    }

    // GET: /Cinema/MovieDetails/5
    public IActionResult MovieDetails(int id)
    {
        var booking = Bookings.FirstOrDefault(b => b.BookingId == id);
        if (booking == null)
        {
            return NotFound();
        }

        var movie = Movies.FirstOrDefault(m => m.MovieId == booking.MovieId);
        ViewBag.Movie = movie;

        return View(booking);
    }

    // GET: /Cinema/About
    public IActionResult About()
    {
        return View();
    }
}