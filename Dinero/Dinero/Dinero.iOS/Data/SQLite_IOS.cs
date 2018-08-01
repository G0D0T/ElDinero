using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Dinero.Data;
using Dinero.iOS.Data;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_IOS))]

namespace Dinero.iOS.Data
{
    public class SQLite_IOS : ISQLite
    {
        public SQLite_IOS() { }

        //Definisco il percorso del database dei contanti
        public SQLite.SQLiteConnection GetConnectionContanti()
        {
            var sqliteFileName = "contantidb.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }

        //Definisco il percorso del database delle carte
        public SQLite.SQLiteConnection GetConnectionCarta()
        {
            var sqliteFileName = "cartadb.db3";
            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }

    }
}