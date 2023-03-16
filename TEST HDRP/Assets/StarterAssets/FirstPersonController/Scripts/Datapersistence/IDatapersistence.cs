using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public interface IDatapersistence
    {
        void loaddata(Gamedata data);
        void savedata(ref Gamedata data);
    }


