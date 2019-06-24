pragma solidity >=0.4.25 <0.6.0;

contract AmazingBankTransactions
{
    //Set of States
    enum StateType { Created, Completed, OutOfCompliance}

    //List of properties
    StateType public  State;
    address public  Bank;
    address public  FederalRevenue;
    string public From;
    string public To;
    string public Currency;
    int public Amount;
    bool public  ComplianceStatus;
    string public  ComplianceDetail;
    uint public Timestamp;

    constructor(string from, string to, string currency, int amount) public
    {
	From = from;
	To = to;
	Currency = currency;
	Amount = amount;
	Bank = msg.sender;
	FederalRevenue = msg.sender;
        ComplianceStatus = true;
        State = StateType.Created;
        ComplianceDetail = "N/A";

        if (compareStrings(from, to))
        {
            State = StateType.OutOfCompliance;
            ComplianceDetail = "Transaction can't be done to the same account.";
        }

        if (Amount <= 0)
        {
            State = StateType.OutOfCompliance;
            ComplianceDetail = "Transaction can't be done with a negative amount.";
        }
    }

    function MakeTransaction(string from, string to, string fromCurrency, string toCurrency, int amount, uint timestamp) public
    {
        if (State == StateType.OutOfCompliance
            || State == StateType.Completed)
        {
	    State == StateType.OutOfCompliance;
            revert();
        }

	Timestamp = timestamp;

	if (!compareStrings(from, From)
            ||!compareStrings(to, To)
            || !compareStrings(fromCurrency, Currency)
            || !compareStrings(toCurrency, Currency)
            || amount != Amount)
	{
    	    ComplianceDetail = "Transaction can't be done to different currencies, amount or accounts defined in the contract.";
            State = StateType.OutOfCompliance;
	}
	else
	{
	    State = StateType.Completed;
	}	
    }

    function compareStrings (string memory a, string memory b) public view returns (bool) 
    {
        return (keccak256(abi.encodePacked((a))) == keccak256(abi.encodePacked((b))) );
    }
}