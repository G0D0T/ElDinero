using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dinero.Data
{
    //Metodi da implementare all'interno di Android e iOS
    public interface ISQLite
    {
        SQLiteConnection GetConnectionContanti();
        SQLiteConnection GetConnectionCarta();
    }
}
