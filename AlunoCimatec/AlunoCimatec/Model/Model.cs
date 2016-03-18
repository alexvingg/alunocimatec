using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunoCimatec.Model
{
    public abstract class Model<T> where T : new()
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int id { get; set; }


        public void Save()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(this);
                });
            }
        }

        public void Delete()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Delete(this);
                });
            }
        }

        public void Update()
        {
            using (var dbConn = new SQLiteConnection(App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Update(this);
                });
            }
        }

        public static ObservableCollection<T> All()
        {
            using (var db = new SQLiteConnection(App.DB_PATH))
            {
                List<T> myCollection = db.Table<T>().ToList<T>();
                ObservableCollection<T> listaContatos = new ObservableCollection<T>(myCollection);
                return listaContatos;
            }
        }

        public static T FindById(int idObj)
        {
            using (var db = new SQLiteConnection(App.DB_PATH))
            {

                var map = db.GetMapping(typeof(T));

                T obj = db.Query<T>(map.GetByPrimaryKeySql, idObj).First();
                return obj;
            }
        }
    }
}
