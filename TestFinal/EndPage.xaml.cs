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

namespace AlGeo
{
    /// <summary>
    /// Logique d'interaction pour EndPage.xaml
    /// </summary>
    public partial class EndPage : Page
    {
        public EndPage(int Choix)
        {
            InitializeComponent();
            if (Choix == 1)
            {
                CommentTBlk.Inlines.Clear();
                CommentTBlk.Inlines.Add(new Run("  للاسف , انتهى الوقت"));
            }
            else if (Choix == 2)
            {
                CommentTBlk.Inlines.Clear();
                CommentTBlk.Inlines.Add(new Run("احسنت ! , لقد اكملت التمرين."));
                CommentTBlk.Inlines.Add(new LineBreak());
                CommentTBlk.Inlines.Add(new Run("اضغط على الزر اسفله لاختيار التمرين التالي."));

            }

        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            //this.NavigationService.Navigate(new StartPage());
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
