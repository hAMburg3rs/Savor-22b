namespace Savor22b;

using System.Collections.Immutable;
using Libplanet.Action;
using Libplanet.Blockchain.Policies;
using Savor22b.Action;

public static class BlockPolicySource
{
    public static BlockPolicy<PolymorphicAction<BaseAction>> GetPolicy()
    {
        return new BlockPolicy<PolymorphicAction<BaseAction>>(
            nativeTokens: ImmutableHashSet.Create(Currencies.KeyCurrency)
        );
    }
}
