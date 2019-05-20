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
    /// Interaction logic for Exercice3.xaml
    /// </summary>
    public partial class Coloriage : Window
    {
        public Coloriage()
        {
            InitializeComponent();
            Coriger.Visibility = Visibility.Hidden;
        }





        private void Rect_MLButtonDown(object sender, MouseButtonEventArgs e)  // POUR POUVOIR PRENDRE LA COLEUR DU RECTANGLES DE COLEURS 
        {
            Rectangle rc = sender as Rectangle;
            DataObject data = new DataObject(rc.Fill);

            DragDrop.DoDragDrop(rc, data, DragDropEffects.Move);
        }


        private void Target_Drop3(object sender, DragEventArgs e)  // LA COLORISATION D'UNE PARTIE DE LA CARTE 
        {

            SolidColorBrush scb = (SolidColorBrush)e.Data.GetData(typeof(SolidColorBrush));
            pathMapAlgeria3.Fill = scb;

        }
        private void Target_Drop2(object sender, DragEventArgs e) // LA COLORISATION D'UNE PARTIE DE LA CARTE 
        {

            SolidColorBrush scb = (SolidColorBrush)e.Data.GetData(typeof(SolidColorBrush));
            pathMapAlgeria2.Fill = scb;

        }
        private void Target_Drop5(object sender, DragEventArgs e) // LA COLORISATION D'UNE PARTIE DE LA CARTE 
        {

            SolidColorBrush scb = (SolidColorBrush)e.Data.GetData(typeof(SolidColorBrush));
            pathMapAlgeria5.Fill = scb;

        }




        private void pathMapAlgeria2_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void pathMapAlgeria5_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void pathMapAlgeria3_MouseEnter(object sender, MouseEventArgs e)
        {


        }
        private void richTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.Show();
            this.Close();
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            Valider.IsEnabled = false;
            Valider.Visibility = Visibility.Hidden;
            Coriger.Visibility = Visibility.Visible;


        }

        private void Corriger_Click(object sender, RoutedEventArgs e)
        {
            pathMapAlgeria3.Fill = Brushes.DarkCyan;
            pathMapAlgeria2.Fill = Brushes.Orange;
            pathMapAlgeria5.Fill = Brushes.Green;
        }
    }
}

