using System;
using System.Collections.Generic;
using RoyalPlayingGame.Dialogs;
using System.Windows.Forms;
using SimplePhysicalEngine.NonPhysicalComponents;
using System.Drawing;
using VisualPart.UserControls;
using SimplePhysicalEngine;

namespace StartUpProject.Dialogs
{
    public class DialogManager
    {
        public Dialog Dialog
        { get; set; }
        public ComplexObject TalkingObject
        { get; set; }
        public ComplexObject Player
        { get; set; }
        public ChoiceBoxInterface ChoiceBox
        {
            get { return choiceBox; }
            set
            {
                choiceBox = value;
                choiceBox.AnswerChoosen += OnAnswerChoosen;
            }
        }
        ChoiceBoxInterface choiceBox;
        public void PrintDialog(PaintEventArgs e, int CameraBias)
        {
            if (Dialog == null || !Dialog.IsActive)
                return;
            if (Dialog.CurrentReplic is NPCReplic)
            {
                ChoiceBox.Visible = false;
                PrintDialogWindow(e, TalkingObject.RealObject.Position, CameraBias, (Dialog.CurrentReplic as NPCReplic).Phrases[0]);
            }
            else if (Dialog.CurrentReplic is PlayerChoice)
            {
                ChoiceBox.Visible = true;
                ChoiceBox.Choice = Dialog.CurrentReplic as PlayerChoice;
            }
            else if (Dialog.CurrentReplic is Answer)
            {
                ChoiceBox.Visible = false;
                PrintDialogWindow(e, Player.RealObject.Position, CameraBias, (Dialog.CurrentReplic as Answer).PlayerPhrases[0]);
            }
        }
        public void Refresh(int deltaTime)
        {
            Dialog?.OnTimerTick(deltaTime);
        }
        private void OnAnswerChoosen(Answer a)
        {
            Dialog.CurrentReplic = a;
            a.CurrentDuration = 0;
        }
        /// <summary>
        /// показывает окно с репликой с пользовательскими параметрами
        /// </summary>
        /// <param name="e"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="showPoint"></param>
        /// <param name="CameraBias"></param>
        /// <param name="text"></param>
        public void PrintDialogWindow(PaintEventArgs e, int width, int height, Vector2 showPoint, int CameraBias, string text)
        {
            PrintDialogWindow(e, width, height, showPoint, CameraBias, text, 12);
        }
        /// <summary>
        /// показывает окно с репликой с пользовательскими параметрами
        /// </summary>
        /// <param name="e"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="showPoint"></param>
        /// <param name="CameraBias"></param>
        /// <param name="text"></param>
        public void PrintDialogWindow(PaintEventArgs e, int width, int height, Vector2 showPoint, int CameraBias, string text, int size)
        {

            e.Graphics.FillRectangle(
                System.Drawing.Brushes.Black,
                (float)showPoint.X - CameraBias,
                (float)showPoint.Y,
                width,
                height);
            e.Graphics.DrawRectangle(
                System.Drawing.Pens.White,
                (float)showPoint.X - CameraBias,
                (float)showPoint.Y,
                width,
                height);

            // отступ от края коробки
            int intent = 10;
            List<string> printedStrings = new List<string>();
            if (text.Length * (size - 2) + 2 * intent >= width)
            {
                string[] strings = text.Split(' ');
                string result = "";
                foreach (string s in strings)
                {
                    if ((result.Length + s.Length + 1) * size + 2 * intent >= width)
                    {
                        printedStrings.Add(result);
                        result = s + "" ;
                    }
                    else
                    {
                        result += s + " ";
                    }
                }
                if (result != "")
                    printedStrings.Add(result);

            }
            else
            {
                printedStrings.Add(text);
            }
            for (int i = 0; i < printedStrings.Count; i++)
            {
                e.Graphics.DrawString(
                    printedStrings[i],
                    new System.Drawing.Font("Arial", size),
                    System.Drawing.Brushes.White,
                    (float)showPoint.X - CameraBias,
                    (float)showPoint.Y + i * (int)(size*1.3));
            }
        }
        /// <summary>
        /// показывает окно с репликой, автоматически подстраивая ширину и высоту
        /// </summary>
        /// <param name="e"></param>
        /// <param name="showPoint"></param>
        /// <param name="CameraBias"></param>
        /// <param name="text"></param>
        public void PrintDialogWindow(PaintEventArgs e, Vector2 showPoint, int CameraBias, string text)
        {
            // отступ от края коробки
            int intent = 10;
            // размер шрифта
            int size = 12;
            int width = 20 * size;
            List<string> printedStrings = new List<string>();
            if (text.Length * size + 2 * intent >= width)
            {
                string[] strings = text.Split(' ');
                string result = "";
                foreach (string s in strings)
                {
                    if ((result.Length + s.Length + 1) * size + 2 * intent >= width)
                    {
                        printedStrings.Add(result);
                        result = "";
                    }
                    else
                    {
                        result += s + " ";
                    }
                }
                if (result != "")
                    printedStrings.Add(result);

            }
            else
                printedStrings.Add(text);

            
            int height = printedStrings.Count * 17 + 2 * intent;
            width = printedStrings[0].Length * (size - 2) + 2 * intent;





            e.Graphics.FillRectangle(
                Brushes.Black,
                (float)showPoint.X - CameraBias,
                (float)showPoint.Y - height,
                width,
                height);
            e.Graphics.DrawRectangle(
                Pens.White,
                (float)showPoint.X - CameraBias,
                (float)showPoint.Y - height,
                width,
                height);

            
            for (int i = 0; i < printedStrings.Count; i++)
            {
                e.Graphics.DrawString(
                    printedStrings[i],
                    new Font("Arial", size),
                    Brushes.White,
                    (float)showPoint.X - CameraBias + intent,
                    (float)showPoint.Y - height + i * 16 + intent);
            }
        }
    }
}
