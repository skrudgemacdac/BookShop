using System;

namespace BookShop_BL.Model
{
    public class Paycheck
    {
        public int PaycheckId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return $"{PaycheckId} from {Created.ToString("dd.MM.yy hh:mm")}";
        }
    }
}
