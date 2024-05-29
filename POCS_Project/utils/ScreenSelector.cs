using System.Threading;
using System.Windows.Forms;

namespace POCS_Project.utils
{
    public static class ScreenSelector
    {
        private static Form _NextScreen { get; set; }

        private static void InitNewScreen()
        {
            Application.Run(_NextScreen);
        }

        public static void ChangeScreen(this Form CurrentScreen, Form NextScreen)
        {
            _NextScreen = NextScreen;
            CurrentScreen.Close();
            var threadScreen = new Thread(InitNewScreen);
            threadScreen.SetApartmentState(ApartmentState.STA);
            threadScreen.Start();
        }
    }
}