using EIEIE_Project;
using System;

public class DungeonClear
{
	public void Clear(GameManager gameManager, Player tempPlayer, int resultExp)
	{
		Random random = new Random();
		var expect = gameManager.itemList.Where(x => gameManager.inventory.Count(s => x.ItemID != s.ItemID) != 0).ToList();

        while (true)
		{
			Console.Clear();
			Console.WriteLine("던전을 클리어하였습니다");

			//떄려잡은 몹 수 표시
			Console.WriteLine("던전에서 몬스터 {0}마리를 잡았습니다",gameManager.killCount);
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
					if(expect.Any() == false)
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
}
