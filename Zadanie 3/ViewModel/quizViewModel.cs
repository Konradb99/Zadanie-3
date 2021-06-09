using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_3.ViewModel
{
    using Model;
    using BaseClass;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Forms;
    using System.IO;

    class quizViewModel : ViewModelBase
    {
        #region prywatne parametry
        private Model model = null;
        private string nazwaTestu, nazwaPliku;
        private OpenFileDialog openFileDialog;
        #endregion
        #region publiczne definicje
        public string NazwaTestu
        {
            get { return nazwaTestu; }
            set
            {
                nazwaTestu = value;
                onPropertyChanged(nameof(NazwaTestu));
            }
        }
        public string NazwaPliku
        {
            get { return nazwaPliku; }
            set
            {
                nazwaPliku = value;
                onPropertyChanged(nameof(NazwaPliku));
            }
        }
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
                            //Wrzucic do metody w model

                            //Model.zapisz(Nazwa testu, nazwapliku)
                            //nic nie zwraca
                            model.Zapis(NazwaTestu, NazwaPliku);
                        }
                        ,
                        arg => (NazwaTestu != "") && (NazwaPliku != "")
                        );
                }
                return dodaj;
            }
        }

        private ICommand otworz = null;
        public ICommand Otworz
        {
            get
            {
                if (otworz == null)
                {
                    otworz = new RelayCommand(
                        arg =>
                        {
                            //Odczyt z pliku
                            openFileDialog = new OpenFileDialog();
                            DialogResult result = openFileDialog.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                nazwaPliku = openFileDialog.FileName;
                            }
                            NazwaTestu = model.PobierzNazwe(nazwaPliku);

                        }
                        ,
                        arg => (NazwaTestu != "") && (NazwaPliku != "")
                        );
                }
                return otworz;
            }
        }
        #endregion
        #region konstruktory
        public quizViewModel(Model model)
        {
            //Dodac metode w model do odczytu z pliku
            this.model = model;
        }
        #endregion
    }
}
