namespace EIEIE_Project;

public class Utility
{
    public static int GetInput(int min, int max)
    {
        while (true)
        {
            Console.Write("���Ͻô� �ൿ�� �Է����ּ���. ->");
            if(int.TryParse(Console.ReadLine(), out int input) && (input >= min) && (input <= max))
            return input;
            
            Console.WriteLine("�߸��� �Է��Դϴ�. �ٽ� �Է����ּ���. ->");
        }
    }

    //�ε� ȭ��
    public static void Loading()
    {
        Console.Clear();
        Console.Write("Loading");
        String str = ".";

        for (int i = 0; i < 4; i++)
        {
            Thread.Sleep(1000);
            Console.Write(str);

        }

    }

    //���� �� ����
    public static void ColorWrite(string str, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(str);
        Console.ResetColor();
    }

}