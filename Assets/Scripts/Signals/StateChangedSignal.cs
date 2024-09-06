using System;

namespace Signals
{
    public class StateChangedSignal : ISignal
    {
        public StateChangedSignal(Type stateType)
        {
            GetStateType = stateType;
        }

        public Type GetStateType { get; }
    }
}