using System;
/* Назначение: Базовый класс для реплик
 * предполагается, что диалог будет графом из реплик
 * Автор: Никитенко А.В.
 */
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
        /// <summary>
        /// квести, который начинается с этой репликой (его ID)
        /// </summary>
        public string PassedQuest { get; set; } = null;
        /// <summary>
        /// квести, который заканчивается с этой репликой (его ID)
        /// </summary>
        public string ReceiveQuest { get; set; } = null;
        public abstract Replic GetNextReplic();

        public bool IsHidden { get; set; }
    }
}
