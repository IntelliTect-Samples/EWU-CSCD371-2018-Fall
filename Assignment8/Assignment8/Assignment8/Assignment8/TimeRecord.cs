namespace Assignment8
{
    /// <summary>
    /// TimeItem is used to store the information associated with each time record in the ListBox
    /// </summary>
    public class TimeRecord
    {
        public string ElapsedTime { get; }
        public string Description { get; set; }
        public string Title { get; set; }

        public TimeRecord(string elapsedTime, string title, string description)
        {
            ElapsedTime = elapsedTime;
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return ElapsedTime;
        }
    }
}