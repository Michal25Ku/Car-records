namespace Laboratorium2.Models
{
    public class Calculator
    {
        public double? A { get; set; }
        public double? B { get; set; }
        public Operators? Op { get; set; }

        public bool IsValid()
        {
            return A != null && B != null && Op != null;
        }

        public double Calculate()
        {
            switch (Op)
            {
                case Operators.ADD:
                    return (double)(A + B);
                    break;
                case Operators.SUM:
                    return (double)(A - B);
                    break;
                case Operators.MUL:
                    return (double)(A * B);
                    break;
                case Operators.DIV:
                    if (B == 0)
                        return double.NaN;

                    return (double)A / (double)B;
                    break;
                case Operators.POW:

                    return Math.Pow((double)A, (double)B);
                    break;
                case Operators.SQRT:

                    return Math.Pow((double)A, (double)(1 / B));
                    break;
                default: return double.NaN;
            }
        }
    }
}
