namespace PKHeX.Core;

/// <summary>
/// <inheritdoc cref="IObedienceLevelReadOnly"/>
/// </summary>
public interface IObedienceLevel : IObedienceLevelReadOnly
{
    /// <summary>
    /// <inheritdoc cref="IObedienceLevelReadOnly.Obedience_Level"/>
    /// </summary>
    new byte Obedience_Level { get; set; }
}

public static class ObedienceExtensions
{
    /// <summary>
    /// Suggests the <see cref="IObedienceLevelReadOnly.Obedience_Level"/> for the entity.
    /// </summary>
    public static byte GetSuggestedObedienceLevel(this IObedienceLevelReadOnly _, PKM entity, int originalMet)
    {
        if (entity.Species is (int)Species.Koraidon or (int)Species.Miraidon && entity is PK9 { FormArgument: not 0 })
            return 0; // Box Legend ride-able is default 0. Everything else is met level!
        if (entity.Version is not ((int)GameVersion.SL or (int)GameVersion.VL))
            return (byte)entity.CurrentLevel; // foreign, play it safe.
        // Can just assume min-level
        return (byte)originalMet;
    }
}
