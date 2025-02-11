using System.Runtime.CompilerServices;

namespace EIEIE_Project;

public class Character
{
    protected int level;
    public virtual int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }
    public string Name { get; set; }
    protected float atk;
    public virtual float Atk
    {
        get
        {
            return atk;
        }
        set
        {
            atk = value;
        }
    }
    protected float def;
    public virtual float Def
    {
        get
        {
            return def;
        }
        set
        {
            def = value;
        }
    }
    public float MaxHP { get; set; }
    public float NowHP { get; set; }
    public float MaxMP { get; set; }
    public float NowMP { get; set; }

    //일반 공격
    public void Attack(Character attacker, Character target)
    {
        float tempHP = target.NowHP;
        Random random = new Random();
        int max = (int)Math.Ceiling(attacker.Atk + (attacker.Atk * 0.1));
        int min = (int)Math.Ceiling(attacker.Atk - (attacker.Atk * 0.1));
        if (random.Next(1, 101) <= 10)
        {
            Utility.ColorWrite("아무일도 일어나지 않았습니다", ConsoleColor.Red);
            Console.WriteLine();
        }
        else
        {
            if (random.Next(1, 101) <= 15)
            {
                target.NowHP = (float)(target.NowHP - (random.Next(min, max) + Math.Ceiling(random.Next(min, max) * 0.6)));
                //Console.WriteLine("치명타 공격!!");
                Utility.ColorWrite("치명타 공격!!", ConsoleColor.Red);
                Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                Console.WriteLine();
                Console.WriteLine("Lv.{0} {1}", target.Level, target.Name);
                Console.WriteLine();

            }
            else
            {
                target.NowHP = target.NowHP - random.Next(min, max);
                Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                Console.WriteLine();
                Console.WriteLine("Lv.{0} {1}", target.Level, target.Name);
                Console.WriteLine();
            }
        }
    }
    //단일기
    public void CharacterSkil(Character attacker, Character target, Skil skil)
    {
        float tempHP = target.NowHP;
        float tempMP = attacker.NowMP;
        Console.WriteLine("{0}의 {1} 스킬사용 ", attacker.Name, skil.Name);
        target.NowHP = (float)(target.NowHP - Math.Ceiling(skil.Damage * (attacker.Atk * 0.3)));
        if (skil.type == 1)
        {
            Random random = new Random();
            if (random.Next(1, 100) <= 15)
            {
                Utility.ColorWrite("치명타 공격!!", ConsoleColor.Red);
                target.NowHP = (float)(target.NowHP - (Math.Ceiling(skil.Damage * (attacker.Atk * skil.skilRatiod))) + Math.Ceiling(skil.Damage * (attacker.Atk * skil.skilRatiod)));
                Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                Console.WriteLine();
            }
            else
            {
                target.NowHP = (float)(target.NowHP - (Math.Ceiling(skil.Damage * (attacker.Atk * skil.skilRatiod))));
                Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                Console.WriteLine();
            }

        }
        else
        {
            target.NowHP = (float)(target.NowHP - (Math.Ceiling(skil.Damage * (attacker.Atk * skil.skilRatiod))));
            Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
            Console.WriteLine();
        }
        attacker.NowMP = attacker.NowMP - skil.Cost;
        Console.WriteLine("MP: {0} -> {1}",tempMP,attacker.NowMP);

    }

    //광역기
    public void CharacterSkil(Character attacker, List<Character> target, Skil skil)
    {
        float[] tempHP = new float[target.Count];
        for (int i = 0; i < target.Count; i++)
        {
            tempHP[i] = target[i].NowHP;
        }

        Console.WriteLine("{0}의 {1} 스킬사용 ", attacker.Name, skil.Name);
        for (int i = 0; i < target.Count; i++)
        {
            target[i].NowHP = (float)(target[i].NowHP - Math.Ceiling(skil.Damage * (attacker.Atk * 0.3)));
        }
        //target.NowHP = (float)(target.NowHP - Math.Ceiling(skil.Damage * (attacker.Atk * 0.3)));
        if (skil.type == 1)
        {
            Random random = new Random();
            if (random.Next(1, 100) <= 15)
            {
                Utility.ColorWrite("치명타 공격!!", ConsoleColor.Red);
                for (int i = 0; i < target.Count; i++)
                {
                    target[i].NowHP = (float)(target[i].NowHP - Math.Ceiling(skil.Damage * (attacker.Atk * 0.3)));
                    Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target[i].Level, target[i].Name, tempHP[i] - target[i].NowHP);
                }
                //Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                Console.WriteLine();
            }
            else
            {
                for (int i = 0; i < target.Count; i++)
                {
                    target[i].NowHP = (float)(target[i].NowHP - Math.Ceiling(skil.Damage * (attacker.Atk * 0.3)));
                    Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target[i].Level, target[i].Name, tempHP[i] - target[i].NowHP);
                }
            }

        }
        else
        {
            for (int i = 0; i < target.Count; i++)
            {
                target[i].NowHP = (float)(target[i].NowHP - Math.Ceiling(skil.Damage * (attacker.Atk * 0.3)));
                Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target[i].Level, target[i].Name, tempHP[i] - target[i].NowHP);
            }
        }
    }
}
public class Player : Character
{
    public override int Level
    {
        get
        {
            return level;
        }
        set
        {
            if (level != value)
            {
                level = value;
                Atk += (level - 1) * 0.5f;
                Def += (level - 1) * 1f;
                MaxExp += 20 + 5 * (level - 1);
            }
        }
    }
    private string job;
    public string Job
    {
        get
        {
            return job;
        }
        set
        {
            job = value;
            if (job == "전사")
            {
                MaxHP = 150;
                NowHP = 150;
                Atk = 20;
                Def = 15;
                MaxMP = 20;
                NowMP = 20;
            }
            else if(job == "마법사")
            {
                MaxHP = 100;
                NowHP = 100;
                Atk = 15;
                Def = 15;
                MaxMP = 50;
                NowMP = 50;
            }
            else if(job == "모험가")
            {
                MaxHP = 150;
                NowHP = 150;
                Atk = 20;
                Def = 15;
                MaxMP = 50;
                NowMP = 50;
            }
        }
    }
   
    public int MaxExp { get; set; }
    private int nowExp;
    public int NowExp
    {
        get
        {
            return nowExp;
        }
        set
        {
            if (nowExp != value)
            {
                nowExp += value;
                if (nowExp == MaxExp)
                {
                    nowExp = 0;
                    Level++;
                }
                else if (nowExp > MaxExp)
                {
                    int extraExp = nowExp - MaxExp;
                    Level++;
                    while (extraExp - MaxExp > 0)
                    {                       
                        extraExp -= MaxExp;
                        Level++;
                    }
                    nowExp = extraExp;
                }
            }
        }
    }
    public int Gold { get; set; }

    
}

public class Monster : Character // Monster 캐릭터 관리
{
    public int MonsterType { get; set; }
    public int MonsterID { get; set; }
    public bool IsDead { get; set; }
    // 몬스터 등급 스톤 -> 브론즈 -> 아이언 - > 실버 -> 골드 -> 플래티넘랭크 순이다.
    // 스톤(LV.1~6)
    public Monster(int id) // MonsterType 1번은 잡몹, 2번은 레어몹, 3번은 보스몹
    {
        if (id == 1)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 1;
            this.Name = "흰색 슬라임[등급: 스톤]"; // EasyScreen
            this.Atk = 2;
            this.Def = 1;
            this.MaxHP = 30;
            this.NowHP = 30;
            Console.WriteLine("설명: 동그란 흰색 슬라임이다.");
        }
        else if (id == 2)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 2;
            this.Name = "고블린[등급: 스톤]"; // EasyScreen
            this.Atk = 2;
            this.Def = 3;
            this.MaxHP = 28;
            this.NowHP = 28;
            Console.WriteLine("설명: 맨손상태, 가죽으로 쪼가리 몸에 두르고있다.");
        }
        else if (id == 3)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 4;
            this.Name = "전투병 고블린[등급: 스톤]"; // EasyScreen
            this.Atk = 3;
            this.Def = 4;
            this.MaxHP = 33;
            this.NowHP = 33;
            Console.WriteLine("설명: 칼날 다 빠지고 녹슨 롱소드를 손에 쥐고 있다, 흉부에 가죽 갑옷을 입고있다");
        }
        else if (id == 4)
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 6;
            this.Name = "홉 고블린[등급: 레어 스톤]"; // EasyScreen 
            this.Atk = 6;
            this.Def = 5;
            this.MaxHP = 54;
            this.NowHP = 54;
            Console.WriteLine("설명: 키가 사람 평균 정도다, 제대로 된 가죽 갑옷을 입고 있다, 무기는 조잡하게 만든 몽둥이");
        }
        else if (id == 5)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 1;
            this.Name = "스켈레톤[등급: 스톤]"; // NormalScreen
            this.Atk = 2;
            this.Def = 1;
            this.MaxHP = 15;
            this.NowHP = 15;
            Console.WriteLine("설명: 아무 장비도 장착 안 되어있는 그냥 스켈레톤이다 하지만 무리지어 다니기 때문에 다구리에 장사없으니 조심하자.");
        }
        else if (id == 6)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 4;
            this.Name = "궁수 스켈레톤[등급: 스톤]"; // NormalScreen
            this.Atk = 5;
            this.Def = 2;
            this.MaxHP = 20;
            this.NowHP = 20;

            Console.WriteLine("설명: 활, 가죽 누더기를 장착하고있다, 죽기전에는 궁수였던거 같다.");

        }
        else if (id == 7)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 3;
            this.Name = "전사 스켈레톤[등급: 스톤]"; // NormalScreen
            this.Atk = 4;
            this.Def = 3;
            this.MaxHP = 23;
            this.NowHP = 23;
            Console.WriteLine("설명: 들고있는 근접 무기가 다양하다, 대부분 녹슨 사슬갑옷을 장착, 죽기전에 전사였던거 같다.");

        }

        else if (id == 8)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 7;
            this.Name = "스피어 군단장 언데드[등급: 브론즈]"; // NormalScreen
            this.Atk = 4;
            this.Def = 3;
            this.MaxHP = 23;
            this.NowHP = 23;
            Console.WriteLine("설명: 글레이즈 폴암, 부서진 파급 갑옷 장착, 꽤나 좋은 품질을 장비를 하고 있다 ");

        }
        else if (id == 9) //수정중
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 8;
            this.Name = "츠바이헨더 군단장 언데드[등급: 레어 브론즈]"; // NormalScreen
            this.Atk = 4;
            this.Def = 3;
            this.MaxHP = 23;
            this.NowHP = 23;
            Console.WriteLine("설명: 은빛 츠바이헨더, 사슬+판급 갑옷 장착, 공략하면 낮은 확률로 은빛 츠바이헨더가 드랍된다는 소문이 있다.  살아생전 꽤나 실력이 있는 군단장이었던 거 같다 하지만 죽었죠?... ");
            // 10 분의 1 확률로 은빛 츠바이헨더 드랍 기능 구현
        }
        else if (id == 10) // 수진님 몬스터
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 7;
            this.Name = "War 고스트[등급: 브론즈]"; // NormalScreen
            this.Atk = 7;
            this.Def = 7;
            this.MaxHP = 63;
            this.NowHP = 63;
            Console.WriteLine("설명: 검은 판급갑옷, 검은 대검 or 검은 방패 한손무기 장착, 발생 원인은 파악을 못 하였으나 전쟁터에서 죽은 사람의 원혼이 뭉쳐서 탄생한다는 소문이 있다, ");
        }
        else if (id == 11)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 7;
            this.Name = " 워리어 비스트맨(돌산양)[등급: 브론즈]"; // HardScreen
            this.Atk = 6;
            this.Def = 5;
            this.MaxHP = 50;
            this.NowHP = 50;
            Console.WriteLine("설명: 둔기 or 도끼를 들고 있다, 갑옷은 인간의 뼈로 만든 흉갑이며 기본 2미터 크기이다. ");
            //Console.WriteLine("비스트맨의 종은 다양하다 하지만 이 던전에는 돌산양 비스트맨이 무리지어 살고있다. 얼굴은 돌산양 상반신 인간 하반신 말 이다. 박치기를 맞으면 상대는 대부분 즉사 한다고 하니 조심하자.");  던전 입장시 설명문으로 사용 예정 -> Dungeon 이동
        }   //Console.WriteLine("선호하는 식량은 인간이며 둔기로 전투불능으로 만들어 신선하게 먹는 걸 좋아한다.")
        else if (id == 12)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 9;
            this.Name = "정예 워리어 비스트맨(돌산양)[등급: 아이언]"; // HardScreen
            this.Atk = 8;
            this.Def = 7;
            this.MaxHP = 65;
            this.NowHP = 65;
            Console.WriteLine("설명: 쌍수 시미터, 체인+판급 합성 갑옷을 장착, 인간 전사를 사냥해서 전리품을 장착한다, 큰 체구에 비해 상당히 민첩하며 괜찮은 장비를 보유하고있어서 공략하기 힘들다. ");
        }
        else if (id == 13)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 7;
            this.Name = "헌터 비스트맨(돌산양)[등급: 아이언]"; // HardScreen
            this.Atk = 6;
            this.Def = 5;
            this.MaxHP = 50;
            this.NowHP = 50;
            Console.WriteLine("설명: 쌍수 시미터, 체인+판급 합성 갑옷을 장착, 인간 전사를 사냥해서 전리품을 장착한다, 큰 체구에 비해 상당히 민첩하며 괜찮은 장비를 보유하고있어서 공략하기 힘들다. ");
            Console.WriteLine("설명: 오랫동안 죽지않고 사냥으로 경험을 쌓은 헌터 비스트맨은 골드 등급 까지도 갈수 있다. ");
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
        //    this.Name = "킹 비스트맨(돌산양)  Boss[]";
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
        //    this.Name = "본 엘더리치  Boss[]";
        //    this.Atk = 30;
        //    this.Def = 5;
        //    this.MaxHP = 600;
        //    this.NowHP = 600;
        //}
        //else
        //{
        //    //예외처리
        //}
        else
        {
            //예외처리
        }

    }
}

public class Skil
{
    public int ID { get; set; }
    public String? Name { get; set; }
    public float Damage { get; set; }
    public double skilRatiod {  get; set; }
    public int range { get; set; }
    public bool IsHad {  get; set; }
    public int Cost {  get; set; }
    public int type { get; set; } // 1물리 2마법
    public string Description { get; set; }
}