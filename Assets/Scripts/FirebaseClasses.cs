
[System.Serializable]
public class Room
{
    public string id;
    public RoomStatus status;
    public string comment="test comment";
    public int adultNumber=2;
    public int babyNumber = 0;


}
public enum RoomStatus
{
    Ready,
    Preparing,
    NotReady
}