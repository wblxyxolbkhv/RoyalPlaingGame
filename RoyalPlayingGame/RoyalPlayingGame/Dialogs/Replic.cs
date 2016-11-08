using System;

namespace RoyalPlayingGame.Dialogs
{
    public abstract class Replic
    {
        public Replic()
        {
            QuestListener.ReplicHidden += OnAnyReplicHidden;
            QuestListener.ReplicShown += OnAnyReplicShown;

            IsHidden = false;
        }

        private void OnAnyReplicShown(int replicID)
        {
            if (replicID.ToString() == ID)
                IsHidden = false;
        }

        private void OnAnyReplicHidden(int replicID)
        {
            if (replicID.ToString() == ID)
                IsHidden = true;
        }

        public string ID
        {
            get;set;
        }
        public string Number
        {
            get; set;
        }
        public string Next
        {
            get; set;
        }
        public int Duration
        {
            get; set;
        } = 1000;
        public int CurrentDuration
        {
            get; set;
        } = 0;
        public string PassedQuest { get; set; } = null;
        public string ReceiveQuest { get; set; } = null;
        public abstract Replic GetNextReplic();

        public bool IsHidden { get; set; }
    }
}
