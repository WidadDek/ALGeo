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
using System.Windows.Shapes;
using System.Xml;

namespace AlGeo
{
    /// <summary>
    /// Interaction logic for WilayaInforamation.xaml
    /// </summary>
    public partial class WilayaInforamation : Window
    {
        public WilayaInforamation()
        {
            InitializeComponent();
        }

        public string getWilayaInformation(int i)
        {
            string information = "";
            XmlDocument monFichier = new XmlDocument();
            monFichier.Load(@"WilayaInformation.xml");
            string str = "DZ_";
            str = str + i;
            XmlNodeList lst = monFichier.GetElementsByTagName(str);
            foreach (XmlNode c in lst)
            {
                information = c.InnerText;
            }
           
            this.nameWilayaRectangle.Fill = DZ_01.Fill;
            this.wilayaInformationRectangle.Fill = DZ_01.Fill;
            this.showImage(i);
            return information;
        }

        private static BitmapImage GetImage1(string imageUri)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageUri, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            return bitmapImage;
        }


        public void showImage(int i)
        {
            // string dz = "Dz_";
            // string path="";
            string lien = @"WilayaImage\" + i + ".jpg";
            this.wilayaImage1.Source = GetImage1(lien);


            // path = dz+ + i+ ".Fill";
            //.NavigationService.Navigate(new Uri(path, UriKind.Relative));
        }

        private void DZ_01_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_01.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(1);
            //this.wilayaImage1.Source = GetImage1();
 
            this.showImage(1);
        }







        private void DZ_02_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_02.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(2);
            this.showImage(2);
            //this.AlgerPath.Fill = Brushes.Orange;
            this.nameWilayaRectangle.Fill = DZ_02.Fill;
            this.wilayaInformationRectangle.Fill = DZ_02.Fill;
        }

        private void DZ_03_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_03.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(3);
            this.showImage(3);
        }

        private void DZ_04_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_04.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(4);
            this.showImage(4);
        }

        private void DZ_05_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_05.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(5);
            this.showImage(5);
        }

        private void DZ_06_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_06.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(6);
            this.showImage(6);
        }

        private void DZ_07_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_07.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(7);
            this.showImage(7);
        }

        private void DZ_08_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_08.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(8);
            this.showImage(8);
        }

        private void DZ_09_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_09.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(9);
            this.showImage(9);
        }

        private void DZ_10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_10.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(10);
            this.showImage(10);
        }

        private void DZ_11_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_11.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(11);
            this.showImage(11);
        }

        private void DZ_12_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_12.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(12);
            this.showImage(12);
        }

        private void DZ_13_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_13.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(13);
        }

        private void DZ_14_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_14.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(14);
        }

        private void DZ_15_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_15.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(15);
        }

        private void DZ_16_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_16.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(16);
        }

        private void DZ_17_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_17.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(17);
        }

        private void DZ_18_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_18.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(18);
        }

        private void DZ_19_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_19.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(19);
        }

        private void DZ_20_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_20.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(20);
        }

        private void DZ_21_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_21.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(21);
        }

        private void DZ_22_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_22.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(22);
        }

        private void DZ_23_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_23.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(23);
        }

        private void DZ_24_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_24.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(24);
        }

        private void DZ_25_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_25.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(25);
        }

        private void DZ_26_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_26.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(26);
        }

        private void DZ_27_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_27.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(27);
        }

        private void DZ_28_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_28.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(28);
        }

        private void DZ_29_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_29.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(29);
        }

        private void DZ_30_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_30.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(30);
        }

        private void DZ_31_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_31.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(31);
        }

        private void DZ_32_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_32.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(32);
        }

        private void DZ_33_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_33.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(33);
        }

        private void DZ_34_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_34.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(34);
        }

        private void DZ_35_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_35.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(35);
        }

        private void DZ_36_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_36.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(36);
        }

        private void DZ_37_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_37.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(37);
        }

        private void DZ_38_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_38.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(38);
        }

        private void DZ_39_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_39.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(39);
        }

        private void DZ_40_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_40.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(40);
        }

        private void DZ_41_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_41.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(41);
        }

        private void DZ_42_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_42.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(42);
        }

        private void DZ_43_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_43.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(43);
        }

        private void DZ_44_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_44.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(44);
        }

        private void DZ_45_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_45.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(45);
        }

        private void DZ_46_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_46.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(46);
        }

        private void DZ_47_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_47.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(47);
        }

        private void DZ_48_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.nameOfWilaya.Text = this.DZ_48.ToolTip.ToString();
            this.wilayaInformation.Text = getWilayaInformation(48);
        }
        private void buttonExitMessageBox_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App.mainWindow.mainFrame.NavigationService.Navigate(new InterfaceHomePage());
            App.mainWindow.Show();
            this.Close();
        }
    }
}
