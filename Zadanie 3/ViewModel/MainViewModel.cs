using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Input;
using Zadanie_3.Model;
using Zadanie_3.ViewModel.BaseClass;
using Microsoft.Win32;

namespace Zadanie_3.ViewModel
{
    using Zadanie_3.Model;
    using BaseClass;
    class MainViewModel : ViewModelBase
    {
        private Model model = new Model();
        public addViewModel addVM { get; set; }
        public quizViewModel quizVM { get; set; }

        private int ladujPytania;

        public int LadujPytania
        {
            get { return ladujPytania; }
            set
            {
                if (ladujPytania != value)
                {
                    ladujPytania = value;
                    onPropertyChanged(nameof(LadujPytania));
                    switch (value)
                    {
                        case 1:
                            addVM.Laduj_pytania();
                            break;
                    }
                }
            }
        }
        public MainViewModel()
        {
            addVM = new addViewModel(model);
            quizVM = new quizViewModel(model);
        }
    }
}