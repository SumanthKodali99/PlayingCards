
namespace PlayingCards
{
    public class Card
    {
        public SuitConstants Suit { get; set; }
        public ValueConstants Value { get; set; }

        public string Caption
        {
            get
            {
                string val;

                switch (this.Value)
                {
                    case ValueConstants.valJ:
                        val = "J";
                        break;
                    case ValueConstants.valQ:
                        val = "Q";
                        break;
                    case ValueConstants.valK:
                        val = "K";
                        break;
                    case ValueConstants.valA:
                        val = "A";
                        break;
                    default:
                        int i;
                        i = (int)this.Value;
                        val =i.ToString();
                        break;

                }

                return val + this.Suit.ToString();
            }
        }
    }
    
    public enum SuitConstants
    {
        H,
        D,
        S,
        C
    }

    //C# doesn't allow an enum to begin with a number, so prefix with "val"
    public enum ValueConstants
    {
        val2 = 2,
        val3 = 3,
        val4 = 4,
        val5 = 5,
        val6 = 6,
        val7 = 7,
        val8 = 8,
        val9 = 9,
        val10 = 10,
        valJ = 11,
        valQ = 12,
        valK = 13,
        valA = 14,
    }
}
