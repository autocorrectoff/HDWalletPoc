using NBitcoin;
using Nethereum.HdWallet;
using Nethereum.Web3.Accounts;

namespace TestProject.lib;

public class HdWallet
{
    public Account AccountFromPrivateKey(string privateKey)
    {
        return new Account(privateKey);
    }

    public Account[] GenerateAccountsForMnemonic(string mnemonic, int limit)
    {
        var wallet = new Wallet(mnemonic, "");
        Account[] accounts = new Account[limit];
        foreach (var i in Enumerable.Range(0, limit))
        {
            var account = wallet.GetAccount(i);
            accounts[i] = account;
        }

        return accounts;
    }

    public Mnemonic GenerateRandomMnemonic()
    {
        return new Mnemonic(Wordlist.English, WordCount.Twelve);
    }
}