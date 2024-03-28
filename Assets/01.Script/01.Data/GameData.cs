using System;
using System.Xml.Serialization;

[Serializable]
 public partial class GameData
{
    public class CharacterData
    {

    }

    public class UserData
    {
        public string userName;
        public int level;
        public int money;
    }

}
