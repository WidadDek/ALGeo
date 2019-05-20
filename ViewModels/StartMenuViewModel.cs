using System;
using AlGeo.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlGeo.ViewModels
{
    public class StartMenuViewModel
    {
        private MemoryGame _mainWindow;
        public StartMenuViewModel(MemoryGame main)
        {
            _mainWindow = main;
            SoundManager.PlayBackgroundMusic();
        }

        public void StartNewGame(int categoryIndex)
        {
            var category = (SlideCategories)categoryIndex;
            GameViewModel newGame = new GameViewModel(category);
            _mainWindow.DataContext = newGame;
        }
    }
}
