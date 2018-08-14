using DemoChat.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoChat.Data
{
    public class ChatItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ChatItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ChatModel>().Wait();
        }

        public Task<List<ChatModel>> GetItemsAsync()
        {
            return database.Table<ChatModel>().ToListAsync();
        }

        public Task<List<ChatModel>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<ChatModel>("SELECT * FROM [ChatModel]");
        }
        public Task<List<ChatModel>> GetItemsNotDoneAsyncByRegion(string region)
        {
            return database.QueryAsync<ChatModel>("SELECT * FROM [ChatModel] WHERE [Region] = '" + region + "'");
        }
        public Task<List<ChatModel>> GetItemsNotDoneAsyncByRegionAndIsRead(string region, string isRead)
        {
            return database.QueryAsync<ChatModel>("SELECT * FROM [ChatModel] WHERE [Region] = '" + region + "' AND [IsRead] = "+isRead);
        }
        public Task<List<ChatModel>> GetCountNotDoneAsyncByRegion(string region)
        {
            return database.QueryAsync<ChatModel>("SELECT * FROM [ChatModel] WHERE [Region] = '" + region + "' AND [IsRead] = 0");
        }

        public Task<int> UpdateIsRead(string region)
        {
            return database.ExecuteAsync("UPDATE [ChatModel] SET [IsRead] = 1 WHERE [Region] = '" + region + "'");
        }
        public Task<ChatModel> GetItemAsync(int id)
        {
            return database.Table<ChatModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ChatModel item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ChatModel item)
        {
            return database.DeleteAsync(item);
        }
    }
}
