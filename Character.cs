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
                    target.NowHP = (float)(target.NowHP - (skil.Damage + (attacker.atk * skil.skilRatiod) + ((attacker.atk * skil.skilRatiod) * 0.6)));
                    Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                    Console.WriteLine();
                }
                else
                {
                    target.NowHP = (float)(target.NowHP - (Math.Ceiling(skil.Damage + (attacker.Atk * skil.skilRatiod))));
                    Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                    Console.WriteLine();
                }

            }
            else
            {
                target.NowHP = (float)(target.NowHP - (Math.Ceiling(skil.Damage + (attacker.Atk * skil.skilRatiod))));
                Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", target.Level, target.Name, tempHP - target.NowHP);
                Console.WriteLine();
            }
            attacker.NowMP = attacker.NowMP - skil.Cost;
            Console.WriteLine("MP: {0} -> {1}", tempMP, attacker.NowMP);

            return true;
        }


    }

    //광역기
    public bool CharacterSkil(Character attacker, List<Character> target, Skil skil)
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
                        target[i].NowHP = (float)(target[i].NowHP - (skil.Damage + (attacker.atk * skil.skilRatiod) + ((attacker.atk * skil.skilRatiod) * 0.6)));
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
            return true;
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
            else if (job == "마검사")
            {
                MaxHP = 125;
                NowHP = 125;
                Atk = 13;
                Def = 2;
                MaxMP = 40;
                NowMP = 40;
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
    // 스톤(Lv.1~6) -> 브론즈(Lv.7~12) -> 아이언(Lv.13~18) -> 실버(Lv.19~28) -> 골드(Lv.29~35) -> 플래티넘(Lv.40~) -> 예측불가(Boss)
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
            this.Details = "설명:  몽둥이 or 녹슨 아밍소드, 제대로 된 가죽 갑옷 장착, 당신을 죽이고 먹을 생각에 신나서 방방 뛰고있습니다.";
        }
        else if (id == 5)
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 6;
            this.Name = "전투병 홉 고블린[등급: 레어 스톤]"; // EasyScreen 
            this.Atk = 7;
            this.Def = 4;
            this.MaxHP = 60;
            this.NowHP = 60;
            this.Details = "설명: 녹슨 아밍소드, 와일드보어 가죽갑옷 장착, 당신을 보더니 뛰어옵니다 이런! 당신을 죽일생각입니다.";
        }
        else if (id == 6)
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
        else if (id == 7)
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
        else if (id == 8)
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

        else if (id == 9)
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
        else if (id == 10) //수정중
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
        else if (id == 11) // 수진님 몬스터
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
        else if (id == 12)
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 11;
            this.Name = "DDr.미믹[등급: 레어 브론즈]"; // HardScreen
            this.Atk = 11;
            this.Def = 11;
            this.MaxHP = 40;
            this.NowHP = 40;
            this.Details = "설명: D급 미믹이다, 토벌 시 입을 벌리면서 랜덤 아이템을 뱉는다, [미믹 등급: DDr. -> CDr. -> BDr. -> ADr.]";
            //추가설명: n, n, n, 확률 드랍";
        }
        else if (id == 13)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 12;
            this.Name = " 워리어 비스트맨(산양인)[등급: 브론즈]"; // HardScreen
            this.Atk = 7;
            this.Def = 5;
            this.MaxHP = 58;
            this.NowHP = 58;
            this.Details = "설명: 둔기 or 도끼, 갑옷은 인간의 뼈로 만든 흉갑 장착, 항상 전투에 목말라있다.";
        }   //Console.WriteLine("선호하는 식량은 인간이며 둔기로 전투불능으로 만들어 신선하게 먹는 걸 좋아한다.")
        
        else if (id == 14)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 14;
            this.Name = "정예 워리어 비스트맨(산양인)[등급: 아이언]"; // HardScreen
            this.Atk = 10;
            this.Def = 7;
            this.MaxHP = 65;
            this.NowHP = 65;
            this.Details = "설명: 배틀액스, 판급갑옷 장착, 인간을 죽여서 장비를 장착하기도 한다, 전투에 노련한 자들이다 발차기를 조심하자. ";
        }
        else if (id == 15)
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
        else if (id == 16)
        {
            this.MonsterType = 1;
            this.MonsterID = id;
            this.Level = 16;
            this.Name = "헌터 비스트맨(산양인)[등급: 아이언]"; // HardScreen
            this.Atk = 14;
            this.Def = 7;
            this.MaxHP = 70;
            this.NowHP = 70;
            this.Details = "설명: 쌍수 시미터, 경번갑 갑옷 장착, 인간 전사를 사냥해서 전리품을 장착한다, 큰 체구에 비해 상당히 민첩하며 괜찮은 장비를 보유하고있어서 공략하기 힘들다, 당신을 사냥감으로 인식했습니다 ";
            //설명: 오랫동안 죽지않고 사냥으로 경험을 쌓은 헌터 비스트맨은 골드 등급 까지도 갈수 있다. ";
        }
        else if (id == 17) //애착 몬스터
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 18;
            this.Name = "시전드 헌터 비스트맨(산양인)[등급: 레어 아이언]"; // HardScreen
            this.Atk = 30;
            this.Def = 10;
            this.MaxHP = 85;
            this.NowHP = 85;
            this.Details = "설명: 소드  브레이커 or 자마다르, 천산갑비늘 어린갑 장착, 수많은 전사를 사냥한 헌터 전문가이다 은신이 특화이며 단검을 주로 사용한다 눈을 감지마라 감는순간 죽으니...";
            //추가설명: n, n, n, 확률 드랍";
        }
        else if (id == 18)
        {
            this.MonsterType = 2;
            this.MonsterID = id;
            this.Level = 22;
            this.Name = "CDr.미믹[등급: 레어 아이언]"; // HardScreen
            this.Atk = 22;
            this.Def = 22;
            this.MaxHP = 40;
            this.NowHP = 40;
            this.Details = "설명: C급 미믹이다, 토벌 시 입을 벌리면서 랜덤 아이템을 뱉는다, [미믹 등급: DDr. -> CDr. -> BDr. -> ADr.]";
            //추가설명: n, n, n, 확률 드랍";
        }
        else if (id == 30)
        {
            this.MonsterType = 3;
            this.MonsterID = id;
            this.Level = 13;
            this.Name = "탐욕의군주 고블린 로드(Boss)[등급: 예측불가]"; // EasyScreen
            this.Atk = 20;
            this.Def = 10;
            this.MaxHP = 100;
            this.NowHP = 100;
            this.Details = "설명: 칼 끄트머리를 우툴두툴 끝이 뾰족한 펄션, 차하르아네 갑주 장착, 일반 고블린 보다는 키와 덩치가 크다, 당신을 찢어 죽일 생각 ";
            //설명:  고블린 무리를 이끄는 고블린 로드가 있다고 한다, 고블린 로드 상태는 어떻게 토벌이 가능하나 만약 홉 고블린 로드가 있다면 Lv.18 이하 모험가는 도망가는걸 추천한다.  ";
        }   //설명:  홉고블린은 크기가 사람 만하며 고블린 보다 힘, 덩치, 능지가 높다  
            //진화단계: 고블린 -> 홉 고블린, 고블린 로드 -> 홉 고블린 로드 이다.
        else if (id == 31)
        {
            this.MonsterType = 3;
            this.MonsterID = id;
            this.Level = 20;
            this.Name = "본 엘더리치(Boss)[등급: 예측불가]"; // NormalScreen
            this.Atk = 28;
            this.Def = 10;
            this.MaxHP = 150;
            this.NowHP = 150;
            this.Details = "설명: 다크 본 스태프, 심연의 보주, 죽은 자의 로브 장착,\n 몸은 미라처럼 삐쩍 마르고 두 눈과 벌린 입에서는 검은색 연기가 피어오른다."; //\n 임시
        }   // 설명: 어둠의 마법을 연구하는건 금기다 그럼에도 어둠에 마법을 연구하는 마법사가 있다 그럼 저주에 걸려 먹지도 자지도 않고 어둠의 마법에 연구만 하다 결국 죽어서 언데드가 된다.
            // 스킬: 뼈보호막 전개(실드가 생겨서 몸을 보호한다), 본 스피어 라이트닝(전기에 둘러 쌓인 뼈 창을 방출한다), 

        else if (id == 32)
        {
            this.MonsterType = 3;
            this.MonsterID = id;
            this.Level = 30;
            this.Name = " 붉은 바폰메트인(Boss)[등급: 예측불가]"; // HardScreen
            this.Atk = 31;
            this.Def = 16;
            this.MaxHP = 220;
            this.NowHP = 220;
            this.Details = "설명: 일격의 파르티잔, 팔콘경번갑 장착, 바폰메트는 악마종의 하나다 생김새는 산양인이랑 비슷하나 키, 덩치, 뿔 크기가 더 크며 털 색이 붉은색이다";
        }   // 설명: 던전에는 아인종 중에 하나인 산양인 비스트맨이 무리 지어 살고있다. 기본 2미터 크기이며 외형은 머리 산양 상반신 인간 하반신 산양의 다리, 온몸에 흰색 털이 나있다.
            // 설명: 던전 깊숙한 곳에 악마종인 파르티잔이 산양인을 통치하고 있다는 소문이 있다 그게 사실이라면 싸우지 말고 도망가는 것이 좋겠다.
            // 스킬: 
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
    public float Damage { get; set; } // 데미지
    public double skilRatiod { get; set; } // 데미지 *
    public int range { get; set; } // 범위
    public bool IsHad { get; set; } // 스킬소유 여부
    public int Cost { get; set; } //MP
    public int type { get; set; } // 1물리 2마법
    public string Description { get; set; } // 스킬설명
}

public class MonsterSkil
{
    public int ID { get; set; }
    public String? Name { get; set; }
    public float Damage { get; set; } // 데미지
    public double skilRatiod { get; set; } // 데미지 *
    public int range { get; set; } // 범위
    public bool IsHad { get; set; } // 스킬소유 여부
    public int Cost { get; set; } //MP
    public int type { get; set; } // 1물리 2마법
    public string Description { get; set; } // 스킬설명
}