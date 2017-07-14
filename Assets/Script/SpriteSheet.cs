public struct SpriteAnim
{
    public System.Collections.Generic.List<UnityEngine.Sprite> spriteList;
    public System.Collections.Generic.Dictionary<int, UnityEngine.Events.UnityAction> events;
    public double speed;
    public bool clampForever;
}

public class SpriteSheet : UnityEngine.MonoBehaviour
{
    public System.Collections.Generic.Dictionary<System.String, SpriteAnim> _animationList = new System.Collections.Generic.Dictionary<string, SpriteAnim>();
    public UnityEngine.Sprite[] _sprites;
    public UnityEngine.SpriteRenderer spriteRenderer;
    public bool initialized = false;
    public bool SpriteSizeAffectUIImage = true;
    public void Awake()
    {
        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponent<UnityEngine.SpriteRenderer>();
        }
    }

    public System.String StripCloneString(System.String s)
    {
        int idx = s.IndexOf("(");
        if (idx == -1)
        {
            return s;
        }
        return s.Substring(0, idx);
    }
    public void init()
    {
        initialized = true;

        if (_sprites.Length == 0)
        {
            gameObject.name = StripCloneString(gameObject.name);
            _sprites = UnityEngine.Resources.LoadAll<UnityEngine.Sprite>("Avatar/" + gameObject.name + "_Sprite");
        }                
    }

    int sprite_add_idx = 0;
    public void AddAnim(System.String name, int frame_count, double speed = 1.0f, bool clampForever = false)
    {
        if (!initialized)
        {
            init();
        }

        System.Collections.Generic.List<UnityEngine.Sprite> animation = new System.Collections.Generic.List<UnityEngine.Sprite>();
        SpriteAnim anim = new SpriteAnim();
        anim.spriteList = new System.Collections.Generic.List<UnityEngine.Sprite>();
        anim.events = new System.Collections.Generic.Dictionary<int, UnityEngine.Events.UnityAction>();
        anim.speed = speed;
        anim.clampForever = clampForever;

        for (int i = 0; i < frame_count;++i )
        {
            anim.spriteList.Add(_sprites[sprite_add_idx]);
            ++sprite_add_idx;
            if (sprite_add_idx >= _sprites.Length)
            {
                sprite_add_idx = sprite_add_idx % _sprites.Length;
            }            
        }

        _animationList.Add(name, anim);
    }



    public void CreateAnimationByName(System.String name, double speed = 1.0f, bool clampForever = false)
    {
        if (!initialized)
        {            
            init();            
        }
        System.Collections.Generic.List<UnityEngine.Sprite> animation = new System.Collections.Generic.List<UnityEngine.Sprite>();
        SpriteAnim anim = new SpriteAnim();
        anim.spriteList = new System.Collections.Generic.List<UnityEngine.Sprite>();
        anim.events = new System.Collections.Generic.Dictionary<int, UnityEngine.Events.UnityAction>();
        anim.speed = speed;
        anim.clampForever = clampForever;
        foreach (UnityEngine.Sprite sprite in _sprites)
        {
            int idx = sprite.name.LastIndexOf("_");
            if (idx != -1 && sprite.name.Substring(0, idx).Equals(name))
            {
                anim.spriteList.Add(sprite);
            }            
        }
        _animationList.Add(name, anim);
    }


    public void CreateAnimationBySprites(
        System.Collections.Generic.List<UnityEngine.Sprite> sprites, 
        System.String name, double speed = 1.0f, bool clampForever = false)
    {        
        System.Collections.Generic.List<UnityEngine.Sprite> animation = new System.Collections.Generic.List<UnityEngine.Sprite>();
        SpriteAnim anim = new SpriteAnim();
        anim.spriteList = new System.Collections.Generic.List<UnityEngine.Sprite>();
        anim.events = new System.Collections.Generic.Dictionary<int, UnityEngine.Events.UnityAction>();
        anim.speed = speed;
        anim.clampForever = clampForever;
        foreach (UnityEngine.Sprite sprite in sprites)
        {
            anim.spriteList.Add(sprite);
        }
        _animationList.Add(name, anim);
    }

    public bool HasAnimation(System.String name)
    {
        return _animationList.ContainsKey(name);
    }

    public float GetAnimationLength(System.String name)
    {
        return _animationList[name].spriteList.Count * spriteChangeFrequent;
    }

    public float GetAnimationLengthWithSpeed(System.String name)
    {
        return (float)(_animationList[name].spriteList.Count * spriteChangeFrequent
            * (1.0f / GetAnimationSpeed(name)));
    }

    public double GetAnimationSpeed(System.String name)
    {
        return _animationList[name].speed;
    }

    public void AddAnimationEvent(System.String name, int frame, UnityEngine.Events.UnityAction action)
    {
        if (frame == -1)
        {
            frame = _animationList[name].spriteList.Count - 1;
        }
        _animationList[name].events.Add(frame, action);
    }

    public void ModifyAnimSpeed(System.String name, double speed)
    {
        SpriteAnim anim = _animationList[name];
        anim.speed = speed;
        _animationList[name] = anim;
    }

    public bool backWards = false;
    public void Play(System.String anim)
    {
        if (_currentAnim == anim)
        {
            return;
        }
        if (!initialized)
        {
            init();
        }
        _currentAnim = anim;
        frameIdx = 0;
        frameTime = 1000000;// 这样会立刻切换Frame
        FixedUpdate();
    }
    public System.String _currentAnim = "";
    public int frameIdx = 0;
    public UnityEngine.Sprite currentSprite;
    float frameTime;
    float spriteChangeFrequent = 1/30.0f;
    public float GetSpriteChangeFrequent()
    {
        return spriteChangeFrequent;
    }

    public void FixedUpdate()
    {
        frameTime += UnityEngine.Time.deltaTime;        
        if (_currentAnim != "")
        {
            SpriteAnim anim = _animationList[_currentAnim];
            double scaledFrameTime = frameTime * anim.speed;
            if (scaledFrameTime > spriteChangeFrequent)
            {
                if (anim.events.ContainsKey(frameIdx-1))
                {
                    anim.events[frameIdx-1].Invoke();
                }
                // 动画会被invoke改变
                if (_animationList[_currentAnim].spriteList != anim.spriteList)
                {
                    return ;
                }

                if (!anim.clampForever)
                {
                    frameIdx = frameIdx % anim.spriteList.Count;
                }
                else
                {
                    frameIdx = UnityEngine.Mathf.Clamp(frameIdx, 0, anim.spriteList.Count-1);
                }
                int idx_temp = frameIdx;
                if (backWards)
                {
                    idx_temp = anim.spriteList.Count - 1 - frameIdx;
                }
                
                System.Collections.Generic.List<UnityEngine.Sprite> spriteList = anim.spriteList;
                if (spriteRenderer)
                {
                    try
                    {
                        spriteRenderer.sprite = spriteList[idx_temp];
                    }
                    catch (System.Exception)
                    {
                        UnityEngine.Debug.Log(gameObject.name + " no sprite renderer");
                    }                    
                }

                currentSprite = anim.spriteList[idx_temp];
                frameIdx++;
                
                frameTime = 0;
            }
        }

        return ;        
    }
}