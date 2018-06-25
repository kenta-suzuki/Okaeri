using System.Collections;
using System.Collections.Generic;

public class GameModel
{
    static GameModel instance;
    public static GameModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameModel();
                instance.Initialize();
            }
            return instance;
        }
    }

    public Master Master { get; private set; }
    public Model Model { get; private set; }

    /// <summary>
    /// 初期処理
    /// </summary>
    public void Initialize()
    {
        Master = new Master();
        Model = new Model();
    }
}
