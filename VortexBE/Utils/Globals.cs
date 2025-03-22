namespace VortexBE.Utils
{
    public class Globals
    {
        public static DateTime SystemDate() => DateTime.UtcNow.AddHours(-5);
        public static string SystemUser() => "Vortex Bird";
    }
}
