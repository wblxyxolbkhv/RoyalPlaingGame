using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using StartUpProject.Quests.QuestStages;
namespace StartUpProject.Quests
{
    public class QuestManager
    {
        private string QuestName { get; set; }
        private string QuestDescription { get; set; }
        private int QuestID { get; set; }
        private string StageName { get; set;}
        private string StageDescription { get; set; }
        private int StageID { get; set; }
        private string StageType { get; set; }
        private int ReqAmount { get; set; }
        private int TargetID { get; set; }
        private int ItemID { get; set; }
        private string ItemName { get; set; }
        private int PointID { get; set; }

        private void LoadQuest(string path)
        {
            XmlDocument questXml = new XmlDocument();
            questXml.Load(path);

            XmlElement rootElement = questXml.DocumentElement;
            QuestID = Convert.ToInt32(rootElement.Attributes.GetNamedItem("id").Value);
            QuestName = rootElement.Attributes.GetNamedItem("name").Value;
            QuestDescription = rootElement.Attributes.GetNamedItem("description").Value;

            Quest quest = new Quest(QuestID, QuestName, QuestDescription);

            foreach(XmlNode xnode in rootElement)
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
                switch(StageType)
                {
                    case "ToPoint":
                        {
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
                                }
                            }
                            ToPointStage tps = new ToPointStage(StageName, StageDescription, StageID);
                            
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
                                    case "targetID":
                                        {
                                            TargetID = Convert.ToInt32(stageParams.LastChild.Value);
                                            break;
                                        }
                                    case "reqAmout":
                                        {
                                            ReqAmount = Convert.ToInt32(stageParams.LastChild.Value);
                                            break;
                                        }
                                }
                            }
                            KillUnitStage kus = new KillUnitStage(StageName, StageDescription, StageID);
                            kus.AddTarget(TargetID, ReqAmount);
                            quest.QuestStages.Add(kus);
                            break;
                        }
                    case "PickItem":
                        {
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
                                    case "itemID":
                                        {
                                            ItemID = Convert.ToInt32(stageParams.LastChild.Value);
                                            break;
                                        }
                                    case "reqAmout":
                                        {
                                            ReqAmount = Convert.ToInt32(stageParams.LastChild.Value);
                                            break;
                                        }
                                    case "itemName":
                                        {
                                            ItemName = stageParams.LastChild.Value;
                                            break;
                                        }
                                }
                            }
                            PickItemStage pis = new PickItemStage(StageName, StageDescription, StageID);
                            pis.AddQuestItem(ItemID, ItemName, ReqAmount);
                            quest.QuestStages.Add(pis);
                            break;
                        }
                }
            }

        }

    }
}
