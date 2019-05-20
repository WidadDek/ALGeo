using System;
using System.Collections.Generic;
using System.Text;
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
	/// Interaction logic for HelpExo.xaml
	/// </summary>
	public partial class HelpExo : Window
	{     
		private List<string> colorBrushesBackground = new List<string>() { "#FF125065", "#FF112F65", "#FF304354", "#d35400", "#f1c40f", "#e74c3c", "#FF112F65", "#FF125065" };
		


		
		
		public HelpExo(int q)
		{
			 this.InitializeComponent();
			 XmlDocument monFichier = new XmlDocument();
           
            monFichier.Load("Help.xml");
            string g = "question";
            g = g +  q ;

            XmlNodeList lst = monFichier.GetElementsByTagName(g);

         
			title.Text = lst[0].InnerText;
            t1.Text = lst[1].InnerText;
            t2.Text = lst[2].InnerText;
            t3.Text = lst[3].InnerText;
            t4.Text = lst[4].InnerText;
			 t5.Text = lst[5].InnerText;
		
		}

		

		private void Exit(object sender, System.Windows.RoutedEventArgs e)
		{
				this.Close () ;
		}
		
		
	}
}