namespace Signals
{
    public class ActionSignal : ISignal
    {
        public ActionSignal(ActionType actionType)
        {
            GetAction = actionType;
        }

        public ActionType GetAction { get; }
    }
}