using System.Diagnostics;
using System.Runtime.InteropServices.Marshalling;

class SayaTubeVideo
{
    private int id; private string title; private int playCount;

    public SayaTubeVideo(string title)
    {
        if(title == null || title.Length > 200)
        {
            throw new ArgumentException("Judul video tidak boleh kosong dan maksimal 200 karakter.");
        }

        this.title = title;
        this.playCount = 0;

        Random random = new Random();
        this.id = random.Next(10000, 99999);
    }

    public void IncreasePlayCount(int count)
    {
        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch(OverflowException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public string GetTitle()
    {
        return title;
    }

    public int GetCount()
    {
        return playCount;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID   : " + id);
        Console.WriteLine("Title      : " + title);
        Console.WriteLine("Play Count : " + playCount);
    }
}

class SayaTubeUser
{
    private int id; private List<SayaTubeVideo> uploadedVideos; private string username;

    public SayaTubeUser(string username)
    {
        if(username == null || username.Length > 100)
        {
            throw new ArgumentException("Username tidak boleh null dan maksimal 100 karakter.");
        }
        this.username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();

        Random random = new Random();
        this.id = random.Next(10000, 99999);
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        for(int i = 0; i < uploadedVideos.Count; i++)
        {
            total = total + uploadedVideos[i].GetCount();
        }
        return total;
    }

    public void AddVideo(SayaTubeVideo video)
    {
        if(video == null || video.GetCount() >= 25000000)
        {
            throw new ArgumentException("Video tidak boleh null dan playcount harus kurang dari maksimum integer");
        }
        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlayCount()
    {
        Console.WriteLine("User          : " + username);
        for(int i = 0;i < uploadedVideos.Count; i++)
        {
            Console.WriteLine("Video " + (i + 1) + " judul : " + uploadedVideos[i].GetTitle());
        }
    }
}

class program
{
    static void Main(string[] args)
    {
        string nama = "Muhammad Faqih Ainulyaqin";

        SayaTubeVideo video1 = new SayaTubeVideo("Review Film Dark Knight Returns oleh " + nama);
        SayaTubeVideo video2 = new SayaTubeVideo("Review Film The Hobit oleh " + nama);
        SayaTubeVideo video3 = new SayaTubeVideo("Review Film Don't Knock Twice Returns oleh " + nama);
        SayaTubeVideo video4 = new SayaTubeVideo("Review Film Man of Steel oleh " + nama);
        SayaTubeVideo video5 = new SayaTubeVideo("Review Film Suicide Squad oleh " + nama);
        SayaTubeVideo video6 = new SayaTubeVideo("Review Film The Marvel oleh " + nama);
        SayaTubeVideo video7 = new SayaTubeVideo("Review Film Spiderman oleh " + nama);
        SayaTubeVideo video8 = new SayaTubeVideo("Review Film Captain America oleh " + nama);
        SayaTubeVideo video9 = new SayaTubeVideo("Review Film Lord of The Rings oleh " + nama);
        SayaTubeVideo video10 = new SayaTubeVideo("Review Film The Conjuring oleh " + nama);


        SayaTubeUser user1 = new SayaTubeUser(nama);
        user1.AddVideo(video1);
        user1.AddVideo(video2);
        user1.AddVideo(video3);
        user1.AddVideo(video4);
        user1.AddVideo(video5);
        user1.AddVideo(video6);
        user1.AddVideo(video7);
        user1.AddVideo(video8);
        user1.AddVideo(video9);
        user1.AddVideo(video10);

        video1.PrintVideoDetails();

        user1.PrintAllVideoPlayCount();
    }
}