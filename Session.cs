using System;

public class Session
{
    public List<Talk> talks { get; set; }
    public int maxLength { get; set; }

	public Session(int maxLength)
	{
        talks = new List<Talk>();
        this.maxLength = maxLength;
	}

    public addTalk(Talk talk)
    {
        talks.add(Talk);
    }
}
