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
        public Quest(string ID, string name, string description, Unit giver, Player player)
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

        public Quest(string ID, string name, string description)
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
        public string ID { get; set; }
        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                if (!string.IsNullOrEmpty(ShownReplic))
                    QuestListener.ReplicShow(Convert.ToInt32(ShownReplic));

                if (!string.IsNullOrEmpty(HiddenReplic))
                    QuestListener.ReplicHide(Convert.ToInt32(HiddenReplic));
            }
        }
        public static event Action QuestCompleted;
        private Player Player { get; set; }
        public List<QuestStage> QuestStages { get; set; }
        private QuestStage currentQuestStage;
        public QuestStage CurrentQuestStage
        {
            get { return currentQuestStage; }
            set
            {
                if (currentQuestStage!=null)
                    currentQuestStage.IsCurrent = false;
                currentQuestStage = value;
                currentQuestStage.IsCurrent = true;
            }
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public Unit QuestGiver { get; set; }

        private string ShownReplic { get; set; }
        private string HiddenReplic { get; set; }

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
            ID = rootElement.Attributes.GetNamedItem("id").Value;
            Name = rootElement.Attributes.GetNamedItem("name").Value;
            Description = rootElement.Attributes.GetNamedItem("description").Value;
            if (rootElement.Attributes.GetNamedItem("shownReplic") != null)
                ShownReplic = rootElement.Attributes.GetNamedItem("shownReplic").Value;
            if (rootElement.Attributes.GetNamedItem("hiddenReplic") != null)
                HiddenReplic = rootElement.Attributes.GetNamedItem("hiddenReplic").Value;


            foreach (XmlNode xnode in rootElement)
            {
                string StageID = xnode.Attributes.GetNamedItem("id").Value;
                string StageType = xnode.Attributes.GetNamedItem("type").Value;
                switch (StageType)
                {
                    case "ToPoint":
                        {
                            ToPointStage tps = new ToPointStage();
                            tps.ID = ID + StageID;
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
                                    case "shownReplic":
                                        {
                                            tps.ShownReplic = stageParams.Attributes.GetNamedItem("id").Value;
                                            break;
                                        }
                                    case "hiddenReplic":
                                        {
                                            tps.HiddenReplic = stageParams.Attributes.GetNamedItem("id").Value;
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
                            tus.ID = ID + StageID;
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
                                    case "shownReplic":
                                        {
                                            tus.ShownReplic = stageParams.Attributes.GetNamedItem("id").Value;
                                            break;
                                        }
                                    case "hiddenReplic":
                                        {
                                            tus.HiddenReplic = stageParams.Attributes.GetNamedItem("id").Value;
                                            break;
                                        }
                                }
                            AddQuestStage(tus);
                            break;
                        }
                    case "KillUnit":
                        {
                            KillUnitStage kus = new KillUnitStage();
                            kus.ID = ID + StageID;
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
                                    case "shownReplic":
                                        {
                                            kus.ShownReplic = stageParams.Attributes.GetNamedItem("id").Value;
                                            break;
                                        }
                                    case "hiddenReplic":
                                        {
                                            kus.HiddenReplic = stageParams.Attributes.GetNamedItem("id").Value;
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
                            pis.ID = ID + StageID;
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
                                    case "shownReplic":
                                        {
                                            pis.ShownReplic = stageParams.Attributes.GetNamedItem("id").Value;
                                            break;
                                        }
                                    case "hiddenReplic":
                                        {
                                            pis.HiddenReplic = stageParams.Attributes.GetNamedItem("id").Value;
                                            break;
                                        }
                                }
                            }
                            AddQuestStage(pis);
                            break;
                        }
                }
                //StageID = ID + StageID;
            }

        }

    }
}

