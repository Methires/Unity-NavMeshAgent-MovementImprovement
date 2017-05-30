using System;

public static class GlobalVariables
{
    public const bool UPDATE_ROTATION = true;

    public const float STOPPING_DISTANCE = 0.1f;
    public const float SPHERE_RANGE = 70.0f;
    public const float NEXT_AREA_OFFSET = 60.0f;
    public const float AGENT_Y_SPAWN_POS_OFFSET = 0.5f;
    public const float NAVMESH_SAMPLER_MAX_DISTANCE = 0.3f;
    public const float AREA_SIZE = 50.0f;

    public static readonly string SAVE_LOC = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
}
