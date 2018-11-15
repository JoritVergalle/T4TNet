using System;

namespace T4T_NET
{
    public class Talk
    {
        public string Title { get; set; }
        public int Length { get; set; }
        public DateTime Time { get; set; }

        public Talk(string title, int length)
        {
            this.Title = title;
            this.Length = length;
        }
    }
}
