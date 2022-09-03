namespace Timer
{
    public class SendTimerInfoSignal
    {
        public int Seconds;
        public int Minutes;

        public SendTimerInfoSignal(int seconds, int minutes)
        {
            Seconds = seconds;
            Minutes = minutes;
        }
    }
}