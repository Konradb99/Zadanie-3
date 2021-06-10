using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadanie_3.View
{
    /// <summary>
    /// Logika interakcji dla klasy QuestionView.xaml
    /// </summary>
    public partial class QuestionView : UserControl
    {
        public QuestionView()
        {
            InitializeComponent();
        }


        //TRESC PYTANIA
        public static readonly DependencyProperty tresc_pytania =
            DependencyProperty.Register(
                nameof(tresc_zapytania),
                typeof(string),
                typeof(QuestionView)
            );


        public string tresc_zapytania
        {
            get { return (string)GetValue(tresc_pytania); }
            set
            {
                SetValue(tresc_pytania, value);
            }
        }


        //NAZWA PYTANIA
        public static readonly DependencyProperty nazwa_pytania =
            DependencyProperty.Register(
                nameof(nazwa_zapytania),
                typeof(string),
                typeof(QuestionView)
            );


        public string nazwa_zapytania
        {
            get { return (string)GetValue(nazwa_pytania); }
            set
            {
                SetValue(nazwa_pytania, value);
            }
        }
        public static readonly DependencyProperty Odp_1_DP =
            DependencyProperty.Register(
                nameof(odpowiedz_1),
                typeof(string),
                typeof(QuestionView)
            );


        //ODPOWIEDZ 1
        public string odpowiedz_1
        {
            get { return (string)GetValue(Odp_1_DP); }
            set
            {
                SetValue(Odp_1_DP, value);
            }
        }
        public static readonly DependencyProperty Odp_2_DP =
            DependencyProperty.Register(
                nameof(odpowiedz_2),
                typeof(string),
                typeof(QuestionView)
            );


        //ODPOWIEDZ 2
        public string odpowiedz_2
        {
            get { return (string)GetValue(Odp_2_DP); }
            set
            {
                SetValue(Odp_2_DP, value);
            }
        }
        public static readonly DependencyProperty Odp_3_DP =
            DependencyProperty.Register(
                nameof(odpowiedz_3),
                typeof(string),
                typeof(QuestionView)
            );

        //ODPOWIEDZ 3
        public string odpowiedz_3
        {
            get { return (string)GetValue(Odp_3_DP); }
            set
            {
                SetValue(Odp_3_DP, value);
            }
        }
        public static readonly DependencyProperty Odp_4_DP =
            DependencyProperty.Register(
                nameof(odpowiedz_4),
                typeof(string),
                typeof(QuestionView)
            );

        //ODPOWIEDZ 4
        public string odpowiedz_4
        {
            get { return (string)GetValue(Odp_4_DP); }
            set
            {
                SetValue(Odp_4_DP, value);
            }
        }
    }
}
