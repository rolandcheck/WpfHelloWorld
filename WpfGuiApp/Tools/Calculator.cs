namespace WpfGuiApp.Tools
{
    public class MyCalculator : IMyCalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }
    }

    public interface IMyCalculator
    {
        int Add(int a, int b);
        int Sub(int a, int b);
    }
}