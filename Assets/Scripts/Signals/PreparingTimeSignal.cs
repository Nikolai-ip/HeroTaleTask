namespace Signals
{
    public class PreparingTimeSignal:ISignal
    {
        public float Time { get; }

        public PreparingTimeSignal(float time)
        {
            Time = time;
        }

    }
}