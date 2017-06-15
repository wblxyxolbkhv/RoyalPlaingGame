using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StartUpProject.Scripts;
using RoyalPlayingGame;

/* Назначение: Глобаный класс для взаимодейтсвия между формой и уровнями
 * Автор: Никитенко А.В.
 */

namespace StartUpProject.GlobalGameComponents
{
    static class Game
    {
        public static void Start()
        {
            CurrentTime = DateTime.Now;
            ItemsManager.Init();
            ScriptManager.Init();
            GameLevel = new StartLevel();
            GameLevel.Interval = Interval;
            MainForm = new MainForm(GameLevel);


            Timer.Tick += GameLevel.OnRefresh;
            Timer.Tick += MainForm.T_Tick;
            Timer.Tick += OnMainTimerTick;
            Timer.Tick += ScriptManager.OnRefresh;
            Timer.Interval = Interval;
            Timer.Start();
            
            


            Application.Run(MainForm);
                  
        }

        

        private static MainForm MainForm;
        private static GameLevel GameLevel;

        static Timer Timer = new Timer();
        private static int Interval = 20;
        private static TimeSpan timeSpan;


        public static DateTime CurrentTime;
        public static int DeltaTime;

        private static void OnMainTimerTick(object sender, EventArgs e)
        {
            timeSpan = DateTime.Now - CurrentTime;
            DeltaTime = timeSpan.Milliseconds;
            CurrentTime = DateTime.Now;
            if (newLevelName != null)
                SetLevel(newLevelName);
        }

        static string newLevelName = null;
        /// <summary>
        /// установка следующего уровня из другого потока
        /// </summary>
        /// <param name="levelName"></param>
        public static void SetLevelInOtherThread(string levelName)
        {
            newLevelName = levelName;
        }
        public static void SetControlVisible(bool turn)
        {
            MainForm.SetControlVisible(turn);
        }
        /// <summary>
        /// переключение возможности управления игроком
        /// </summary>
        public static void SetControlAvaible(bool turn)
        {
            GameLevel.IsControlStop = !turn;
        }
        /// <summary>
        /// установка следующего уровня
        /// </summary>
        /// <param name="levelName"></param>
        public static void SetLevel(string levelName)
        {
            switch (levelName)
            {
                case "start":
                    break;
                case "default":
                    MainForm.ResetLevel(GameLevel);
                    Timer.Tick -= GameLevel.OnRefresh;
                    GameLevel = null;
                    //GC.Collect();


                    GameLevel = new GameLevel();
                    GameLevel.Interval = Interval;
                    MainForm.SetLevel(GameLevel);
                    Timer.Tick += GameLevel.OnRefresh;
                    break;
            }
            newLevelName = null;
        }
    }
}
