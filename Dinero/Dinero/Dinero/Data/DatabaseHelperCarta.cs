using Dinero.Model;
using SQLite;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Dinero.Data
{
    public class DatabaseHelperCarta
    {
        static object locker = new object(); //da sostituire eventualmente con costrutto using
        SQLiteConnection db; //Variabile per la connessione al db

        public DatabaseHelperCarta()
        {
            //Prendo il percorso del db e, se non esiste, creo la tabella
            db = DependencyService.Get<ISQLite>().GetConnectionCarta();
            db.CreateTable<Transazione>();
        }

        //Funzione per ricevere in output la lista delle transazioni, eventualmente valutando il filtro in input (param)
        public List<Transazione> GetTransazioni(int param)
        {
            lock (locker)
            {
                /*if (db.Table<Transazione>().Count() == 0)
                {
                    return null;
                }
                else*/ if (param == 0)
                {
                    db.CreateTable<Transazione>();
                    return db.Query<Transazione>("SELECT * FROM Transazione ORDER BY Id DESC").ToList();
                }
                else if (param == 1)
                {
                    db.CreateTable<Transazione>();
                    return db.Query<Transazione>("SELECT * FROM Transazione WHERE date(Quando) > date('now','-7 days') ORDER BY Id DESC").ToList();
                }
                else
                {
                    db.CreateTable<Transazione>();
                    return db.Query<Transazione>("SELECT * FROM Transazione WHERE date(Quando) > date('now','-1 month') ORDER BY Id DESC").ToList();
                }
            }
        }

        //Funzione per aggiungere una nuova transazione
        public int AddTransazione(Transazione tr)
        {
            lock(locker)
            {
                if (tr.Id != 0)
                {
                    db.Update(tr);
                    return tr.Id;
                }
                else
                {
                    return db.Insert(tr);
                }

            }
        }

        //Funzione per cancellare una transazione esistente
        public int DeleteTransazione(object tr)
        {
            lock(locker)
            {
                return db.Delete(tr);
            }
        }

        //Richiamo una query per definire il totale delle transazioni > 0, eventualmente valutando il filtro in input (param)
        public double QueryEntrata(int param)
        {
            lock (locker)
            {
                double d;
                try
                {
                    if (param == 0)
                    {
                        d = db.ExecuteScalar<double>("SELECT SUM(Importo) FROM Transazione WHERE Importo > 0");
                    }
                    else if (param == 1)
                    {
                        d = db.ExecuteScalar<double>("SELECT SUM(Importo) FROM Transazione WHERE date(Quando) > date('now','-7 days') AND Importo > 0");
                    }
                    else
                    {
                        d = db.ExecuteScalar<double>("SELECT SUM(Importo) FROM Transazione WHERE date(Quando) > date('now','-1 month') AND Importo > 0");
                    }
                    return d;
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        //Richiamo una query per definire il totale delle transazioni < 0, eventualmente valutando il filtro in input (param)
        public double QueryUscita(int param)
        {
            lock (locker)
            {
                double d;
                try
                {
                    if (param == 0)
                    {
                        d = db.ExecuteScalar<double>("SELECT SUM(Importo) FROM Transazione WHERE Importo < 0");
                    }
                    else if (param == 1)
                    {
                        d = db.ExecuteScalar<double>("SELECT SUM(Importo) FROM Transazione WHERE date(Quando) > date('now','-7 days') AND Importo < 0");
                    }
                    else
                    {
                        d = db.ExecuteScalar<double>("SELECT SUM(Importo) FROM Transazione WHERE date(Quando) > date('now','-1 month') AND Importo < 0");
                    }
                    return d;
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        //Funzione per cancellare interamente la tabella carta
        public int DropCarta()
        {
            lock (locker)
            {
                return db.DropTable<Transazione>();
            }
        }
    }
}
