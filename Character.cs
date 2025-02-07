namespace EIEIE_Project;

public class Character
{
    public int Level { get; set; }
    public string Name { get; set; }
    public float Atk { get; set; }
    public float Def { get; set; }
    public float MaxHP { get; set; }
    public float NowHP { get; set; }
}

public class Player : Character
{
    public string Job { get; set; }
    public float MaxMP { get; set; }
    public float NowMP { get; set; }
    public int MaxExp { get; set; }
    public int NowExp { get; set; }
    public int Gold { get; set; }
}

public class Monster : Character
{
    public int MonsterType { get; set; }
    public int MonsterID { get; set; }
}