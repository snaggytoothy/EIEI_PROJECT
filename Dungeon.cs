using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
namespace EIEIE_Project;

class Dungeon
{
    public void DoorDungeon(GameManager gameManager)
    {
        Utility.Loading();

        Console.Clear();
        Console.WriteLine("던전에 들어왔다.");
        Console.WriteLine("3개의 통로가 눈앞에 보인다.");
        Console.WriteLine("각 통로 마다 팻말이 박혀있다.");
        Console.WriteLine();
        Console.WriteLine("1. 쉬움");
        Console.WriteLine("2. 보통");
        Console.WriteLine("3. 어려움");

        int input = Utility.GetInput(1, 3);

        switch (input)
        {
            case 1:
                if (gameManager.player.Level >= 1) EasyScreen(gameManager);
                else Console.WriteLine("레벨이 부족합니다! (Lv.1 이상 필요)");
                break;
            case 2:
                if (gameManager.player.Level >= 8) NormalScreen(gameManager);
                else Console.WriteLine("레벨이 부족합니다! (Lv.1 이상 필요)");
                break;
            case 3:
                if (gameManager.player.Level >= 12) HardScreen(gameManager);
                else Console.WriteLine("레벨이 부족합니다! (Lv.1 이상 필요)");
                break;
        }

    }

    public void EasyScreen(GameManager gameManager)
    {

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
        Console.WriteLine();

        Utility.GetInput(0, 0);
        DoorDungeon(gameManager); // 던전입구 입장
    }

    public void NormalScreen(GameManager gameManager)
    {
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
        Console.WriteLine();

        Utility.GetInput(0, 0);
        DoorDungeon(gameManager); // 던전입구 입장
    }

    public void HardScreen(GameManager gameManager)
    {
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

        Utility.GetInput(0, 0);
        DoorDungeon(gameManager); // 던전입구 입장 // 임시저장

    }

    public void DungeonProgress(GameManager gameManager,int level)
    {
        //플레이어의 진입시 상태를 저장
        Player tempPlayer = new Player() { NowExp = gameManager.player.NowExp, Gold = gameManager.player.Gold, NowHP = gameManager.player.NowHP, Level = gameManager.player.Level };
        List<Monster> monsters = new List<Monster>();
        //easy던전 입장
        if (level == 1)
        {
            //난이도에 맞는 몬스터 생성
            monsters.Add(new Monster(1));
            monsters.Add(new Monster(2));
            monsters.Add(new Monster(3));
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
                    break;
                }
                else if(monsters.FindAll(x=>x.IsDead).Count==monsters.Count)
                {
                    monsters.Clear();
                    //승리화면으로
                    break;
                }
            }
                
        }
        //normal 던전 입장
        else if (level == 2)
        {

        }
        //hard던전 입장
        else if (level == 3)
        {

        }
        else
        {
            //예외처리
        }
    }

    public void PlayerTurn(GameManager gameManager,List<Monster> monsters)
    {
        int input;
        Console.WriteLine("Battle!!");
        Console.WriteLine();
        for (int i = 0; i < monsters.Count; i++)
        {
            if (monsters[i].IsDead == false)
            {
                Console.WriteLine("{0} Lv {1} {2}   HP {3} / {4}", i, monsters[i].Name, monsters[i].Level, monsters[i].NowHP, monsters[i].MaxHP);
            }
            else if (monsters[i].IsDead == true)
            {
                Console.WriteLine("{0} Lv {1} {2}   Dead", i, monsters[i].Name, monsters[i].Level);
            }
        }

        Console.WriteLine("[내정보]");
        Console.WriteLine("Lv. {0}  {1}  ({2})", gameManager.player.Level, gameManager.player.Name, gameManager.player.Job);
        Console.WriteLine("HP {0}/{1}", gameManager.player.NowHP, gameManager.player.MaxHP);
        Console.WriteLine();
        Console.WriteLine("0. 턴종료");
        Console.WriteLine();
        Console.WriteLine("대상을 선택해주세요");
        Console.Write(">>>");
        input = Utility.GetInput(0, monsters.FindAll(x=>x.IsDead==false).Count);
        float tempHP = monsters[input-1].NowHP;
        if (input == 0)
        {
            return;
        }
        else { 
            gameManager.player.Attack(gameManager.player, monsters[input - 1]);
            if (monsters[input - 1].NowHP <= 0)
            {
                monsters[input - 1].IsDead = true;
                monsters[input - 1].NowHP = 0;
                gameManager.killCount++;
            }

        }
        Console.Clear();
        Console.WriteLine("Battle!!");
        Console.WriteLine();
        Console.WriteLine("{0} 의 공격!", gameManager.player.Name);
        Console.WriteLine("Lv.{0} {1} 을(를) 맞췄습니다. [데미지] : {2}", monsters[input - 1].Level, monsters[input - 1].Name, tempHP - monsters[input - 1].NowHP);
        Console.WriteLine();
        Console.WriteLine("Lv.{0} {1}", monsters[input - 1].Level, monsters[input - 1].Name);
        if(monsters[input].IsDead == true)
        {
            Console.WriteLine("HP {0} -> Dead", monsters[input - 1].Level);
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
            Console.WriteLine("{0} 의 공격!", monsters[i].Name);
            monsters[i].Attack(monsters[i], gameManager.player);
            if (gameManager.player.NowHP <= 0)
            {
                gameManager.player.NowHP = 0;
            }
            Console.WriteLine("{1} 을(를) 맞췄습니다. [데미지] : {2}", gameManager.player.Name,tempHP - gameManager.player.NowHP);
            Console.WriteLine();
            Console.WriteLine("Lv.{0} {1}", gameManager.player.Level,gameManager.player.Name);
            if (gameManager.player.NowHP<=0)
            {
                Console.WriteLine("HP {0} -> Dead", gameManager.player.NowHP);
            }
            else
            {
                Console.WriteLine("HP {0} -> {1}", tempHP,gameManager.player.NowHP);
            }

            Console.WriteLine("?아무키 입력 다음");
            Console.WriteLine();
            Console.Write(">>");
            Console.ReadKey();
        }
    }

    public void Clear(GameManager gameManager, Player tempPlayer, int resultExp)
    {
        Random random = new Random();
        var expect = gameManager.itemList.Where(x => gameManager.inventory.Count(s => x.ItemID != s.ItemID) != 0).ToList();

        while (true)
        {
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
                    if (expect.Any() == false)
                    {
                        break;
                    }
                    //보유하지 않은 아이템에서 몬스터 플래그가 트루인 아이템을 추가
                    var find = expect.FindAll(x => x.MonsterFlag == true).ToList();
                    int temp = find[random.Next(0, find.Count)].ItemID;
                    Console.WriteLine("{0}", find[temp].Name);
                    gameManager.inventory.Add(find[temp]);
                }
                else
                {
                    break;
                }
            }

            gameManager.killCount = 0;
            Console.WriteLine("0. 나가기");
            Console.ReadKey();
        }


    }

    public void Fail(GameManager gameManager, Player tempPlayer)
    {
        int Input;
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

            Console.WriteLine();
            Console.WriteLine("1. 게임종료");
            Console.WriteLine("2. 던전 재시작(리트라이)");
            Console.WriteLine("3. 게임 재시작(던전입장화면으로)");
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
                //리트라이
            }
            else if (Input == 3)
            {
                //던전입장화면으로
            }
        }
    }
}










       
