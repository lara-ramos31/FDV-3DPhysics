# FDV-3DPhysics

*Fundamentos del Desarrollo de Videojuegos*' assignment: 3D physics exercises.

![A scene showcasing the 3D physics concepts introduced](Media/demo.gif)

## Table of contents
1. [Task 1](#task-1)
    - [Case 1](#case-1)
    - [Case 2](#case-2)
    - [Case 3](#case-3)
    - [Case 4](#case-4)
    - [Case 5](#case-5)
    - [Case 6](#case-6)
    - [Case 7](#case-7)
    - [Case 8](#case-8)
    - [Case 9](#case-9)
2. [Task 2](#task-2)
3. [Task 3](#task-3)
4. [Task 4](#task-4)

## Task 1

> The exercise consists of experimenting with different Rigidbody and Collider component configurations, and then explain the results obtained based off of what was explained in class. We'll configure a scene with 3 objects: a plane, a cube and a sphere.
> - The plane is placed at (0, 0, 0).
> - The cube is placed at (0, 0.5, 0).
> - The sphere is placed at (0.64, 1.79, -0.36).
> - The camera is left to its default configuration.

![A screenshot with the described scene in the Unity editor](Media/task1_scene.gif)

A few definitions (according to the [Unity Manual](https://docs.unity3d.com/6000.5/Documentation/Manual/CollidersOverview.html)):
- Static collider: a GameObject with a collider but no Rigidbody.
- Rigidbody collider: a GameObject with both a collider and a Rigidbody.
  - Dynamic collider: a non-kinematic Rigidbody collider ("Is Kinematic" disabled).
  - Kinematic collider: a kinematic Rigibody collider ("Is Kinematic" enabled).

Only dynamic colliders are directly affected by physics. Static colliders' transforms are never meant to be modified by code, while kinematic's transforms are.

### Case 1

> - The plane is not a physical object, but it has a collider.
> - The cube is a physical object (it has both a Rigidbody and a Collider).
> - The sphere is not a physical object, but it has a collider.

![Case 1's scene](Media/task1_case1.gif)

When playing the scene, both the plane and the sphere stay floating (unaffected by gravity) because they are not physical objects. Even though the cube is a physical object and therefore affected by gravity, it is on top of the plane. When a dynamic collider (the cube) interacts with a static collider (the plane), Unity applies forces *only* to the dynamic collider, which essentially means that the plane will push the cube against gravity, and keep it on top forever.

### Case 2

> - The plane is not a physical object, but it has a collider.
> - The cube is a physical object (it has both a Rigidbody and a Collider).
> - The sphere is a physical object (it has both a Rigidbody and a Collider).

![Case 2's scene](Media/task1_case2.gif)

When playing the scene, the plane stays still since it is a static collider and thus unaffected by physics. The sphere's initial position is in the air, so it falls over the cube (which is slightly moved), and then rolls off the plane. Like in the previous case, the plane creates an upwards force that keeps the dynamic objects from falling through it.

### Case 3

> - The plane is not a physical object, but it has a collider.
> - The cube is a physical object (it has both a Rigidbody and a Collider).
> - The sphere is a kinematic object (it has a kinematic Rigidbody and a Collider).

![Case 3's scene](Media/task1_case3.gif)

Just like the other cases, the plane stays still since it is a static collider, and the cube stays still because the plane creates a force that keeps it from falling through. The sphere is now a kinematic object, so it is no longer directly affected by physics. Unlike the plane, though, it is allowed to be moved freely, and would trigger collision messages if a dynamic collider ever were to intersect with it.

### Case 4

> - The plane is a physical object (it has both a Rigidbody and a Collider).
> - The cube is a physical object (it has both a Rigidbody and a Collider).
> - The sphere is a physical object (it has both a Rigidbody and a Collider).

![Case 4's scene](Media/task1_case4_concave.gif)

This time, since **everything** is a dynamic object, they all get affected by gravity and end up infinitely falling down. 

Note: we get an error indicating that `Concave Mesh Colliders are not supported when used with dynamic Rigidbody GameObjects`, which is triggered by the plane's mesh. This would likely cause collision detection problems, but in this particular case it doesn't really affect us, since everything just falls down anyway. If we wanted to avoid this problem, we'd have to tick "Convex" in the plane's mesh collider:

![A screenshot of the Inspector showing the "Convex" option for the Mesh Collider](Media/task1_case4_convex_option.png)

With the "convex" option set, the collider's mesh now resembles a prism and therefore causes the cube to start a little higher when playing the scene:

![Case 4's scene, with the Convex option set](Media/task1_case4_convex.gif)

### Case 5

> - The plane is a physical object (it has both a Rigidbody and a Collider).
> - The cube is a physical object (it has both a Rigidbody and a Collider).
> - The sphere is a physical object with 10 times the mass of the cube (it has both a Rigidbody and a Collider).

![Case 5's scene](Media/task1_case5.gif)

This case has the same results as the previous one, since the plane is still a dynamic object affected by gravity and the sphere's velocity does not depend on its mass. Had the plane stayed as a static object, the sphere would have hit the cube with a bigger force, maybe even making it move while bouncing off.

### Case 6

> - The plane is a physical object (it has both a Rigidbody and a Collider).
> - The cube is a physical object (it has both a Rigidbody and a Collider).
> - The sphere is a physical object with 100 times the mass of the cube (it has both a Rigidbody and a Collider).

![Case 6's scene](Media/task1_case6.gif)

This case is virtually the same as the previous one: the sphere's mass does not affect the outcome. All three objects fall indefinitely.

### Case 7

> - The plane is a physical object (it has both a Rigidbody and Collider).
> - The cube is a physical object (it has both a Rigidbody and a Collider).
> - The sphere is a physical object **with friction** (it has both a Rigidbody and a Collider).

![A screnshot of the Inspector showing the physics material's properties](Media/task1_case7_friction_material.png)

In Unity, we can add friction by setting a custom physics material to the sphere's collider. I used the default material properties, with a friction coefficient of 0.6. 

![Case 7's scene using the friction material](Media/task1_case7_friction.gif)

Adding friction in this case, though, does not affect the end result, because the sphere will never get to collide with the other objects in the scene. If it were to hit the cube or the plane, its velocity would likely be dampened until it stops moving.

There's another option if we want a dynamic object's entire movement to emulate air friction: by using the Rigidbody's "Linear Damping" property.

![A screenshot of the Inspector showing the Rigidbody's properties](Media/task1_case7_rigidbody_damping.png)

I opted to set the Rigidbody's Linear Damping to 5 to properly see its effects in the scene.

![Case 7's scene using Linear Damping](Media/task1_case7_damping.gif)

### Case 8

***This case's statement differs from the one in the assignment, because having the plane still be a physical object makes no sense if we want to actually see the interactions***.

> - The plane is a ***NOT*** physical object (it only has a Collider).
> - The cube is a physical object (it has both a Rigidbody and a Collider).
> - The sphere is a kinematic object, and also a Trigger (it has a kinematic Rigidbody and a Collider).

![Case 8's scene](Media/task1_case8.gif)

In this case, since the sphere is a kinematic object, it is unaffected by physics. It never interacts with the other two objects.

![Case 8's scene with an alternative cube placement](Media/task1_case8_alt.gif)

If the cube were to try to collide with it, it would pass through it, and the potential collision would just be a Trigger event. If the sphere were to be manually moved towards the plane (a static collider), a Trigger event would be sent.

### Case 9

***This case's statement differs from the one in the assignment, because having the plane still be a physical object makes no sense if we want to actually see the interactions***.

> - The plane is a ***NOT*** physical object (it only has a Collider).
> - The cube is a physical object (it has both a Rigidbody and a Collider).
> - The sphere is a physical object, and also a Trigger (it has a Rigidbody and a Collider).

![Case 9's scene](Media/task1_case9.gif)

In this final case, the sphere is back to being a dynamic object, so it is affected by gravity again. However, since it is now a Trigger collider, it passes right through both the static collider (the plane) and the dynamic collider (the cube). Each time the sphere is "inside" these other objects, a Trigger event would be sent.

## Task 2

> Write a controller with the Up-Down, Left-Right arrows to move a cylinder with physics.

![Task 2's demo scene](Media/task2.gif)

This assignment is pretty straightforward. For starters, I switched the project back to using the Legacy Input System for simplicity's sake.

```c#
using UnityEngine;

public class Script_Task2 : MonoBehaviour
{
    public float baseForce = 6.7f;
    public float boostForce = 15f;
    private Vector3 moveVector;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogError("Error: GameObject has no Rigidbody!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxis("Vertical");
        float sideways = Input.GetAxis("Horizontal");
        float currentForce = Input.GetKey(KeyCode.Space) ? boostForce : baseForce;
        moveVector.Set(currentForce * sideways, 0, currentForce * forward);
    }

    void FixedUpdate()
    {
        if (rb == null) { return; }
        rb.AddForce(moveVector);
    }
}
```

This script is based off of my [Linear Motion assignment's task 4 script](https://github.com/lara-ramos31/FDV-MovRect1/blob/main/README.md#task-4). The main difference is the usage of the Rigidbody's `AddForce()` method instead of the `transform.Translate()` method. The forces are a bit higher than the speeds were in that exercise, since otherwise the cylinder will move very slowly. Note that the forces are applied in the `FixedUpdate()` method, since they have to be computed alongside the rest of the physics simulation.

To avoid having the cylinder fall off because of the forces, we have to prevent its Rigidbody from ever rotating in the X or Z axes.

![A screenshot of the Inspector showing the Rigidbody's fixed X and Z axes](Media/task2_fixed_axes.png)

## Task 3

> Create many cubes or spheres with a dynamic Rigidbody. Whenever the capsule collides with something, print to the console the name of the object it collided with, and change its color after the collision.

![Task 3's scene](Media/task3.gif)

For this task I modified the previous task's script to include a new snippet for whenever the `OnCollisionEnter()` event is triggered:
```c#
void OnCollisionEnter(Collision collision)
{
    GameObject obj = collision.gameObject;
    if (obj.CompareTag("Floor")) { return; }
    Debug.Log("Collided with " + collision.gameObject.name);
    Renderer renderer = obj.GetComponent<Renderer>();
    if (renderer == null) { return; }
    if (renderer.material == null) { return; }
    renderer.material.color = Random.ColorHSV();
}
```

This way, the cylinder is responsible for changing the material of the cubes and spheres in the scene, while printing to the console the name of the object it collided with. Since the floor is a static collider, it can also trigger this collision event, so I added a `"Floor"` tag to prevent changing the floor's color seemingly at random.

## Task 4

> The scene must include 3 objects: A kinematic cube, a kinematic sphere cylinder, and a dynamic sphere. Mark the cylinder as the objective for the sphere to reach. The cube must serve as an obstacle between them. Write a script that makes the sphere move towards the cylinder. When the sphere reaches the cube, the latter must change its material and move forwards.

![Task 4's scene](Media/task4.gif)

This time, two scripts are needed. The first one corresponds to the sphere:

```c#
using UnityEngine;

public class Script_Task4_Sphere : MonoBehaviour
{
    public Transform objective;
    public float speed = 5.0f;
    private Vector3 moveVector;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogError("Error: GameObject has no Rigidbody!");
        }
        if (objective == null) {
            Debug.LogError("Error: GameObject has no objective!");
        }
    }
    void FixedUpdate()
    {
        if (rb == null) { return; }
        moveVector = speed * (objective.position - transform.position).normalized;
        rb.AddForce(moveVector);
    }
}
```

The movement logic inside `FixedUpdate()` uses the Rigidbody's `AddForce()` function to continuously add a force that points towards the objective at any given time.

```c#
using UnityEngine;

public class Script_Task4_Cube : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    private Renderer render;
    private Vector3 moveVector;
    private bool shouldMove = false;

    void Start()
    {
        moveVector = speed * Vector3.forward;
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogError("Error: GameObject has no Rigidbody!");
        }
        render = GetComponent<Renderer>();
        if (render == null) {
            Debug.LogError("Error: GameObject has no Renderer!");
        }
    }

    void FixedUpdate()
    {
        if (rb == null) { return; }
        if (shouldMove) {
            rb.MovePosition(transform.position + Time.fixedDeltaTime * moveVector);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        shouldMove = true;
        render.material.color = Random.ColorHSV();
        Debug.Log("Cube: I've been hit!");
    }
}
```

For the cube, the logic is simple aswell. A `shouldMove` flag is set to true only when the sphere finally collides with the cube (which also triggers the color change). We never risk detecting a collision between the cube and the plane because the latter is a static object, and static-kinematic collisions do not trigger collision events. After that, the cube moves indefinitely in the world's `forward` direction. Since the cube is kinematic, it has to be done using the `MovePosition()` method to directly modify the position, since trying to apply forces to it won't work.