using SQLite;

namespace DemoChat.Models
{
    public class ChatModel
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Message { get; set; }

        public int Type { get; set; }

        public string CreatedDate { get; set; }

        public string ImageUrl { get; set; }

        public string body { get; set; }

        public string title { get; set; }

        public string Region { get; set; }

        public int IsRead { get; set; }

    }
}
