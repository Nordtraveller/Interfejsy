using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerInput {
    public int horizontal;
    public int vertical;
    public bool X;
    public bool Y;
    public bool A;
    public bool B;
    public bool LB;
    public bool RB;
    public bool menu;
}

public class Player : MonoBehaviour {

    public int hp = 100;
    public int mana = 200;
    public int[] stats;
    public int level = 1;
    public int statPointsSpend = 0;
    public int statPointsToSpend = 0;
    public List<Ability> abilities;
    static Player myInstance;

    public PlayerInput input{ get { return input_; } }
    private PlayerInput input_;
    private bool horizontalInUse_ = false;
    private bool verticalInUse_ = false;

    public static Player Instance
    {
        get
        {
            if (myInstance == null)
            {
                GameObject go = new GameObject();
                myInstance = go.AddComponent<Player>();
            }
            return myInstance;
        }
    }

    private void Awake() {
        input_ = new PlayerInput();
    }

    void Start () {
        abilities = new List<Ability>();
        stats = new int[4];
    }

	void Update () {
        SetInput();



	}

    public void LevelUp()
    {
        level += 1;
        statPointsToSpend += 3;
    }

    public void AddToStat(int index)
    {
        if(statPointsToSpend != 0)
        {
            statPointsToSpend -= 1;
            stats[index] += 1;
        }
    }

    private void SetInput() {
        if (horizontalInUse_) {
            input_.horizontal = 0;

            bool bHorizontal = Input.GetAxisRaw("Horizontal") != 0.0f;
            if (!bHorizontal) {
                horizontalInUse_ = false;
            }
        }
        else {
            input_.horizontal = (int) Input.GetAxisRaw("Horizontal");
            if (input_.horizontal != 0.0f) {
                horizontalInUse_ = true;
            }
        }

        if (verticalInUse_) {
            input_.vertical = 0;

            bool bvertical = Input.GetAxisRaw("Vertical") != 0.0f;
            if (!bvertical) {
                verticalInUse_ = false;
            }
        }
        else {
            input_.vertical = (int) -Input.GetAxisRaw("Vertical");
            if (input_.vertical != 0.0f) {
                verticalInUse_ = true;
            }
        }

        input_.X = Input.GetButtonDown("X");
        input_.Y = Input.GetButtonDown("Y");
        input_.A = Input.GetButtonDown("A");
        input_.B = Input.GetButtonDown("B");
        input_.LB = Input.GetButtonDown("LB");
        input_.RB = Input.GetButtonDown("RB");
        input_.menu = Input.GetButtonDown("Menu");
    }
}
