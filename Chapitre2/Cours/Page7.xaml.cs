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
    /// Logique d'interaction pour Page7.xaml
    /// </summary>
    public partial class Page7 : Page
    {

        public Page7()
        {
            InitializeComponent();
            this.txtInformation.FontSize = 20;
            // this.arrow1.Visibility = System.Windows.Visibility.Hidden;
            // this.arrow2.Visibility = System.Windows.Visibility.Hidden;
            // this.arrow3.Visibility = System.Windows.Visibility.Hidden;
        }

        private static BitmapImage GetImage(string imageUri)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageUri, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            return bitmapImage;
        }

        private void pathMapAlgeria3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.txtInformation.FontSize = 20;

            //  this.arrow1.Visibility = System.Windows.Visibility.Visible;
            // this.arrow2.Visibility = System.Windows.Visibility.Hidden;
            // this.arrow3.Visibility = System.Windows.Visibility.Hidden;
            this.txtInformation.Text = " مناخ البحر الأبيض المتوسط : يوجد مناخ البحر الأبيض المتوسط شمال الجزائر في المنطقة الممتدة من البحر الى السلسلة الجبلية التلية";
            imageChange.Source = GetImage(@"../../Images/Interface/kipr.jpg");
            /*int milliseconds = 200000;
            Thread.Sleep(milliseconds);
            imageChange.Source = GetImage(@"../Images\Interface\poo.jpg");*/
        }

        private void pathMapAlgeria2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.txtInformation.FontSize = 20;
            //  this.arrow1.Visibility = System.Windows.Visibility.Hidden;
            // this.arrow2.Visibility = System.Windows.Visibility.Hidden;
            //this.arrow3.Visibility = System.Windows.Visibility.Visible;
            this.txtInformation.Text = "يحتل المناخ الصحراوي أكبر مساحة في الجزائر تقدر بِ %86 أي 2 مليون كلم² ،  وهو مناخ قاس جدا شديد الحرارة صيفا، وشديد البرودةِ شتاء ";
            imageChange.Source = GetImage(@"..\..\Images\Interface\desert-sahara.jpg");
        }

        private void pathMapAlgeria5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.txtInformation.FontSize = 20;

            /// this.arrow1.Visibility = System.Windows.Visibility.Hidden;
            //this.arrow2.Visibility = System.Windows.Visibility.Visible;
            //this.arrow3.Visibility = System.Windows.Visibility.Hidden;
            this.txtInformation.Text = "يسود المناخ القاري في المناطق الداخلية البعيدة عن المؤثرات البحريةيتميز بصيف حار وشتاء بارد و امطار قليلة";
            imageChange.Source = GetImage(@"../../Images/Interface/poo.jpg");
        }
    }
}
