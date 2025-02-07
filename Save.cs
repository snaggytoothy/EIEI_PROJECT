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
    public Character character;
    public List<SaveItemData> saveItemData;
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

    public void LoadPlayer(List<SaveItemData> myItem, Character character)
    {
        if (File.Exists(FilePath))
        {
            SaveData loadData = LoadData(FilePath);
            character = loadData.character;
            myItem = loadData.saveItemData;

        }
        else
        {
            return;
        }
    }

    public void SavePlayer(Character character, List<SaveItemData> saveItemDatas)
    {
        SaveData saveData = new SaveData() { character = character, saveItemData = saveItemDatas};
        SaveFile(saveData, FilePath);
    }

}