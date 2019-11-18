namespace LP.Core
{
    public static class GameEvents
    {
        public static System.Action SaveInitiated;

        public static void OnSaveInitiated()
        {
            SaveInitiated?.Invoke();
        }
    }
}
