namespace BookShop_BL.Model
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
