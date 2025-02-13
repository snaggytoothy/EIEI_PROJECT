using System;
using System.ComponentModel.Design;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
namespace EIEIE_Project;

class Dungeon
{
    public void DoorDungeon(GameManager gameManager)
    {
        Utility.Loading();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("던전에 들어왔습니다.");
            Console.WriteLine("3개의 통로가 눈앞에 보입니다.");
            Console.WriteLine("각 통로 마다 팻말이 박혀있습니다.");
            Console.WriteLine();
            Console.Write("1. ");
            Utility.ColorWrite("쉬움 ", ConsoleColor.Green);
            Console.WriteLine("| Lv 1 이상 입장가능");
            Console.Write("2. ");
            Utility.ColorWrite("보통 ", ConsoleColor.Yellow);
            Console.WriteLine("| Lv 8 이상 입장가능");
            Console.Write("3. ");
            Utility.ColorWrite("어려움 ", ConsoleColor.DarkRed);
            Console.WriteLine("| Lv 14 이상 입장가능");
            Console.WriteLine();
            Utility.ColorWrite("0.나가기\n\n", ConsoleColor.Red);

            int input = Utility.GetInput(0, 3);

            switch (input)
            {
                case 1:
                    if (gameManager.player.Level >= 1) EasyScreen(gameManager);
                    else { Utility.ColorWrite("레벨이 부족합니다! (Lv.1 이상 필요) (아무 키나 눌러 확인)\n", ConsoleColor.Red); Console.ReadKey(); }
                    break;
                case 2:
                    if (gameManager.player.Level >= 8) NormalScreen(gameManager);
                    else { Utility.ColorWrite("레벨이 부족합니다! (Lv.8 이상 필요) (아무 키나 눌러 확인)\n", ConsoleColor.Red); Console.ReadKey(); }
                    break;
                case 3:
                    if (gameManager.player.Level >= 14) HardScreen(gameManager);
                    else { Utility.ColorWrite("레벨이 부족합니다! (Lv.12 이상 필요) (아무 키나 눌러 확인)\n", ConsoleColor.Red); Console.ReadKey(); }
                    break;
            }
            if (input == 0) break;
        }
    }

    public void EasyScreen(GameManager gameManager)
    {
        int cmd;
        Console.WriteLine("던전을 걸어가고 있습니다.");
        for (int i = 0; i < 3; i++)
        {
            Utility.ColorWrite("뚜벅\n", ConsoleColor.Cyan);
            Thread.Sleep(1000); // 1초 시간지연
        }

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("[던전의 정보]");
        Console.WriteLine("고블린 무리를 지배하는 고블린 로드는 강력한 지휘력과 전투 능력을 갖춘 존재다.\n그보다 더욱 위협적인 홉 고블린 로드는 인간과 맞먹는 체격과 지능, 그리고 압도적인 힘을 지닌다.\n일반 고블린이 홉 고블린으로 진화하듯, 로드 역시 더 강한 존재로 변하며 군대를 이끈다.\n 만약 홉 고블린 로드가 등장 한다면 Lv.18 이하의 모험가는 전투를 고민하기 전에 즉시 도망치는 것이 현명할 것이다.\n진화 단계 : 고블린 → 홉 고블린, 고블린 로드 → 홉 고블린 로드");
        Console.WriteLine();
        Console.Write("난이도 ");
        Utility.ColorWrite("쉬움", ConsoleColor.Green);
        Console.WriteLine("입니다.");
        Console.WriteLine();
        // Utility(캐릭터 상태창);
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine($"Lv. {gameManager.player.Level}");
        Console.WriteLine($"{gameManager.player.Name} ({gameManager.player.Job})");
        Console.WriteLine($"공격력: {gameManager.player.Atk}");
        Console.WriteLine($"방어력: {gameManager.player.Def}");
        Console.WriteLine($"체력: {gameManager.player.NowHP}\nGold: {gameManager.player.Gold} G");
        Console.WriteLine($"경험치: {gameManager.player.NowExp} / {gameManager.player.MaxExp}");

        Console.WriteLine();
        Utility.ColorWrite("0. 도망가기\n", ConsoleColor.Yellow);
        Utility.ColorWrite("1. 진입하기\n", ConsoleColor.Yellow);
        Console.WriteLine();

        cmd = Utility.GetInput(0, 1);
        if (cmd == 0)
        {
            return;
        }
        else if (cmd == 1)
        {
            while (true)
            {
                if (gameManager.exitFlag == 1)
                {
                    gameManager.exitFlag = 0;
                    break;
                }
                else if (gameManager.exitFlag == 0)
                {
                    DungeonProgress(gameManager, 1); // 던전입구 입장
                }
                else break;
            }

        }
    }

    public void NormalScreen(GameManager gameManager)
    {
        int cmd;
        Console.WriteLine("던전을 걸어가고 있습니다.");
        for (int i = 0; i < 3; i++)
        {
            Utility.ColorWrite("뚜벅\n", ConsoleColor.Cyan);
            Thread.Sleep(1000); // 1초 시간지연
        }

        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("[던전의 정보]");
        Console.WriteLine("이곳은 언데드가 배회하는 저주의 던전. 어둠 속에서 스켈레톤 군단이 무리를 지어 움직인다.\r\n가장 두려운 존재는, 금기의 마법을 탐구하다 저주에 잠식된 한 마법사였다.\r\n그는 먹지도, 자지도 못한 채 연구에 몰두하다가 결국 육체를 잃고 언데드가 되었다.\r\n그러나 죽음조차 그의 집념을 꺾지 못했고, 그는 이제 불멸의 존재로 남았다.\r\n그의 실험실에서는 아직도 마법의 촛불이 흔들리고, 금단의 연구는 계속되고 있다.\r\n그리고… 어둠 속에서 그의 차가운 붉은 눈이 모험가를 지켜보고 있다...");
        Console.WriteLine();
        Console.Write("난이도 ");
        Utility.ColorWrite("보통", ConsoleColor.Yellow);
        Console.WriteLine("입니다.");
        Console.WriteLine();

        // Utility(캐릭터 상태창);

        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine($"Lv. {gameManager.player.Level}");
        Console.WriteLine($"{gameManager.player.Name} ({gameManager.player.Job})");
        Console.WriteLine($"공격력: {gameManager.player.Atk}");
        Console.WriteLine($"방어력: {gameManager.player.Def}");
        Console.WriteLine($"체력: {gameManager.player.NowHP}\nGold: {gameManager.player.Gold} G");
        Console.WriteLine($"경험치: {gameManager.player.NowExp} / {gameManager.player.MaxExp}");

        Console.WriteLine();
        Utility.ColorWrite("0. 도망가기\n", ConsoleColor.Yellow);
        Utility.ColorWrite("1. 진입하기\n", ConsoleColor.Yellow);
        Console.WriteLine();

        cmd = Utility.GetInput(0, 1);
        if (cmd == 0)
        {
            return;
        }
        else if (cmd == 1)
        {
            while (true)
            {
                if (gameManager.exitFlag == 1)
                {
                    gameManager.exitFlag = 0;
                    break;
                }
                else if (gameManager.exitFlag == 0)
                {
                    DungeonProgress(gameManager, 2); // 던전입구 입장
                }
                else break;

            }
        }
    }

    public void HardScreen(GameManager gameManager)
    {
        int cmd;
        Console.WriteLine("던전을 걸어가고 있습니다.");
        for (int i = 0; i < 3; i++)
        {
            Utility.ColorWrite("뚜벅\n", ConsoleColor.Cyan);
            Thread.Sleep(1000); // 1초 시간지연
        }

        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("[던전의 정보]");
        Console.WriteLine("이 던전에는 산양인 비스트맨들이 무리를 지어 살고 있으며, 그들의 본능은 포식과 사냥이다.\r\n그들은 평균 2미터의 거구에 산양의 머리와 다리, 인간의 상반신을 가진 흉포한 존재.\r\n특히 인간을 선호하는 식성을 가졌으며, 둔기로 전투불능 상태로 만든 뒤 신선한 상태에서 먹는 것을 즐긴다.\r\n그중에서도 가장 두려운 존재는 헌터 비스트맨, 수많은 사냥을 통해 경험을 쌓은 헌터 베테랑은 진화를 한다.\r\n그들은 골드 등급 모험가조차 사냥할 수 있는 강적으로, 그들의 영역에 발을 들인다면 결코 살아남기 어렵다.\r\n\r\n그러나 더 깊이 들어가면 더욱 끔찍한 소문이 들려온다…\r\n던전의 심연에는 ‘악마종 바폰메트인’이 비스트맨들을 지배하고 있다는 전설이 존재한다.\r\n만약 그 소문이 사실이라면, 전투는 어리석은 선택이며 오직 도망만이 유일한 생존법이다.\r\n");
        Console.WriteLine();
        Console.Write("난이도 ");
        Utility.ColorWrite("어려움", ConsoleColor.Red);
        Console.WriteLine("입니다.");
        Console.WriteLine();

        // Utility(캐릭터 상태창);

        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine($"Lv. {gameManager.player.Level}");
        Console.WriteLine($"{gameManager.player.Name} ({gameManager.player.Job})");
        Console.WriteLine($"공격력: {gameManager.player.Atk}");
        Console.WriteLine($"방어력: {gameManager.player.Def}");
        Console.WriteLine($"체력: {gameManager.player.NowHP}\nGold: {gameManager.player.Gold} G");
        Console.WriteLine($"경험치: {gameManager.player.NowExp} / {gameManager.player.MaxExp}");

        Console.WriteLine();
        Utility.ColorWrite("0. 도망가기\n", ConsoleColor.Yellow);
        Utility.ColorWrite("1. 진입하기\n", ConsoleColor.Yellow);
        Console.WriteLine();

        cmd = Utility.GetInput(0, 1);
        if (cmd == 0)
        {
            return;
        }
        else if (cmd == 1)
        {
            while (true)
            {
                if (gameManager.exitFlag == 1)
                {
                    gameManager.exitFlag = 0;
                    break;
                }
                else if (gameManager.exitFlag == 0)
                {
                    DungeonProgress(gameManager, 3); // 던전입구 입장
                }
                else break;

            }
        }

    }

    //몬스터 생성
    void CreateMonster(List<Monster> monsters, int level, int wave) // id 1~3 -> easy 일반 몬스터 id 4~5-> easy 레어 몬스터 id 30 -> easy 보스몬스터 id 6~8->normal 스켈레톤(많이) 9-> normal 일반 10~11 normal 레어몬스터 31 -> normal 보스몬스터 12~16->hard 일반몬스터 17~18-> hard 레어몬스터 32->hard 보스몬스터
    {
        Random random = new Random();
        monsters.Clear();
        int monsterID;
        int monsterNum;
        if (level == 1)
        {
            if (wave == 1)
            {
                monsterNum = random.Next(1, 3);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(1, 4);
                    monsters.Add(new Monster(monsterID));
                }

            }
            else if (wave == 2)
            {
                monsterNum = random.Next(1, 3);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(1, 4);
                    monsters.Add(new Monster(monsterID));
                }
                if (random.Next(1, 101) > 90)
                {
                    monsters.Add(new Monster(random.Next(4, 6)));//레어몬스터 확률생성
                }

            }
            else if (wave == 3)
            {
                monsterNum = random.Next(2, 4);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(1, 4);
                    monsters.Add(new Monster(monsterID));
                }
                monsters.Add(new Monster(30));//보스몬스터 확정생성
            }
        }

        else if (level == 2)
        {
            if (wave == 1)
            {
                monsterNum = random.Next(0, 2);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(9, 10);
                    monsters.Add(new Monster(monsterID));
                }
                monsterNum = random.Next(3, 4);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(6, 9);
                    monsters.Add(new Monster(monsterID));
                }

            }
            else if (wave == 2)
            {
                monsterNum = random.Next(0, 2);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(9, 10);
                    monsters.Add(new Monster(monsterID));
                }
                monsterNum = random.Next(4, 6);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(6, 9);
                    monsters.Add(new Monster(monsterID));
                }
                if (random.Next(0, 101) > 90)
                {
                    monsters.Add(new Monster(random.Next(9, 11)));//레어몬스터 확률
                }

            }
            else if (wave == 3)
            {
                monsterNum = random.Next(2, 4);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(9, 10);
                    monsters.Add(new Monster(monsterID));
                }
                monsterNum = random.Next(6, 8);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(6, 9);
                    monsters.Add(new Monster(monsterID));
                }
                monsters.Add(new Monster(31));//보스몬스터 확정생성
            }
        }

        else if (level == 3)
        {
            if (wave == 1)
            {
                monsterNum = random.Next(3, 5);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(12, 17);
                    monsters.Add(new Monster(monsterID));
                }

            }
            else if (wave == 2)
            {
                monsterNum = random.Next(4, 7);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(12, 17);
                    monsters.Add(new Monster(monsterID));
                }
                if (random.Next(0, 101) > 90)
                {
                    monsters.Add(new Monster(random.Next(17, 19)));//레어몬스터 확률생성
                }
            }
            else if (wave == 3)
            {
                monsterNum = random.Next(7, 11);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(12, 17);
                    monsters.Add(new Monster(monsterID));
                }
                monsters.Add(new Monster(32));//보스몬스터 확정생성
            }
        }
    }

    //던전진행
    public void DungeonProgress(GameManager gameManager, int level)
    {
        //플레이어의 진입시 상태를 저장
        Player tempPlayer = new Player() { NowExp = gameManager.player.NowExp, Gold = gameManager.player.Gold, NowHP = gameManager.player.NowHP, Level = gameManager.player.Level, MaxExp = gameManager.player.MaxExp };
        List<Monster> monsters = new List<Monster>();

        int wave = 3;
        int resultExp = 0;
        //던전시작
        for (int i = 1; i <= wave + 1; i++)
        {
            if (gameManager.exitFlag == 1)
            {
                break;
            }
            else if (gameManager.exitFlag == 0)
            {
                if (i == 1)
                {
                    CreateMonster(monsters, level, i);
                }
                else if (i == 2)
                {
                    CreateMonster(monsters, level, i);
                }
                else if (i == 3)
                {
                    CreateMonster(monsters, level, i);
                }
                else
                {
                    for (int j = 0; j < monsters.Count; j++)
                    {
                        resultExp += monsters[j].Level;
                    }
                    monsters.Clear();
                    //승리화면으로
                    Clear(gameManager, tempPlayer, resultExp, level);
                    gameManager.exitFlag = 1;
                    return;
                }

                while (true)
                {
                    Console.Clear();
                    //플레이어 턴
                    PlayerTurn(gameManager, monsters);
                    //적 몬스터 턴
                    EnemyTurn(gameManager, monsters);
                    if (gameManager.player.NowHP <= 0)
                    {
                        //패배화면으로
                        //monsters.Clear();
                        Fail(gameManager, tempPlayer);
                        if (gameManager.exitFlag == 0)
                        {
                            continue;
                        }
                        else if (gameManager.exitFlag == 1)
                        {
                            break;
                        }
                    }
                    if (monsters.FindAll(x => x.IsDead == true).Count == monsters.Count)
                    {
                        for (int j = 0; j < monsters.Count; j++)
                        {
                            resultExp += monsters[j].Level;
                        }
                        break;
                    }
                }
            }

        }
    }

    void MonsterDisplay(List<Monster> monsters)
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            //살아잇는 몬스터 표시
            if (monsters[i].IsDead == false)
            {
                Utility.ColorWrite($"{i + 1}", ConsoleColor.DarkRed);
                Console.WriteLine(" Lv {0} {1}   HP {2} / {3}  {4}", monsters[i].Level, monsters[i].Name, monsters[i].NowHP, monsters[i].MaxHP, monsters[i].Details);
                Console.WriteLine();
            }
            //죽은 몬스터 표시
            else if (monsters[i].IsDead == true)
            {
                Utility.ColorWrite($"{i + 1} Lv {monsters[i].Level} {monsters[i].Name}   Dead", ConsoleColor.DarkGray);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }

    bool NormalAttack(GameManager gameManager, List<Monster> monsters)
    {
        int input;
        float tempHP;
        while (true)
        {
            Console.Clear();
            //현재 몬스터 표시
            MonsterDisplay(monsters);
            Console.WriteLine("공격할 몬스터를 고르세요");
            Console.Write("0. 뒤로가기");
            Console.WriteLine();
            //몬스터 공격명령
            input = Utility.GetInput(0, monsters.Count);
            //죽은 몬스터 골랐을때
            if (input == 0)
            {
                return false;
            }
            else
            {
                if (monsters[input - 1].IsDead == true)
                {
                    Utility.ColorWrite("잘못된 입력입니다.(아무 키나 눌러 확인)", ConsoleColor.Red);
                    Console.ReadKey();
                }
                //살아있는 몬스터 골랐을때
                else
                {
                    tempHP = monsters[input - 1].NowHP;
                    //결과창 표시
                    Console.WriteLine("Battle!!");
                    Console.WriteLine();
                    Console.WriteLine("{0} 의 공격!", gameManager.player.Name);
                    gameManager.player.Attack(gameManager.player, monsters[input - 1]);//공격
                    //공격한 몬스터가 죽으면
                    if (monsters[input - 1].NowHP <= 0)
                    {
                        monsters[input - 1].IsDead = true;
                        monsters[input - 1].NowHP = 0;
                        gameManager.killCount = gameManager.killCount + 1;
                    }
                    if (monsters[input - 1].IsDead == true)
                    {
                        Utility.ColorWrite($"HP {tempHP.ToString("n1")} -> Dead\n", ConsoleColor.DarkRed);
                    }
                    else
                    {
                        Utility.ColorWrite($"HP {tempHP.ToString("n1")} -> {monsters[input - 1].NowHP.ToString("n1")}\n", ConsoleColor.DarkRed);
                    }

                    Console.WriteLine();
                    Console.WriteLine("아무 키나 눌러 확인");
                    Console.ReadKey();
                    break;
                }
            }

        }
        return true;
    }

    void SkilDisplay(GameManager gameManager)
    {
        Utility.ColorWrite("[스킬 보유 목록]\n", ConsoleColor.Cyan);
        for (int i = 0; i < gameManager.mySkils.Count; i++)
        {
            Utility.ColorWrite($"{i + 1}", ConsoleColor.Cyan);
            Console.WriteLine(" {0} 소모 MP : {1} 기본 데미지 : {2} 공격 계수: {3} 범위 {4} 설명 : {5}", gameManager.mySkils[i].Name, gameManager.mySkils[i].Cost, gameManager.mySkils[i].Damage, gameManager.mySkils[i].skilRatiod, gameManager.mySkils[i].range, gameManager.mySkils[i].Description);
        }
    }

    bool SkilAttack(GameManager gameManager, List<Monster> monsters)
    {
        int skillInput;
        int input;
        while (true)
        {
            Console.Clear();
            SkilDisplay(gameManager);
            Console.WriteLine();
            Console.WriteLine("사용할 스킬을 고르세요");
            Console.Write("0. 뒤로가기");
            Console.WriteLine();
            skillInput = Utility.GetInput(0, gameManager.mySkils.Count);

            if (skillInput == 0)
            {
                return false;
            }
            else
            {   //단일기
                if (gameManager.mySkils[skillInput - 1].range == 1)
                {

                    while (true)
                    {
                        Console.Clear();
                        MonsterDisplay(monsters);
                        Console.WriteLine();
                        Console.WriteLine("공격할 몬스터 고르세요");
                        Console.Write("0. 뒤로가기");
                        Console.WriteLine();
                        input = Utility.GetInput(0, monsters.Count);
                        if (input == 0)
                        {
                            break;
                        }
                        else
                        {
                            if (monsters[input - 1].IsDead == true)
                            {
                                Console.Clear();
                                Utility.ColorWrite("잘못된 입력입니다.(아무 키나 눌러 확인)\n", ConsoleColor.Red);
                                Console.ReadKey();
                                continue;
                            }
                            else
                            {
                                Console.Clear();
                                float tempHP = monsters[input - 1].NowHP;
                                float tempMP = gameManager.player.NowMP;
                                if (gameManager.player.CharacterSkil(gameManager.player, monsters[input - 1], gameManager.mySkils[skillInput - 1]))
                                {

                                    if (monsters[input - 1].NowHP <= 0)
                                    {
                                        monsters[input - 1].IsDead = true;
                                        monsters[input - 1].NowHP = 0;
                                        gameManager.killCount = gameManager.killCount + 1;

                                    }

                                    if (monsters[input - 1].IsDead == true)
                                    {
                                        Utility.ColorWrite($"HP {tempHP.ToString("n1")} -> Dead\n", ConsoleColor.DarkRed);
                                    }
                                    else
                                    {
                                        Utility.ColorWrite($"HP {tempHP.ToString("n1")} -> {monsters[input - 1].NowHP.ToString("n1")}\n", ConsoleColor.DarkRed);
                                    }

                                    Console.WriteLine();
                                    Console.WriteLine();
                                    gameManager.player.NowMP = gameManager.player.NowMP - gameManager.mySkils[skillInput - 1].Cost;
                                    Utility.ColorWrite($"PlayerMP : {tempMP.ToString("n1")} -> {gameManager.player.NowMP.ToString("n1")}\n", ConsoleColor.Blue);
                                    Console.WriteLine("아무 키나 눌러 확인");
                                    Console.ReadKey();
                                    return true;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                        }
                    }

                }
                else if (gameManager.mySkils[skillInput - 1].range >= 2)
                {
                    //광역기
                    while (true)
                    {
                        MonsterDisplay(monsters);
                        Console.WriteLine();
                        Console.WriteLine("공격할 몬스터 고르세요");
                        Console.Write("0. 뒤로가기");
                        Console.WriteLine();
                        input = Utility.GetInput(0, monsters.Count);
                        if (input == 0)
                        {
                            break;
                        }
                        else
                        {
                            if (monsters[input - 1].IsDead == true)
                            {
                                Console.Clear();
                                Utility.ColorWrite("잘못된 입력입니다.(아무 키나 눌러 확인)", ConsoleColor.Red);
                                Console.WriteLine();
                                Console.ReadKey();
                                continue;
                            }
                            else
                            {
                                Console.Clear();
                                float[] tempHP = new float[gameManager.mySkils[skillInput - 1].range];
                                float tempMP = gameManager.player.NowMP;

                                for (int i = 0; i < gameManager.mySkils[skillInput - 1].range; i++)
                                {

                                    if ((input - 1) - (int)(gameManager.mySkils[skillInput - 1].range / 2) + i < 0)
                                    {
                                        continue;
                                    }
                                    else if ((input - 1) - (int)(gameManager.mySkils[skillInput - 1].range / 2) + i >= monsters.Count)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        tempHP[i] = monsters[(input - 1) - (int)(gameManager.mySkils[skillInput - 1].range / 2) + i].NowHP;
                                        if (gameManager.player.CharacterSkil(gameManager.player, monsters[(input - 1) - (int)(gameManager.mySkils[skillInput - 1].range / 2) + i], gameManager.mySkils[skillInput - 1]))
                                        {
                                            if (monsters[(input - 1) - (int)(gameManager.mySkils[skillInput - 1].range / 2) + i].NowHP <= 0)
                                            {
                                                monsters[(input - 1) - (int)(gameManager.mySkils[skillInput - 1].range / 2) + i].IsDead = true;
                                                monsters[(input - 1) - (int)(gameManager.mySkils[skillInput - 1].range / 2) + i].NowHP = 0;
                                                gameManager.killCount = gameManager.killCount + 1;
                                                if (monsters[(input - 1) - (int)(gameManager.mySkils[skillInput - 1].range / 2) + i].IsDead == true)
                                                {
                                                    Utility.ColorWrite($"HP {tempHP[i].ToString("n1")} -> Dead\n", ConsoleColor.DarkRed);
                                                }
                                            }
                                            else
                                            {
                                                Utility.ColorWrite($"HP {tempHP[i].ToString("n1")} -> {monsters[(input - 1) - (int)(gameManager.mySkils[skillInput - 1].range / 2) + i].NowHP.ToString("n1")}\n", ConsoleColor.DarkRed);
                                            }
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                }
                                if (gameManager.player.NowMP < gameManager.mySkils[skillInput - 1].Cost)
                                {
                                    return false;
                                }
                                else
                                {
                                    gameManager.player.NowMP = gameManager.player.NowMP - gameManager.mySkils[skillInput - 1].Cost;
                                    Utility.ColorWrite($"PlayerMP : {tempMP} -> {gameManager.player.NowMP}", ConsoleColor.Blue);
                                    Console.WriteLine();
                                    Console.WriteLine("아무 키나 눌러 확인");
                                    Console.ReadKey();
                                    return true;

                                }
                            }

                        }
                    }
                }
            }
        }
    }

    void UseItem(GameManager gameManager)
    {
        int input;
        //아이템사용
        while (true)
        {
            Console.WriteLine();
            Utility.ColorWrite("[소비 아이템 목록]\n", ConsoleColor.Blue);
            for (int i = 0; i < gameManager.inventoryConsumables.Count; i++)
            {
                if (gameManager.inventoryConsumables[i].Count > 0 && gameManager.inventoryConsumables.Any() == true)
                {
                    Console.Write("-");
                    Utility.ColorWrite($" {i + 1}", ConsoleColor.Blue);
                    Console.WriteLine($" {gameManager.inventoryConsumables[i].Name} | {gameManager.inventoryConsumables[i].Inform} | 보유 개수 : {gameManager.inventoryConsumables[i].Count}");
                }
                else
                {
                    Console.WriteLine("소비아이템이 없습니다");
                }
            }
            Console.WriteLine();
            Utility.ColorWrite("0. 나가기\n\n", ConsoleColor.Red);
            input = Utility.GetInput(0, gameManager.inventoryConsumables.FindAll(x => x.Count > 0).Count);

            if (input == 0)
            {
                break;
            }
            else
            {
                if (gameManager.inventoryConsumables[input - 1].ItemID == 7)
                {
                    gameManager.inventoryConsumables[input - 1].Use(gameManager.player);
                }
                else if (gameManager.inventoryConsumables[input - 1].ItemID == 8)
                {
                    gameManager.inventoryConsumables[input - 1].RecoverMP(gameManager.player);
                }
                else if (gameManager.inventoryConsumables[input - 1].ItemID == 9)
                {
                    gameManager.inventoryConsumables[input - 1].Use(gameManager, 10);
                }
                if (gameManager.inventoryConsumables[input - 1].Count == 0)
                {
                    gameManager.inventoryConsumables.Remove(gameManager.inventoryConsumables[input - 1]);
                }
            }
        }
    }

    public void PlayerTurn(GameManager gameManager, List<Monster> monsters)
    {
        int input;
        float tempHP;

        while (true)
        {
            Console.Clear();
            Utility.ColorWrite("Battle!!\n", ConsoleColor.DarkRed);
            Console.WriteLine();
            MonsterDisplay(monsters);

            Utility.ColorWrite("[내정보]\n", ConsoleColor.Green);
            Console.WriteLine("Lv. {0}  {1}  ({2})", gameManager.player.Level, gameManager.player.Name, gameManager.player.Job);
            Console.WriteLine("HP {0} / {1}", gameManager.player.NowHP.ToString("n1"), gameManager.player.MaxHP);
            Console.WriteLine("MP {0} / {1}", gameManager.player.NowMP, gameManager.player.MaxMP);
            Console.WriteLine();
            Console.WriteLine("0. 턴종료");
            Utility.ColorWrite("1. 공격\n", ConsoleColor.Magenta);
            Utility.ColorWrite("2. 스킬사용\n", ConsoleColor.Cyan);
            Utility.ColorWrite("3. 아이템사용\n", ConsoleColor.Blue);
            Console.WriteLine();
            input = Utility.GetInput(0, 3);
            if (input == 0)
            {
                if (input == 0)
                {
                    //턴 종료
                    return;
                }
            }
            else if (input == 1)
            {
                //일반공격
                if (NormalAttack(gameManager, monsters))
                {
                    //공격 성공시 턴 종료
                    return;
                }
                else
                {   //실패시(공격 취소) 반복문 처음으로
                    continue;
                }
            }
            else if (input == 2)
            {
                //스킬공격
                if (SkilAttack(gameManager, monsters))
                {
                    //공격 성공시 턴 종료
                    return;
                }
                else
                {
                    //실패시(공격 취소 및 MP부족) 반복문 처음으로
                    continue;
                }

            }
            else if (input == 3)
            {
                //아이템 사용
                UseItem(gameManager);
            }

        }


        //Console.Clear();

    }

    public void EnemyTurn(GameManager gameManager, List<Monster> monsters)
    {
        int input;
        float tempHP;
        Console.Clear();
        Utility.ColorWrite("Battle!!\n", ConsoleColor.DarkRed);
        Console.WriteLine();
        for (int i = 0; i < monsters.Count; i++)
        {
            tempHP = gameManager.player.NowHP;
            if (monsters[i].IsDead == false)
            {
                Console.WriteLine("{0} 의 공격!", monsters[i].Name);
                monsters[i].Attack(monsters[i], gameManager.player);
                if (gameManager.player.NowHP <= 0)
                {
                    gameManager.player.NowHP = 0;
                }
                if (gameManager.player.NowHP <= 0)
                {
                    Utility.ColorWrite($"HP {(gameManager.player.NowHP).ToString("n1")} -> 치명상을 받고 피를 흘리며 도주!", ConsoleColor.DarkGray);
                }
                else
                {
                    Utility.ColorWrite($"HP {tempHP.ToString("n1")} -> {gameManager.player.NowHP.ToString("n1")}", ConsoleColor.DarkMagenta);
                }

                Console.WriteLine("아무 키나 눌러 확인");
                Console.ReadKey();
            }
            else
            {

            }
        }
        gameManager.TurnCount++;
    }

    public void Clear(GameManager gameManager, Player tempPlayer, int resultExp, int level)
    {
        gameManager.TurnCount = 0;

        Random random1 = new Random();
        Console.Clear();
        Utility.ColorWrite("던전을 클리어하였습니다!\n", ConsoleColor.Cyan);
        //떄려잡은 몹 수 표시        
        Console.WriteLine("던전에서 몬스터 {0}마리를 잡았습니다", gameManager.killCount);
        gameManager.player.NowExp = gameManager.player.NowExp + resultExp;
        gameManager.player.Gold = gameManager.player.Gold + resultExp * 20;

        //체력경험치 증가 표시
        Utility.ColorWrite($"HP : {tempPlayer.NowHP.ToString("n1")} -> {gameManager.player.NowHP.ToString("n1")}\n", ConsoleColor.DarkGreen);
        if (gameManager.player.Level != tempPlayer.Level)
        {
            Utility.ColorWrite($"Lv. {tempPlayer.Level} -> {gameManager.player.Level}\n", ConsoleColor.Green);
        }
        Utility.ColorWrite($"Exp. {tempPlayer.NowExp} -> {gameManager.player.NowExp}\n", ConsoleColor.Green);

        //얻은 아이템 표시 및 추가        
        Console.WriteLine();
        Utility.ColorWrite("[획득 아이템]\n", ConsoleColor.DarkYellow);
        Console.WriteLine();
        gameManager.player.Gold = gameManager.player.Gold + resultExp * 50;
        Utility.ColorWrite($"{gameManager.player.Gold} Gold\n", ConsoleColor.Yellow);

        while (true)
        {
            //40%의 확률로            
            if (random1.Next(1, 101) > 60)
            {
                Random random2 = new Random();
                var result = gameManager.equipments.Where(x => gameManager.inventoryEquipment.Count(s => x.ItemID == s.ItemID) == 0).ToList();
                var find = result.FindAll(x => x.MonsterFlag == true).ToList();
                if (find.Count == 0)
                {
                    break;
                }
                int temp = random2.Next(0, find.Count);
                Console.WriteLine("{0}", find[temp].Name);
                gameManager.inventoryEquipment.Add(find[temp]);
            }
            else
            {
                break;
            }
        }


        if (random1.Next(1, 101) > 90)
        {
            if (level == 1)
            {
                var find = gameManager.equipments.FindAll(x => x.ERareFlag == true).ToList();
                int temp = random1.Next(0, find.Count);
                Console.WriteLine("{0}", find[temp].Name);
                gameManager.inventoryEquipment.Add(find[temp]);
            }
            else if (level == 2)
            {
                var find = gameManager.equipments.FindAll(x => x.NRareFlag == true).ToList();
                int temp = random1.Next(0, find.Count);
                Console.WriteLine("{0}", find[temp].Name);
                gameManager.inventoryEquipment.Add(find[temp]);
            }
            else if (level == 3)
            {
                var find = gameManager.equipments.FindAll(x => x.HRareFlag == true).ToList();
                int temp = random1.Next(0, find.Count);
                Console.WriteLine("{0}", find[temp].Name);
                gameManager.inventoryEquipment.Add(find[temp]);
            }
            else { }


        }

        gameManager.killCount = 0;
        Console.WriteLine("\n아무 키나 눌러 나가기");
        Console.ReadKey();
        return;
    }


    public void Fail(GameManager gameManager, Player tempPlayer)
    {
        gameManager.TurnCount = 0;

        int Input;
        string? tempName;
        Random random = new Random();
        if (gameManager.inventoryEquipment.Any() == true)
        {
            int removeIndex = random.Next(0, gameManager.inventoryEquipment.Count);
            tempName = gameManager.inventoryEquipment[removeIndex].Name;
            gameManager.player.Gold = gameManager.player.Gold - 300;
            gameManager.inventoryEquipment.RemoveAt(removeIndex);
        }
        else
        {
            gameManager.player.Gold = gameManager.player.Gold - (gameManager.player.Gold / 2);
            tempName = "없음";
        }

        while (true)
        {
            Console.Clear();
            Utility.ColorWrite("[GameOver]\n", ConsoleColor.Red);
            Console.WriteLine("던전공략 실패");
            Console.WriteLine("캐릭터가 치명상을 입고 도주하였습니다!!");
            Console.WriteLine();

            //유저스탯 - 레벨 / 이름
            Console.WriteLine("Lv. {0} NAME : {1}", gameManager.player.Level, gameManager.player.Name);
            //입장시점 HP -> 0
            Console.WriteLine("HP {0} -> {1}", tempPlayer.NowHP.ToString("n1"), gameManager.player.NowHP.ToString("n1"));
            Console.WriteLine("Gold {0} -> {1}", tempPlayer.Gold, gameManager.player.Gold);
            if (gameManager.inventoryEquipment.Count > 1)
            {
                Console.WriteLine("잃어버린 아이템 : {0}", tempName);
            }
            Utility.ColorWrite("휴식중", ConsoleColor.Yellow);
            String str = ".";

            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(1000);
                Console.Write(str);

            }

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("1. 게임종료");
            Console.WriteLine("2. 던전 재시작");
            Console.WriteLine("3. 던전입장화면으로");
            Console.WriteLine();
            Input = Utility.GetInput(1, 3);
            gameManager.killCount = 0;

            if (Input == 1)
            {
                //게임종료
                Environment.Exit(0);
            }
            else if (Input == 2)
            {
                gameManager.player.NowHP = gameManager.player.MaxHP;
                gameManager.exitFlag = 0;
                break;
                //리트라이
            }
            else if (Input == 3)
            {
                gameManager.player.NowHP = gameManager.player.MaxHP;
                gameManager.exitFlag = 1;
                //던전입장화면으로
                return;
            }
        }
    }
}











