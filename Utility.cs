namespace EIEIE_Project;

public class Utility
{
    public static int GetInput(int min, int max)
    {
        while (true)
        {
            Console.Write("원하시는 행동을 입력해주세요.");
            if(int.TryParse(Console.ReadLine(), out int input) && (input >= min) && (input <= max))
            return input;
            
            Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
        }
    }

    public static void Loading()
    {
        Console.Clear();
        Console.Write("행동중");
        String str = ".";

        for (int i = 0; i < 4; i++)
        {
            Thread.Sleep(1000); // 1초 시간지연
            Console.Write(str);

        }

    }

    public static void ColorWrite(string str, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(str);
        Console.ResetColor();
    }
}