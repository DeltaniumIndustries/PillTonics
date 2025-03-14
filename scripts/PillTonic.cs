using System;

namespace XRL.World.Parts
{
    [Serializable]
    public class PillTonic : IPart
    {
        public override bool WantEvent(int ID, int cascade) =>
            ID == AfterObjectCreatedEvent.ID || base.WantEvent(ID, cascade);

        public override bool HandleEvent(AfterObjectCreatedEvent @event)
        {
            var examinerPart = ParentObject.GetPart<Examiner>();
            if (examinerPart != null)
            {
                if (examinerPart.Unknown.Contains("tube"))
                {
                    ReplaceTubeWithCapsule(examinerPart);
                }
            }
            return base.HandleEvent(@event);
        }

        private void ReplaceTubeWithCapsule(Examiner part)
        {
            part.Unknown = part.Unknown.Replace(" tube", " capsule");
            part.Alternate = part.Alternate.Replace(" tube", " capsule");
        }

    }
}
