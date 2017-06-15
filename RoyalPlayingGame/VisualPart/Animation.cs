using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
/* Назначение: Класс для анимации
 * Автор: Никитенко А.В.
 */
namespace VisualPart
{
    public enum AnimationMode { Loop, Once }
    public class Animation
    {
        private Animation() { }
        /// <summary>
        /// обычная загрузка из папки
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="delay"></param>
        public Animation(string folder, int delay)
        {
            frames = new List<Image>();
            Folder = folder;
            //updateFrameTimer = new Timer();
            Delay = delay;
            //updateFrameTimer.Interval = Delay;
            //updateFrameTimer.Tick += OnUpdateFrame;
            Mode = AnimationMode.Loop;
            IsActive = true;

            GetFrames(Color.White);
            if (frames.Count == 0)
            {
                CurrentFrame = null;
                currentFrameIndex = -1;
            }
            else
            {
                CurrentFrame = frames[0];
                currentFrameIndex = 0;
            }
        }
        /// <summary>
        /// загрузка из папки с указанием какой цвет надо считать прозрачным на фреймах (по умолчанию белый)
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="delay"></param>
        /// <param name="c"></param>
        public Animation(string folder, int delay, Color c)
        {
            frames = new List<Image>();
            Folder = folder;
            //updateFrameTimer = new Timer();
            Delay = delay;
            //updateFrameTimer.Interval = Delay;
            //updateFrameTimer.Tick += OnUpdateFrame;
            Mode = AnimationMode.Loop;
            IsActive = true;

            GetFrames(c);
            if (frames.Count == 0)
            {
                CurrentFrame = null;
                currentFrameIndex = -1;
            }
            else
            {
                CurrentFrame = frames[0];
                currentFrameIndex = 0;
            }
        }
        /// <summary>
        ///  тестовая перегрузка для загрузки фреймов из ресурсов
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="name"></param>
        public Animation(int delay, string name)
        {
            frames = new List<Image>();
            //Folder = folder;
            //updateFrameTimer = new Timer();
            Delay = delay;
            //updateFrameTimer.Interval = Delay;
            //updateFrameTimer.Tick += OnUpdateFrame;
            Mode = AnimationMode.Loop;
            IsActive = true;

            GetFramesFromResources(name);
            if (frames.Count == 0)
            {
                CurrentFrame = null;
                currentFrameIndex = -1;
            }
        }

        private void GetFrames(Color c)
        {
            int frameNum = 0;
            while (true)
            {
                Bitmap i = null;
                try
                {
                    i = (Bitmap)Image.FromFile(Folder + @"/" + frameNum + ".png");
                }
                catch
                {
                    break;
                }
                i.MakeTransparent(c);
                frames.Add(i);
                frameNum++;
            }
        }
        private void GetFramesFromResources(string name)
        {
            int frameNum = 0;
            while (true)
            {
                Bitmap i = null;
                try
                {
                    //i = (Bitmap)Image.FromFile(Folder + @"/" + frameNum + ".png");
                    i = (Bitmap)VisualPart.Properties.Resources.ResourceManager.GetObject(name + "_" + frameNum.ToString());
                    if (i == null)
                        break;
                }
                catch
                {
                    break;
                }
                i.MakeTransparent(Color.White);
                frames.Add(i);
                frameNum++;
            }
        }

        //private void OnUpdateFrame(object sender, EventArgs e)
        public void OnUpdateFrame(int deltaTime)
        {
            if (!IsActive)
                return;
            if (currentFrameIndex == -1)
                return;
            if (currentDelay >= Delay)
            {
                currentDelay = 0;
                currentFrameIndex++;
                if (currentFrameIndex >= frames.Count)
                {
                    if (Mode == AnimationMode.Loop)
                        currentFrameIndex = 0;
                    else
                    {
                        IsActive = false;
                        AnimationEnd?.Invoke();
                        Stop();
                        return;
                    }
                }
                CurrentFrame = frames[currentFrameIndex];
            }
            else
                currentDelay += deltaTime;
        }

        public AnimationMode Mode { get; set; }
        public bool IsActive { get; set; } = true;

        int Delay { get; set; }
        List<Image> frames;
        public Image CurrentFrame { get; private set; }
        int currentFrameIndex;
        string Folder { get; set; }




        //Timer updateFrameTimer;
        int currentDelay;

        public void Start()
        {
            currentFrameIndex = 0;
            CurrentFrame = frames[0];
            //updateFrameTimer.Start();
            currentDelay = 0;
            IsActive = true;
        }
        public void Stop()
        {
            currentFrameIndex = 0;
            currentDelay = 0;
            //updateFrameTimer.Stop();
            IsActive = false;
        }
        public event Action AnimationEnd;
    }
}
