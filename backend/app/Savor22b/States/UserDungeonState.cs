namespace Savor22b.States;

using System.Collections.Immutable;
using Bencodex.Types;

public class UserDungeonState : State
{
    public static readonly int MaxDungeonKey = 5;
    public static readonly int DungeonKeyChargeIntervalBlock = 12;

    public static readonly int MaxDungeonConquestKeyCount = 3;

    public static readonly int DungeonConquestKeyChargeIntervalBlock = 100;

    public ImmutableList<DungeonHistoryState> DungeonHistories { get; private set; }
    public ImmutableList<DungeonConquestHistoryState> DungeonConquestHistories { get; private set; }

    public UserDungeonState()
    {
        DungeonHistories = ImmutableList<DungeonHistoryState>.Empty;
        DungeonConquestHistories = ImmutableList<DungeonConquestHistoryState>.Empty;
    }

    public UserDungeonState(
        ImmutableList<DungeonHistoryState> dungeonKeyHistories,
        ImmutableList<DungeonConquestHistoryState> dungeonConquestHistories
    )
    {
        DungeonHistories = dungeonKeyHistories;
        DungeonConquestHistories = dungeonConquestHistories;
    }

    public UserDungeonState(Dictionary encoded)
    {
        if (encoded.TryGetValue((Text)nameof(DungeonHistories), out var dungeonKeyHistories))
        {
            DungeonHistories = ((List)dungeonKeyHistories)
                .Select(element => new DungeonHistoryState((Dictionary)element))
                .ToImmutableList();
        }
        else
        {
            DungeonHistories = ImmutableList<DungeonHistoryState>.Empty;
        }

        DungeonConquestHistories = ((List)encoded[nameof(DungeonConquestHistories)])
            .Select(element => new DungeonConquestHistoryState((Dictionary)element))
            .ToImmutableList();
    }

    public IValue Serialize()
    {
        return new Dictionary(
            new[]
            {
                new KeyValuePair<IKey, IValue>(
                    (Text)nameof(DungeonHistories),
                    new List(DungeonHistories.Select(element => element.Serialize()))
                ),
                new KeyValuePair<IKey, IValue>(
                    (Text)nameof(DungeonConquestHistories),
                    new List(DungeonConquestHistories.Select(element => element.Serialize()))
                ),
            }
        );
    }

    public int GetDungeonKeyCount(long blockIndex)
    {
        return MaxDungeonKey - GetCurrentDungeonHistories(blockIndex).Count;
    }

    public int GetDungeonConquestKeyCount(int dungeonId, long blockIndex)
    {
        return MaxDungeonConquestKeyCount
            - GetCurrentDungeonConquestHistories(dungeonId, blockIndex).Count;
    }

    public bool CanUseDungeonKey(long blockIndex)
    {
        return GetDungeonKeyCount(blockIndex) > 0;
    }

    public bool CanUseDungeonConquestKey(int dungeonId, long blockIndex)
    {
        return GetDungeonConquestKeyCount(dungeonId, blockIndex) > 0;
    }

    public int CalculateDungeonClear(Libplanet.Action.IRandom random)
    {
        return random.Next(0, 2) == 1 ? 1 : 0;
    }

    public int CalculateDungeonConquest(Libplanet.Action.IRandom random)
    {
        return random.Next(0, 2) == 1 ? 1 : 0;
    }

    public ImmutableList<DungeonHistoryState> GetCurrentDungeonHistories(long blockIndex)
    {
        var lowerBoundIndex = blockIndex - (MaxDungeonKey * DungeonKeyChargeIntervalBlock);
        var result = new List<DungeonHistoryState>();

        for (int i = DungeonHistories.Count - 1; i >= 0; i--)
        {
            var history = DungeonHistories[i];

            if (history.BlockIndex > lowerBoundIndex && history.BlockIndex <= blockIndex)
            {
                result.Add(history);
            }
            else if (history.BlockIndex <= lowerBoundIndex)
            {
                break;
            }
        }

        return result.ToImmutableList();
    }

    public ImmutableList<DungeonConquestHistoryState> GetCurrentDungeonConquestHistories(
        int dungeonID,
        long blockIndex
    )
    {
        var lowerBoundIndex =
            blockIndex - (MaxDungeonConquestKeyCount * DungeonConquestKeyChargeIntervalBlock);
        var result = new List<DungeonConquestHistoryState>();

        for (int i = DungeonConquestHistories.Count - 1; i >= 0; i--)
        {
            var history = DungeonConquestHistories[i];

            if (
                history.BlockIndex > lowerBoundIndex
                && history.BlockIndex <= blockIndex
                && dungeonID == history.DungeonId
            )
            {
                result.Add(history);
            }
            else if (history.BlockIndex <= lowerBoundIndex)
            {
                break;
            }
        }

        return result.ToImmutableList();
    }

    public bool IsDungeonCleared(int dungeonID, long blockIndex)
    {
        for (int i = DungeonHistories.Count - 1; i >= 0; i--)
        {
            var history = DungeonHistories[i];

            if (dungeonID == history.DungeonId && history.DungeonClearStatus == 1)
            {
                return true;
            }
        }

        return false;
    }

    public UserDungeonState AddDungeonHistory(DungeonHistoryState dungeonHistory)
    {
        return new UserDungeonState(DungeonHistories.Add(dungeonHistory), DungeonConquestHistories);
    }

    public UserDungeonState AddDungeonConquestHistory(
        DungeonConquestHistoryState dungeonConquestHistory
    )
    {
        return new UserDungeonState(
            DungeonHistories,
            DungeonConquestHistories.Add(dungeonConquestHistory)
        );
    }
}
