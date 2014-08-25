Advanced Pooling System
=======================

Advanced Pooling System is an out-of-the-box object pooling system which along with the ease of use rapidly increases performance in games. It enables you to significantly reduce memory allocation, garbage collection and you can seamlessly create thousands of objects and particle effects. We wanted to make it more user friendly, so the basic methods like Instantiate, Destroy, etc. can be replaced by Advanced Pooling System's InstantiateAPS, DestroyAPS respectively.

 Features:
=======================
- Pool multiple prefab types
- Supports pooling of gameobjects, sounds & particle effects
- Pre-instantiated objects
- Expandable pools to provide extra instances when necessary
 
How To Pool
=======================
Instantiating From Pool:

    PoolingSystem pS = PoolingSystem.Instance;

    pS.InstantiateAPS("prefabName");
    pS.InstantiateAPS("prefabName", _position, _rotation); 
    pS.InstantiateAPS("prefabName", _position, _rotation, parent);


Destroying/Recycling Pooled Object:

    myPrefab.DestroyAPS();

License
=======================
For any developers wanting to use "Advanced Pooling System" in their games, you are welcome to do so. You can use "Advanced Pooling System" in any and all games either modified or unmodified. It is expressly forbid to sell or commercially distribute "Advanced Pooling System" outside of your games. You can freely use it in as many games as you would like but you cannot commercially distribute the source code either directly or compiled into a library outside of your game.

If you use "Advanced Pooling System" include a "Advanced Pooling System" logo on your about credits page, splash page or anywhere else your game might show up.
