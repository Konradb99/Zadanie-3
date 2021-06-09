using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Zadanie_3.Model
{
    class Model
    {
        public ObservableCollection<Pytanie> Pytania { get; set; }
        public string nazwaPliku;
        public int wczytana = 0;
        //Dodawanie pytań
        //Dodawanie pytania do bazy danego quizu
        public ObservableCollection<Pytanie> Dodaj_pytanie(Pytanie pytanie, ObservableCollection<Pytanie> Pytania)
        {
            this.Pytania = Pytania;
            Pytania.Add(new Pytanie(pytanie));
            return Pytania;
        }
        public ObservableCollection<Pytanie> Edytuj_pytanie(Pytanie pytanie, ObservableCollection<Pytanie> Pytania, int index)
        {
            this.Pytania = Pytania;
            Pytania.RemoveAt(index);
            Pytania.Insert(index, new Pytanie(pytanie));
            return Pytania;
        }
        //Przygotowanie tablicy z odpowiedziami
        public string[] Przygotuj_odpowiedzi(string odp1, string odp2, string odp3, string odp4)
        {
            string[] odp = { odp1, odp2, odp3, odp4 };
            return odp;
        }
        //Przygotowanie pytania do dodania do bazy
        public Pytanie Przygotuj_pytanie(string nazwa, string tresc, string[] odp, int index)
        {
            Pytanie result = new Pytanie(nazwa, tresc, odp, index);
            return result;
        }

        //Operacje na pliku quizu
        //Zapis calego testu do pliku
        public void Zapis(string nazwaTestu, string nazwaPliku)
        {
            string fileName = nazwaPliku;
            fileName += ".txt";

            StreamWriter file = new StreamWriter(fileName, true, Encoding.Default);

            try
            {
                file.WriteLine(nazwaTestu);
                if (Pytania.Count() > 0)
                {
                    foreach (var item in Pytania)
                    {
                        file.WriteLine(item.WriteString());
                    }
                }
            }
            finally
            {
                file.Close();
            }
        }

        public string PobierzNazwe(string nazwaPliku)
        {
            string line;
            int counter = 0;
            this.nazwaPliku = nazwaPliku;
            try
            {
                using (StreamReader file = new StreamReader(this.nazwaPliku))
                {
                    while ((line = file.ReadLine()) != null && counter == 0)
                    {
                        this.wczytana = 1;
                        return line;
                    }
                }
                this.wczytana = 1;
            }
            catch
            {
                throw;
            }
            return line;
        }

        internal ObservableCollection<Pytanie> Odczyt(string nazwaPliku)
        {
            string line;
            int counter = 0;
            int odp_index = 0;
            this.nazwaPliku = nazwaPliku;
            Pytanie pytanko;
            Pytania.Clear();
            string[] odp = { "", "", "", "" };
            pytanko = new Pytanie("", "", odp, 0);
            using (StreamReader file = new StreamReader(this.nazwaPliku))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (counter != 0)
                    {
                        if (odp_index == 0)
                        {
                            pytanko.nazwa = line;
                            pytanko.tresc = line;
                            odp_index = odp_index + 1;
                        }
                        else if (odp_index == 1)
                        {
                            string[] answer = line.Split('|');
                            if(answer[0] == "1")
                            {
                                pytanko.poprawna = odp_index - 1;
                            }
                            pytanko.odp[odp_index - 1] = answer[1];
                            odp_index = odp_index + 1;
                        }
                        else if (odp_index == 2)
                        {
                            string[] answer = line.Split('|');
                            if (answer[0] == "1")
                            {
                                pytanko.poprawna = odp_index - 1;
                            }
                            pytanko.odp[odp_index - 1] = answer[1];
                            odp_index = odp_index + 1;
                        }
                        else if (odp_index == 3)
                        {
                            string[] answer = line.Split('|');
                            if (answer[0] == "1")
                            {
                                pytanko.poprawna = odp_index - 1;
                            }
                            pytanko.odp[odp_index - 1] = answer[1];
                            odp_index = odp_index + 1;
                        }
                        else if (odp_index == 4)
                        {
                            string[] answer = line.Split('|');
                            if (answer[0] == "1")
                            {
                                pytanko.poprawna = odp_index - 1;
                            }
                            pytanko.odp[odp_index - 1] = answer[1];
                            odp_index = odp_index + 1;
                        }
                        else if (odp_index == 5)
                        {
                            Pytania = this.Dodaj_pytanie(pytanko, Pytania);
                            string[] odp_clear = { "", "", "", "" };
                            pytanko = new Pytanie("", "", odp_clear, 0);
                            //Pytania[nr_pytania] = pytanko;
                            //nr_pytania++;
                            odp_index = 0;
                        }
                    }
                    counter++;
                }
            }
            this.wczytana = 0;
            return Pytania;
        }
    }
}
