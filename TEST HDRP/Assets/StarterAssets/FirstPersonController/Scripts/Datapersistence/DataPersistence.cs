using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistence : MonoBehaviour
{
    [Header("file stroage config")]
    [SerializeField] private string filename;
    private FileDataHandler dataHandler;
    private Gamedata gamedata;
    private List<IDatapersistence> datapersistenceobjects;
    public static DataPersistence instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found other persistence manager in the scean");
        }
        instance = this;
    }
    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, filename);
        this.datapersistenceobjects = FindAllDataPersistenceObjects();
        load();
    }
    public void newgame (){
        this.gamedata = new Gamedata();
    }
    public void load() {
        this.gamedata = dataHandler.load();
        if (this.gamedata == null)
        {
            Debug.Log("Can't find any save file. Init new data to default");

            newgame();
        }
        foreach (IDatapersistence datapersistenceobj in datapersistenceobjects)
        {
            datapersistenceobj.loaddata(gamedata);
        }
    }
    public void save(){
        foreach (IDatapersistence datapersistenceobj in datapersistenceobjects)
        {
            datapersistenceobj.savedata(ref gamedata);
        }
        dataHandler.save(gamedata);
    }
    private List<IDatapersistence> FindAllDataPersistenceObjects() {
        IEnumerable<IDatapersistence> datapersistenceobjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDatapersistence>();
        return new List<IDatapersistence>(datapersistenceobjects);
    }

    //just for test
    private void clicksave()
    {
        save();
    }

}
