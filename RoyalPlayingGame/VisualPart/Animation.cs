﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace VisualPart
{
    public enum AnimationMode { Loop, Once }
    public class Animation
    {
        private Animation() { }
        public Animation(string folder, int delay)
        {
            frames = new List<Image>();
            Folder = folder;
            updateFrameTimer = new Timer();
            Delay = delay;
            updateFrameTimer.Interval = Delay;
            updateFrameTimer.Tick += OnUpdateFrame;
            Mode = AnimationMode.Loop;
            IsActive = true;

            GetFrames();
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

        private void OnUpdateFrame(object sender, EventArgs e)
        {
            if (currentFrameIndex == -1)
                return;

            currentFrameIndex++;
            if (currentFrameIndex >= frames.Count)
            {
                if (Mode == AnimationMode.Loop)
                    currentFrameIndex = 0;
                else
                {
                    IsActive = false;
                    AnumationEnd?.Invoke();
                    Stop();
                    return;
                }
            }
            CurrentFrame = frames[currentFrameIndex];
        }

        public AnimationMode Mode { get; set; }
        public bool IsActive { get; set; } 

        int Delay { get; set; }
        List<Image> frames;
        public Image CurrentFrame { get; private set; }
        int currentFrameIndex;
        string Folder { get; set; }


        Timer updateFrameTimer;

        private void GetFrames()
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
                i.MakeTransparent(Color.White);
                frames.Add(i);
                frameNum++;
            }
        }
        public void Start()
        {
            currentFrameIndex = 0;
            updateFrameTimer.Start();
            IsActive = true;
        }
        public void Stop()
        {
            updateFrameTimer.Stop();
        }
        public event Action AnumationEnd;
    }
}
