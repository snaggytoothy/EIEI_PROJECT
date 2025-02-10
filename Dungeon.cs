using System;
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
            Console.WriteLine("던전에 들어왔다.");
            Console.WriteLine("3개의 통로가 눈앞에 보인다.");
            Console.WriteLine("각 통로 마다 팻말이 박혀있다.");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 쉬움");
            Console.WriteLine("2. 보통");
            Console.WriteLine("3. 어려움");

            int input = Utility.GetInput(0, 3);

            switch (input)
            {
                case 1:
                    if (gameManager.player.Level >= 1) EasyScreen(gameManager);
                    else { Console.WriteLine("레벨이 부족합니다! (Lv.1 이상 필요)"); Console.ReadKey(); }
                    break;
                case 2:
                    if (gameManager.player.Level >= 8) NormalScreen(gameManager);
                    else { Console.WriteLine("레벨이 부족합니다! (Lv.8 이상 필요)"); Console.ReadKey(); }
                    break;
                case 3:
                    if (gameManager.player.Level >= 12) HardScreen(gameManager);
                    else { Console.WriteLine("레벨이 부족합니다! (Lv.12 이상 필요)"); Console.ReadKey(); }
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
            Console.WriteLine("뚜벅");
            Thread.Sleep(1000); // 1초 시간지연
        }

        Console.WriteLine();
        Console.WriteLine("길가던 할아버지도 입장할수있는");
        Console.WriteLine("난이도 쉬움입니다.");

        Console.WriteLine();
        // Utility(캐릭터 상태창);
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");


        Console.WriteLine();
        Console.WriteLine("0. 도망가기");
        Console.WriteLine("1. 진입하기");
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
                DungeonProgress(gameManager, 1); // 던전입구 입장
                if (gameManager.exitFlag == 1)
                {
                    gameManager.exitFlag = 0;
                    break;
                }
            }

        }
    }

    public void NormalScreen(GameManager gameManager)
    {
        int cmd;
        Console.WriteLine("던전을 걸어가고 있습니다.");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("뚜벅");
            Thread.Sleep(1000); // 1초 시간지연
        }

        Console.WriteLine();
        Console.WriteLine("이제 모험가라고 불릴 수 있는 단계입니다.");
        Console.WriteLine("난이도 보통입니다.");
        Console.WriteLine();

        // Utility(캐릭터 상태창);

        Console.WriteLine("캐릭터의 정보가 표시됩니다.");


        Console.WriteLine();
        Console.WriteLine("0. 도망가기");
        Console.WriteLine("1. 진입하기");
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
                DungeonProgress(gameManager, 1); // 던전입구 입장
                if (gameManager.exitFlag == 1)
                {
                    gameManager.exitFlag = 0;
                    break;
                }
            }
        }
    }

    public void HardScreen(GameManager gameManager)
    {
        int cmd;
        Console.WriteLine("던전을 걸어가고 있습니다.");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("뚜벅");
            Thread.Sleep(1000); // 1초 시간지연
        }

        Console.WriteLine();
        Console.WriteLine("상당히 무서운 몬스터들이 있는 던전입니다 조심하세요 순식간에 사망합니다.");
        Console.WriteLine("난이도 어려움입니다.");
        Console.WriteLine();

        // Utility(캐릭터 상태창);

        Console.WriteLine("캐릭터의 정보가 표시됩니다.");


        Console.WriteLine();
        Console.WriteLine("0. 도망가기");
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("0. 도망가기");
        Console.WriteLine("1. 진입하기");
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
                DungeonProgress(gameManager, 1); // 던전입구 입장
                if (gameManager.exitFlag == 1)
                {
                    gameManager.exitFlag = 0;
                    break;
                }
            }
        }

    }

    public void DungeonProgress(GameManager gameManager, int level)
    {
        //플레이어의 진입시 상태를 저장
        Player tempPlayer = new Player() { NowExp = gameManager.player.NowExp, Gold = gameManager.player.Gold, NowHP = gameManager.player.NowHP, Level = gameManager.player.Level };
        List<Monster> monsters = new List<Monster>();
        //easy던전 입장
        if (level == 1)
        {
            int wave = 3;
            int resultExp = 0;
            //난이도에 맞는 몬스터 생성            

            for (int i = 1; i <= wave + 1; i++)
            {
                if (i == 1)
                {
                    monsters.Clear();
                    monsters.Add(new Monster(1));
                }
                else if (i == 2)
                {
                    monsters.Clear();
                    monsters.Add(new Monster(2));
                    monsters.Add(new Monster(3));
                }
                else if (i == 3)
                {
                    monsters.Clear();
                    monsters.Add(new Monster(2));
                    monsters.Add(new Monster(3));
                    monsters.Add(new Monster(4));
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
                    break;
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
                        continue;
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
        //normal 던전 입장
        else if (level == 2)
        {
            int wave = 3;
            int resultExp = 0;
            //난이도에 맞는 몬스터 생성            

            for (int i = 1; i <= wave + 1; i++)
            {
                if (i == 1)
                {
                    monsters.Clear();
                    monsters.Add(new Monster(5));
                    monsters.Add(new Monster(6));
                }
                else if (i == 2)
                {
                    monsters.Clear();
                    monsters.Add(new Monster(6));
                    monsters.Add(new Monster(7));
                    monsters.Add(new Monster(8));
                }
                else if (i == 3)
                {
                    monsters.Clear();
                    monsters.Add(new Monster(5));
                    monsters.Add(new Monster(6));
                    monsters.Add(new Monster(7));
                    monsters.Add(new Monster(8));
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
                    break;
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
                        monsters.Clear();
                        Fail(gameManager, tempPlayer);
                        break;
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
        //hard던전 입장
        else if (level == 3)
        {
            int wave = 3;
            int resultExp = 0;
            //난이도에 맞는 몬스터 생성            

            for (int i = 1; i <= wave + 1; i++)
            {
                if (i == 1)
                {
                    monsters.Clear();
                    monsters.Add(new Monster(3));
                }
                else if (i == 2)
                {
                    monsters.Clear();
                    monsters.Add(new Monster(3));
                    monsters.Add(new Monster(4));
                }
                else if (i == 3)
                {
                    monsters.Clear();
                    monsters.Add(new Monster(3));
                    monsters.Add(new Monster(4));
                    monsters.Add(new Monster(5));
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
                    break;
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
                        monsters.Clear();
                        Fail(gameManager, tempPlayer);
                        break;
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
        else
        {
            //예외처리
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
            for (int i = 0; i < monsters.Count; i++)
            {
                //살아잇는 몬스터 표시
                if (monsters[i].IsDead == false)
                {
                    Console.WriteLine("{0} Lv {1} {2}   HP {3} / {4}", i + 1, monsters[i].Name, monsters[i].Level, monsters[i].NowHP, monsters[i].MaxHP);
                }
                //죽은 몬스터 표시
                else if (monsters[i].IsDead == true)
                {
                    Console.WriteLine("{0} Lv {1} {2}   Dead", i + 1, monsters[i].Name, monsters[i].Level);
                }
            }

            Console.WriteLine("[내정보]");
            Console.WriteLine("Lv. {0}  {1}  ({2})", gameManager.player.Level, gameManager.player.Name, gameManager.player.Job);
            Console.WriteLine("HP {0}/{1}", gameManager.player.NowHP, gameManager.player.MaxHP);
            Console.WriteLine();
            Console.WriteLine("0. 턴종료");
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 아이템사용");
            Console.WriteLine();
            Console.WriteLine("대상을 선택해주세요");
            Console.Write(">>>");
            input = Utility.GetInput(0, 2);
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
                //몬스터 공격화면으로 이동
                break;
            }
            else if (input == 2)
            {
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
                        gameManager.inventoryConsumables[input - 1].Use(gameManager.player);
                        Console.WriteLine("Anykey. 진행");
                        Console.ReadKey();
                    }
                }

            }

        }
        while (true)
        {
            Console.Clear();
            //현재 몬스터 표시
            for (int i = 0; i < monsters.Count; i++)
            {
                if (monsters[i].IsDead == false)
                {
                    Console.WriteLine("{0} Lv {1} {2}   HP {3} / {4}", i + 1, monsters[i].Name, monsters[i].Level, monsters[i].NowHP, monsters[i].MaxHP);
                }
                else if (monsters[i].IsDead == true)
                {
                    Console.WriteLine("{0} Lv {1} {2}   Dead", i + 1, monsters[i].Name, monsters[i].Level);
                }
            }
            //몬스터 공격명령
            input = Utility.GetInput(1, monsters.Count);
            tempHP = monsters[input - 1].NowHP;
            //죽은 몬스터 골랐을때
            if (monsters[input - 1].IsDead == true)
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.WriteLine();
                Console.WriteLine("아무키 입력. 다음");
                Console.WriteLine();
                Console.Write(">>");
                Console.ReadKey();
            }
            //살아있는 몬스터 골랐을때
            else
            {
                gameManager.player.Attack(gameManager.player, monsters[input - 1]);//공격
                //공격한 몬스터가 죽으면
                if (monsters[input - 1].NowHP <= 0)
                {
                    monsters[input - 1].IsDead = true;
                    monsters[input - 1].NowHP = 0;
                    gameManager.killCount = gameManager.killCount + 1;
                    Console.WriteLine("{0}킬째", gameManager.killCount);
                }
                break;
            }
        }
        //결과창 표시
        Console.Clear();
        Console.WriteLine("Battle!!");
        Console.WriteLine();
        Console.WriteLine("{0} 의 공격!", gameManager.player.Name);
        Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", monsters[input - 1].Level, monsters[input - 1].Name, tempHP - monsters[input - 1].NowHP);
        Console.WriteLine();
        Console.WriteLine("Lv.{0} {1}", monsters[input - 1].Level, monsters[input - 1].Name);
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
    }

    public void EnemyTurn(GameManager gameManager, List<Monster> monsters)
    {
        int input;
        float tempHP = 0;
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
                Console.WriteLine("{0} 을(를) 맞췄습니다. [데미지] : {1}", gameManager.player.Name, tempHP - gameManager.player.NowHP);
                Console.WriteLine();
                Console.WriteLine("Lv.{0} {1}", gameManager.player.Level, gameManager.player.Name);
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
    }

    public void Clear(GameManager gameManager, Player tempPlayer, int resultExp)
    {
        Random random = new Random();
        var expectequiment = gameManager.equipments.Where(x => gameManager.inventoryEquipment.Count(s => x.ItemID != s.ItemID) != 0).ToList();
        //var expectconsumables = gameManager.consumables.Where(x => gameManager.inventoryConsumables.Count(s => x.ItemID != s.ItemID) != 0).ToList();            
        Console.Clear();
        Console.WriteLine("던전을 클리어하였습니다");
        //떄려잡은 몹 수 표시        
        Console.WriteLine("던전에서 몬스터 {0}마리를 잡았습니다", gameManager.killCount);
        gameManager.player.NowExp = gameManager.player.NowExp + resultExp;
        gameManager.player.Gold = gameManager.player.Gold + resultExp * 50;

        //체력경험치 증가 표시        
        Console.WriteLine("HP : {0} -> {1}", tempPlayer.NowHP, gameManager.player.NowHP);
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
            if (random.Next(1, 101) > 60)
            {
                //전체 아이템리스트와 보유 아이템 리스트 비교                
                //비교한 리스트에 아무것도 없다면 정지                
                if (expectequiment.Any() == false)
                {
                    break;
                }
                //보유하지 않은 아이템에서 몬스터 플래그가 트루인 아이템을 추가                
                var find = expectequiment.FindAll(x => x.MonsterFlag == true).ToList();
                int temp = find[random.Next(0, find.Count)].ItemID;
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
    }


    public void Fail(GameManager gameManager, Player tempPlayer)
    {
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
            if (gameManager.inventoryEquipment.Any() == true)
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
                //던전입장화면으로
                return;
            }
        }
    }
}











