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

namespace AlGeo.Chapitre2.Cours
{
    /// <summary>
    /// Logique d'interaction pour Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        // <summary>
        /// Logique d'interaction pour Page14.xaml
        /// </summary>
        public Page2()
        {
            InitializeComponent();

        }
        private static BitmapImage GetImage1(string imageUri)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageUri, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            return bitmapImage;
        }



        private void ellipse1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.imageArrow1.Visibility = Visibility.Visible;
            this.imageArrow2.Visibility = Visibility.Hidden;
            this.imageArrow3.Visibility = Visibility.Hidden;
            this.imageArrow4.Visibility = Visibility.Hidden;
            this.imageArrow5.Visibility = Visibility.Hidden;
            this.imageArrow6.Visibility = Visibility.Hidden;
            this.txtInformation2.Text = "الجزائر العاصمة كمية التساقط و الحرارة فيها معتدلين";
            imageInformation.Source = GetImage1(@"..\Images\sun.png");
        }

        private void ellipse2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.imageArrow1.Visibility = Visibility.Hidden;
            this.imageArrow2.Visibility = Visibility.Visible;
            this.imageArrow3.Visibility = Visibility.Hidden;
            this.imageArrow4.Visibility = Visibility.Hidden;
            this.imageArrow5.Visibility = Visibility.Hidden;
            this.imageArrow6.Visibility = Visibility.Hidden;
            this.txtInformation2.Text = "وهران ولاية ساحلية, تعرف باعتدال مناخها, كمية تساقط الأمطار فيها مرتفعة جدا";
            imageInformation.Source = GetImage1(@"..\Images\pluie.png");
        }

        private void ellipse3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.imageArrow1.Visibility = Visibility.Hidden;
            this.imageArrow2.Visibility = Visibility.Hidden;
            this.imageArrow3.Visibility = Visibility.Visible;
            this.imageArrow4.Visibility = Visibility.Hidden;
            this.imageArrow5.Visibility = Visibility.Hidden;
            this.imageArrow6.Visibility = Visibility.Hidden;
            this.txtInformation2.Text = "النعامة مدينة داخلية تعرف ارتفاع شديد لدرجة الحرارة";
            imageInformation.Source = GetImage1(@"..\Images\soleil.png");
        }

        private void ellipse4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.imageArrow1.Visibility = Visibility.Hidden;
            this.imageArrow2.Visibility = Visibility.Hidden;
            this.imageArrow3.Visibility = Visibility.Hidden;
            this.imageArrow4.Visibility = Visibility.Visible;
            this.imageArrow5.Visibility = Visibility.Hidden;
            this.imageArrow6.Visibility = Visibility.Hidden;
            this.txtInformation2.Text = "سطيف ولاية داخلية, تتميز بحرارة مرتفعة صيفا وبرودة شتاء";
            imageInformation.Source = GetImage1(@"..\Images\pluie.png");
        }

        private void ellipse6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.imageArrow1.Visibility = Visibility.Hidden;
            this.imageArrow2.Visibility = Visibility.Hidden;
            this.imageArrow3.Visibility = Visibility.Hidden;
            this.imageArrow4.Visibility = Visibility.Hidden;
            this.imageArrow5.Visibility = Visibility.Hidden;
            this.imageArrow6.Visibility = Visibility.Visible;
            this.txtInformation2.Text = "عنابة مدينة ساحلية و مشمسة, كمية تساقط الأمطار فيها معتدلة";
            imageInformation.Source = GetImage1(@"..\Images\sun.png");
        }

        private void ellipse5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.imageArrow1.Visibility = Visibility.Hidden;
            this.imageArrow2.Visibility = Visibility.Hidden;
            this.imageArrow3.Visibility = Visibility.Hidden;
            this.imageArrow4.Visibility = Visibility.Hidden;
            this.imageArrow5.Visibility = Visibility.Visible;
            this.imageArrow6.Visibility = Visibility.Hidden;
            this.txtInformation2.Text = "تبسة ولاية داخلية تعرف تساقط الثلوج و الأمطار بغزارة  ";
            imageInformation.Source = GetImage1(@"..\Images\Cloud.png");
        }

        private void HelpButton_MouseLeave(object sender, MouseEventArgs e)
        {
            this.InfoBulleGrid.Visibility = Visibility.Hidden;
        }

        private void HelpButton_MouseMove(object sender, MouseEventArgs e)
        {
            this.InfoBulleGrid.Visibility = Visibility.Visible;
        }
    }
}