namespace PDFMenu
{
    public class RestaurantGot
    {
        public string email { get; set; } = " ";
        public string phone_number { get; set; } = " ";

        public string restaurant { get; set; } = " ";

        public Int16 rating { get; set; } = 0;

        public string cover_photo { get; set; } = " ";

        public string main_photo { get; set; } = " ";
        public string password { get; set; } = " ";
        public string password_confirmation { get; set; } = " ";
        public string facebook { get; set; } = " ";
        public string instagram { get; set; } = " ";
        public string twitter { get; set; } = " ";
        public string country { get; set; } = " ";
        public string city { get; set; } = " ";
        public string district { get; set; } = " ";
        public string address { get; set; } = " ";

        public string[] tags { get; set; }
        public string menu_pdf { get; set; } = " ";
        public string opening_hours { get; set; } = " ";
        public DateTime menu_upload_date { get; set; }
    }
}
