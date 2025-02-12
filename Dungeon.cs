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
            Console.WriteLine("1. 쉬움 | Lv 1 이상 입장가능");
            Console.WriteLine("2. 보통 | Lv 8 이상 입장가능");
            Console.WriteLine("3. 어려움 | Lv 14 이상 입장가능");
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

        Console.WriteLine();
        Console.WriteLine("길가던 할아버지도 입장할수있는");
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

        Console.WriteLine();
        Console.WriteLine("이제 모험가라고 불릴 수 있는 단계입니다.");
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

        Console.WriteLine();
        Console.WriteLine("상당히 무서운 몬스터들이 있는 던전입니다 조심하세요 순식간에 사망합니다.");
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
                monsters.Add(new Monster(random.Next(4,6)));//레어몬스터 확정생성
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
                monsters.Add(new Monster(random.Next(9, 11)));//레어몬스터 확정생성
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
                monsters.Add(new Monster(random.Next(17,19)));//레어몬스터 확정생성
            }
            else if (wave == 3)
            {
                monsterNum = random.Next(7, 11);
                for (int i = 0; i < monsterNum; i++)
                {
                    monsterID = random.Next(12, 17);
                    monsters.Add(new Monster(monsterID));
                }
                //monsterNum = random.Next(9, 11);
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
                    Clear(gameManager, tempPlayer, resultExp);
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
                Console.WriteLine(" Lv {0} {1}   HP {2} / {3}  {4}",  monsters[i].Level, monsters[i].Name, monsters[i].NowHP, monsters[i].MaxHP, monsters[i].Details);
                Console.WriteLine();
            }
            //죽은 몬스터 표시
            else if (monsters[i].IsDead == true)
            {
                Utility.ColorWrite($"{i + 1} Lv {monsters[i].Level} {monsters[i].Name}   Dead", ConsoleColor.DarkGray);
                Console.WriteLine();
                //Console.WriteLine("{0} Lv {1} {2}   Dead", i + 1, monsters[i].Level, monsters[i].Name);
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
                        //Console.WriteLine("{0}킬째", gameManager.killCount);
                    }
                    /*Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", monsters[input - 1].Level, monsters[input - 1].Name, tempHP - monsters[input - 1].NowHP);
                    Console.WriteLine();
                    Console.WriteLine("Lv.{0} {1}", monsters[input - 1].Level, monsters[input - 1].Name);*/
                    if (monsters[input - 1].IsDead == true)
                    {
                        Console.WriteLine("HP {0} -> Dead", tempHP);
                    }
                    else
                    {
                        Console.WriteLine("HP {0} -> {1}", tempHP, monsters[input - 1].NowHP);
                    }

                    Console.WriteLine();
                    Console.WriteLine("아무키 입력. 다음");
                    Console.WriteLine();
                    Console.Write(">>");
                    Console.ReadKey();
                    break;
                }
            }

        }
        return true;
    }

    void SkilDisplay(GameManager gameManager)
    {
        Console.WriteLine("스킬 보유 목록");
        for (int i = 0; i < gameManager.mySkils.Count; i++)
        {
            Console.WriteLine("{0} {1} 소모 MP : {2} 기본 데미지 : {3} 공격 계수: {4} 범위 {5} 설명 : {6}", i + 1, gameManager.mySkils[i].Name, gameManager.mySkils[i].Cost, gameManager.mySkils[i].Damage, gameManager.mySkils[i].skilRatiod, gameManager.mySkils[i].range, gameManager.mySkils[i].Description);
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
            Console.Write(">>");
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
                        MonsterDisplay(monsters);
                        Console.WriteLine();
                        Console.WriteLine("공격할 몬스터 고르세요");
                        Console.Write("0. 뒤로가기");
                        Console.Write(">>");
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
                                Console.WriteLine("잘못된 입력입니다.");
                                Console.WriteLine();
                                Console.WriteLine("아무키 입력. 다음");
                                Console.WriteLine();
                                Console.Write(">>");
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
                                        //Console.WriteLine("{0}킬째", gameManager.killCount);

                                    }

                                    if (monsters[input - 1].IsDead == true)
                                    {
                                        Console.WriteLine("HP {0} -> Dead", tempHP);
                                    }
                                    else
                                    {
                                        Console.WriteLine("HP {0} -> {1}", tempHP, monsters[input - 1].NowHP);
                                    }

                                    Console.WriteLine();
                                    Console.WriteLine("아무키 입력. 다음");
                                    Console.WriteLine();
                                    gameManager.player.NowMP = gameManager.player.NowMP - gameManager.mySkils[skillInput - 1].Cost;
                                    Console.WriteLine("PlayerMP: {0} -> {1}", tempMP, gameManager.player.NowMP);
                                    Console.Write(">>");
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
                        Console.Write(">>");
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
                                Console.WriteLine("잘못된 입력입니다.");
                                Console.WriteLine();
                                Console.WriteLine("아무키 입력. 다음");
                                Console.WriteLine();
                                Console.Write(">>");
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
                                                //Console.WriteLine("{0}킬째", gameManager.killCount);
                                                if (monsters[(input - 1) - (int)(gameManager.mySkils[skillInput - 1].range / 2) + i].IsDead == true)
                                                {
                                                    Console.WriteLine("HP {0} -> Dead", tempHP[i]);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("HP {0} -> {1}", tempHP[i], monsters[(input - 1) - (int)(gameManager.mySkils[skillInput - 1].range / 2) + i].NowHP);
                                                }
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("아무키 입력. 다음");
                                            Console.WriteLine();
                                            Console.Write(">>");
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                }
                                if (gameManager.player.NowMP < gameManager.mySkils[skillInput-1].Cost)
                                {
                                    return false;
                                }
                                else 
                                {
                                    gameManager.player.NowMP = gameManager.player.NowMP - gameManager.mySkils[skillInput - 1].Cost;
                                    Console.WriteLine("PlayerMP: {0} -> {1}", tempMP, gameManager.player.NowMP);
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
            Console.WriteLine("[소비 아이템 목록]");
            for (int i = 0; i < gameManager.inventoryConsumables.Count; i++)
            {
                if (gameManager.inventoryConsumables[i].Count > 0 && gameManager.inventoryConsumables.Any() == true)
                {
                    Console.WriteLine($"- {i + 1} {gameManager.inventoryConsumables[i].Name} | {gameManager.inventoryConsumables[i].Inform} | 보유 개수 : {gameManager.inventoryConsumables[i].Count}");
                }
                else
                {
                    Console.WriteLine("소비아이템이 없습니다");
                }
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
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
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            MonsterDisplay(monsters);

            Console.WriteLine("[내정보]");
            Console.WriteLine("Lv. {0}  {1}  ({2})", gameManager.player.Level, gameManager.player.Name, gameManager.player.Job);
            Console.WriteLine("HP {0} / {1}", gameManager.player.NowHP, gameManager.player.MaxHP);
            Console.WriteLine("MP {0} / {1}", gameManager.player.NowMP, gameManager.player.MaxMP);
            Console.WriteLine();
            Console.WriteLine("0. 턴종료");
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 스킬사용");
            Console.WriteLine("3. 아이템사용");
            Console.WriteLine();
            Console.WriteLine("대상을 선택해주세요");
            Console.Write(">>>");
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
        Console.WriteLine("Battle!!");
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
                /*Console.WriteLine("{0} 을(를) 맞췄습니다. [데미지] : {1}", gameManager.player.Name, tempHP - gameManager.player.NowHP);
                Console.WriteLine();
                Console.WriteLine("Lv.{0} {1}", gameManager.player.Level, gameManager.player.Name);*/
                if (gameManager.player.NowHP <= 0)
                {
                    Console.WriteLine("HP {0} -> Dead", gameManager.player.NowHP);
                }
                else
                {
                    Console.WriteLine("HP {0} -> {1}", tempHP, gameManager.player.NowHP);
                }

                Console.WriteLine("?아무키 입력 다음");
                Console.WriteLine();
                Console.Write(">>");
                Console.ReadKey();
            }
            else
            {

            }
        }
        gameManager.TurnCount++;
    }

    public void Clear(GameManager gameManager, Player tempPlayer, int resultExp)
    {
        gameManager.TurnCount = 0;

        Random random1 = new Random();

        //var expectconsumables = gameManager.consumables.Where(x => gameManager.inventoryConsumables.Count(s => x.ItemID != s.ItemID) != 0).ToList();            
        Console.Clear();
        Console.WriteLine("던전을 클리어하였습니다");
        //떄려잡은 몹 수 표시        
        Console.WriteLine("던전에서 몬스터 {0}마리를 잡았습니다", gameManager.killCount);
        gameManager.player.NowExp = gameManager.player.NowExp + resultExp;
        gameManager.player.Gold = gameManager.player.Gold + resultExp * 20;

        //체력경험치 증가 표시
        Console.WriteLine("HP : {0} -> {1}", tempPlayer.NowHP, gameManager.player.NowHP);
        if (gameManager.player.Level != tempPlayer.Level)
        {
            Console.WriteLine("Lv.{0} -> {1}", tempPlayer.Level, gameManager.player.Level);
        }
        Console.WriteLine("EXP : {0} -> {1}", tempPlayer.NowExp, gameManager.player.NowExp);

        //얻은 아이템 표시 및 추가        
        Console.WriteLine();
        Console.WriteLine("[획득 아이템]");
        Console.WriteLine();
        gameManager.player.Gold = gameManager.player.Gold + resultExp * 50;
        Console.WriteLine("{0} Gold", gameManager.player.Gold);

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

        gameManager.killCount = 0;
        Console.WriteLine("Anykey. 나가기");
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
            Console.WriteLine("[GameOver]");
            Console.WriteLine("던전공략 실패");
            Console.WriteLine("캐릭터가 사망하였습니다.");
            Console.WriteLine();

            //유저스탯 - 레벨 / 이름
            Console.WriteLine("Lv. {0} NAME : {1}", gameManager.player.Level, gameManager.player.Name);
            //입장시점 HP -> 0
            Console.WriteLine("HP {0} -> {1}", tempPlayer.NowHP, gameManager.player.NowHP);
            Console.WriteLine("Gold {0} -> {1}", tempPlayer.Gold, gameManager.player.Gold);
            if (gameManager.inventoryEquipment.Count > 1)
            {
                Console.WriteLine("잃어버린 아이템 : {0}", tempName);
            }
            Console.WriteLine();
            Console.WriteLine("1. 게임종료");
            Console.WriteLine("2. 던전 재시작");
            Console.WriteLine("3. 던전입장화면으로");
            Console.Write(">>");
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











