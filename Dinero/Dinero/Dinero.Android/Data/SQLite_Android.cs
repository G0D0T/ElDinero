using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Dinero.Data;
using System.IO;
using Xamarin.Forms;
using Dinero.Droid.Data;

[assembly: Dependency(typeof(SQLite_Android))]

namespace Dinero.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }

        //Definisco il percorso del database dei contanti
        public SQLite.SQLiteConnection GetConnectionContanti()
        {
            var sqliteFilename = "contantidb.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }

        //Definisco il percorso del database delle carte
        public SQLite.SQLiteConnection GetConnectionCarta()
        {
            var sqliteFilename = "cartadb.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}