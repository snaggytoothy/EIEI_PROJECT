using EIEIE_Project;
using System;

public class DungeonFail
{
	public void Fail(Player player,Player tempPlayer)
	{
        int Input;
		while (true)
		{
            Console.WriteLine("[GameOver]");
            Console.WriteLine("던전공략 실패");
            Console.WriteLine("캐릭터가 사망하였습니다.");
            Console.WriteLine();

            //유저스탯 - 레벨 / 이름
            Console.WriteLine("Lv. {0} NAME : {1}", player.Level, player.Name);
            //입장시점 HP -> 0
            Console.WriteLine("HP {0} -> {1}", tempPlayer.NowHP, player.NowHP);

            Console.WriteLine();
            Console.WriteLine("1. 게임종료");
            Console.WriteLine("2. 던전 재시작(리트라이)");
            Console.WriteLine("3. 게임 재시작(던전입장화면으로)");
            Console.Write(">>");
            Input = Utility.GetInput(1, 3);

            if (Input == 1)
            {
                //게임종료
                Environment.Exit(0);
            }
            else if(Input == 2) 
            {
                //리트라이
            }
            else if(Input == 3)
            {
                //던전입장화면으로
            }
        }
	}
}
