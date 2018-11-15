using System;
using System.Collections.Generic;

namespace T4T_NET
{
    public class Session
    {
        public List<Talk> Talks { get; set; }
        public int MaxLength { get; set; }

        public Session(int maxLength)
        {
            Talks = new List<Talk>();
            this.MaxLength = maxLength;
        }

        public void AddTalk(Talk talk)
        {
            Talks.Add(talk);
        }
    }
}
