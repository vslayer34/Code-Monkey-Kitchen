/// <summary>
/// Contains reference to animation parameters
/// </summary>
public static class AnimationParameters
{
    /// <summary>
    /// Contains references to player's animation parameters
    /// </summary>
    public static class Player
    {
        /// <summary>
        /// Reference to<c>isWalking</c>parameter
        /// </summary>
        public const string IS_WALKING = "isWalking";
    }


    /// <summary>
    /// Contains references to container counter's animation parameters
    /// </summary>
    public static class ContainerCounter
    {
        /// <summary>
        /// Reference to<c>OpenClose</c>parameter
        /// </summary>
        public const string OPEN_CLOSE = "OpenClose";
    }


    /// <summary>
    /// Contains references to cutting counter's animation parameters
    /// </summary>
    public static class CuttingCounter
    {
        /// <summary>
        /// Reference to<c>Cut</c>parameter
        /// </summary>
        public const string CUT = "Cut";
    }
    

    /// <summary>
    /// Contains references to UI and HUD animations
    /// </summary>
    public static class GameUI
    {
        public const string UI_COUNT_TIME = "Number Pop Out";
        public const string UI_FLASHING_PROGRESS_BAR = "Is Flashing";
        public const string UI_DELIVERY_RESULT_PPO_OUT = "Pop out";
    }
}