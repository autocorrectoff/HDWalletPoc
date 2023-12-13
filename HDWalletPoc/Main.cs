using NBitcoin;
using Nethereum.Web3;
using TestProject.lib;

// Connect to Polygon
var web3 = new Web3("https://polygon-mainnet.infura.io/v3/c9657d3c5621495c9f6b60c3913df958");
var eth = web3.Eth;

// Get block number
var blockNumber = await eth.Blocks.GetBlockNumber.SendRequestAsync();
Console.WriteLine($"Current block number is {blockNumber}");

var w = new HdWallet();

// Get address from private key
string privateKey = "1ac6251479849562ba0a1c2abfda9c4cecad138ff00841792d357a3902185194";
var account = w.AccountFromPrivateKey(privateKey);
Console.WriteLine("Address: " + account.Address);

// Get Matic balance
var myBalance = await eth.GetBalance.SendRequestAsync(account.Address);
var myBalanceEth = Web3.Convert.FromWei(myBalance);
Console.WriteLine($"Balance for {account.Address} is {myBalanceEth}");

// Generate a new seed phrase
Mnemonic mnemonic = w.GenerateRandomMnemonic();
Console.WriteLine("Seed Phrase: " + mnemonic);

// Restore from mnemonic
var accounts = w.GenerateAccountsForMnemonic("vicious bargain portion never view antique mention border have general adjust insane", 5);
foreach (var acc in accounts)
{
    Console.WriteLine("Address: " + acc.Address);
    Console.WriteLine("PK: " + acc.PrivateKey);
}

// Aiight didn't think it would be that simple; checking out

