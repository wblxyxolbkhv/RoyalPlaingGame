﻿using System.Collections.Generic;
using System.Xml;
using System;
using RoyalPlayingGame.Exceptions;

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
        public void LoadDialog(string path)
        {
            XmlDocument dialogXml = new XmlDocument();
            dialogXml.Load(path);

            XmlElement rootElement = dialogXml.DocumentElement;
            List<NPCReplic> NPCReplics = new List<NPCReplic>();
            List<PlayerChoice> choices = new List<PlayerChoice>();

            #region Парсинг xml
            foreach (XmlNode xnode in rootElement)
            {
                switch(xnode.Name)
                {
                    case "replic":
                        {
                            NPCReplic rep = new NPCReplic();
                            XmlNode num = xnode.Attributes.GetNamedItem("number");
                            rep.Number = num.Value;
                            num = xnode.Attributes.GetNamedItem("next");
                            rep.Next = num.Value;
                            XmlNode newQuest = xnode.Attributes.GetNamedItem("newQuest");
                            if (newQuest != null)
                                rep.GiveQuest = Convert.ToInt32(newQuest.Value);
                            XmlNode recQuest = xnode.Attributes.GetNamedItem("recQuest");
                            if (recQuest != null)
                                rep.ReceiveQuest = Convert.ToInt32(recQuest.Value);
                            rep.Phrases.Add(xnode.LastChild.Value);
                            NPCReplics.Add(rep);
                            break;
                        }
                    case "choice":
                        {
                            PlayerChoice rep = new PlayerChoice();
                            XmlNode num = xnode.Attributes.GetNamedItem("number");
                            rep.Number = num.Value;
                            XmlNode newQuest = xnode.Attributes.GetNamedItem("newQuest");
                            if (newQuest !=null)
                                rep.GiveQuest = Convert.ToInt32(newQuest.Value);
                            XmlNode recQuest = xnode.Attributes.GetNamedItem("recQuest");
                            if (recQuest != null)
                                rep.ReceiveQuest = Convert.ToInt32(recQuest.Value);
                            choices.Add(rep);

                            foreach (XmlNode ans in xnode)
                            {
                                Answer a = new Answer();
                                XmlNode number = ans.Attributes.GetNamedItem("number");
                                a.Number = number.Value;
                                number = ans.Attributes.GetNamedItem("next");
                                a.Next = number.Value;
                                newQuest = ans.Attributes.GetNamedItem("newQuest");
                                if (newQuest != null)
                                    a.GiveQuest = Convert.ToInt32(newQuest.Value);
                                recQuest = ans.Attributes.GetNamedItem("recQuest");
                                if (recQuest != null)
                                    a.ReceiveQuest = Convert.ToInt32(recQuest.Value);
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
                if (CurrentReplic.GiveQuest != null)
                    QuestManager.GiveQuest(CurrentReplic.GiveQuest.Value);
                if (CurrentReplic.ReceiveQuest != null)
                    QuestManager.ReceiveQuest(CurrentReplic.ReceiveQuest.Value);
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
