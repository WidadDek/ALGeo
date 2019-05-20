using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlGeo
{
    /*Cette interface Exige l’implémentation de la méthode nécessaire présentée ci-dessous.*/
    interface IExerciceTypeQuestionnaire
    {
        void GetQuestionFromFile(string path);//La methode qui doit etre obligatoirement implémenté:Elle sert à recupperer lesquestion du fichier. 
    }
}
