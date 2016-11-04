using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoyalPlayingGame.Units;
using RoyalPlayingGame.Item;
using System.Xml;
using RoyalPlayingGame.Quests.QuestStages;
using RoyalPlayingGame.Journal;

namespace RoyalPlayingGame.Quests
{
    public class Quest
    {
        public Quest(int ID, string name, string description, Unit giver, Player player)
        {
            Player = player;
            this.ID = ID;
            Name = name;
            Description = description;
            QuestGiver = giver;
            QuestStages = new List<QuestStage>();
            IsActive = false;
            Notes = new List<JournalNote>();
        }

        public Quest(int ID, string name, string description)
        {
            this.ID = ID;
            Name = name;
            Description = description;
            QuestStages = new List<QuestStage>();
            IsActive = false;
            Notes = new List<JournalNote>();
        }

        public Quest()
        {
            IsActive = true;
            QuestStages = new List<QuestStage>();
            Notes = new List<JournalNote>();         
        }

        private void OnNextStage()
        {
            if (QuestStages.IndexOf(CurrentQuestStage) < QuestStages.Count-1)
            {
                CurrentQuestStage.QuestStageCompleted -= OnNextStage;
                CurrentQuestStage = QuestStages[QuestStages.IndexOf(CurrentQuestStage) +1];
                CurrentQuestStage.QuestStageCompleted += OnNextStage;
            }
            else QuestCompleted?.Invoke();
        }

        public List<JournalNote> Notes { get; set; }
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public static event Action QuestCompleted;
        private Player Player { get; set; }
        public List<QuestStage> QuestStages { get; set; }
        public QuestStage CurrentQuestStage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Unit QuestGiver { get; set; }

        public void AddQuestStage(QuestStage questStage)
        {
            QuestStages.Add(questStage);
            if (QuestStages.IndexOf(questStage) == 0)
            {
                CurrentQuestStage = questStage;
                CurrentQuestStage.QuestStageCompleted += OnNextStage;
            }
        }


        public void LoadQuest(string path)
        {
            XmlDocument questXml = new XmlDocument();
            questXml.Load(path);

            XmlElement rootElement = questXml.DocumentElement;
            ID = Convert.ToInt32(rootElement.Attributes.GetNamedItem("id").Value);
            Name = rootElement.Attributes.GetNamedItem("name").Value;
            Description = rootElement.Attributes.GetNamedItem("description").Value;

            foreach (XmlNode xnode in rootElement)
            {
                int StageID = Convert.ToInt32(xnode.Attributes.GetNamedItem("id").Value);
                string StageType = xnode.Attributes.GetNamedItem("type").Value;
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
                                            tps.Name = stageParams.LastChild.Value;
                                            break;
                                        }
                                    case "description":
                                        {
                                            tps.Description = stageParams.LastChild.Value;
                                            break;
                                        }
                                    case "point":
                                        {
                                            tps.AddPoint(Convert.ToInt32(stageParams.Attributes.GetNamedItem("id").Value), stageParams.Attributes.GetNamedItem("objective").Value);
                                            break;
                                        }
                                }
                            }
                            AddQuestStage(tps);
                            break;
                        }
                    case "ToUnit":
                        {
                            ToUnitStage tus = new ToUnitStage();
                            foreach (XmlNode stageParams in xnode)
                            switch (stageParams.Name)
                            {
                                case "name":
                                    {
                                        tus.Name = stageParams.LastChild.Value;
                                        break;
                                    }
                                case "description":
                                    {
                                        tus.Description = stageParams.LastChild.Value;
                                        break;
                                    }
                            }
                            AddQuestStage(tus);
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
                                            kus.Name = stageParams.LastChild.Value;
                                            break;
                                        }
                                    case "description":
                                        {
                                            kus.Description = stageParams.LastChild.Value;
                                            break;
                                        }
                                    case "target":
                                        {
                                            int targetID = (Convert.ToInt32(stageParams.Attributes.GetNamedItem("id").Value));
                                            int reqAmount = (Convert.ToInt32(stageParams.Attributes.GetNamedItem("amount").Value));
                                            string objective = stageParams.Attributes.GetNamedItem("objective").Value;
                                            kus.AddTarget(targetID, reqAmount,objective);
                                            break;
                                        }
                                }
                            }
                            AddQuestStage(kus);
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
                                            pis.Name = stageParams.LastChild.Value;
                                            break;
                                        }
                                    case "description":
                                        {
                                            pis.Description = stageParams.LastChild.Value;
                                            break;
                                        }
                                    case "item":
                                        {
                                            int itemID = (Convert.ToInt32(stageParams.Attributes.GetNamedItem("id").Value));
                                            int reqAmount = (Convert.ToInt32(stageParams.Attributes.GetNamedItem("amount").Value));
                                            string name = stageParams.Attributes.GetNamedItem("name").Value;
                                            string objective = stageParams.Attributes.GetNamedItem("objective").Value;
                                            pis.AddQuestItem(itemID, name, reqAmount, objective);
                                            break;
                                        }
                                }
                            }
                            AddQuestStage(pis);
                            break;
                        }
                }
            }

        }

    }
}

