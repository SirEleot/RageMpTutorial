using RAGE;
using RAGE.Elements;

namespace Tuter
{
    class Browser
    {
        private static string Url = "package://Cef/index.html";
        private static bool IsOpened = false;
        private static int BlureTime = 500;
        private static RAGE.Ui.HtmlWindow Cef;

        public static void Open(string page)
        {
            //Cef.Url = page;
            Prepair(true);
        }

        public static void Create()
        {
            Cef = new RAGE.Ui.HtmlWindow(Url);
        } 

        public static void Close()
        {
            Prepair(false);
        }

        public static void Call(string fnc)
        {
            Cef.ExecuteJs(fnc);
        }
        private static void Prepair(bool isOpen)
        {
            IsOpened = isOpen;
            Player.LocalPlayer.FreezePosition(isOpen);
            RAGE.Ui.Cursor.Visible = isOpen;
            if (isOpen) RAGE.Game.Graphics.TransitionToBlurred(BlureTime);
            else RAGE.Game.Graphics.TransitionFromBlurred(0);
        }
    }
}
