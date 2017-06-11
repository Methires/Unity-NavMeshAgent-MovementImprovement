using System;

public static class GlobalVariables
{
    public const bool UPDATE_ROTATION = true;

    public const float STOPPING_DISTANCE = 0.1f;
    public const float SPHERE_RANGE = 70.0f;
    public const float AGENT_Y_SPAWN_POS_OFFSET = 0.5f;
    public const float NAVMESH_SAMPLER_MAX_DISTANCE = 0.05f;
    public const float VELOCITY_FRACTION = 0.25f;
    public const float START_DELAY = 1.0f;
    public const float NAVMESH_POINT_Y = -0.4166666f;

    public static readonly string SAVE_LOC = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
}
