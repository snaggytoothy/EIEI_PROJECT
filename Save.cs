using Newtonsoft.Json;
using System.IO;

namespace EIEIE_Project;

public class SaveItemData
{
    public int ItemID;
    public bool IsEquiped;
}

public class SaveData
{
    public Player player;
    public List<SaveItemData> saveItemData;
    public List<Consumable> consumablesItems;
}

public class Save
{
    string FilePath = @"..\..\save.json";

    void SaveFile(SaveData data, String FilePath)
    {
        try
        {
            string userData = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(FilePath, userData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    static SaveData LoadData(String FilePath)
    {
        if (File.Exists(FilePath))
        {
            string userData = File.ReadAllText(FilePath);

            SaveData Save = JsonConvert.DeserializeObject<SaveData>(userData);

            return Save;
        }
        else
        {
            return null;
        }

    }

    public void LoadPlayer(List<SaveItemData> myItem, Player player)
    {
        if (File.Exists(FilePath))
        {
            SaveData loadData = LoadData(FilePath);
            player = loadData.player;
            myItem = loadData.saveItemData;

        }
        else
        {
            return;
        }
    }

    public void SavePlayer(Player player, List<SaveItemData> saveItemDatas, List<Consumable> consumablesItems)
    {
        SaveData saveData = new SaveData() { player = player, saveItemData = saveItemDatas, consumablesItems = consumablesItems};
        SaveFile(saveData, FilePath);
    }


}