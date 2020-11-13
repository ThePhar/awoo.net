using System;
using System.Linq;
using Awoo.Core.Actions.Game;
using Awoo.Core.Actions.Player;
using Awoo.Core.Enums;
using Awoo.Core.Records;
using Awoo.Core.Reducers;
using Awoo.Core.Roles;
using Awoo.Core.Util;
using ReduxSimple;

// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable InconsistentNaming

namespace Awoo
{
    public static class Program
    {
        private static void Main()
        {
            var store = new ReduxStore<GameState>(RootReducer.CreateReducers(), true);
            store.ObserveAction().Subscribe(_ =>
            {
                // Console.Clear();
                PrintGameStats(store);
            });

            #region Players Added
            const string Phar = "Phar";
            const string Cainsith = "cainsith";
            const string Jaxico = "Jaxico";
            const string Sinsorium = "Sinsorium";
            const string RarefiedLuck = "RarefiedLuck";
            const string Psyberia = "Psyberia!";
            const string SirSaltimus = "SirSaltimus";
            const string Breadly = "Breadly";
            const string DarkFalz = "DarkFalz";
            const string iDrop = "iDrop";
            const string SefiCompacto = "SefiCompacto";
            const string Bullied = "Gets Bullied By Dori";
            const string Cheez = "cheezburg";
            const string Tzoonami = "tzoonami";
            const string Dori = "ElsalvaDorian";
            const string SaberRider = "SaberRider";
            const string JaggerGascar = "JaggerGascar";
            const string Vascosta = "Vascosta Rica";
            const string Nub = "nub";
            const string NetGlowGillie = "NetGlowGillie";
            const string WolfGirl = "Wolfgirl1477";
            const string KillJoy = "Kill Joy";
            const string Canadian = "TheCanadian";
            #endregion
            
            store.Dispatch(new SetIdentifierAction { Identifier = "EXAMPLE GAME" });
            
            // Players Join
            #region Players Joined
            store.Dispatch(new AddPlayerAction { Identifier = Phar });
            store.Dispatch(new AddPlayerAction { Identifier = Cainsith });
            store.Dispatch(new AddPlayerAction { Identifier = Jaxico });
            store.Dispatch(new AddPlayerAction { Identifier = Sinsorium });
            store.Dispatch(new AddPlayerAction { Identifier = RarefiedLuck });
            store.Dispatch(new AddPlayerAction { Identifier = Psyberia });
            store.Dispatch(new AddPlayerAction { Identifier = SirSaltimus });
            store.Dispatch(new AddPlayerAction { Identifier = Breadly });
            store.Dispatch(new AddPlayerAction { Identifier = DarkFalz });
            store.Dispatch(new AddPlayerAction { Identifier = iDrop });
            store.Dispatch(new AddPlayerAction { Identifier = SefiCompacto });
            store.Dispatch(new AddPlayerAction { Identifier = Bullied });
            store.Dispatch(new AddPlayerAction { Identifier = Cheez });
            store.Dispatch(new AddPlayerAction { Identifier = Tzoonami });
            store.Dispatch(new AddPlayerAction { Identifier = Dori });
            store.Dispatch(new AddPlayerAction { Identifier = "TEST PLAYER" });
            store.Dispatch(new AddPlayerAction { Identifier = SaberRider });
            store.Dispatch(new AddPlayerAction { Identifier = JaggerGascar });
            store.Dispatch(new AddPlayerAction { Identifier = Vascosta });
            store.Dispatch(new AddPlayerAction { Identifier = Nub });
            store.Dispatch(new AddPlayerAction { Identifier = NetGlowGillie });
            store.Dispatch(new AddPlayerAction { Identifier = WolfGirl });
            store.Dispatch(new AddPlayerAction { Identifier = KillJoy });
            store.Dispatch(new AddPlayerAction { Identifier = Canadian });
            #endregion

            // Player Leaves
            store.Dispatch(new RemovePlayerAction { Identifier = "TEST PLAYER" });
            
            // Assign Roles
            #region Player Assigns
            store.Dispatch(new AssignRoleAction { Identifier = Phar, RoleToAssign = new Bodyguard() });
            store.Dispatch(new AssignRoleAction { Identifier = Sinsorium, RoleToAssign = new Hunter() });
            store.Dispatch(new AssignRoleAction { Identifier = RarefiedLuck, RoleToAssign = new Werewolf() });
            store.Dispatch(new AssignRoleAction { Identifier = Psyberia, RoleToAssign = new Witch() });
            store.Dispatch(new AssignRoleAction { Identifier = SirSaltimus, RoleToAssign = new Sorceress() });
            store.Dispatch(new AssignRoleAction { Identifier = Breadly, RoleToAssign = new Werewolf() });
            store.Dispatch(new AssignRoleAction { Identifier = iDrop, RoleToAssign = new Seer() });
            store.Dispatch(new AssignRoleAction { Identifier = Cheez, RoleToAssign = new Mayor() });
            store.Dispatch(new AssignRoleAction { Identifier = Tzoonami, RoleToAssign = new Werewolf() });
            store.Dispatch(new AssignRoleAction { Identifier = Dori, RoleToAssign = new Mason() });
            store.Dispatch(new AssignRoleAction { Identifier = SaberRider, RoleToAssign = new Werewolf() });
            store.Dispatch(new AssignRoleAction { Identifier = Vascosta, RoleToAssign = new Mason() });
            store.Dispatch(new AssignRoleAction { Identifier = Nub, RoleToAssign = new Lycan() });
            store.Dispatch(new AssignRoleAction { Identifier = NetGlowGillie, RoleToAssign = new Werewolf() });
            store.Dispatch(new AssignRoleAction { Identifier = WolfGirl, RoleToAssign = new Mason() });
            store.Dispatch(new AssignRoleAction { Identifier = KillJoy, RoleToAssign = new Prince() });
            #endregion
            
            // Night 1
            store.Dispatch(new SetNightAction());
            
            // Day 1
            store.Dispatch(new SetDayAction());
            store.Dispatch(new VoteLynchAction { Identifier = Phar, Accusing = NetGlowGillie });
            store.Dispatch(new ClearVoteAction { Identifier = Phar });
            store.Dispatch(new VoteLynchAction { Identifier = Bullied, Accusing = Phar });
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = Bullied });

            // Night 2
            store.Dispatch(new SetNightAction());
            store.Dispatch(new EliminateAction { Identifier = SirSaltimus, Reason = EliminationCause.Werewolves });
            
            // Day 2
            store.Dispatch(new SetDayAction());
            store.Dispatch(new VoteLynchAction { Identifier = Phar, Accusing = Cheez });
            store.Dispatch(new VoteLynchAction { Identifier = Bullied, Accusing = Cheez });
            store.Dispatch(new VoteLynchAction { Identifier = Phar, Accusing = WolfGirl });
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = Bullied });
            store.Dispatch(new VoteLynchAction { Identifier = Nub, Accusing = WolfGirl });
            store.Dispatch(new VoteLynchAction { Identifier = Sinsorium, Accusing = WolfGirl });
            store.Dispatch(new VoteLynchAction { Identifier = Bullied, Accusing = Jaxico });
            store.Dispatch(new VoteLynchAction { Identifier = Bullied, Accusing = WolfGirl });
            store.Dispatch(new VoteLynchAction { Identifier = SefiCompacto, Accusing = WolfGirl });
            store.Dispatch(new VoteLynchAction { Identifier = Breadly, Accusing = WolfGirl });
            store.Dispatch(new VoteLynchAction { Identifier = iDrop, Accusing = WolfGirl });
            store.Dispatch(new VoteLynchAction { Identifier = Vascosta, Accusing = WolfGirl });
            store.Dispatch(new VoteLynchAction { Identifier = NetGlowGillie, Accusing = WolfGirl });
            store.Dispatch(new VoteLynchAction { Identifier = Tzoonami, Accusing = WolfGirl });
            store.Dispatch(new VoteLynchAction { Identifier = RarefiedLuck, Accusing = WolfGirl });
            store.Dispatch(new VoteLynchAction { Identifier = KillJoy, Accusing = WolfGirl });
            store.Dispatch(new VoteLynchAction { Identifier = Bullied, Accusing = Jaxico });
            store.Dispatch(new VoteLynchAction { Identifier = SaberRider, Accusing = Jaxico });
            store.Dispatch(new EliminateAction { Identifier = WolfGirl, Reason = EliminationCause.LeftGame });

            // Night 3
            store.Dispatch(new SetNightAction());
            store.Dispatch(new EliminateAction { Identifier = Cainsith, Reason = EliminationCause.Werewolves });

            // Day 3
            store.Dispatch(new SetDayAction());
            store.Dispatch(new VoteLynchAction { Identifier = Nub, Accusing = Bullied });
            store.Dispatch(new VoteLynchAction { Identifier = Bullied, Accusing = Nub });
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = iDrop });
            store.Dispatch(new VoteLynchAction { Identifier = iDrop, Accusing = Jaxico });
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = Dori });
            store.Dispatch(new VoteLynchAction { Identifier = Dori, Accusing = Jaxico });
            store.Dispatch(new ClearVoteAction { Identifier = iDrop });
            store.Dispatch(new ClearVoteAction { Identifier = Jaxico });
            store.Dispatch(new ClearVoteAction { Identifier = Dori });
            store.Dispatch(new VoteLynchAction { Identifier = SefiCompacto, Accusing = Bullied });
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = Bullied });
            store.Dispatch(new VoteLynchAction { Identifier = Bullied, Accusing = Jaxico });
            store.Dispatch(new VoteLynchAction { Identifier = Phar, Accusing = Sinsorium });
            store.Dispatch(new ClearVoteAction { Identifier = Phar });
            store.Dispatch(new VoteLynchAction { Identifier = Vascosta, Accusing = Bullied });
            store.Dispatch(new VoteLynchAction { Identifier = Phar, Accusing = Vascosta });
            store.Dispatch(new ClearVoteAction { Identifier = Bullied });
            store.Dispatch(new VoteLynchAction { Identifier = Bullied, Accusing = Dori });
            store.Dispatch(new VoteLynchAction { Identifier = Canadian, Accusing = Dori });
            store.Dispatch(new VoteLynchAction { Identifier = NetGlowGillie, Accusing = Bullied });
            store.Dispatch(new VoteLynchAction { Identifier = Tzoonami, Accusing = Bullied });
            store.Dispatch(new VoteLynchAction { Identifier = KillJoy, Accusing = Bullied });
            store.Dispatch(new VoteLynchAction { Identifier = Psyberia, Accusing = Dori });
            store.Dispatch(new VoteLynchAction { Identifier = Dori, Accusing = Bullied });
            store.Dispatch(new VoteLynchAction { Identifier = Cheez, Accusing = Bullied });
            store.Dispatch(new VoteLynchAction { Identifier = Breadly, Accusing = Bullied });
            store.Dispatch(new EliminateAction { Identifier = Bullied, Reason = EliminationCause.Lynching });

            // Night 4
            store.Dispatch(new SetNightAction());
            store.Dispatch(new EliminateAction { Identifier = Phar, Reason = EliminationCause.Werewolves });

            // Day 4
            store.Dispatch(new SetDayAction());
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = KillJoy });
            store.Dispatch(new VoteLynchAction { Identifier = KillJoy, Accusing = Jaxico });
            store.Dispatch(new ClearVoteAction { Identifier = Jaxico });
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = Canadian });
            store.Dispatch(new VoteLynchAction { Identifier = SefiCompacto, Accusing = KillJoy });
            store.Dispatch(new VoteLynchAction { Identifier = Psyberia, Accusing = Canadian });
            store.Dispatch(new VoteLynchAction { Identifier = SefiCompacto, Accusing = Canadian });
            store.Dispatch(new VoteLynchAction { Identifier = Breadly, Accusing = Canadian });
            store.Dispatch(new VoteLynchAction { Identifier = JaggerGascar, Accusing = KillJoy });
            store.Dispatch(new VoteLynchAction { Identifier = KillJoy, Accusing = JaggerGascar });
            store.Dispatch(new ClearVoteAction { Identifier = Breadly });
            store.Dispatch(new ClearVoteAction { Identifier = KillJoy });
            store.Dispatch(new VoteLynchAction { Identifier = Canadian, Accusing = Dori });
            store.Dispatch(new VoteLynchAction { Identifier = DarkFalz, Accusing = KillJoy });
            store.Dispatch(new VoteLynchAction { Identifier = iDrop, Accusing = Canadian });
            store.Dispatch(new VoteLynchAction { Identifier = Cheez, Accusing = SefiCompacto });
            store.Dispatch(new VoteLynchAction { Identifier = KillJoy, Accusing = SefiCompacto });
            store.Dispatch(new VoteLynchAction { Identifier = Dori, Accusing = Canadian });
            store.Dispatch(new EliminateAction { Identifier = Canadian, Reason = EliminationCause.Lynching });

            // Night 5
            store.Dispatch(new SetNightAction());

            // Day 5
            store.Dispatch(new SetDayAction());
            store.Dispatch(new VoteLynchAction { Identifier = Nub, Accusing = Cheez });
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = Cheez });
            store.Dispatch(new ClearVoteAction { Identifier = Jaxico });
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = KillJoy });
            store.Dispatch(new VoteLynchAction { Identifier = SaberRider, Accusing = KillJoy });
            store.Dispatch(new ClearVoteAction { Identifier = Jaxico });
            store.Dispatch(new VoteLynchAction { Identifier = Psyberia, Accusing = SaberRider });
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = SaberRider });
            store.Dispatch(new VoteLynchAction { Identifier = SefiCompacto, Accusing = SaberRider });
            store.Dispatch(new VoteLynchAction { Identifier = Breadly, Accusing = SaberRider });
            store.Dispatch(new VoteLynchAction { Identifier = Dori, Accusing = SaberRider });
            store.Dispatch(new VoteLynchAction { Identifier = Vascosta, Accusing = SaberRider });
            store.Dispatch(new VoteLynchAction { Identifier = JaggerGascar, Accusing = SaberRider });
            store.Dispatch(new VoteLynchAction { Identifier = KillJoy, Accusing = SaberRider });
            store.Dispatch(new VoteLynchAction { Identifier = DarkFalz, Accusing = SaberRider });
            store.Dispatch(new VoteLynchAction { Identifier = SefiCompacto, Accusing = Dori });
            store.Dispatch(new VoteLynchAction { Identifier = SefiCompacto, Accusing = SaberRider });
            store.Dispatch(new VoteLynchAction { Identifier = Tzoonami, Accusing = SaberRider });
            store.Dispatch(new EliminateAction { Identifier = SaberRider, Reason = EliminationCause.Lynching });

            // Night 6
            store.Dispatch(new SetNightAction());
            store.Dispatch(new EliminateAction { Identifier = RarefiedLuck, Reason = EliminationCause.Witch });
            store.Dispatch(new EliminateAction { Identifier = Dori, Reason = EliminationCause.Werewolves });

            // Day 6
            store.Dispatch(new SetDayAction());
            store.Dispatch(new VoteLynchAction { Identifier = SefiCompacto, Accusing = Breadly });
            store.Dispatch(new VoteLynchAction { Identifier = Nub, Accusing = Breadly });
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = Breadly });
            store.Dispatch(new VoteLynchAction { Identifier = Vascosta, Accusing = Breadly });
            store.Dispatch(new VoteLynchAction { Identifier = Sinsorium, Accusing = Breadly });
            store.Dispatch(new VoteLynchAction { Identifier = KillJoy, Accusing = Breadly });
            store.Dispatch(new VoteLynchAction { Identifier = Psyberia, Accusing = Breadly });
            store.Dispatch(new VoteLynchAction { Identifier = DarkFalz, Accusing = Breadly });
            store.Dispatch(new VoteLynchAction { Identifier = Cheez, Accusing = Breadly });
            store.Dispatch(new VoteLynchAction { Identifier = JaggerGascar, Accusing = Breadly });
            store.Dispatch(new VoteLynchAction { Identifier = Tzoonami, Accusing = Breadly });
            store.Dispatch(new EliminateAction { Identifier = Breadly, Reason = EliminationCause.Lynching });

            // Night 7
            store.Dispatch(new SetNightAction());
            store.Dispatch(new EliminateAction { Identifier = DarkFalz, Reason = EliminationCause.Werewolves });

            // Day 7
            store.Dispatch(new SetDayAction());
            store.Dispatch(new VoteLynchAction { Identifier = Psyberia, Accusing = Tzoonami });
            store.Dispatch(new VoteLynchAction { Identifier = Nub, Accusing = Tzoonami });
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = Tzoonami });
            store.Dispatch(new VoteLynchAction { Identifier = Sinsorium, Accusing = Tzoonami });
            store.Dispatch(new VoteLynchAction { Identifier = Vascosta, Accusing = Tzoonami });
            store.Dispatch(new VoteLynchAction { Identifier = KillJoy, Accusing = Tzoonami });
            store.Dispatch(new VoteLynchAction { Identifier = SefiCompacto, Accusing = Tzoonami });
            store.Dispatch(new VoteLynchAction { Identifier = NetGlowGillie, Accusing = Tzoonami });
            store.Dispatch(new VoteLynchAction { Identifier = JaggerGascar, Accusing = Tzoonami });
            store.Dispatch(new EliminateAction { Identifier = Tzoonami, Reason = EliminationCause.Lynching });

            // Night 8
            store.Dispatch(new SetNightAction());
            store.Dispatch(new EliminateAction { Identifier = KillJoy, Reason = EliminationCause.Werewolves });

            // Day 8
            store.Dispatch(new SetDayAction());
            store.Dispatch(new VoteLynchAction { Identifier = SefiCompacto, Accusing = NetGlowGillie });
            store.Dispatch(new VoteLynchAction { Identifier = iDrop, Accusing = NetGlowGillie });
            store.Dispatch(new VoteLynchAction { Identifier = Sinsorium, Accusing = NetGlowGillie });
            store.Dispatch(new VoteLynchAction { Identifier = Vascosta, Accusing = NetGlowGillie });
            store.Dispatch(new VoteLynchAction { Identifier = Nub, Accusing = NetGlowGillie });
            store.Dispatch(new VoteLynchAction { Identifier = Jaxico, Accusing = NetGlowGillie });
            store.Dispatch(new VoteLynchAction { Identifier = Psyberia, Accusing = NetGlowGillie });
            store.Dispatch(new EliminateAction { Identifier = NetGlowGillie, Reason = EliminationCause.Lynching });

            // End Game
            store.Dispatch(new SetNightAction());
            store.Dispatch(new EndGameAction());
        }

        private static void WriteColorLine(object input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        private static void WriteColor(object input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(input);
            Console.ResetColor();
        }

        private static void PrintGameStats(this ReduxStore<GameState> store)
        {
            var game = store.State;

            Console.Write("ID:  "); WriteColorLine(game.Identifier, ConsoleColor.Yellow);
            Console.Write("DAY: "); WriteColorLine(game.Day, ConsoleColor.Yellow);
            Console.WriteLine("PHS: " + game.Phase);
            Console.WriteLine("PLC: " + game.Players.Count);

            // Calculate votes.
            var votes = game.GetLynchCandidates();
            string lynchDeterminant;

            if (votes.Length == 0)
                lynchDeterminant = "No One Will Be Lynched";
            else if (votes.Length == 1)
                lynchDeterminant = $"Currently {votes[0]} will be determined to be lynched at EOD";
            else
            {
                lynchDeterminant = "Currently there is a tie between ";
                foreach (var player in votes)
                {
                    lynchDeterminant += player + ", ";
                }
            }

            Console.WriteLine($"\n-- {lynchDeterminant} --\n");
            
            Console.WriteLine("\t=== Players ===");
            foreach (var player in game.Players.Select(entry => entry.Value))
            {
                var padding = 24;
                
                Console.Write($"\tID: {player.Identifier.PadRight(padding)} | ");
                
                WriteColor($"ROLE: [ {player.Role.ToString()?.PadRight(12)} ] ", GetTeamRole(player));
                Console.Write("| ");
                
                
                if (player.Alive)
                    WriteColor("ALIVE", ConsoleColor.Green);
                else
                    WriteColor($"ELIMINATED [{player.CauseOfDeath}]\n", ConsoleColor.Red);

                if (player.Alive)
                {
                    switch (player.Accusation.Type)
                    {
                        case VoteType.None:
                            Console.WriteLine();
                            break;
                        case VoteType.Lynch:
                            Console.WriteLine($" (Lynch {player.Accusation.Identifier})");
                            break;
                        case VoteType.NoLynch:
                            Console.WriteLine(" (No Lynch)");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            
            var history = store.GetHistory().PreviousStates;
            
            Console.WriteLine("\n\t=== Last 10 Actions ===");
            foreach (var a in history.Take(5))
            {
                Console.WriteLine($"\tTYPE: {new DateTimeOffset(a.Date).ToUnixTimeMilliseconds()} :: {a.Action}");
            }

            Console.WriteLine();
        }

        private static ConsoleColor GetTeamRole(PlayerState player)
        {
            return player.Role.Team switch
            {
                Team.Villagers  => ConsoleColor.Blue,
                Team.Werewolves => ConsoleColor.Red,
                Team.Tanner     => ConsoleColor.Yellow,
                Team.Vampires   => ConsoleColor.Magenta,
                Team.Cult       => ConsoleColor.Green,
                Team.LoneWolf   => ConsoleColor.DarkRed,
                Team.Lovers     => ConsoleColor.DarkMagenta,
                _               => throw new ArgumentOutOfRangeException()
            };
        }
    }
}