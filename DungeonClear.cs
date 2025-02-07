using EIEIE_Project;
using System;

public class DungeonClear
{
	public void Clear(Player player, Player tempPlayer ,List<Item> inventory, List<Item> EntireItems, int count, int resultExp)
	{
		Random random = new Random();

		while (true)
		{
			Console.WriteLine("던전을 클리어하였습니다");

			//떄려잡은 몹 수 표시
			Console.WriteLine("던전에서 몬스터 {0}마리를 잡았습니다",count);
			player.NowExp = player.NowExp + resultExp;
			player.Gold = player.Gold + resultExp * 50;

			//체력경험치 증가 표시
			Console.WriteLine("HP : {0} -> {1}", tempPlayer.HP, player.HP);
            Console.WriteLine("EXP : {0} -> {1}", tempPlayer.NowExp, player.NowExp);

			//얻은 아이템 표시 및 추가
			Console.WriteLine();
			Console.WriteLine("[획득 아이템]");

			while (true)
			{
				//40%의 확률로
                if (random.Next(1, 100) >= 60)
                {
                    //전체 아이템리스트와 보유 아이템 리스트 비교
                    var expect = EntireItems.Except(inventory);
					//비교한 리스트에 아무것도 없다면 정지
					if(expect.Any() == false)
					{
						break;
					}
                    //보유하지 않은 아이템에서 몬스터 플래그가 트루인 아이템
                    var find = expect.FindAll(x => x.MonsterFlag == true);
                    //표시하고
                    Console.WriteLine(find[random.Next(0, find.Count)].Name)
					//보유아이템에 추가
					inventory.Add(find[random.Next(0, find.Count)]);
                }
				else
				{
					break;
				}
            }
			
			
            Console.WriteLine("0. 나가기");
			Console.ReadKey();
		}

	}
}
