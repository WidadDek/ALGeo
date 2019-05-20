using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media.Imaging;

namespace AlGeo
{
    class Animations
    {

        /* afficher des images a un instant/ event precis selon le chemin ( uri ) relatif donné */ 
        public static BitmapImage GetImage(string imageUri)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageUri, UriKind.RelativeOrAbsolute);
            bitmapImage.EndInit();
            return bitmapImage;
        }

      
        /**  ajouter des sons aux boutons selons leurs types **/ 
        public static void AddSound(int i)
        {
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();

            switch (i)
            {
                /* button Click */ 
                case 1:                                    
                    sp.SoundLocation = @"Sounds\CLICK.WAV";
                    sp.Play();
                    break; 
                /* Load Page */
                case 2:                   
                    sp.SoundLocation = @"Sounds\CHIMES.WAV";
                    sp.Play();
                    break;

                /* Applaudissement */
                case 3:
                    sp.SoundLocation = @"Sounds\APPLAUSE.WAV";
                    sp.Play();
                    break;

            }
        }
    }
}
