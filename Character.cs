namespace EIEIE_Project;

public class Character
{
    public int Level { get; set; }
    public string Name { get; set; }
    public float Atk { get; set; }
    public float Def { get; set; }
    public float MaxHP { get; set; }
    public float NowHP { get; set; }

    public void Attack(Character attacker, Character target)
    {
        Random random = new Random();
        int max = (int)Math.Ceiling(attacker.Atk + (attacker.Atk * 0.1));
        int min = (int)Math.Ceiling(attacker.Atk - (attacker.Atk * 0.1));

        target.NowHP = target.NowHP - random.Next(min, max);
    }
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
    public bool IsDead { get; set; }

    public Monster(int id) // MonsterType 1번은 잡몹, 2번은 보스몹
    {
        if (id == 1)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 1;
            this.Name = "고블린";
            this.Atk = 2;
            this.Def = 5;
            this.MaxHP = 30;
            this.NowHP = 30;
        }
        else if (id == 2) // 수진님 몬스터
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 2;
            this.Name = "고스트";
            this.Atk = 3;
            this.Def = 5;
            this.MaxHP = 50;
            this.NowHP = 50;
        }
        else if (id == 3)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 3;
            this.Name = "슬라임";
            this.Atk = 2;
            this.Def = 5;
            this.MaxHP = 100;
            this.NowHP = 100;
        }
        else if (id == 4)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 5;
            this.Name = "스켈레톤";
            this.Atk = 10;
            this.Def = 10;
            this.MaxHP = 50;
            this.NowHP = 50;
        }
        else if (id == 5)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 8;
            this.Name = "물의 요정";
            this.Atk = 12;
            this.Def = 5;
            this.MaxHP = 80;
            this.NowHP = 80;
        }
        else if (id == 6)
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 5;
            this.Name = "킹 고블린";
            this.Atk = 10;
            this.Def = 10;
            this.MaxHP = 200;
            this.NowHP = 200;
        }
        else if (id == 7)
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 10;
            this.Name = "정령왕 픽시";
            this.Atk = 30;
            this.Def = 5;
            this.MaxHP = 450;
            this.NowHP = 450;
        }
        else if (id == 8)
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 15;
            this.Name = "언데드 군단장";
            this.Atk = 30;
            this.Def = 5;
            this.MaxHP = 600;
            this.NowHP = 600;
        }
        else
        {
            //예외처리
        }

    }
}