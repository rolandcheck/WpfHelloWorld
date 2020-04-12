namespace WpfGuiApp.Tools
{
    public class MyService : IMyService
    {
        public int DifficultCalculations(int a, int b)
        {
            return a + b;
        }
    }

    public interface IMyService
    {
        int DifficultCalculations(int a, int b);
    }
}