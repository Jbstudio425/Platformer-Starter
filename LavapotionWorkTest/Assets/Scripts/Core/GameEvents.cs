namespace LP.Core
{
    public class GameEvents
    {
        public static System.Action SaveInitiated;

        public static void OnSaveInitiated()
        {
            SaveInitiated?.Invoke();
        }
    }
}
