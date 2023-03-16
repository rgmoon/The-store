using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class FileDataHandler 
{
    private string dataDirPath = "";
    private string datafileName = "";
    public FileDataHandler(string dataDirPath, string datafileName)
    { 
        this.dataDirPath = dataDirPath;
        this.datafileName = datafileName;
    }
    public Gamedata load()
    {
        string fullpath = Path.Combine(dataDirPath, datafileName);
        Gamedata loadedData = null;
        if (File.Exists(fullpath))
            try {
                string loaddata = "";
                using (FileStream stream = new FileStream(fullpath, FileMode.Open)) {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        loaddata = reader.ReadToEnd();
                    }
                }
                loadedData = JsonUtility.FromJson<Gamedata>(loaddata);
            }
            catch (Exception e)
            {
                Debug.LogError("Error load" + fullpath + "\n" + e);
            }
        return loadedData;
    }
    public void save(Gamedata data)
    { 
    string fullpath = Path.Combine(dataDirPath, datafileName);
        try{
        Directory.CreateDirectory(Path.GetDirectoryName(fullpath));
            string savedata = JsonUtility.ToJson(data, true);
            using (FileStream stream = new FileStream(fullpath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream)) { 
                writer.Write(savedata);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file" + fullpath + "\n" + e);
       }
    }
}
