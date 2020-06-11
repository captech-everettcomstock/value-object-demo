namespace ValueObjectDemo.Types
{
    public class Status : StringEnum
    {
        public static Status Available = new Status("Available");

        public static Status Unavailable = new Status("Unavailable");

        public static Status Unknown = new Status("Unknown");

        private Status(string value) : base(value) { }
    }
}
