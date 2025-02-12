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
    public string Details { get; set; }
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
                if ((random.Next(min, max) - target.Def * 0.5) <= 0)
                {
                    target.NowHP = (float)(target.NowHP - 1);
                }
                else
                {
                    target.NowHP = (float)(target.NowHP - (random.Next(min, max) + Math.Ceiling(random.Next(min, max) * 0.6)) - target.Def * 0.5);
                }
                    
                //Console.WriteLine("치명타 공격!!");
                Utility.ColorWrite("치명타 공격!!", ConsoleColor.Red);
                Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                Console.WriteLine();
                Console.WriteLine("Lv.{0} {1}", target.Level, target.Name);
                Console.WriteLine();

            }
            else
            {
                if ((random.Next(min, max) - target.Def * 0.5) <= 0)
                {
                    target.NowHP = (float)(target.NowHP - 1);
                }
                else
                {
                    target.NowHP = (float)(target.NowHP - (random.Next(min, max) - target.Def * 0.5));
                }
                Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                Console.WriteLine();
                Console.WriteLine("Lv.{0} {1}", target.Level, target.Name);
                Console.WriteLine();
            }
        }
    }
    //스킬사용
    public bool CharacterSkil(Character attacker, Character target, Skil skil)
    {
        if (attacker.NowMP < skil.Cost)
        {
            Utility.ColorWrite("MP가 부족합니다", ConsoleColor.Red);
            Console.WriteLine();
            Console.WriteLine("현재 MP : {0}", attacker.NowMP);
            Console.ReadKey();
            Console.Clear();
            return false;
        }
        else
        {
            float tempHP = target.NowHP;
            float tempMP = attacker.NowMP;
            Console.WriteLine("{0}의 {1} 스킬사용 ", attacker.Name, skil.Name);
            //target.NowHP = (float)(target.NowHP - Math.Ceiling(skil.Damage * (attacker.Atk * 0.3)));
            if (skil.type == 1)
            {
                Random random = new Random();
                if (random.Next(1, 100) <= 15)
                {
                    Utility.ColorWrite("치명타 공격!!", ConsoleColor.Red);
                    if ((float)((Math.Ceiling(skil.Damage + (attacker.Atk * skil.skilRatiod))) - target.Def * 0.5) <= 0)
                    {
                        target.NowHP = (float)(target.NowHP - 1);
                    }
                    else
                    {
                        target.NowHP = (float)(target.NowHP - (skil.Damage + (attacker.atk * skil.skilRatiod) + ((attacker.atk * skil.skilRatiod) * 0.6)) - target.Def * 0.5);
                    }

                    Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                    Console.WriteLine();
                    return true;
                }
                else
                {
                    if ((float)((Math.Ceiling(skil.Damage + (attacker.Atk * skil.skilRatiod))) - target.Def * 0.5) <= 0)
                    {
                        target.NowHP = (float)(target.NowHP - -1);
                    }
                    else
                    {
                        target.NowHP = (float)(target.NowHP - (Math.Ceiling(skil.Damage + (attacker.Atk * skil.skilRatiod))) - target.Def * 0.5);
                    }
                    Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                    Console.WriteLine();
                    return true;
                }

            }
            else
            {
                if ((float)((Math.Ceiling(skil.Damage + (attacker.Atk * skil.skilRatiod))) - target.Def * 0.5) <= 0)
                {
                    target.NowHP = (float)(target.NowHP - 1);
                }
                else
                {
                    target.NowHP = (float)(target.NowHP - (Math.Ceiling(skil.Damage + (attacker.Atk * skil.skilRatiod))) - target.Def * 0.5);

                    Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                    Console.WriteLine();
                }

                return true;
            }
            
        }
        return false;
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
                Atk = 15;
                Def = 2;
                MaxMP = 20;
                NowMP = 20;
            }
            else if (job == "마법사")
            {
                MaxHP = 100;
                NowHP = 100;
                Atk = 10;
                Def = 1;
                MaxMP = 50;
                NowMP = 50;
            }
            else if (job == "모험가")
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
    // 스톤(Lv.1~6) -> 브론즈(Lv.7~12) -> 아이언(Lv.13~18) -> 실버(Lv.19~28) -> 골드(Lv.29~35) -> 플래티넘(Lv.40~)
    public Monster(int id) // MonsterType 1번은 잡몹, 2번은 레어몹, 3번은 보스몹
    {
        if (id == 1)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 1;
            this.Name = "흰색 슬라임[등급: 스톤]"; // EasyScreen
            this.Atk = 3;
            this.Def = 0;
            this.MaxHP = 30;
            this.NowHP = 30;
            this.Details = "설명: 장비 장착 없음, 동그란 흰색 슬라임이다.";
        }
        else if (id == 2)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 2;
            this.Name = "고블린[등급: 스톤]"; // EasyScreen
            this.Atk = 4;
            this.Def = 1;
            this.MaxHP = 28;
            this.NowHP = 28;
            this.Details = "설명: 장비 장착 없음, 생가죽 팬티 장착, 손톱과 발톱으로 공격한다.";
        }
        else if (id == 3)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 4;
            this.Name = "전투병 고블린[등급: 스톤]"; // EasyScreen
            this.Atk = 5;
            this.Def = 2;
            this.MaxHP = 33;
            this.NowHP = 33;
            this.Details = "설명: 녹슨 쇼트소드, 흉부에 생가죽 갑옷 장착, 무기를 들고있어 조금 위협적이다.";
        }
        else if (id == 4)
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 6;
            this.Name = "홉 고블린[등급: 레어 스톤]"; // EasyScreen 
            this.Atk = 7;
            this.Def = 3;
            this.MaxHP = 50;
            this.NowHP = 50;
            this.Details = "설명:  몽둥이 or 녹슨 아밍소드, 제대로 된 가죽 갑옷 장착, 키가 사람 평균 정도이며 고블린 보다는 지능이 좋다,";
        }
        else if (id == 5)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 1;
            this.Name = "스켈레톤[등급: 스톤]"; // NormalScreen
            this.Atk = 3;
            this.Def = 1;
            this.MaxHP = 15;
            this.NowHP = 15;
            this.Details = "설명: 장비 장착 없음, 그냥 스켈레톤이다 하지만 무리지어 다니기 때문에 다구리에 장사없으니 조심하자.";
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
            this.Details = "설명: 활, 가죽 누더기를 장착, 죽기전에는 궁수였던거 같다.";

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
            this.Details = "설명: 들고있는 근접 무기가 다양함,녹슨 사슬갑옷 장착, 살아생전에 전사였던거 같다.";

        }

        else if (id == 8)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 7;
            this.Name = "스피어 정예병 언데드[등급: 브론즈]"; // NormalScreen
            this.Atk = 7;
            this.Def = 5;
            this.MaxHP = 48;
            this.NowHP = 48;
            this.Details = "설명: 글레이즈 폴암, 부서진 파급 갑옷 장착, 꽤나 좋은 품질을 장비를 하고 있다 살아생전에 정예병사였던거 같다. ";

        }
        else if (id == 9) //수정중
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 12;
            this.Name = "츠바이헨더 군단장 언데드[등급: 레어 브론즈]"; // NormalScreen
            this.Atk = 8;
            this.Def = 9;
            this.MaxHP = 62;
            this.NowHP = 62;
            this.Details = "설명: 은빛 츠바이헨더, 사슬+판급 갑옷 장착, 살아생전 꽤나 실력이 있는 군단장이었던 거 같다 하지만 죽었죠?... ";
            // 10 분의 1 확률로 은빛 츠바이헨더 드랍 기능 구현 // 공략하면 낮은 확률로 은빛 츠바이헨더가 드랍된다는 소문이 있다. 
        }
        else if (id == 10) // 수진님 몬스터
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 12;
            this.Name = "War 고스트[등급: 레어 브론즈]"; // NormalScreen
            this.Atk = 10;
            this.Def = 1;
            this.MaxHP = 84;
            this.NowHP = 84;
            this.Details = "설명: 검은 판급갑옷, 검은 대검 or 검은 방패 한손무기 장착, 발생 원인은 파악을 못 하였으나 전쟁터에서 죽은 사람의 원혼이 뭉쳐서 탄생한다는 소문이 있다, ";
        }
        else if (id == 11)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 12;
            this.Name = " 워리어 비스트맨(돌산양)[등급: 브론즈]"; // HardScreen
            this.Atk = 7;
            this.Def = 5;
            this.MaxHP = 58;
            this.NowHP = 58;
            this.Details = "설명: 둔기 or 도끼, 갑옷은 인간의 뼈로 만든 흉갑 장착, 항상 전투에 목말라있다. ";
            //Console.WriteLine("비스트맨의 종은 다양하다 하지만 이 던전에는 돌산양 비스트맨이 무리지어 살고있다. 기본 2미터 크기이며 얼굴은 돌산양 상반신 인간 하반신 말 이다. 박치기를 맞으면 상대는 대부분 즉사 한다고 하니 조심하자.");  던전 입장시 설명문으로 사용 예정 -> Dungeon 이동
        }   //Console.WriteLine("선호하는 식량은 인간이며 둔기로 전투불능으로 만들어 신선하게 먹는 걸 좋아한다.")
        
        else if (id == 12)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 14;
            this.Name = "정예 워리어 비스트맨(돌산양)[등급: 아이언]"; // HardScreen
            this.Atk = 10;
            this.Def = 7;
            this.MaxHP = 65;
            this.NowHP = 65;
            this.Details = "설명: 배틀액스, 판급갑옷 장착, 인간을 죽여서 장비를 장착하기도 한다, 전투에 노련한 자들이다 발차기를 조심하자. ";
        }
        else if (id == 13)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 15;
            this.Name = "half 키메라[등급: 아이언]"; // HardScreen
            this.Atk = 12;
            this.Def = 5;
            this.MaxHP = 78;
            this.NowHP = 78;
            this.Details = "설명: 장비 장착 없음, 키메라는 여러 생물체의 특정 부위가 합쳐진 생명체이다 종류가 다양해서 특정하기 힘들다 성체가 아니라 아직 약하다. ";
            //설명: ";
        }
        else if (id == 14)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 16;
            this.Name = "헌터 비스트맨(돌산양)[등급: 아이언]"; // HardScreen
            this.Atk = 14;
            this.Def = 7;
            this.MaxHP = 70;
            this.NowHP = 70;
            this.Details = "설명: 쌍수 시미터, 경번갑 갑옷 장착, 인간 전사를 사냥해서 전리품을 장착한다, 큰 체구에 비해 상당히 민첩하며 괜찮은 장비를 보유하고있어서 공략하기 힘들다. ";
            //설명: 오랫동안 죽지않고 사냥으로 경험을 쌓은 헌터 비스트맨은 골드 등급 까지도 갈수 있다. ";
        }
        
        else if (id == 15)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 18;
            this.Name = "시전드 헌터 비스트맨(돌산양)[등급: 레어 아이언]"; // HardScreen
            this.Atk = 30;
            this.Def = 10;
            this.MaxHP = 82;
            this.NowHP = 82;
            this.Details = "설명: 소드  브레이커 or 자마다르, 천산갑비늘 어린갑 장착, 수많은 전사를 사냥한 헌터 전문가이다 은신이 특화이며 단검을 주로 사용한다 눈을 감지마라 감는순간 죽으니...";
            //설명:  ";
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
    public double skilRatiod { get; set; }
    public int range { get; set; }
    public bool IsHad { get; set; }
    public int Cost { get; set; }
    public int type { get; set; } // 1물리 2마법
    public string Description { get; set; }
    public int Price { get; set; }

}