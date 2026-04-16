using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Feedback
    {
        public string Name {  get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }
    }
}
