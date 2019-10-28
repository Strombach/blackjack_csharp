namespace BlackJack.view
{
    public struct InputLetter
    {
        public const char toPlay = 'p';
        public const char toHit = 'h';
        public const char toStand = 's';
        public const char toQuit = 'q';
        public char getPlay() {
            return toPlay;
        }
        public char getHit() {
            return toHit;
        }
        public char getStand() {
            return toStand;
        }
        public char getQuit() {
            return toQuit;
        }
    }
}
