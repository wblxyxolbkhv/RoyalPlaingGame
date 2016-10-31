using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;
using RoyalPlayingGame.Item;
using System.Xml;
using StartUpProject.Quests.QuestStages;

namespace StartUpProject.Quests
{
    public class Quest
    {
        public Quest(int ID, string name, string description, Unit giver, Player player)
        {
            Player = player;
            this.ID = ID;
            QuestName = name;
            QuestDescription = description;
            QuestGiver = giver;
            QuestStages = new List<QuestStage>();
            IsActive = true;
            QuestStage.QuestStageCompleted += OnNextStage;
        }

        public Quest(int ID, string name, string description)
        {
            this.ID = ID;
            QuestName = name;
            QuestDescription = description;
            QuestStages = new List<QuestStage>();
            IsActive = false;
            QuestStage.QuestStageCompleted += OnNextStage;
        }

        private void OnNextStage()
        {
            if (CurrentQuestStage.QuestStageIndex < QuestStages.Count)
                CurrentQuestStage = QuestStages[CurrentQuestStage.QuestStageIndex + 1];
            else QuestCompleted?.Invoke();
        }

        public int ID { get; set; }
        public bool IsActive { get; set; }
        public static event Action QuestCompleted;
        private Player Player { get; set; }
        public List<QuestStage> QuestStages { get; set; }
        public QuestStage CurrentQuestStage { get; set; }
        public string QuestName { get; set; }
        public string QuestDescription { get; set; }
        public Unit QuestGiver { get; set; }

        public void AddQuestStage(QuestStage questStage)
        {
            QuestStages.Add(questStage);
            if (questStage.QuestStageIndex == 1)
            {
                CurrentQuestStage = questStage;
            }
        }

        private string QuestName1 { get; set; }
        private string QuestDescription1 { get; set; }
        private int QuestID { get; set; }
        private string StageName { get; set; }
        private string StageDescription { get; set; }
        private int StageID { get; set; }
        private string StageType { get; set; }
        private int ReqAmount { get; set; }
        private int TargetID { get; set; }
        private int ItemID { get; set; }
        private string ItemName { get; set; }


        private void LoadQuest(string path)
        {
            XmlDocument questXml = new XmlDocument();
            questXml.Load(path);

            XmlElement rootElement = questXml.DocumentElement;
            QuestID = Convert.ToInt32(rootElement.Attributes.GetNamedItem("id").Value);
            QuestName1 = rootElement.Attributes.GetNamedItem("name").Value;
            QuestDescription1 = rootElement.Attributes.GetNamedItem("description").Value;

            Quest quest = new Quest(QuestID, QuestName1, QuestDescription1);

            foreach (XmlNode xnode in rootElement)
            {
                StageID = Convert.ToInt32(xnode.Attributes.GetNamedItem("id").Value);
                StageType = xnode.Attributes.GetNamedItem("type").Value;
                //foreach(XmlNode stageParams in xnode)
                //{
                //    switch(stageParams.Name)
                //    {
                //        case "name":
                //            {
                //                StageName = stageParams.LastChild.Value;
                //                break;
                //            }
                //        case "description":
                //            {
                //                StageDescription = stageParams.LastChild.Value;
                //                break;
                //            }
                //    }
                //}
                switch (StageType)
                {
                    case "ToPoint":
                        {
                            ToPointStage tps = new ToPointStage();
                            foreach (XmlNode stageParams in xnode)
                            {
                                switch (stageParams.Name)
                                {
                                    case "name":
                                        {
                                            tps.QuestStageName = stageParams.LastChild.Value;
                                            break;
                                        }
                                    case "description":
                                        {
                                            tps.QuestStageDescription = stageParams.LastChild.Value;
                                            break;
                                        }
                                    case "Point":
                                        {
                                            tps.AddPoint(Convert.ToInt32(stageParams.Attributes.GetNamedItem("id").Value));
                                            break;
                                        }
                                }
                            }


                            quest.QuestStages.Add(tps);

                            break;
                        }
                    case "ToUnit":
                        {
                            ToUnitStage tus = new ToUnitStage(StageName, StageDescription, StageID);
                            quest.QuestStages.Add(tus);
                            break;
                        }
                    case "KillUnit":
                        {
                            KillUnitStage kus = new KillUnitStage();
                            foreach (XmlNode stageParams in xnode)
                            {
                                switch (stageParams.Name)
                                {
                                    case "name":
                                        {
                                            StageName = stageParams.LastChild.Value;
                                            break;
                                        }
                                    case "description":
                                        {
                                            StageDescription = stageParams.LastChild.Value;
                                            break;
                                        }
                                    case "target":
                                        {
                                            TargetID = (Convert.ToInt32(stageParams.Attributes.GetNamedItem("id").Value));
                                            ReqAmount = (Convert.ToInt32(stageParams.Attributes.GetNamedItem("amount").Value));
                                            kus.AddTarget(TargetID, ReqAmount);
                                            break;
                                        }
                                }
                            }
                            //KillUnitStage kus = new KillUnitStage(StageName, StageDescription, StageID);
                            quest.QuestStages.Add(kus);
                            break;
                        }
                    case "PickItem":
                        {
                            PickItemStage pis = new PickItemStage();
                            foreach (XmlNode stageParams in xnode)
                            {
                                switch (stageParams.Name)
                                {
                                    case "name":
                                        {
                                            StageName = stageParams.LastChild.Value;
                                            break;
                                        }
                                    case "description":
                                        {
                                            StageDescription = stageParams.LastChild.Value;
                                            break;
                                        }
                                    case "item":
                                        {
                                            ItemID = (Convert.ToInt32(stageParams.Attributes.GetNamedItem("id").Value));
                                            ReqAmount = (Convert.ToInt32(stageParams.Attributes.GetNamedItem("amount").Value));
                                            ItemName = stageParams.Attributes.GetNamedItem("name").Value;
                                            pis.AddQuestItem(ItemID, ItemName, ReqAmount);
                                            break;
                                        }
                                }
                            }

                            //pis.AddQuestItem(ItemID, ItemName, ReqAmount);
                            quest.QuestStages.Add(pis);
                            break;
                        }
                }
            }

        }

    }
}

