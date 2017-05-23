using Churchplus_Records.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Churchplus_Records.Data
{
    public class RecordRepository
    {
        SQLiteConnection database;

        public RecordRepository(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<Record>();
        }

        public List<Record> GetAllRecords()
        {
            return database.Table<Record>().ToList();
        }

        public List<Record> GetExpiredRecords()
        {
            var result = database.Table<Record>().Where(s => s.Expired == true).ToList();

            return result;
        }
        public Record GetSingleRecord(int id)
        {
            return database.Table<Record>().Where(i => i.ID == id).FirstOrDefault();

        }
        public int SaveRecord(Record record)
        {
            if (record.ID != 0)
            {
                return database.Update(record);
            }
            else
            {
                return database.Insert(record);
            }
        }

        public int DeleteRecord(Record record)
        {
            return database.Delete(record);
        }
    }
}
