using UnityEngine;
using System.Collections;

/// <summary>
/// Time manager.
/// </summary>

public class TimeManager : SingleBehaviour<TimeManager> 
{
	#region Variables (private)

    private bool _isPause;
    
    private bool _ModifyCurrentStep;
    private float _Step;
    private float _SpeedFactor;
    
    #endregion
    
	#region Unity event functions
    
    /// <summary>
    /// Awake this instance.
    /// </summary>
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _ModifyCurrentStep = false;
        _SpeedFactor       = 1.0f;
        _isPause = false ;
    }

    void Start()
    {
        //GameManager.instance.PauseGame += ActionToDoByPause;
    }
	/// <summary>
	/// Update this instance.
	/// </summary>

    void Update()
    {
        if (_ModifyCurrentStep)
        {
            _SpeedFactor = Mathf.Lerp(_SpeedFactor, _Step, Time.deltaTime);
        }
    }
    
    #endregion

	#region Methods
     
	/// <summary>
	/// Deltas the time.
	/// </summary>
	/// <returns>The time.</returns>
    
    public float DeltaTime()
    {
        if (_isPause)
            return 0.0f;

        return Time.deltaTime* _SpeedFactor;
    }

	/// <summary>
	/// Modifies the current speed factor.
	/// </summary>
	/// <param name="step">Step.</param>

    public void ModifyCurrentSpeedFactor(float step)
    {
        if (step != 0)
            _Step = step;
        else
            return;
        if (!_ModifyCurrentStep)
            _ModifyCurrentStep = true;
    }
    
    public int GetMinute(float time)
    {
        int minute = (int)time/60; 
        return minute;
    }

    public int GetSecond(float time)
    {
        int second = (int)time % 60;
        return second;
    }
    /// <summary>
    /// pass variable true of false to tell script that game is paused or not.
    /// </summary>
    /// <param name="currentValue">value of game paused true or false.</param>
    private void ActionToDoByPause( bool currentValue )
    {
        _isPause = currentValue;
    }
    #endregion
}

// <('.'<) ^( '-' )^ (>‘.’)> v( ‘.’ )v <(' .' )> <('.'<) ^( '.' )^ (>‘.’)> v( ‘.’ )v <(' .' )>

/*         
                                                                                 ,.ood888888888888boo.,
                     Tb.         Tb.                                       .od888P^""            ""^Y888bo.
                     :$$b.        $$$b.                                .od8P''   ..oood88888888booo.    ``Y8bo.
                     :$$$$b.      :$$$$b.                           .odP'"  .ood8888888888888888888888boo.  "`Ybo.
                     :$$$$$$b     :$$$$$$b                        .d8'   od8'd888888888f`8888't888888888b`8bo   `Yb.
                      $$$$$$$b     $$$$$$$b                      d8'  od8^   8888888888[  `'  ]8888888888   ^8bo  `8b
                      $$$$$$$$b    :$$$$$$$b                   .8P  d88'     8888888888P      Y8888888888     `88b  Y8.
                      :$$$$$$$$b---^$$$$$$$$b                 d8' .d8'       `Y88888888'      `88888888P'       `8b. `8b
                      :$$$$$$$$$b        ""^Tb               .8P .88P            """"            """"            Y88. Y8.
                       $$$$$$$$$$b    __...__`.              88  888                                              888  88
                       $$$$$$$$$$$b.g$$$$$$$$$pb             88  888                                              888  88
                       $$$$$$$$$$$$$$$$$$$$$$$$$b            88  888.        ..                        ..        .888  88
                       $$$$$$$$$$$$$$$$$$$$$$$$$$b           `8b `88b,     d8888b.od8bo.      .od8bo.d8888b     ,d88' d8'
                       :$$$$$$$$$$$$$$$$$$$$$$$$$$;           Y8. `Y88.    8888888888888b    d8888888888888    .88P' .8P
                       :$$$$$$$$$$$$$^T$$$$$$$$$$P;            `8b  Y88b.  `88888888888888  88888888888888'  .d88P  d8'
                       :$$$$$$$$$$$$$b  "^T$$$$P' :              Y8.  ^Y88bod8888888888888..8888888888888bod88P^  .8P
                       :$$$$$$$$$$$$$$b._.g$$$$$p.db              `Y8.   ^Y888888888888888LS888888888888888P^   .8P'
                       :$$$$$$$$$$$$$$$$$$$$$$$$$$$$;               `^Yb.,  `^^Y8888888888888888888888P^^'  ,.dP^'
                       :$$$$$$$$"""^^T$$$$$$$$$$$$P^;                  `^Y8b..   ``^^^Y88888888P^^^'    ..d8P^'
                       :$$$$$$$$       ""^^T$$$P^'  ;                      `^Y888bo.,            ,.od888P^'
                       :$$$$$$$$    .'       `"     ;                           "`^^Y888888888888P^^'"         
                       $$$$$$$$;   /                :                
                       $$$$$$$$;           .----,   :                
                       $$$$$$$$;         ,"          ;               
                       $$$$$$$$$p.                   |               
                      :$$$$$$$$$$$$p.                :               
                      :$$$$$$$$$$$$$$$p.            .'               
                      :$$$$$$$$$$$$$$$$$$p...___..-"                 
                      $$$$$$$$$$$$$$$$$$$$$$$$$;                     
   .db.               $$$$$$$$$$$$$$$$$$$$$$$$$$                     
  d$$$$bp.            $$$$$$$$$$$$$$$$$$$$$$$$$$;                    
 d$$$$$$$$$$pp..__..gg$$$$$$$$$$$$$$$$$$$$$$$$$$$                    
d$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$p._            .gp. 
$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$p._.ggp._.d$$$$b
 */
 
/*
         (\_/)
     (  =(^Y^)=
  ____\_(m___m)_______
*/