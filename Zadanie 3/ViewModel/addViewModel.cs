using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Zadanie_3.ViewModel
{
    using Model;
    using BaseClass;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

    class addViewModel : ViewModelBase
    {
        #region Parametry

        #region prywatne
        private Model model = null;
        private string nazwa = "", nazwaTestu = "";
        private string tresc = "";
        private string odp1 = "", odp2 = "", odp3 = "", odp4 = "";
        private int poprawnyIndex;
        public ObservableCollection<Pytanie> Pytania { get; set; }
        #endregion

        #region definicje publiczne
        public int PoprawnyIndex
        {
            get
            {
                return poprawnyIndex;
            }
            set
            {
                poprawnyIndex = value;
                onPropertyChanged(nameof(PoprawnyIndex));
            }
        }
        public string Tresc
        {
            get { return tresc; }
            set
            {
                tresc = value;
                onPropertyChanged(nameof(Tresc));
            }
        }
        public string Nazwa
        {
            get { return nazwa; }
            set
            {
                nazwa = value;
                onPropertyChanged(nameof(Nazwa));
            }
        }
        public string NazwaTestu
        {
            get { return nazwaTestu; }
            set
            {
                nazwaTestu = value;
                onPropertyChanged(nameof(NazwaTestu));
            }
        }
        public string Odp1
        {
            get { return odp1; }
            set
            {
                odp1 = value;
                onPropertyChanged(nameof(Odp1));
            }
        }
        public string Odp2
        {
            get { return odp2; }
            set
            {
                odp2 = value;
                onPropertyChanged(nameof(Odp2));
            }
        }
        public string Odp3
        {
            get { return odp3; }
            set
            {
                odp3 = value;
                onPropertyChanged(nameof(Odp3));
            }
        }
        public string Odp4
        {
            get { return odp4; }
            set
            {
                odp4 = value;
                onPropertyChanged(nameof(Odp4));
            }
        }
        private int idZaznaczenia;
        public int IDZaznaczenia
        {
            get { return idZaznaczenia; }
            set
            {
                if (value == idZaznaczenia) return;
                idZaznaczenia = value;
                onPropertyChanged(nameof(IDZaznaczenia));
                Nazwa = WybranePytanie.nazwa;
                Tresc = WybranePytanie.tresc;
                Odp1 = WybranePytanie.odp[0];
                Odp2 = WybranePytanie.odp[1];
                Odp3 = WybranePytanie.odp[2];
                Odp4 = WybranePytanie.odp[3];
            }
        }
        #endregion
        #region ListBox
        private Pytanie wybranePytanie;
        public Pytanie WybranePytanie
        {
            get { return wybranePytanie;  }
            set
            {
                if (value == wybranePytanie) return;
                wybranePytanie = value;
                onPropertyChanged(nameof(WybranePytanie));
                Nazwa = WybranePytanie.nazwa;
                Tresc = WybranePytanie.tresc;
                Odp1 = WybranePytanie.odp[0];
                Odp2 = WybranePytanie.odp[1];
                Odp3 = WybranePytanie.odp[2];
                Odp4 = WybranePytanie.odp[3];
            }
        }
        #endregion
        #endregion
        #region Metody
        private ICommand dodaj = null;
        public ICommand Dodaj 
        {
            get
            {
                if (dodaj == null)
                {
                    dodaj = new RelayCommand(
                        arg =>
                        {
                            string[] odp = model.Przygotuj_odpowiedzi(Odp1, Odp2, Odp3, Odp4);
                            Pytanie pytanko = model.Przygotuj_pytanie(Nazwa, Tresc, odp, PoprawnyIndex);
                            Pytania = model.Dodaj_pytanie(pytanko, Pytania);
                        }
                        ,
                        arg => ((Nazwa != "") && (Tresc != "") && (Odp1 != "") && (Odp2 != "") && (Odp3 != "") && (Odp4 != "")) ? true : false
                        );
                }
                return dodaj;
            }
        }
        private ICommand edytuj = null;
        public ICommand Edytuj
        {
            get
            {
                if (edytuj == null)
                {
                    edytuj = new RelayCommand(
                        arg =>
                        {
                            string[] odp = model.Przygotuj_odpowiedzi(Odp1, Odp2, Odp3, Odp4);
                            Pytanie pytanko = model.Przygotuj_pytanie(Nazwa, Tresc, odp, PoprawnyIndex);
                            Pytania = model.Edytuj_pytanie(pytanko, Pytania, IDZaznaczenia);
                        }
                        ,
                        arg => ((Nazwa != "") && (Tresc != "") && (Odp1 != "") && (Odp2 != "") && (Odp3 != "") && (Odp4 != "")) ? true : false
                        );
                }
                return edytuj;
            }
        }

        private RelayCommand radiopoprawna;
        public ICommand RadioPoprawna
        {
            get
            {
                return radiopoprawna ?? (radiopoprawna = new RelayCommand(poprawna, p => true
                                                                         )
                                        );
            }
        }
        private void poprawna(object obj)
        {
            if (obj == null)
            {
                return;
            }
            if (!int.TryParse(obj.ToString(), out int poprawna_odp))
            {
                return;
            }
            PoprawnyIndex = poprawna_odp - 1;
        }
        public void Laduj_pytania()
        {
            if(model.nazwaPliku != "" && model.nazwaPliku != null && model.wczytana == 1)
            {
                Pytania = model.Odczyt(model.nazwaPliku);
            }
        }
        #endregion
        #region konstruktory
        public addViewModel(Model model)
        {
            //Dodac metode w model do odczytu z pliku
            this.model = model;
            Pytania = new ObservableCollection<Pytanie>();
        }
        #endregion
    }
}



//TODO LIST

    // -> Edycja istniejacych pytan