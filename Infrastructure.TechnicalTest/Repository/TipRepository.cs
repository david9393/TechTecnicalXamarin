using Infrastructure.TechnicalTest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TechnicalTest.Repository
{
   public class TipRepository : ITipRepository
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection _database => lazyInitializer.Value;
        static bool initialized = false;
        public TipRepository()
        {
            InitializeAsync().SafeFireAndForget(false);
        }
        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!_database.TableMappings.Any(m => m.MappedType.Name == typeof(TipModel).Name))
                {
                    await _database.CreateTablesAsync(CreateFlags.None, typeof(TipModel)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }
        public async Task<List<TipModel>> GetTipsAync()
        {
            return await _database.Table<TipModel>().OrderBy(i=>i.Fecha).ToListAsync();
        }
        public async Task<int> AddTipAsync(TipModel tip)
        {
            return await _database.InsertAsync(tip);
        }
        public async Task<int> UpdateTipAsync(TipModel tip)
        {
            return await _database.UpdateAsync(tip);
        }
        public async Task<int> DeleteTipAsync(TipModel tip)
        {
            return await _database.DeleteAsync(tip);

        }
    }
}
