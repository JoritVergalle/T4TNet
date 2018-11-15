using System;

namespace T4T_NET
{
    public class Track
    {
        public Session Morning { get; set; }
        public Session Afternoon { get; set; }

        public Track()
        {
            Morning = new Session(180);
            Afternoon = new Session(240);
        }
    }
}

