namespace Shenmue_2_Skipper
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new ShenmueForm());
        }
    }
}