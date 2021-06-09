using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_3.Model
{
    class Pytanie
    {
        public string nazwa;
        public string tresc;
        public string[] odp;
        public int poprawna;

        public Pytanie(string nazwa, string tresc, string[] odp, int indexpoprawny)
        {
            this.nazwa = nazwa;
            this.tresc = tresc;
            this.odp = odp;
            this.poprawna = indexpoprawny;
        }

        public Pytanie(Pytanie pytanie)
        {
            this.nazwa = pytanie.nazwa;
            this.tresc = pytanie.tresc;
            this.odp = pytanie.odp;
            this.poprawna = pytanie.poprawna;
        }

        public Pytanie()
        {
            this.nazwa = "";
            this.tresc = "";
            this.odp[0] = "";
            this.odp[1] = "";
            this.odp[2] = "";
            this.odp[3] = "";
            this.poprawna = 0;
        }

        //Dodac metode do formatowania do zapisu
        public string WriteString()
        {
            string writeString = $"{this.tresc}\n";
            switch (poprawna)
            {
                case 0:
                    for(int i = 0; i < this.odp.Length; i++)
                    {
                        if (i == 0)
                        {
                            writeString += $"1|{this.odp[i]}\n";
                        }
                        else
                        writeString += $"0|{this.odp[i]}\n";
                    }
                    break;
                case 1:
                    for (int i = 0; i < this.odp.Length; i++)
                    {
                        if (i == 1)
                        {
                            writeString += $"1|{this.odp[i]}\n";
                        }
                        else
                            writeString += $"0|{this.odp[i]}\n";
                    }
                    break;
                case 2:
                    for (int i = 0; i < this.odp.Length; i++)
                    {
                        if (i == 2)
                        {
                            writeString += $"1|{this.odp[i]}\n";
                        }
                        else
                            writeString += $"0|{this.odp[i]}\n";
                    }
                    break;
                case 3:
                    for (int i = 0; i < this.odp.Length; i++)
                    {
                        if (i == 3)
                        {
                            writeString += $"1|{this.odp[i]}\n";
                        }
                        else
                            writeString += $"0|{this.odp[i]}\n";
                    }
                    break;
            }
            writeString += "**********";
            return writeString;
        }

        //ToString -> Do wyswietlenia nazwy pytania przy edycji/dodawaniu
        public override string ToString()
        {
            return $"{nazwa}";
        }


    }
}
