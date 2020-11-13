namespace Awoo.Core.Enums
{
    public enum EliminationCause
    {
        // Non-Role Eliminations
        Unknown,
        LeftGame,
        Lynching,
        
        // Role-Caused Eliminations
        Werewolves,
        Cupid,
        Hunter,
        Huntress,
        Masons,
        SuicideBomber,
        Witch,
        
        // Role Requirement Eliminations
        PacifistFailure,
        TeenageWerewolfFailure,
        VillageIdiotFailure
    }
}