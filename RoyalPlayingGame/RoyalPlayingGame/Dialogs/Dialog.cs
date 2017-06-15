using System.Collections.Generic;
using System.Xml;
using System;
using RoyalPlayingGame.Exceptions;
/* Назначение: Класс для диалога
 * представляет из себя граф с узлами Replic, 
 * которые могут оказаться любым из наследников
 * Автор: Никитенко А.В.
 */
namespace RoyalPlayingGame.Dialogs
{
    public class Dialog
    {
        Replic RootReplic
        {
            get;set;
        }
        public Replic CurrentReplic
        {
            get;
            set;
        }
        public bool IsActive
        {
            get; set;
        } = false;
        public string ID
        {
            get; set;
        }
        /// <summary>
        /// загрузка диалога из xml
        /// </summary>
        /// <param name="path"></param>
        public void LoadDialog(string path)
        {
            XmlDocument dialogXml = new XmlDocument();
            dialogXml.Load(path);

            XmlElement rootElement = dialogXml.DocumentElement;
            List<NPCReplic> NPCReplics = new List<NPCReplic>();
            List<PlayerChoice> choices = new List<PlayerChoice>();
            
            ID = rootElement.Attributes.GetNamedItem("id").Value;

            #region Парсинг xml
            foreach (XmlNode xnode in rootElement)
            {
                switch(xnode.Name)
                {
                    case "replic":
                        {
                            NPCReplic rep = new NPCReplic();
                            XmlNode num = xnode.Attributes.GetNamedItem("number");
                            rep.ID = ID + num.Value;
                            rep.Number = num.Value;
                            num = xnode.Attributes.GetNamedItem("next");
                            rep.Next = num.Value;
                            XmlNode newQuest = xnode.Attributes.GetNamedItem("newQuest");
                            if (newQuest != null)
                                rep.ReceiveQuest = newQuest.Value;
                            XmlNode passQuest = xnode.Attributes.GetNamedItem("passQuest");
                            if (passQuest != null)
                                rep.PassedQuest = passQuest.Value;
                            rep.Phrases.Add(xnode.LastChild.Value);
                            NPCReplics.Add(rep);
                            break;
                        }
                    case "choice":
                        {
                            PlayerChoice rep = new PlayerChoice();
                            XmlNode num = xnode.Attributes.GetNamedItem("number");
                            rep.ID = ID + num.Value;
                            rep.Number = num.Value;
                            XmlNode newQuest = xnode.Attributes.GetNamedItem("newQuest");
                            if (newQuest != null)
                                rep.ReceiveQuest = newQuest.Value;
                            XmlNode passQuest = xnode.Attributes.GetNamedItem("passQuest");
                            if (passQuest != null)
                                rep.PassedQuest = passQuest.Value;
                            choices.Add(rep);

                            foreach (XmlNode ans in xnode)
                            {
                                Answer a = new Answer();
                                XmlNode number = ans.Attributes.GetNamedItem("number");
                                a.ID = ID + number.Value;
                                a.Number = number.Value;
                                number = ans.Attributes.GetNamedItem("next");
                                a.Next = number.Value;

                                XmlNode hidden = ans.Attributes.GetNamedItem("hide");
                                if (hidden == null)
                                    a.IsHidden = false;
                                else a.IsHidden = Convert.ToBoolean(hidden.Value);

                                newQuest = ans.Attributes.GetNamedItem("newQuest");
                                if (newQuest != null)
                                    a.ReceiveQuest = newQuest.Value;
                                passQuest = ans.Attributes.GetNamedItem("passQuest");
                                if (passQuest != null)
                                    a.PassedQuest = passQuest.Value;
                                a.PlayerPhrases.Add(ans.LastChild.Value);
                                rep.Answers.Add(a);
                            }
                            break;
                        }
                }
            }
            #endregion

            #region Построение графа диалога
            foreach (NPCReplic replic in NPCReplics)
            {
                foreach (PlayerChoice pc in choices)
                {
                    if (replic.Next == pc.Number)
                    {
                        replic.NextChoice = pc;
                        break;
                    }
                }
                if (replic.Number == "0")
                    RootReplic = replic;
            }
            foreach (PlayerChoice pc in choices)
            {
                foreach(Answer answer in pc.Answers)
                {
                    foreach (NPCReplic replic in NPCReplics)
                    {
                        if (answer.Next == replic.Number)
                        {
                            answer.NextReplic = replic;
                            break;
                        }
                    }
                }
                if (pc.Number == "0")
                    RootReplic = pc;
            }
            CurrentReplic = RootReplic;
            #endregion
        }
        public void OnTimerTick(int deltaTime)
        {
            if (CurrentReplic == null)
            {
                IsActive = false;
                return;
            }
            CurrentReplic.CurrentDuration += deltaTime;
            if (CurrentReplic.CurrentDuration > CurrentReplic.Duration)
            {
                if (CurrentReplic.PassedQuest != null)
                    QuestListener.PassQuest(CurrentReplic.PassedQuest);
                if (CurrentReplic.ReceiveQuest != null)
                    QuestListener.ReceiveQuest(CurrentReplic.ReceiveQuest);
                CurrentReplic = CurrentReplic.GetNextReplic();
                if (CurrentReplic!=null)
                    CurrentReplic.CurrentDuration = 0;
            }
        }
        public void GoToDialogBeginning()
        {
            CurrentReplic = RootReplic;
            CurrentReplic.CurrentDuration = 0;
        }
    }
}
