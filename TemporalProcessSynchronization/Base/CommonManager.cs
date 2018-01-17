using System.Drawing;

namespace Base
{
    public class CommonManager
    {
        public static Color GetColorForStatus(string status)
        {
            return status == "Critical" ? Color.LightCoral : status == "Warning" ? Color.LightGoldenrodYellow : Color.LightGreen;
        }
    }
}
