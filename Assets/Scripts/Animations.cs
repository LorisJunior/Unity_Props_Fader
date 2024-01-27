using UnityEngine;

public static class Animations
{
    // String to hash is faster than using strings to call animator
    public static int moveX = Animator.StringToHash("Move X");
    public static int moveY = Animator.StringToHash("Move Y");
    public static int speed = Animator.StringToHash("Speed");
}
