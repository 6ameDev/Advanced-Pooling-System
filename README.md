Advanced Pooling System
=======================

Advanced Pooling System is an out-of-the-box object pooling system for Unity which along with the ease of use rapidly increases performance in games. It enables you to significantly reduce memory allocation, garbage collection and you can seamlessly create thousands of objects and particle effects. We wanted to make it more user friendly, so the basic methods used in Unity like Instantiate, Destroy, etc. can be replaced by Advanced Pooling System's InstantiateAPS, DestroyAPS respectively.

<a href="http://swiftfingergames.blogspot.com/2014/08/APSDemo.html">DEMO</a>
=======================

 Features:
=======================
- Pool multiple prefab types
- Supports pooling of gameobjects, sounds & particle effects
- Pre-instantiated objects
- Expandable pools to provide extra instances when necessary
 
How To Pool in Unity
=======================
Instantiating From Pool:

    PoolingSystem pS = PoolingSystem.Instance;

    // To spawn the prefab as it is
    pS.InstantiateAPS("prefabName");
     
    // To spawn the prefab at a position and with a specific rotation
    pS.InstantiateAPS("prefabName", _position, _rotation); 
     
    // Same as above, also makes the spawned prefab a child of "parent" gameobject
    pS.InstantiateAPS("prefabName", _position, _rotation, parent);


Destroying/Recycling Pooled Object:

    myPrefab.DestroyAPS();

Using Sounds in APS:

    void Start() {
       PoolingSystem.Instance.InstantiateAPS("soundPrefab");
    }
    void Update() {
       // Whenever you wish to play sound, call this function. Also works well with automatic weapon sounds.
       soundPrefab.PlaySound();
    }

Using Particle Effects in APS:

    void Start() {
       PoolingSystem.Instance.InstantiateAPS("effectPrefab");
    }
    void Update() {
       // Whenever you wish to play effect, call this function.
       //Pass the amount of particles to be emitted, as the parameter. In this example we use 50.
       effectPrefab.PlayEffect(50);
    }

License
=======================
Copyright © 2014 Sumit Das (SwiftFinger Games)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to use
or modify "Advanced Pooling System" in any and all games, subject to the
following conditions:

1. The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

2. Any product developed using "Advanced Pooling System" requires clearly
readable "Advanced Pooling System" logo on splash screen or credits screen.

3. It is expressly forbid to sell or commercially distribute "Advanced Pooling System"
outside of your games. You can freely use it in your games but you cannot commercially
distribute the source code either directly or compiled into a library outside of
your game.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
