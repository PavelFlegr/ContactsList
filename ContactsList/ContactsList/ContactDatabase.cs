using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ContactsList
{
    class ContactDatabase
    {
        private SQLiteConnection db;
        public ContactDatabase(string path)
        {
            db = new SQLiteConnection(path);
            db.CreateTable<Contact>();
        }

        public List<Contact> GetContacts()
        {
            return db.Table<Contact>().ToList();
        }

        public int SaveItem(Contact item)
        {
            if (item.ID != 0)
            {
                return db.Update(item);
            }
            else
            {
                return db.Insert(item);
            }
        }
    }
}
