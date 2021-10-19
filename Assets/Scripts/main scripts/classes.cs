using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;






[System.Serializable]
public class RateInfo
{
    public Dictionary<string, float> rates = new Dictionary<string, float>();
    public float stars = 4;
}
[System.Serializable]
public class BaseInfo
{
    public string id = "007";
   
    public string name = "Sala7";
    public RateInfo rate;
    public float stars = 4;
    Discipline discipline = Discipline.Hadded;
    public string profilePic = "https://static7.depositphotos.com/1158045/696/i/950/depositphotos_6969840-stock-photo-engineer-portrait.jpg";
    public string tags = "7added,7aded,hadded,Haded,7did,hdid";
    public string description = "The process of writing a job description requires having a clear understanding of  the job’s duties and responsibilities. The job posting should also include a concise picture of the skills required for the position to attract qualified job candidates. Organize the job description into five sections: Company Information, Job Description, Job Requirements, Benefits and a Call to Action. Be sure to include keywords that will help make your job posting searchable. A well-defined job description will help attract qualified candidates as well as help reduce employee turnover  in the long run.";
    public string title = " 7added";
    public List<string> allImagesAndVideos = new List<string>();
}
[System.Serializable]
public class UserInfo : BaseInfo
{
    public string email = "gg@gmail.com";
    public string tel = "25420749";
    public List<string> allMyArticles = new List<string>();
}
[System.Serializable]
public class WorkerInfo : UserInfo
{

    public int score = 0;
}

[System.Serializable]
public class Article : BaseInfo
{
    public bool isANeed = false;
    public string userID = "007";

}
public enum Discipline
{
    Najjar,
    Hadded,
    Dahhen,
    Blombier,
    InstaWork,
    NoDisciplineNeeded

}
