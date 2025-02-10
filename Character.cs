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

public class Monster : Character // Monster 캐릭터 관리
{
    public int MonsterType { get; set; }
    public int MonsterID { get; set; }
    public bool IsDead { get; set; }
    // 몬스터 등급 스톤 -> 브론즈 -> 아이언 - > 실버 -> 골드 -> 플래티넘랭크 순이다.
    public Monster(int id) // MonsterType 1번은 잡몹, 2번은 레어몹, 3번은 보스몹
    {
        if (id == 1)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 1;
            this.Name = "흰색 슬라임[스톤]"; // EasyScreen
            this.Atk = 2;
            this.Def = 1;
            this.MaxHP = 30;
            this.NowHP = 30;
            Console.WriteLine("설명: 동그란 흰색 슬라임이다.");
        }
        else if(id == 2)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 2;
            this.Name = "고블린[스톤]"; // EasyScreen
            this.Atk = 2;
            this.Def = 3;
            this.MaxHP = 30;
            this.NowHP = 30;
            Console.WriteLine("설명: 맨손상태, 가죽으로 쪼가리 몸에 두르고있다.");
        }
        else if (id == 3)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 4;
            this.Name = "전투병 고블린[스톤]"; // EasyScreen
            this.Atk = 3;
            this.Def = 4;
            this.MaxHP = 38;
            this.NowHP = 38;
            Console.WriteLine("설명: 칼날 다 빠지고 녹슨 롱소드를 손에 쥐고 있다, 흉부에 가죽 갑옷을 입고있다");
        }
        else if (id == 4) // 강태현 몬스터
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 6;
            this.Name = "홉 고블린[레어 브론즈]"; // EasyScreen 
            this.Atk = 6;
            this.Def = 5;
            this.MaxHP = 45;
            this.NowHP = 45;
            Console.WriteLine("설명: 키가 사람 평균 정도다, 제대로 된 가죽 갑옷을 입고 있다, 무기는 조잡하게 만든 몽둥이");
        }
        else if (id == 5)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 1;
            this.Name = "스켈레톤[스톤]"; // NormalScreen
            this.Atk = 2;
            this.Def = 1;
            this.MaxHP = 15;
            this.NowHP = 20;
            Console.WriteLine("설명: 아무 장비도 장착 안 되어있는 그냥 스켈레톤이다 하지만 무리지어 다니기 때문에 다구리에 장사없으니 조심하자.");
        }
        else if (id == 6)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 4;
            this.Name = "궁수 스켈레톤[스톤]"; // NormalScreen
            this.Atk = 5;
            this.Def = 2;
            this.MaxHP = 15;
            this.NowHP = 20;
            Console.WriteLine("설명: 활, 가죽 누더기를 장착하고있다, 죽기전에는 궁수였던거 같다.");

        }

        else if (id == 7)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 3;
            this.Name = "전사 스켈레톤[스톤]"; // NormalScreen
            this.Atk = 4;
            this.Def = 3;
            this.MaxHP = 16;
            this.NowHP = 20;
            Console.WriteLine("설명: 들고있는 근접 무기가 다양하다, 대부분 녹슨 사슬갑옷을 장착, 죽기전에 전사였던거 같다.");

        }
        else if (id == 8) // 수진님 몬스터
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 7;
            this.Name = "War 고스트[레어 아이언]"; // NormalScreen
            this.Atk = 7;
            this.Def = 6;
            this.MaxHP = 70;
            this.NowHP = 70;
            Console.WriteLine("설명: 검은 판급갑옷, 검은 대검 or 검은 방패 한손무기 장착, 발생 원인은 파악을 못 하였으나 전쟁터에서 죽은 사람의 원혼이 뭉쳐서 탄생한다는 소문이 있다, ");
        }

        //else if (id == )
        //{
        //    this.MonsterType = 1;
        //    this.MonsterID = id;
        //    this.Level = 8;
        //    this.Name = "물의 요정[]";
        //    this.Atk = 12;
        //    this.Def = 5;
        //    this.MaxHP = 80;
        //    this.NowHP = 80;
        //}
        //else if (id == )
        //{
        //    this.MonsterType = 3;
        //    this.MonsterID = id;
        //    this.Level = 5;
        //    this.Name = "킹 고블린 Boss[실버]";
        //    this.Atk = 10;
        //    this.Def = 10;
        //    this.MaxHP = 200;
        //    this.NowHP = 200;
        //}
        //else if (id == )
        //{
        //    this.MonsterType = 3;
        //    this.MonsterID = id;
        //    this.Level = 10;
        //    this.Name = "정령왕 픽시 Boss[]";
        //    this.Atk = 30;
        //    this.Def = 5;
        //    this.MaxHP = 450;
        //    this.NowHP = 450;
        //}
        //else if (id == )
        //{
        //    this.MonsterType = 3;
        //    this.MonsterID = id;
        //    this.Level = 15;
        //    this.Name = "언데드 군단장 Boss[]";
        //    this.Atk = 30;
        //    this.Def = 5;
        //    this.MaxHP = 600;
        //    this.NowHP = 600;
        //}
        //else
        //{
        //    //예외처리
        //}

    }
}