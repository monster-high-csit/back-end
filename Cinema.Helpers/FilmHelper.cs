namespace Cinema.Helpers
{
    public static class FilmHelper
    {
        public static bool IsCorrectRating(this int value)
        {
            if (value >= 0 && value <= 100)
            {
                return true;
            }

            return false;
        }
        public static bool IsCorrectDuration(this int value)
        {
            if (value >= 1 && value <= 1000)
            {
                return true;
            }

            return false;
        }
    }
}
